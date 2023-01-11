namespace PenielBikeControle.Models
{
    public class Servico
    {
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Servico(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }
    }
}
