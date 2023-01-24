namespace PenielBikeControle.Models
{
    public class ProdutoEstoque
    {
        public int Id { get; set; }
        public TipoProdutoEstoque TipoProduto { get; set; }
        public int TipoProdutoId { get; set; }
        public string Nome { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Descricao { get; set; }
        public double PrecoCusto { get; set; }
        public double PrecoFinal { get; set; }
        public int QtdeEmEstoque { get; set; }

        public ProdutoEstoque() { }

        public ProdutoEstoque(int id, TipoProdutoEstoque tipoProduto, string nome, string? marca, string? modelo, string? descricao, double precoCusto, double precoFinal, int qtdeEmEstoque, int tipoProdutoId)
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
            TipoProdutoId = tipoProdutoId;
        }
    }
}
