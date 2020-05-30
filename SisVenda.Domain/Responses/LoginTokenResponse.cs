using System;
using System.Collections.Generic;
using System.Text;

namespace SisVenda.Domain.Responses
{
    public class LoginTokenResponse : IResponse
    {
        public LoginTokenResponse() { }
        public LoginTokenResponse(string token)
        {
            Token = token;
        }

        public string Token { get; private set; }
    }
}
