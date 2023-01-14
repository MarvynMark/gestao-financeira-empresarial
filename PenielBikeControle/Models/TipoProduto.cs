namespace PenielBikeControle.Models
{
    public class TipoProduto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public TipoProduto(){ }

        public TipoProduto(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
