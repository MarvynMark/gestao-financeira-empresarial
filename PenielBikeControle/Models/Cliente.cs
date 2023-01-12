namespace PenielBikeControle.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateOnly DataDeNascimento { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public Cliente(int id, string nome, DateOnly dataDeNascimento, string cpf, string endereco)
        {
            Id = id;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Cpf = cpf;
            Endereco = endereco;
        }
    }
}
