using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class TipoProdEstoqRepository : ITipoProdEstoqRepository
    {
        private readonly DataContext _context;
        public TipoProdEstoqRepository(DataContext context) => _context = context;
            
        public void Salvar(TipoProdutoEstoque tipoProduto)
        {
            _context.TiposProduto.Add(tipoProduto);
            _context.SaveChanges();
        }
        public IList<TipoProdutoEstoque> GetAll()
        {
            var listaDeTiposDeProduto = _context.TiposProduto.ToList();
            if (listaDeTiposDeProduto.Any())
                return listaDeTiposDeProduto;
            else
                return new List<TipoProdutoEstoque>();
        }

        public TipoProdutoEstoque GetById(int id)
        {
            return _context.TiposProduto.SingleOrDefault(x => x.Id == id);
        }
    }
}
