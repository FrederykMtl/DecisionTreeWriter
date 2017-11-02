using System.Collections.Generic;

namespace DataManager
{
    public static class DataExtensions
    {
        public static string ToCsvString(this List<string> list)
        {
            //if (!list.Any())
            //    return string.Empty;

            return string.Join(",", list);
        }
    }
}
