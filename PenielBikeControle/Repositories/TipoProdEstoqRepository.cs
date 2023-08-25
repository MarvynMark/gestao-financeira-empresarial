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
            
        public async Task<TipoProdutoEstoque> Salvar(TipoProdutoEstoque tipoProduto)
        {
            await _context.TiposProduto.AddAsync(tipoProduto);
            await _context.SaveChangesAsync();
            return tipoProduto;
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

        public async Task<bool> Remover(int id) 
        {
            var tipoProduto = await _context.TiposProduto.SingleOrDefaultAsync(x => x.Id == id);

            if (tipoProduto is not null) 
            {
                tipoProduto.Removido = true;
                _context.Update(tipoProduto);
                
                var result = await _context.SaveChangesAsync();

                if (result != 0) 
                {
                    return true;
                }
                else 
                {
                    return false; 
                }
            }
            else 
            {
                return false;
            }
        }

        public async Task Editar(TipoProdutoEstoque tipoProduto)
        {
            _context.TiposProduto.Update(tipoProduto);
            await _context.SaveChangesAsync();
        }
    }
}
