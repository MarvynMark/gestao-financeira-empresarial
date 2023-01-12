namespace PenielBikeControle.Models
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double Preco { get; set; }
        public Venda Venda { get; set; }
        public TipoItemVenda TipoItemVenda { get; set; }
    }
}
