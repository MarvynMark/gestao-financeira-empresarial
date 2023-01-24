namespace PenielBikeControle.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateOnly DataDeNascimento { get; set; }
        public string? Cpf { get; set; }
        public string? Endereco { get; set; }
        public IList<ProdutoCliente>? ProdutosCliente { get; set; }

        public Cliente() { }
        
        public Cliente(int id, string nome, DateOnly dataDeNascimento, string? cpf, string? endereco, IList<ProdutoCliente>? produtosCliente)
        {
            Id = id;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Cpf = cpf;
            Endereco = endereco;
            ProdutosCliente = produtosCliente;
        }
    }
}
