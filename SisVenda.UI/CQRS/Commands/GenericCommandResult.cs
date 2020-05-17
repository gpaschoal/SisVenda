namespace SisVenda.UI.CQRS.Commands
{
    public class GenericCommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
