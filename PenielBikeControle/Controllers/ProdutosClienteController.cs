using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Repositories.Iterfaces;
using PenielBikeControle.Utils;

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
            return View();
        }

        public async Task<ActionResult> Lista()
        {
            var produtosCliente = await _produtoClienteRepository.GetAll();
            return View(produtosCliente);
        }

        // GET: ProdutoClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdutoClienteController/Create
        public async Task<ActionResult> Cadastro()
        {
            ProdutoClienteViewModel produtoClienteViewModel = new ProdutoClienteViewModel();
            var listaClientes = await _clienteRepository.GetAll();
            produtoClienteViewModel.ListaClientes = listaClientes.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            });
            return View(produtoClienteViewModel);
        }

        // POST: ProdutoClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cadastro(ProdutoClienteViewModel produtoClienteViewModel)
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

                    await _produtoClienteRepository.Salvar(produtoCliente);
                    dtContextTransaction.Commit();

                    return RedirectToAction(nameof(Cadastro));
                }
                catch
                {
                    dtContextTransaction.Rollback();
                    return View(nameof(Cadastro));
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

        [HttpDelete]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Remover(int id)
        {
            try
            {
                var result = await _produtoClienteRepository.Remover(id);
                if (result)
                {
                    return ControllerUtils.RetornoJsonResult(true, "Sua venda foi removida com sucesso!");
                }
                else
                {
                    return ControllerUtils.RetornoJsonResult(false, "Venda não removida.");
                }
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }
    }
}
