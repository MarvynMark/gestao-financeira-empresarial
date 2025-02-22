using System.ComponentModel.DataAnnotations;

namespace PenielBikeControle.Models.ViewModels
{
    public class CadastroUsuarioViewModel
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "O nome de usuário não pode conter caracteres especiais.")]
        public string NomeUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "O login é obrigatório.")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "O login deve ter entre 6 e 12 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "O login não pode conter espaços ou caracteres especiais.")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 8 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "A confirmação da senha é obrigatória.")]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        [DataType(DataType.Password)]
        public string SenhaConfirmacao { get; set; } = string.Empty;
    }
}
