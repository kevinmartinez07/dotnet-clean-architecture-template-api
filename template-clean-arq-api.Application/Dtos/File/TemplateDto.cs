namespace template_clean_arq_api.Application.Dtos.File
{
    public sealed record TemplateDto(string Name, string ContentType, byte[] Content);
}
