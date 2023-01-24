namespace PenielBikeControle.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
        public IList<ItemVenda>? ItensDaVenda { get; set; }
        public bool VendaPaga { get; set; }
        public bool ProdutoEstoqueEntregue { get; set; }
        public double DescontoTotal { get; set; }

        public Venda() { }

        public Venda(int id, DateTime data, Cliente cliente, int clienteId, Funcionario funcionario, int funcionarioId, IList<ItemVenda>? itensDaVenda, bool vendaPaga, bool produtoEstoqueEntregue, double descontoTotal)
        {
            Id = id;
            Data = data;
            Cliente = cliente;
            ClienteId = clienteId;
            Funcionario = funcionario;
            FuncionarioId = funcionarioId;
            ItensDaVenda = itensDaVenda;
            VendaPaga = vendaPaga;
            ProdutoEstoqueEntregue = produtoEstoqueEntregue;
            DescontoTotal = descontoTotal;
        }
    }
}
