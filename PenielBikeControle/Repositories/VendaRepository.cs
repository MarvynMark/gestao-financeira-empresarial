using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DataContext _context;
        public VendaRepository(DataContext context) => _context = context;

        public Venda Salvar(Venda venda)
        {
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return venda;
        }

        public IList<Venda> GetAll()
        {
            var vendas = _context.Vendas.Include(c => c.Cliente).Include(v => v.Funcionario).Include(i => i.ItensDaVenda).ToList();
            if (vendas.Any())
                return vendas;
            else
                return new List<Venda>();
        }

        public Venda GetById(int id)
        {
            return _context.Vendas.Include(x => x.Funcionario).Include(c => c.Cliente).Include(i => i.ItensDaVenda).SingleOrDefault(x => x.Id == id);
        }
    }
}
