
namespace PenielBikeControle.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public bool Removido { get; set; }
        public DateTime DataCadastro { get; set; }

        public Usuario(int id, string nome, string email, string login, string senha, string telefone, bool removido, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            Telefone = telefone;
            Removido = removido;
            DataCadastro = dataCadastro;
        }
    }
}