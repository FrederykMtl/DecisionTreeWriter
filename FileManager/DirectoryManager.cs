using System;
using System.Collections;
using System.Globalization;
using System.IO;
using FileManager.Resources;

namespace FileManager
{
    /// <summary>
    /// Manages operations linked to application directories
    /// </summary>
    public static class DirectoryManager
    {
        public static void CreateApplicationDirectories()
        {
            var directoryResource = ApplicationDirectories.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

            foreach (DictionaryEntry resource in directoryResource)
            {
                var directory = Environment.CurrentDirectory + resource.Value;

                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
            }
        }
    }
}