using System.ComponentModel.DataAnnotations;

namespace PenielBikeControle.Models
{
    public class TipoProdutoEstoque
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar a descrição do tipo do produto")]
        [StringLength(150)]
        [Display(Name = "Tipo produto")]
        public string Descricao { get; set; }
        public bool Removido { get; set; }
        public TipoProdutoEstoque(){ }

        public TipoProdutoEstoque(int id, string descricao, bool removido)
        {
            Id = id;
            Descricao = descricao;
            Removido = removido;
        }
    }
}
