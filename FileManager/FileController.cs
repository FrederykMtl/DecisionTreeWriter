using System;
using System.Globalization;
using System.IO;
using System.Xml;
using FileManager.Resources;

namespace FileManager
{
    //<inheritdoc/>
    public class FileController : IFileController
    {
        public string GetTextFileContent(string className, string fileLocation)
        {
            var path = GetFilelocation(className, fileLocation);

            return !File.Exists(path) ? string.Empty : File.ReadAllText(path);
        }

        public void SaveTextFileContent(string className, string content, string fileLocation)
        {
            var path = GetFilelocation(className, fileLocation);

            File.WriteAllText(path, content);
        }

        public XmlDocument GetXmlFileContent(string className, string fileLocation)
        {
            var path = GetFilelocation(className, fileLocation);

            if (!File.Exists(path))
                return new XmlDocument();

            XmlDocument document = new XmlDocument();
            document.Load(path);

            return document;
        }

        public void SaveXmlFileContent(string className, XmlDocument document, string fileLocation)
        {
            var path = GetFilelocation(className, fileLocation);

            document.Save(path);
        }

        private static string GetFilelocation(string className, string fileLocation)
        {
            var directoryResource = ApplicationDirectories.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

            string directory = directoryResource.GetString(fileLocation);

            var resourceSet = ApplicationFiles.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);

            return Environment.CurrentDirectory + directory + resourceSet.GetString(className);
        }
    }
}
