namespace template_clean_arq_api.Infrastructure.Commons.Constants
{
    internal class GeneralConstants
    {
        //TODO: cambiar a ingles
        internal const string EXISTING_TRANSACTION = "Ya existe una transacción activa.";
        internal const string NON_EXISTENT_TRANSACTION = "No hay una transacción activa para confirmar.";

        internal const string ERROR_HEADER_INVALID = "El header '{0}' es obligatorio.";
        internal const string ERROR_HEADER_MISSING = "El header '{0}' debe ser un dato válido.";

        internal const string ERROR_QUERIES_INVALID = "El query '{0}' es obligatorio.";
        internal const string ERROR_QUERIES_MISSING = "El query '{0}' debe ser un dato válido.";
    }
}
