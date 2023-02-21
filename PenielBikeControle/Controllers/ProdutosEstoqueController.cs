using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Controllers
{
    public class ProdutosEstoqueController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IProdutoEstoqueRepository _produtoEstoqueReposirory;
        private readonly ITipoProdEstoqRepository _tipoProdutoEstoqueRepository;
        public ProdutosEstoqueController(DataContext dataContext, IProdutoEstoqueRepository produtoEstoqueRepository, ITipoProdEstoqRepository tipoProdutoRepository)
        {
            _produtoEstoqueReposirory = produtoEstoqueRepository;
            _tipoProdutoEstoqueRepository = tipoProdutoRepository;
            _dataContext = dataContext;
        }
        // GET: CadastroDeProdutoController
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Lista()
        {
            var produtos = await _produtoEstoqueReposirory.GetAll();
            return View(produtos);
        }


        // GET: CadastroDeProdutoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CadastroDeProdutoController/Create
        public async Task<ActionResult> Cadastro()
        {
            ProdutoEstoqueViewModel produtoEstoqueViewModel = new ProdutoEstoqueViewModel();
            produtoEstoqueViewModel.Produto = new ProdutoEstoque();
            var listaDeProdutos = await _tipoProdutoEstoqueRepository.GetAll();
            produtoEstoqueViewModel.ListaTiposDeProduto = listaDeProdutos.Select(x => new SelectListItem 
            {
                Value = x.Id.ToString(),
                Text = x.Descricao
            });


            return View(produtoEstoqueViewModel);
        }

        // POST: CadastroDeProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cadastro(ProdutoEstoqueViewModel produtoEstoqueViewModel)
        {
            using (var dtContexTransaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    ProdutoEstoque produtoEstoque = new ProdutoEstoque();
                    produtoEstoque.Descricao = produtoEstoqueViewModel.Produto.Descricao;
                    produtoEstoque.TipoProdutoId = produtoEstoqueViewModel.TipoDeProdutoId;
                    produtoEstoque.PrecoCusto = produtoEstoqueViewModel.Produto.PrecoCusto;
                    produtoEstoque.PrecoFinal = produtoEstoqueViewModel.Produto.PrecoFinal;
                    produtoEstoque.Modelo = produtoEstoqueViewModel.Produto.Modelo;
                    produtoEstoque.Marca = produtoEstoqueViewModel.Produto.Marca;
                    produtoEstoque.Nome = produtoEstoqueViewModel.Produto.Nome;
                    produtoEstoque.QtdeEmEstoque = produtoEstoqueViewModel.Produto.QtdeEmEstoque;

                    await _produtoEstoqueReposirory.Salvar(produtoEstoque);
                    dtContexTransaction.Commit();
                    return RedirectToAction(nameof(Cadastro));
                }
                catch
                {
                    dtContexTransaction.Rollback();
                    return View();
                }
            }
        }

        // GET: CadastroDeProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CadastroDeProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CadastroDeProdutoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CadastroDeProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
