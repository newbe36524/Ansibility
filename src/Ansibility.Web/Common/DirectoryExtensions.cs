using System.IO;

namespace Ansibility.Web.Common
{
    public static class DirectoryExtensions
    {
        public static void CreateIfNotExsist(string directoryName)
        {
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }
    }
}