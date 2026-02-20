using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using System.Text.Json;
using template_clean_arq_api.Application.Commons.Constants;
using template_clean_arq_api.Application.Models;

namespace template_clean_arq_api.Presentation.Middleware
{
    public class ApiMiddleware(ILogger<ApiMiddleware> pLogger) : IMiddleware
    {
        private readonly ILogger<ApiMiddleware> _Logger = pLogger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                string? authHeader = context.Request.Headers.Authorization.SingleOrDefault();
                if (authHeader != null && authHeader.StartsWith(GeneralConstants.Headers.BEARER, StringComparison.OrdinalIgnoreCase))
                {
                    string token = authHeader[GeneralConstants.Headers.BEARER.Length..].Trim();
                    if (!string.IsNullOrEmpty(token))
                    {
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var validationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = "https://SettingsApp.com",
                            ValidateAudience = true,
                            ValidAudience = "https://ApiGateway.com",
                            ValidateLifetime = false,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9vN#dP!x2Yk$uE7mBqZ0*Ls@Rc4FwT1eG!hXjVmA5oK8nC6bI3D^zUyWtSrMpLbQ"))
                        };
                        var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                        var claimsToHeadersMap = new Dictionary<string, string>
                        {
                            {GeneralConstants.Headers.GROUP_PLACE_ROLE_USER_ID,GeneralConstants.Headers.GROUP_PLACE_ROLE_USER_ID },
                            {GeneralConstants.Headers.PROPERTY_ID,GeneralConstants.Headers.PROPERTY_ID },
                            {GeneralConstants.Headers.USER_ID,GeneralConstants.Headers.USER_ID },
                            {GeneralConstants.Headers.ROLE_ID,GeneralConstants.Headers.ROLE_ID },
                            {GeneralConstants.Headers.ROLE_TYPE_ID,GeneralConstants.Headers.ROLE_TYPE_ID },
                            {GeneralConstants.Headers.GROUP_PLACE_ID,GeneralConstants.Headers.GROUP_PLACE_ID },
                            {GeneralConstants.Headers.SUPER_ADMIN_ID,GeneralConstants.Headers.SUPER_ADMIN_ID },
                            {GeneralConstants.Headers.PROVIDER_ID,GeneralConstants.Headers.PROVIDER_ID },
                            {GeneralConstants.Headers.REQUEST_ID,GeneralConstants.Headers.REQUEST_ID },
                            {GeneralConstants.Headers.IS_ROOT,GeneralConstants.Headers.IS_ROOT },
                            {GeneralConstants.Headers.NAME,GeneralConstants.Headers.NAME },
                            { JwtRegisteredClaimNames.Jti, JwtRegisteredClaimNames.Jti }
                        };
                        foreach (var claimMap in claimsToHeadersMap)
                        {
                            var claim = principal.Claims.FirstOrDefault(c => c.Type == claimMap.Key);
                            if (claim != null && !string.IsNullOrEmpty(claim.Value))
                            {
                                context.Request.Headers.TryAdd(claimMap.Value, claim.Value);
                            }
                        }
                        context.User = principal;
                    }
                }
                await next(context);
            }
            catch (SecurityTokenException exception)
            {
                _Logger.LogWarning(exception, $"El token de autorización no es válido {exception.Message ?? ""}.");
                var statusCode = StatusCode.ExceptionStatusCodeMap.TryGetValue(exception.GetType(), out var code) ? code : HttpStatusCode.InternalServerError;
                var response = ApiResponse<string>.Failure(ErrorsConstants.Response(ErrorsConstants.Keys.INTERNAL_SERVER_ERROR));
                string resultJson = JsonSerializer.Serialize(response);
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.ContentType = GeneralConstants.Headers.APPLICATION_JSON;
                await context.Response.WriteAsync(resultJson);
            }
            catch (Exception exception)
            {
                _Logger.LogError(exception, $"Error en middleware: {exception.Message ?? exception.InnerException?.Message!}.");
                var statusCode = StatusCode.ExceptionStatusCodeMap.TryGetValue(exception.GetType(), out var code) ? code : HttpStatusCode.InternalServerError;
                var response = ApiResponse<string>.Failure(ErrorsConstants.Response(ErrorsConstants.Keys.INTERNAL_SERVER_ERROR));
                string resultJson = JsonSerializer.Serialize(response);
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = GeneralConstants.Headers.APPLICATION_JSON;
                await context.Response.WriteAsync(resultJson);
            }
        }
    }
}
