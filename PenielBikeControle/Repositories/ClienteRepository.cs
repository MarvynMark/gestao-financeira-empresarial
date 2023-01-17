using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;
        public ClienteRepository(DataContext context) => _context = context;

        public void Salvar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public IList<Cliente> GetAll()
        {
            var listaDeClientes = _context.Clientes.ToList();
            if (listaDeClientes.Any())
                return listaDeClientes;
            else
                return new List<Cliente>();
        }
        public Cliente GetById(int id)
        {
            return _context.Clientes.SingleOrDefault(x => x.Id == id);
        }
    }
}
