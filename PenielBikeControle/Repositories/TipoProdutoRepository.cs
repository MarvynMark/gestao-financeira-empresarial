using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class TipoProdutoRepository : ITipoProdutoRepository
    {
        private readonly DataContext _context;
        public TipoProdutoRepository(DataContext context) => _context = context;
            
        public void Salvar(TipoProduto tipoProduto)
        {
            _context.TiposProduto.Add(tipoProduto);
            _context.SaveChanges();
        }
    }
}
