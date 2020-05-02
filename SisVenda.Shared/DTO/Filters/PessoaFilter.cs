namespace SisVenda.Shared.DTO.Filters
{
    public class PessoaFilter : IFilter
    {
        public bool? TpCliente { get; set; }
        public bool? TpFornecedor { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Email { get; set; }

        public int RowsByPage { get; set; }
        public int PageNumber { get; set; }
    }
}
