namespace SisVenda.UI.CQRS.Responses
{
    public class LoginResponse : IResponse
    {
        public string Token { get; set; }
    }
}