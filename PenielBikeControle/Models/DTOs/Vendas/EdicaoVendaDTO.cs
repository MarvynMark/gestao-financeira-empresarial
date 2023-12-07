namespace PenielBikeControle.Models.DTOs.Vendas
{
    public class EdicaoVendaDTO
    {
        public int VendaId { get; set; }
        public DateTime DataDaVenda { get; set; }
        public decimal Desconto { get; set; }
        public bool VendaPaga { get; set; }
        public bool ProdutoEntregue { get; set; }
    }
}