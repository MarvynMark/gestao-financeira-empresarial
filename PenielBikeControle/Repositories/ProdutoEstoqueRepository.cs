using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class ProdutoEstoqueRepository : IProdutoEstoqueRepository
    {
        private readonly DataContext _context;
        public ProdutoEstoqueRepository(DataContext context) => _context = context;

        public void Salvar(ProdutoEstoque produto)
        {
            _context.ProdutosEstoque.Add(produto);
            _context.SaveChanges();
        }
    }
}
