namespace PenielBikeControle.Models
{
    public class TipoItemVenda
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public TipoItemVenda(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
