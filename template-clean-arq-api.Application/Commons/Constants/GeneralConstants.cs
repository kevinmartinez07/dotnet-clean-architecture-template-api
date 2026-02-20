namespace template_clean_arq_api.Application.Commons.Constants
{
    public static class GeneralConstants
    {
        public const string APPLICATION_JSON = "application/json";
        public const string FAILURE = "Failure";

        public static class DateFormats
        {
            public static class Date
            {
                public const string DMY_SLASH_4 = "dd/MM/yyyy";
                public const string DMY_SLASH_2 = "dd/MM/yy";
                public const string DMY_DASH_4 = "dd-MM-yyyy";
                public const string DMY_DASH_2 = "dd-MM-yy";
                public const string YMD_DASH = "yyyy-MM-dd";
                public const string YMD_SLASH = "yyyy/MM/dd";
                public const string YMD_COMPACT = "yyyyMMdd";
                public const string DMY_DOT_4 = "dd.MM.yyyy";
                public const string MDY_SLASH_4 = "MM/dd/yyyy";
                public const string MDY_SLASH_2 = "MM/dd/yy";
            }
        }

        /// <summary>
        /// Rutas utilizadas en la aplicación.
        /// </summary>
        public static class Paths
        {
            /// <summary>
            /// Path de blobs en Azure Storage.
            /// </summary>
            public static class Blob
            {
                public const string DOCUMENT_MANAGEMENT_FILE = "properties/{0}/document_management/";
                public const string REQUEST_FILE = "properties/{0}/requests/{1}/{2}";
                public const string INVOICE_FILE = "properties/{0}/invoices/";
                public const string POST_FILE = "properties/{0}/post/{1}/";
                public const string PROPERTY_FILE = "properties/{0}/{1}";
                public const string CUSTOM_PATH = "{0}/{1}";
            }
        }

        /// <summary>
        /// Headers HTTP personalizados utilizados en la aplicación.
        /// </summary>
        public static class Headers
        {
            public const string GROUP_PLACE_ROLE_USER_ID = "GroupPlaceRoleUserId";
            public const string AUTHORIZATION = "Authorization";
            public const string PROPERTY_ID = "PropertyId";
            public const string USER_ID = "UserId";
            public const string ROLE_ID = "RoleId";
            public const string ROLE_TYPE_ID = "RoleTypeId";
            public const string GROUP_PLACE_ID = "GroupPlaceId";
            public const string SUPER_ADMIN_ID = "SuperAdminId";
            public const string PROVIDER_ID = "ProviderId";
            public const string REQUEST_ID = "RequestId";
            public const string SESSION_ID = "SessionId";
            public const string IS_ROOT = "IsRoot";
            public const string NAME = "Name";
            public const string BEARER = "Bearer ";
            public const string APPLICATION_JSON = "application/json";
            public const string ERROR = "errors";
            public const string INVALIT_TOKEN_MESSAGE = "Token inválido";
            public const string SERVER_ERROR = "Server Error";
            public const string SERVER_ERROR_MESSAGE = "Ha ocurrido un error en el servidor";
            public const string USER_AGENT = "User-Agent";
            public const string IP = "X-Forwarded-For";
        }

        /// <summary>
        /// Archivos y sus tipos relacionados.
        /// </summary>
        public static class File
        {
            public static class Image
            {
                public const int MAX_WIDTH = 1920;
                public const int MAX_HEIGHT = 1920;
                public const int QUALITY = 85;
                public const int MAX_SIZE_BYTES = 5 * 1024 * 1024; // 5 MB
                public static readonly List<string> EXTENSIONS = [".png", ".jpg", ".jpeg", ".webp"];
                public static readonly List<string> CONTENT_TYPES = ["image/png", "image/jpeg", "image/jpg", "image/webp"];
            }

            public static class Pdf
            {
                public const int MAX_SIZE_BYTES = 10 * 1024 * 1024; // 10 MB
                public static readonly List<string> EXTENSIONS = [".pdf"];
                public static readonly List<string> CONTENT_TYPES = ["application/pdf"];
            }

            public static class Docx
            {
                public const int MAX_SIZE_BYTES = 10 * 1024 * 1024; // 10 MB
                public static readonly List<string> EXTENSIONS = [".docx"];
                public static readonly List<string> CONTENT_TYPES = ["application/vnd.openxmlformats-officedocument.wordprocessingml.document"];
            }

            public static class Xlsx
            {
                public const int MAX_SIZE_BYTES = 10 * 1024 * 1024; // 10 MB
                public static readonly List<string> EXTENSIONS = [".xlsx"];
                public static readonly List<string> CONTENT_TYPES = ["application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"];
            }

            public static class Gif
            {
                public const int MAX_COLORS = 256;
                public const int MAX_WIDTH = 1280;
                public const int MAX_HEIGHT = 1280;
                public const int MAX_SIZE_BYTES = 5 * 1024 * 1024; // 5 MB
                public static readonly List<string> EXTENSIONS = [".gif"];
                public static readonly List<string> CONTENT_TYPES = ["image/gif"];
            }

            public static class Csv
            {
                public const char SEPARATOR = ';';
                public const int MAX_SIZE_BYTES = 5 * 1024 * 1024; // 5 MB
                public static readonly List<string> EXTENSIONS = [".csv"];
                public static readonly List<string> CONTENT_TYPES = ["text/csv", "application/vnd.ms-excel"];
            }
        }
    }
}
