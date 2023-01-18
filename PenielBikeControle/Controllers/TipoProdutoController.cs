using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Controllers
{
    public class TipoProdutoController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ITipoProdutoRepository _tipoProdutoRepository;

        public TipoProdutoController(DataContext dataContext, ITipoProdutoRepository tipoProdutoRepository)
        {
            _dataContext = dataContext;
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
            using (var dtContextTransaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    _tipoProdutoRepository.Salvar(tipoProduto);
                    dtContextTransaction.Commit();
                    return RedirectToAction(nameof(Create));
                }
                catch
                {
                    dtContextTransaction.Rollback();
                    return View();
                }
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
