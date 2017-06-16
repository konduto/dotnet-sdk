using System.IO;
using System.Reflection;

namespace KdtTests.Properties
{
    internal static class Resources
    {
        /// <summary>
        /// Loads an embed resource file
        /// </summary>
        /// <param name="name">File name</param>
        /// <param name="extension">File extension</param>
        /// <returns>String</returns>
        internal static string Load(string name, string extension = "txt")
        {
            var assembly = typeof(Resources).GetTypeInfo().Assembly;
            var resource = assembly.GetManifestResourceStream($"KdtTests.Resources.{name}.{extension}");
            return new StreamReader(resource).ReadToEnd();
        }
    }
}
