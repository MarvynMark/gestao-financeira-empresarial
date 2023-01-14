using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class ItemVendaRepository : IItemVendaRepository
    {
        private readonly DataContext _context;
        public ItemVendaRepository(DataContext context) => _context = context;

        public void Salvar(ItemVenda itemVenda)
        {
            _context.ItensVenda.Add(itemVenda);
            _context.SaveChanges();
        }
    }
}
