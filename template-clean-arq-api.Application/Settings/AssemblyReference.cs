using System.Reflection;

namespace template_clean_arq_api.Application.Settings
{
    public class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
