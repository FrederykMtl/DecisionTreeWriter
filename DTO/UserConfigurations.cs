namespace DTO
{
    public enum Languages
    {
        CSharp,
        CPlusPlus,
        Java,
        Python,
        NoCodeGeneration
    }

    public class UserConfigurations
    {
        public Languages Language;
        public string RightBranchLabel;
        public string LeftBranchLabel;
    }
}