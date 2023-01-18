namespace PenielBikeControle.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public Vendedor Vendedor { get; set; }
        public int VendedorId { get; set; }
        public IList<ItemVenda>? ItensDaVenda { get; set; }
        public double DescontoTotal { get; set; }

        public Venda() { }

        public Venda(int id, DateTime data, Cliente cliente, int clienteId, Vendedor vendedor, int vendedorId, IList<ItemVenda>? itensDaVenda, double descontoTotal)
        {
            Id = id;
            Data = data;
            Cliente = cliente;
            ClienteId = clienteId;
            Vendedor = vendedor;
            VendedorId = vendedorId;
            ItensDaVenda = itensDaVenda;
            DescontoTotal = descontoTotal;
        }
    }
}
