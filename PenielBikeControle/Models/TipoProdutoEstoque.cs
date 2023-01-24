namespace PenielBikeControle.Models
{
    public class TipoProdutoEstoque
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public TipoProdutoEstoque(){ }

        public TipoProdutoEstoque(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
