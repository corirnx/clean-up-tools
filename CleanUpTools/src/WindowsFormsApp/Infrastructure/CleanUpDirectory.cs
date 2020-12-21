using System.IO;

namespace WindowsFormsApp.Infrastructure
{
    internal class CleanUpDirectory
    {
        internal DirectoryInfo Directory { get; set; }
        internal string Extension { get; set; }
        internal bool? Recursive { get; set; }
    }
}
