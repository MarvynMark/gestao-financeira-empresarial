using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Controllers
{
    public class TipoProdutoEstoqueController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ITipoProdEstoqRepository _tipoProdutoRepository;

        public TipoProdutoEstoqueController(DataContext dataContext, ITipoProdEstoqRepository tipoProdutoRepository)
        {
            _dataContext = dataContext;
            _tipoProdutoRepository = tipoProdutoRepository;
        }

        // GET: TipoProdutoController
        public ActionResult Index()
        {
            return View();
        }

         public ActionResult Lista()
        {
            var tiposProduto = _tipoProdutoRepository.GetAll();
            return View(tiposProduto);
        }

        // GET: TipoProdutoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoProdutoController/Create
        public ActionResult Cadastro()
        {
            return View();
        }

        // POST: TipoProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(TipoProdutoEstoque tipoProduto)
        {
            using (var dtContextTransaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    _tipoProdutoRepository.Salvar(tipoProduto);
                    dtContextTransaction.Commit();
                    return RedirectToAction(nameof(Cadastro));
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
