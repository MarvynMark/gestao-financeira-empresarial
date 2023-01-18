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
        private readonly IProdutoEstoqueRepository _protudoEstoqueReposirory;
        private readonly ITipoProdutoRepository _tipoProdutoEstoqueRepository;
        public ProdutosEstoqueController(IProdutoEstoqueRepository produtoEstoqueRepository, ITipoProdutoRepository tipoProdutoRepository)
        {
            _protudoEstoqueReposirory = produtoEstoqueRepository;
            _tipoProdutoEstoqueRepository = tipoProdutoRepository;
        }
        // GET: CadastroDeProdutoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CadastroDeProdutoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CadastroDeProdutoController/Create
        public ActionResult Create()
        {
            ProdutoEstoqueViewModel produtoEstoqueViewModel = new ProdutoEstoqueViewModel();
            produtoEstoqueViewModel.Produto = new ProdutoEstoque();
            produtoEstoqueViewModel.ListaTiposDeProduto = _tipoProdutoEstoqueRepository.GetAll().Select(x => new SelectListItem 
            {
                Value = x.Id.ToString(),
                Text = x.Descricao
            });


            return View("CadastroDeProduto", produtoEstoqueViewModel);
        }

        // POST: CadastroDeProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoEstoqueViewModel produtoEstoqueViewModel)
        {
            using (var dtContexTransaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    ProdutoEstoque produtoEstoque = new ProdutoEstoque();
                    produtoEstoque.Descricao = produtoEstoqueViewModel.Produto.Descricao;
                    produtoEstoque.TipoProdutoId = produtoEstoqueViewModel.TipoDeProdutoId;
                    produtoEstoque.PrecoFinal = produtoEstoqueViewModel.Produto.PrecoFinal;
                    produtoEstoque.Modelo = produtoEstoqueViewModel.Produto.Modelo;
                    produtoEstoque.Marca = produtoEstoqueViewModel.Produto.Marca;
                    produtoEstoque.Nome = produtoEstoqueViewModel.Produto.Nome;
                    produtoEstoque.QtdeEmEstoque = produtoEstoqueViewModel.Produto.QtdeEmEstoque;

                    _protudoEstoqueReposirory.Salvar(produtoEstoque);
                    dtContexTransaction.Commit();
                    return RedirectToAction(nameof(Create));
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
