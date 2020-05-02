namespace SisVenda.Shared.Extencoes
{
    public static class Validacoes
    {
        public static bool ValidaEmail(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
