namespace PenielBikeControle.Models
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public Venda Venda { get; set; }
        public TipoItemVenda TipoItemVenda { get; set; }

        public ItemVenda() { }
        public ItemVenda(int id, string nome, string marca, string modelo, double preco, int quantidade, Venda venda, TipoItemVenda tipoItemVenda)
        {
            Id = id;
            Nome = nome;
            Marca = marca;
            Modelo = modelo;
            Preco = preco;
            Quantidade = quantidade;
            Venda = venda;
            TipoItemVenda = tipoItemVenda;
        }
    }
}
