using System.Reflection;

namespace template_clean_arq_api.Presentation.Settings
{
    public class AssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
