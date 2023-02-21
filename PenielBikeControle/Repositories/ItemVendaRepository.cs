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
    }
}
