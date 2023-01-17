using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Controllers
{
    public class TipoProdutoController : Controller
    {
        private readonly ITipoProdutoRepository _tipoProdutoRepository;

        public TipoProdutoController(ITipoProdutoRepository tipoProdutoRepository)
        {
            _tipoProdutoRepository = tipoProdutoRepository;
        }

        // GET: TipoProdutoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoProdutoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoProdutoController/Create
        public ActionResult Create()
        {
            return View("CreateTipoProduto");
        }

        // POST: TipoProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTipoProduto(TipoProduto tipoProduto)
        {
            try
            {
                _tipoProdutoRepository.Salvar(tipoProduto);
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoProdutoController/Edit/5
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

        // GET: TipoProdutoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoProdutoController/Delete/5
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
