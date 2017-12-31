using DTO;

namespace DecisionTreeWriter.Strategy
{
    public interface ICodeGenerationStrategy
    {
        string GenerateClass(Node classNode);
    }
}