using Microsoft.AspNetCore.Identity;

namespace PenielBikeControle.Models
{
    public class Usuario : IdentityUser
    {
        public bool Removido { get; set; } = false;
        public DateTime DataCadastro { get; set; } = new DateTime();
    }
}