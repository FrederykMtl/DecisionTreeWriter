using DTO;
using FileManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileManagerTests
{
    /// <summary>
    /// Summary description for XmlDocumentBuilder
    /// </summary>
    [TestClass]
    public class XmlDocumentBuilderTest
    {
        private readonly Node _rootNode;

        public XmlDocumentBuilderTest()
        {
            _rootNode = new Node("Is this the real life?", NodeType.Root);
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Build_WithOneRootNodeNoAttribute_ValidDocumentBuilt()
        {
            //ARRANGE
            XmlDocumentBuilder builder = new XmlDocumentBuilder();
            //ACT
            var document = builder.Build(_rootNode, "Bohemian_Rhapsody");
            //ASSERT
            Assert.IsNotNull(document);
        }

        [TestMethod]
        public void Build_WithOneRootNodeWithTestAttribute_ValidDocumentBuilt()
        {
            //ARRANGE
            XmlDocumentBuilder builder = new XmlDocumentBuilder();
            _rootNode.TestValue = 60;
            //ACT
            var document = builder.Build(_rootNode, "Bohemian_Rhapsody");
            //ASSERT
            Assert.IsNotNull(document);
        }

        [TestMethod]
        public void Build_WithMultipleNodes_ValidDocumentBuilt()
        {
            //ARRANGE
            XmlDocumentBuilder builder = new XmlDocumentBuilder();
            _rootNode.LeftNode = new Node("Is this the real life?", NodeType.Node)
            {
                LeftNode = new Node("Nope.", NodeType.Node)
            };
            _rootNode.RightNode = new Node("Is this just fantasy?", NodeType.Node)
            {
                RightNode = new Node("Caught in a landslide", NodeType.Node)
            };
            //ACT
            var document = builder.Build(_rootNode, "Bohemian_Rhapsody");
            //ASSERT
            Assert.IsNotNull(document);

            var elements = document.GetElementsByTagName("Node");
            Assert.IsNotNull(elements);
            Assert.AreEqual(4, elements.Count);
            Assert.IsNotNull(elements[2].Attributes);
            Assert.AreEqual(2, elements[2].Attributes.Count);
            Assert.AreEqual("Is this just fantasy?", elements[2].Attributes[0].Value);
            Assert.AreEqual("right", elements[2].Attributes[1].Value);
        }
    }
}
