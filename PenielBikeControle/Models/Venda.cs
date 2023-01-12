namespace PenielBikeControle.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
        public IList<ItemVenda> ItensDaVenda { get; set; }
    }
}
