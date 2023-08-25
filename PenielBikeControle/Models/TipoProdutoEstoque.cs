using System.ComponentModel.DataAnnotations;

namespace PenielBikeControle.Models
{
    public class TipoProdutoEstoque
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar a descrição do tipo do produto")]
        [StringLength(150)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public TipoProdutoEstoque(){ }

        public TipoProdutoEstoque(int id, string descricao, bool removido)
        {
            Id = id;
            Descricao = descricao;
            Removido = removido;
        }
    }
}
