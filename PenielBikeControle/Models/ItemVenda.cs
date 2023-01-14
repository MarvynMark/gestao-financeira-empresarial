namespace PenielBikeControle.Models
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public Venda Venda { get; set; }
        public ProdutoEstoque ProdutoEstoque { get; set; }

        public ItemVenda() { }

        public ItemVenda(int id, Venda venda, ProdutoEstoque produtoEstoque)
        {
            Id = id;
            Venda = venda;
            ProdutoEstoque = produtoEstoque;
        }
    }
}
