using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DataContext _context;
        public VendaRepository(DataContext context) => _context = context;

        public void Salvar(Venda venda)
        {
            _context.Vendas.Add(venda);
            _context.SaveChanges();
        }
    }
}
