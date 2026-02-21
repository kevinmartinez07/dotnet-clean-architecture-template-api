using Microsoft.AspNetCore.Http;

namespace template_clean_arq_api.Application.Abstraction
{
    public interface IHeaderValidator
    {
        Task<Guid> GetGuidHeader(IHeaderDictionary headers, string headerName, out Guid value);
        Task<string> GetStringHeader(IHeaderDictionary headers, string headerName, out string value);
        Task<Guid> GetGuidQuery(IQueryCollection queries, string name);
        Task<string> GetStringQuery(IQueryCollection queries, string name);
    }
}
