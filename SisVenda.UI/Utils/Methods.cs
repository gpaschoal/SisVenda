using System.Reflection;
using Newtonsoft.Json;
using SisVenda.UI.CQRS.Filters;

namespace SisVenda.UI.Utils
{
    public static class Methods
    {
        public static T Deserialize<T>(this object value)
        {
            return JsonConvert.DeserializeObject<T>(value.ToString());
        }
        public static string HttpQueryBuilder<T>(this T value) where T : IFilter
        {
            //Testing if is null
            if (value is null) return "";

            //Hold my filter props while FOREACH my filter props
            string tempQuery = "";

            //For every valid prop from my filter I'll add to my query
            foreach (PropertyInfo prop in value.GetType().GetProperties())
                if (prop.GetValue(value) != null)
                {
                    PrintTest.PrintConsole(tempQuery);
                    if (string.IsNullOrEmpty(tempQuery)) tempQuery = "?";
                    else tempQuery += @"&";
                    PrintTest.PrintConsole(tempQuery);
                    tempQuery += $"{prop.Name}={prop.GetValue(value)}";
                }

            PrintTest.PrintConsole(tempQuery);
            return tempQuery.Replace("&", "");
        }
    }
}