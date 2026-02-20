namespace template_clean_arq_api.Application.Dtos.File
{
    public sealed record FileDto(Stream Content, string FileName, string ContentType, string Extension, long Length, long? Width = null, long? Height = null) : IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            if (Content is IAsyncDisposable asyncDisposable)
            {
                await asyncDisposable.DisposeAsync();
            }
            else
            {
                Content.Dispose();
            }
        }
    }
}
