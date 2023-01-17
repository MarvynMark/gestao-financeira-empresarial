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
        public IList<TipoProduto> GetAll()
        {
            var listaDeTiposDeProduto = _context.TiposProduto.ToList();
            if (listaDeTiposDeProduto.Any())
                return listaDeTiposDeProduto;
            else
                return new List<TipoProduto>();
        }

        public TipoProduto GetById(int id)
        {
            return _context.TiposProduto.SingleOrDefault(x => x.Id == id);
        }
    }
}
