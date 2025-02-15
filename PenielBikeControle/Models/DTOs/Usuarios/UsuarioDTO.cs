namespace PenielBikeControle.Models.DTOs.Usuarios
{
    public class UsuarioDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string ConfirmeSenha { get; set; } = string.Empty;
    }
}