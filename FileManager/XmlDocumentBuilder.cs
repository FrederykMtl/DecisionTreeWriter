using System;
using System.Xml;
using DTO;
using FileManager.Interfaces;
using FileManager.Resources;

namespace FileManager
{
    /// <summary>
    /// Builds an XML document from a decision tree.
    /// </summary>
    public class XmlDocumentBuilder : IXmlDocumentBuilder
    {
        /// <summary>
        /// Builds an XML document from a decision tree, starting with the root node.
        /// </summary>
        /// <param name="rootNode">The root of the tree</param>
        /// <param name="decisionTreeName">The name of the decision tree</param>
        /// <returns>An xmldocument with the complete decision tree</returns>
        public XmlDocument Build(Node rootNode, string decisionTreeName)
        {
            XmlDocument document = new XmlDocument();
            var declaration = document.CreateXmlDeclaration("1.0", Constants.DefaultEncoding, null);
            document.InsertBefore(declaration, document.DocumentElement);

            XmlNode decisionTree = document.CreateElement(decisionTreeName);
            document.AppendChild(decisionTree);

            XmlNode root = document.CreateElement("Root");
            var name = document.CreateAttribute("name");
            name.Value = rootNode.Name;
            root.Attributes?.Append(name);

            if (rootNode.TestValue.HasValue)
            {
                var testValue = document.CreateAttribute("test");
                testValue.Value = rootNode.TestValue.Value.ToString();
                root.Attributes?.Append(testValue);
            }

            if(rootNode.LeftNode != null)
                root.AppendChild(CreateElementFromNode(rootNode.LeftNode, document, "left"));

            if (rootNode.RightNode != null)
                root.AppendChild(CreateElementFromNode(rootNode.RightNode, document, "right"));

            decisionTree.AppendChild(root);

            return document;
        }

        /// <summary>
        /// Takes a node and creates an XML element
        /// </summary>
        /// <param name="node"></param>
        /// <param name="document"></param>
        /// <param name="decision"></param>
        /// <returns></returns>
        private XmlNode CreateElementFromNode(Node node, XmlDocument document, string decision)
        {
            string nodeName = string.Empty;

            if (node.Type == NodeType.Node)
                nodeName = "Node";

            if (node.Type == NodeType.SubTree)
                nodeName = "Subtree";

            XmlNode newNode = document.CreateElement(nodeName);

            var name = document.CreateAttribute("text");
            name.Value = node.Name;
            newNode.Attributes?.Append(name);

            AddDecisionAttribute(document, decision, newNode);
            AddTestAttribute(node, document, newNode);

            if (node.Type == NodeType.Node && node.LeftNode != null)
            {
                newNode.AppendChild(CreateElementFromNode(node.LeftNode, document, "left"));
            }

            if (node.Type == NodeType.Node && node.RightNode != null)
            {
                newNode.AppendChild(CreateElementFromNode(node.RightNode, document, "right"));
            }

            return newNode;
        }

        private static void AddDecisionAttribute(XmlDocument document, string decision, XmlNode newNode)
        {
            if (string.IsNullOrWhiteSpace(decision))
                return;

            //leaves room for a third possibility
            switch (decision.ToLower())
            {
                case "left":
                    var leftAttr = document.CreateAttribute("decision");
                    leftAttr.Value = "left";
                    newNode.Attributes?.Append(leftAttr);
                    break;
                case "right":
                    var rightAttr = document.CreateAttribute("decision");
                    rightAttr.Value = "right";
                    newNode.Attributes?.Append(rightAttr);
                    break;
                default:
                    throw new ArgumentException("Decision argument unrecognized");
            }
        }

        /// <summary>
        /// Adds the test value attribute
        /// </summary>
        /// <param name="node"></param>
        /// <param name="document"></param>
        /// <param name="newNode"></param>
        private static void AddTestAttribute(Node node, XmlDocument document, XmlNode newNode)
        {
            if (!node.TestValue.HasValue)
                return;

            var testValue = document.CreateAttribute("test");
            testValue.Value = node.TestValue.Value.ToString();
            newNode.Attributes?.Append(testValue);
        }
    }
}
