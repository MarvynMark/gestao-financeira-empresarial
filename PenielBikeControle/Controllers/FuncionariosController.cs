using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IFuncionarioRepository _funcionarioRepository;
        public FuncionariosController(DataContext dataContext, IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _dataContext = dataContext;
        }

        // GET: VendedoresController
        public ActionResult Index()
        {
            var funcionarios = _funcionarioRepository.GetAll();
            return View("ListaFuncionarios", funcionarios);
        }

        // GET: VendedoresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VendedoresController/Create
        public ActionResult Cadastro()
        {
            return View("CadastroFuncionarios");
        }

        // POST: VendedoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(Funcionario funcionario)
        {
            using (var dtContextTransaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    _funcionarioRepository.Salvar(funcionario);
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

        // GET: VendedoresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VendedoresController/Edit/5
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

        // GET: VendedoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VendedoresController/Delete/5
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
