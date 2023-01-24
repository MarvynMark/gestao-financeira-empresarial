namespace PenielBikeControle.Models
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public Venda Venda { get; set; }
        public int VendaId { get; set; }
        public ProdutoEstoque ProdutoEstoque { get; set; }
        public int ProdutoEstoqueId { get; set; }
        public ProdutoCliente? ProdutoCliente { get; set; }
        public int? ProdutoClienteId { get; set; }

        public ItemVenda() { }

        public ItemVenda(int id, Venda venda, int vendaId, ProdutoEstoque produtoEstoque, int produtoEstoqueId, ProdutoCliente? produtoCliente, int? produtoClienteId)
        {
            Id = id;
            Venda = venda;
            VendaId = vendaId;
            ProdutoEstoque = produtoEstoque;
            ProdutoEstoqueId = produtoEstoqueId;
            ProdutoCliente = produtoCliente;
            ProdutoClienteId = produtoClienteId;
        }
    }
}
