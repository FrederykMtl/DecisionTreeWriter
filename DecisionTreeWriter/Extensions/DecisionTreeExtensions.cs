// ReSharper disable once CheckNamespace
namespace DecisionTreeWriter
{
    public static class DecisionTreeExtensions
    {
        public static bool IsNumeric(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            try
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                double.Parse(text);

                return true;
            }
            catch
            {
               // just dismiss errors but return false 
            } 
            return false;
        }
    }
}
