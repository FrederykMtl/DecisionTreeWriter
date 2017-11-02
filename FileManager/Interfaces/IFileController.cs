using System.Xml;

// ReSharper disable once CheckNamespace
namespace FileManager
{
    /// <summary>
    /// This is the interface for the class responsible for managing
    /// file content such as loading and saving. It uses the resource file to
    /// know all the file locations.
    /// DOES NOT manage file content or formatting.
    /// </summary>
    public interface IFileController
    {
        string GetTextFileContent(string className, string fileLocation);
        void SaveTextFileContent(string className, string content, string fileLocation);

        XmlDocument GetXmlFileContent(string className, string fileLocation);
        void SaveXmlFileContent(string className, XmlDocument document, string fileLocation);
    }
}
