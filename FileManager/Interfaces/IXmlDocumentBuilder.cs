using System.Xml;
using DTO;

namespace FileManager.Interfaces
{
    public interface IXmlDocumentBuilder
    {
        XmlDocument Build(Node rootNode, string decisionTreeName);
    }
}
