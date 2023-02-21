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
            //return (from p in _context.ProdutosEstoque
            //              join t in _context.TiposProduto
            //              on p.TipoProduto.Id equals t.Id
            //              where p.Id == id
            //              select new ProdutoEstoque
            //              {
            //                  Id = p.Id,
            //                  TipoProduto = t,
            //                  Nome = p.Nome,
            //                  Marca = p.Marca,
            //                  Modelo = p.Modelo,
            //                  Descricao = p.Descricao,
            //                  PrecoCusto = p.PrecoCusto,
            //                  PrecoFinal = p.PrecoFinal,
            //                  QtdeEmEstoque = p.QtdeEmEstoque
            //              }).FirstOrDefault();

            return await _context.ProdutosEstoque.Include(x => x.TipoProduto).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
