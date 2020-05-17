namespace SisVenda.UI.Utils
{
    public static class PrintTest
    {
        public static void PrintConsole(object obj)
        {
            string loginAsJson = System.Text.Json.JsonSerializer.Serialize(obj);
            System.Diagnostics.Debug.Print(loginAsJson);
        }
    }
}