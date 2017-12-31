using DataManager;
using DecisionTreeManagerTests.Stubs;
using DecisionTreeWriter.Presenters;
using DTO;
using FileManager.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DecisionTreeManagerTests.Presenters
{
    [TestClass]
    public class PanelPresenterTest
    {
        [TestMethod]
        public void SaveTreeToFile_WithValidNodeTree_CodeGeneratedAndSaved()
        {
            //Arrange
            var listManager = new Mock<INodeListManager>();
            var builder = new Mock<IXmlDocumentBuilder>();
            var config = new UserConfigurations {Language = Languages.CSharp};
            builder.SetupAllProperties();
            var controller = new FileControllerStub();

            PanelPresenter presenter = new PanelPresenter("TestPanel", listManager.Object);
            presenter.AddRoot();
            
            //ACT
            presenter.SaveTreeToFile(controller, builder.Object, config);
            //ASSERT
            Assert.AreNotEqual(controller.SavedTextContent, string.Empty);
            Assert.IsTrue(controller.SavedTextContent.Contains("I saved class "));
        }
    }
}