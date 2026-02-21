using Microsoft.AspNetCore.Http;
using template_clean_arq_api.Application.Dtos.File;

namespace template_clean_arq_api.Application.Strategies
{
    public interface IFileNormalizer
    {
        bool CanHandle(string contentType, string extension);
        Task<FileDto> Normalize(IFormFile file, CancellationToken cancellationToken);
        Task<FileDto> Normalize(FileDto file, CancellationToken cancellationToken);
    }
}
