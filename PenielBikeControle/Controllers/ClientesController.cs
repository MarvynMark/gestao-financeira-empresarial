using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Controllers
{
    public class ClientesController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IClienteRepository _clienteRepository;
        public ClientesController(DataContext dataContext, IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _dataContext = dataContext; 
        }

        // GET: ClienteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View("Cadastro");
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCliente(Cliente cliente)
        {
            using (var dtContextTransaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    _clienteRepository.Salvar(cliente);
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

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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
