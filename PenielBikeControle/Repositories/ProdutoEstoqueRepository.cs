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

        public void Salvar(ProdutoEstoque produto)
        {
            _context.ProdutosEstoque.Add(produto);
            _context.SaveChanges();
        }

        public IList<ProdutoEstoque> GetAll()
        {
            var listaDeProdutos = _context.ProdutosEstoque.ToList();
            if (listaDeProdutos.Any())
                return listaDeProdutos;
            else
                return new List<ProdutoEstoque>();
        }
        public ProdutoEstoque GetById(int id)
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

            return _context.ProdutosEstoque.Include(x => x.TipoProduto).SingleOrDefault(x => x.Id == id);
        }
    }
}
