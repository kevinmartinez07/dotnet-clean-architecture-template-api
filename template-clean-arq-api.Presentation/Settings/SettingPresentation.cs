namespace template_clean_arq_api.Presentation.Settings
{
    public static class SettingPresentation
    {
        public static IServiceCollection Presentation(this IServiceCollection services)
        {
            //services.AddTransient<ApiMiddleware>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            return services;
        }
    }
}
