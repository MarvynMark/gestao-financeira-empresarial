using Microsoft.EntityFrameworkCore;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class ProdutoEstoqueRepository : IProdutoEstoqueRepository
    {
        private readonly DataContext _context;
        public ProdutoEstoqueRepository(DataContext context) => _context = context;

        public async Task Salvar(ProdutoEstoque produto)
        {
            await _context.ProdutosEstoque.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<ProdutoEstoque>> GetAll()
        {
            var listaDeProdutos = await _context.ProdutosEstoque.Include(x => x.TipoProduto).ToListAsync();
            if (listaDeProdutos.Any())
                return listaDeProdutos;
            else
                return new List<ProdutoEstoque>();
        }
        public async Task<ProdutoEstoque> GetById(int id)
        {
            return await _context.ProdutosEstoque.Include(x => x.TipoProduto).SingleOrDefaultAsync(x => x.Id == id) ?? new ProdutoEstoque();
        }

        public async Task Editar(ProdutoEstoque produto)
        {
            _context.ProdutosEstoque.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Remover(int id) 
        {
            var produto = await _context.ProdutosEstoque.SingleOrDefaultAsync(x => x.Id == id);

            if (produto is not null) 
            {
                produto.Removido = true;
                _context.Update(produto);
                
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
    }
}
