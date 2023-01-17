using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly IVendedorRepository _vendedorRepository;
        public VendedoresController(IVendedorRepository vendedorRepository)
        {
            _vendedorRepository = vendedorRepository;
        }

        // GET: VendedoresController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VendedoresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VendedoresController/Create
        public ActionResult Create()
        {
            return View("CreateVendedor");
        }

        // POST: VendedoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVendedor(Vendedor vendedor)
        {
            try
            {
                _vendedorRepository.Salvar(vendedor);
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
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
