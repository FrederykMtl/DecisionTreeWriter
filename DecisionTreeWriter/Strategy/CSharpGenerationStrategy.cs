using System;
using DTO;
using FileManager;

namespace DecisionTreeWriter.Strategy
{
    public class CSharpGenerationStrategy :  ICodeGenerationStrategy
    {
        private readonly string _classTemplate;

        /// <summary>
        /// Encapsulating accessor method for the class template
        /// </summary>
        /// <returns>Th current class template</returns>
        public string GetClassTemplate()
        {
            return _classTemplate;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="controller">a valid controller for file loading</param>
        public CSharpGenerationStrategy(IFileController controller)
        {
            if(controller == null)
                throw new ArgumentException("A file controller is required for this class.");

            _classTemplate = controller.GetTextFileContent("CSharpClassTemplate.txt", "Templates");
        }

        /// <summary>
        /// Generates a code class
        /// </summary>
        /// <param name="classNode"></param>
        /// <returns></returns>
        public string GenerateClass(Node classNode)
        {
            if(classNode == null)
                throw new ArgumentException("Invalid node");
  
            return string.Format(_classTemplate, classNode.Name, classNode.TestValue ?? 0);
        }
    }
}
