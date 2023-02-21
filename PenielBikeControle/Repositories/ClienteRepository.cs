using Microsoft.EntityFrameworkCore;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;
        public ClienteRepository(DataContext context) => _context = context;

        public async Task Salvar(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Cliente>> GetAll()
        {
            var listaDeClientes = await _context.Clientes.ToListAsync();
            if (listaDeClientes.Any())
                return listaDeClientes;
            else
                return new List<Cliente>();
        }
        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
