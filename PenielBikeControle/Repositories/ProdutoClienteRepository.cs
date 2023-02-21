using Microsoft.EntityFrameworkCore;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class ProdutoClienteRepository : IProdutoClienteRepository
    {
        private readonly DataContext _dataContext;

        public ProdutoClienteRepository(DataContext dataContext) => _dataContext = dataContext;        

        public async Task<ProdutoCliente> Salvar(ProdutoCliente clienteProduto)
        {
            await _dataContext.ProdutosCliente.AddAsync(clienteProduto);
            await _dataContext.SaveChangesAsync();
            return clienteProduto;
        }
        public async Task<ProdutoCliente> GetById(int id)
        {
            return await _dataContext.ProdutosCliente.Include(x => x.Cliente).SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IList<ProdutoCliente>> GetAll()
        {
            return await _dataContext.ProdutosCliente.Include(x => x.Cliente).ToListAsync();
        }
    }
}
