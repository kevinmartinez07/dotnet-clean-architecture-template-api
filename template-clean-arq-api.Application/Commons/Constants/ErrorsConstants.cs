namespace template_clean_arq_api.Application.Commons.Constants
{
    /// <summary>
    /// Errores comunes utilizados en la aplicación.
    /// </summary>
    public static class ErrorsConstants
    {
        /// <summary>
        /// Llaves de error para identificar tipos de errores específicos.
        /// </summary>
        public static class Keys
        {
            public const string BAD_REQUEST = "BAD_REQUEST";
            public const string NO_CONTENT = "NO_CONTENT";
            public const string UNAUTHORIZED = "UNAUTHORIZED";
            public const string FORBIDDEN = "FORBIDDEN";
            public const string NOT_FOUND = "NOT_FOUND";
            public const string REQUEST_TIMEOUT = "REQUEST_TIMEOUT";
            public const string CONFLICT = "CONFLICT";
            public const string UNPROCESSABLE_ENTITY = "UNPROCESSABLE_ENTITY";
            public const string LOCKED = "LOCKED";
            public const string INTERNAL_SERVER_ERROR = "INTERNAL_SERVER_ERROR";
        }

        /// <summary>
        /// Mensajes de error genericos para cada tipo de error.
        /// </summary>
        public static class Messages
        {
            //TODO: cambiar a ingles
            public const string BAD_REQUEST = "La solicitud no es válida.";
            public const string NO_CONTENT = "No se encontró contenido para mostrar.";
            public const string UNAUTHORIZED = "No tiene autorización para realizar esta acción.";
            public const string FORBIDDEN = "Acceso denegado.";
            public const string NOT_FOUND = "El recurso solicitado no fue encontrado.";
            public const string REQUEST_TIMEOUT = "La solicitud excedió el tiempo de espera.";
            public const string CONFLICT = "Conflicto en la solicitud.";
            public const string UNPROCESSABLE_ENTITY = "No se pudo procesar la entidad enviada.";
            public const string LOCKED = "El recurso está bloqueado.";
            public const string INTERNAL_SERVER_ERROR = "Se produjo un error inesperado.";
        }


        /// <summary>
        /// Mensajes de error relacionados con headers HTTP.
        /// </summary>
        public static class Headers
        {
            public const string HEADER_INVALID = "El header '{0}' es obligatorio.";
            public const string HEADER_MISSING = "El header '{0}' debe ser un dato válido.";
        }

        /// <summary>
        /// Mensajes de error relacionados con queries HTTP.
        /// </summary>
        public static class Queries
        {
            public const string QUERY_INVALID = "El query '{0}' es obligatorio.";
            public const string QUERY_MISSING = "El query '{0}' debe ser un dato válido.";
        }

        /// <summary>
        /// Mensajes de error relacionados con transacciones.
        /// </summary>
        public static class Transactions
        {
            public const string EXISTING_TRANSACTION = "Ya existe una transacción activa.";
            public const string NON_EXISTENT_TRANSACTION = "No hay una transacción activa para confirmar.";
        }

        private static readonly IReadOnlyDictionary<string, string> MapResponse =
            new Dictionary<string, string>
            {
                [Keys.BAD_REQUEST] = Messages.BAD_REQUEST,
                [Keys.NO_CONTENT] = Messages.NO_CONTENT,
                [Keys.UNAUTHORIZED] = Messages.UNAUTHORIZED,
                [Keys.FORBIDDEN] = Messages.FORBIDDEN,
                [Keys.NOT_FOUND] = Messages.NOT_FOUND,
                [Keys.REQUEST_TIMEOUT] = Messages.REQUEST_TIMEOUT,
                [Keys.CONFLICT] = Messages.CONFLICT,
                [Keys.UNPROCESSABLE_ENTITY] = Messages.UNPROCESSABLE_ENTITY,
                [Keys.LOCKED] = Messages.LOCKED,
                [Keys.INTERNAL_SERVER_ERROR] = Messages.INTERNAL_SERVER_ERROR
            };


        /// <summary>
        /// Retorna { key : mensaje } usando el catálogo. Si la key no existe, usa INTERNAL_SERVER_ERROR.
        /// </summary>
        public static Dictionary<string, string> Response(string? key = null, string? customMessage = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                return new Dictionary<string, string> { { Keys.INTERNAL_SERVER_ERROR, customMessage ?? Messages.INTERNAL_SERVER_ERROR } };

            return new Dictionary<string, string>{
                        { key, customMessage ?? (MapResponse.TryGetValue(key, out var message) ? message : Messages.INTERNAL_SERVER_ERROR) }
                    };
        }
    }
}
