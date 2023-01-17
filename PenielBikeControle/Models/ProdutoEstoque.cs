namespace PenielBikeControle.Models
{
    public class ProdutoEstoque
    {
        public int Id { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public string Nome { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Descricao { get; set; }
        public double PrecoCusto { get; set; }
        public double PrecoFinal { get; set; }
        public int QtdeEmEstoque { get; set; }

        public ProdutoEstoque() { }

        public ProdutoEstoque(int id, TipoProduto tipoProduto, string nome, string? marca, string? modelo, string? descricao, double precoCusto, double precoFinal, int qtdeEmEstoque)
        {
            Id = id;
            TipoProduto = tipoProduto;
            Nome = nome;
            Marca = marca;
            Modelo = modelo;
            Descricao = descricao;
            PrecoCusto = precoCusto;
            PrecoFinal = precoFinal;
            QtdeEmEstoque = qtdeEmEstoque;
        }
    }
}
