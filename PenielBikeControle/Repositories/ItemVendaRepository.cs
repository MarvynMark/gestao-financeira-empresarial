using Microsoft.EntityFrameworkCore;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class ItemVendaRepository : IItemVendaRepository
    {
        private readonly DataContext _context;
        public ItemVendaRepository(DataContext context) => _context = context;

        public async Task Salvar(ItemVenda itemVenda)
        {
            await _context.ItensVenda.AddAsync(itemVenda);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<ItemVenda>> ObterItensVendidos(int vendaId)
        {
            return await _context.ItensVenda.Where(i => i.VendaId == vendaId).Include(p => p.ProdutoEstoque).Include(pc => pc.ProdutoCliente).ToListAsync();
        }
    }
}
