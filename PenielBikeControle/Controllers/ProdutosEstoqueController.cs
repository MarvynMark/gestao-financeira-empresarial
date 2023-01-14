using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Controllers
{
    public class ProdutosEstoqueController : Controller
    {
        private readonly IProdutoEstoqueRepository _protudoEstoqueReposirory;
        public ProdutosEstoqueController(IProdutoEstoqueRepository produtoEstoqueRepository)
        {
                _protudoEstoqueReposirory = produtoEstoqueRepository;
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
            return View();
        }

        // POST: CadastroDeProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoEstoque produtoEstoque)
        {
            try
            {
                _protudoEstoqueReposirory.Salvar(produtoEstoque);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                
                return View();
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
