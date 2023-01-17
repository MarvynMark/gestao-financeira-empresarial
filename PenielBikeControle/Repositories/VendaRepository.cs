using Microsoft.AspNetCore.Rewrite;
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
            var idVenda = _context.SaveChanges(); // TODO: Mudar o commit da transação para a controller, após fazer todo o processo. E adicionar rollback no catch caso falha
            if (idVenda > 0)
                return venda;
            else
                return null;
        }

        public Venda GetById(int id)
        {
            return _context.Vendas.SingleOrDefault(x => x.Id == id);
        }
    }
}
