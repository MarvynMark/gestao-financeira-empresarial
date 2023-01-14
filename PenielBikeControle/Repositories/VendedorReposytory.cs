using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class VendedorReposytory : IVendedorRepository
    {
        private readonly DataContext _context;
        public VendedorReposytory(DataContext context) => _context = context;
        
        public void Salvar(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges(); 
        }
        
    }
}
