namespace PenielBikeControle.Models
{
    public class ProdutoCliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Descricao { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        public ProdutoCliente() { }

        public ProdutoCliente(string nome, string? marca, string? modelo, string? descricao, Cliente cliente, int clienteId)
        {
            Nome = nome;
            Marca = marca;
            Modelo = modelo;
            Descricao = descricao;
            Cliente = cliente;
            ClienteId = clienteId;
        }
    }
}
