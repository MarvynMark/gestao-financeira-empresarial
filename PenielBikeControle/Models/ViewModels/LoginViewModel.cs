using System.ComponentModel.DataAnnotations;

namespace PenielBikeControle.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o seu login")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe sua senha")]
        public string Senha { get; set; } = string.Empty;
    }
}
