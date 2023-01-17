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
        public IList<Vendedor> GetAll()
        {
            var listaDeVendedores = _context.Vendedores.ToList();
            if (listaDeVendedores.Any())
                return listaDeVendedores;
            else
                return new List<Vendedor>();
        }
        public Vendedor GetById(int id)
        {
            return _context.Vendedores.SingleOrDefault(x => x.Id == id);
        }
    }
}
