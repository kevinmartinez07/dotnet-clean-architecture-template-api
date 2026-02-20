namespace template_clean_arq_api.Application.Dtos.File
{
    public sealed record ColumnXlsx(int Index, string Header, double Width,
        string? NumberFormat = null, bool Hidden = false, bool IsEditable = true);
}
