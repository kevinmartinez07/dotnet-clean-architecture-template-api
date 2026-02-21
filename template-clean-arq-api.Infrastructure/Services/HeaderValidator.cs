using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using template_clean_arq_api.Application.Abstraction;
using template_clean_arq_api.Infrastructure.Commons.Constants;

namespace template_clean_arq_api.Infrastructure.Services
{
    public class HeaderValidator : IHeaderValidator
    {
        public Task<Guid> GetGuidHeader(IHeaderDictionary headers, string headerName, out Guid value)
        {
            if (!headers.TryGetValue(headerName, out StringValues result))
            {
                throw new ArgumentException(string.Format(GeneralConstants.ERROR_HEADER_INVALID, headerName));
            }
            return !Guid.TryParse(result, out value)
                ? throw new ArgumentException(string.Format(GeneralConstants.ERROR_HEADER_MISSING, headerName))
                : Task.FromResult(value);
        }

        public Task<string> GetStringHeader(IHeaderDictionary headers, string headerName, out string value)
        {
            value = string.Empty;
            if (!headers.TryGetValue(headerName, value: out StringValues result))
            {
                throw new ArgumentException(string.Format(GeneralConstants.ERROR_HEADER_INVALID, headerName));
            }
            value = result.ToString();
            return Task.FromResult(value);
        }

        public Task<Guid> GetGuidQuery(IQueryCollection queries, string name)
        {
            if (!queries.TryGetValue(name, value: out StringValues result))
            {
                throw new ArgumentException(string.Format(GeneralConstants.ERROR_QUERIES_INVALID, name));
            }

            return Task.FromResult(!Guid.TryParse(result, out Guid value) ? throw new ArgumentException(string.Format(GeneralConstants.ERROR_QUERIES_MISSING, name)) : value);
        }

        public Task<string> GetStringQuery(IQueryCollection queries, string name)
        {
            if (!queries.TryGetValue(name, value: out StringValues result))
            {
                throw new ArgumentException(string.Format(GeneralConstants.ERROR_QUERIES_INVALID, name));
            }

            return Task.FromResult(result.ToString());
        }
    }
}
