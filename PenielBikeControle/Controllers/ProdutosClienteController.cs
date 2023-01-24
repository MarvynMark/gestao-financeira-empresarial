using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Controllers
{
    public class ProdutosClienteController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IProdutoClienteRepository _produtoClienteRepository;
        private readonly IClienteRepository _clienteRepository;

        public ProdutosClienteController(DataContext dataContext, IProdutoClienteRepository produtoClienteRepository, IClienteRepository clienteRepository)
        {
            _dataContext = dataContext;
            _produtoClienteRepository = produtoClienteRepository;
            _clienteRepository = clienteRepository;
        }


        // GET: ProdutoClienteController
        public ActionResult Index()
        {
            var produtosCliente = _produtoClienteRepository.GetAll();

            return View("ListaProdCli", produtosCliente);
        }

        // GET: ProdutoClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdutoClienteController/Create
        public ActionResult Cadastro()
        {
            ProdutoClienteViewModel produtoClienteViewModel = new ProdutoClienteViewModel();
            produtoClienteViewModel.ListaClientes = _clienteRepository.GetAll().Select(x => new SelectListItem {
                Value = x.Id.ToString(),
                Text = x.Nome
            });
            return View("CadastroProdCli", produtoClienteViewModel);
        }

        // POST: ProdutoClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(ProdutoClienteViewModel produtoClienteViewModel)
        {
            using (var dtContextTransaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    ProdutoCliente produtoCliente = new ProdutoCliente();
                    produtoCliente.Descricao = produtoClienteViewModel.ProdutoCliente.Descricao;
                    produtoCliente.Modelo = produtoClienteViewModel.ProdutoCliente.Modelo;
                    produtoCliente.Marca = produtoClienteViewModel.ProdutoCliente.Marca;
                    produtoCliente.Nome = produtoClienteViewModel.ProdutoCliente.Nome;
                    produtoCliente.ClienteId = produtoClienteViewModel.ClienteId;

                    _produtoClienteRepository.Salvar(produtoCliente);
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

        // GET: ProdutoClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutoClienteController/Edit/5
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

        // GET: ProdutoClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdutoClienteController/Delete/5
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
