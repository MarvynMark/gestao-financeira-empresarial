namespace PenielBikeControle.Models.DTOs.Vendas
{
    public class VendaDTO
    {
        public string DataVenda { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }
        public bool VendaPaga { get; set; }
        public bool ProdutoEntregue { get; set; }
        public decimal Desconto { get; set; }
        public List<string> ItensVenda { get; set; } = new List<string>();
    }
}