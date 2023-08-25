namespace PenielBikeControle.Models.ViewModels
{
    public class ClienteViewModel
    {
        public IList<Cliente> Clientes { get; set; }
        public AdicionarClienteViewModel Cliente { get; set; }

        public ClienteViewModel(IList<Cliente> clientes, AdicionarClienteViewModel cliente)
        {
            Clientes = clientes;
            Cliente = cliente;
        }
    }
}