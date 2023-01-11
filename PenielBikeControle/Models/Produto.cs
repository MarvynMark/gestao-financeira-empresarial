namespace PenielBikeControle.Models
{
    public class Produto
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double Preco { get; set; }

        public Produto(string nome, string marca, string modelo, double preco)
        {
            Nome = nome;
            Marca = marca;
            Modelo = modelo;
            Preco = preco;
        }
    }
}
