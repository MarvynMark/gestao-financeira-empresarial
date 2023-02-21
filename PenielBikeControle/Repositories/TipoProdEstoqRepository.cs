using Microsoft.EntityFrameworkCore;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class TipoProdEstoqRepository : ITipoProdEstoqRepository
    {
        private readonly DataContext _context;
        public TipoProdEstoqRepository(DataContext context) => _context = context;
            
        public async Task Salvar(TipoProdutoEstoque tipoProduto)
        {
            await _context.TiposProduto.AddAsync(tipoProduto);
            await _context.SaveChangesAsync();
        }
        public async Task<IList<TipoProdutoEstoque>> GetAll()
        {
            var listaDeTiposDeProduto = await _context.TiposProduto.ToListAsync();
            if (listaDeTiposDeProduto.Any())
                return listaDeTiposDeProduto;
            else
                return new List<TipoProdutoEstoque>();
        }

        public async Task<TipoProdutoEstoque> GetById(int id)
        {
            return await _context.TiposProduto.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
