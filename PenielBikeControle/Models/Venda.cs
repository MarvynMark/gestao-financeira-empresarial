namespace PenielBikeControle.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
        public IList<ItemVenda>? ItensDaVenda { get; set; }
        public double DescontoTotal { get; set; }

        public Venda() { }
        public Venda(int id, DateTime data, Cliente cliente, Vendedor vendedor, IList<ItemVenda>? itensDaVenda, double descontoTotal)
        {
            Id = id;
            Data = data;
            Cliente = cliente;
            Vendedor = vendedor;
            ItensDaVenda = itensDaVenda;
            DescontoTotal = descontoTotal;
        }
    }
}
