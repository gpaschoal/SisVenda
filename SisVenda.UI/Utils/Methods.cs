using Newtonsoft.Json;

namespace SisVenda.UI.Utils
{
    public static class Methods
    {
        public static T Deserialize<T>(this object value)
        {
            return JsonConvert.DeserializeObject<T>(value.ToString());
        }
    }
}