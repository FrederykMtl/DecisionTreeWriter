using System;
using System.Xml;
using FileManager;

namespace DecisionTreeManagerTests.Stubs
{
    public class FileControllerStub : IFileController
    {
        public string SavedXmlContent;
        public string SavedTextContent;

        public string GetTextFileContent(string className, string fileLocation)
        {
            switch (className)
            {
                case "CSharpClassTemplate.txt":
                    return "Class template for {0} with value {1}";
                default:
                    return string.Empty;
            }
        }

        public void SaveTextFileContent(string className, string content, string fileLocation)
        {
            SavedTextContent =
                $"I saved class {className}, it has {content} content, and it's in directory {fileLocation}";
        }

        public XmlDocument GetXmlFileContent(string className, string fileLocation)
        {
            throw new NotImplementedException();
        }

        public void SaveXmlFileContent(string className, XmlDocument xmlDocument, string fileLocation)
        {
            SavedTextContent =
                $"I saved class {className}, it has {xmlDocument?.InnerText } content, and it's in directory {fileLocation}";
        }
    }
}
