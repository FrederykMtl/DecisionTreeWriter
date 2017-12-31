using System;
using DecisionTreeManagerTests.Stubs;
using DecisionTreeWriter.Strategy;
using DTO;
using FileManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecisionTreeManagerTests.Strategy
{
    [TestClass]
    public class CSharpGenerationStrategyTest
    {
        [TestMethod]
        public void Constructor_ValidController_ValidInstanceReturned()
        {
            //ARRANGE
            IFileController controller = new FileControllerStub();
            //ACT
            var cSharpGenerationStrategy = new CSharpGenerationStrategy(controller);
            //ASSERT
            Assert.IsNotNull(cSharpGenerationStrategy);
            Assert.AreEqual("Class template for {0} with value {1}", cSharpGenerationStrategy.GetClassTemplate());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NullValue_ExceptionRaised()
        {
            //ARRANGE
            //ACT
            // ReSharper disable once UnusedVariable
            var cSharpGenerationStrategy = new CSharpGenerationStrategy(null);
        }

        [TestMethod]
        public void GenerateClass_ValidConfiguration_ValidGeneratedCode()
        {
            //ARRANGE
            IFileController controller = new FileControllerStub();
            var cSharpGenerationStrategy = new CSharpGenerationStrategy(controller);
            var node = new Node("TestNode", NodeType.Node)
            {
                TestValue = 57
            };
            //ACT
            var resultingClass = cSharpGenerationStrategy.GenerateClass(node);
            //ASSERT
            Assert.IsNotNull(resultingClass);
            Assert.AreEqual("Class template for TestNode with value 57", resultingClass);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateClass_NullValue_ExceptionRaised()
        {
            //ARRANGE
            IFileController controller = new FileControllerStub();
            var cSharpGenerationStrategy = new CSharpGenerationStrategy(controller);
            //ACT
            // ReSharper disable once UnusedVariable
            var resultingClass = cSharpGenerationStrategy.GenerateClass(null);
        }
    }
}
