using System;
using DecisionTreeWriter.Strategy;
using DTO;
using FileManager;

namespace DecisionTreeWriter.Factories
{
    public static class StrategyFactory
    {
        public static ICodeGenerationStrategy GetClassInstance(UserConfigurations configuration, IFileController controller)
        {
            switch (configuration.Language)
            {
                case Languages.CSharp:
                    return new CSharpGenerationStrategy(controller);
                case Languages.CPlusPlus:
                    break;
                case Languages.Java:
                    break;
                case Languages.Python:
                    break;
                case Languages.NoCodeGeneration:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return null;
        }
    }
}
