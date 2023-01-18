using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Repositories;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Controllers
{
    public class VendasController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoEstoqueRepository _protudoEstoqueRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IItemVendaRepository _itemVendaRepository;

        public VendasController(DataContext dataContext, IVendaRepository vendaRepository, IProdutoEstoqueRepository protudoEstoqueRepository, IClienteRepository clienteRepository, IVendedorRepository vendedorRepository, IItemVendaRepository itemVendaRepository)
        {
            _dataContext = dataContext;
            _vendaRepository = vendaRepository;
            _protudoEstoqueRepository = protudoEstoqueRepository;
            _clienteRepository = clienteRepository;
            _vendedorRepository = vendedorRepository;
            _itemVendaRepository = itemVendaRepository;
        }


        // GET: VendaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VendaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VendaController/Create
        public ActionResult Create()
        {
            VendaViewModel vendaViewModel = new VendaViewModel();
            
            vendaViewModel.ListaDeProdutos = _protudoEstoqueRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.Nome} - {x.Modelo} - {x.Descricao}"
            });
            vendaViewModel.ListaDeClientes = _clienteRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            });
            vendaViewModel.ListaDeVendedores = _vendedorRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            });

            return View("CadastroDeVendas", vendaViewModel);
        }

        // POST: VendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendaViewModel vendaViewModel)
        {
            using (var dtContextTransaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    Venda venda = new Venda();
                    venda.DescontoTotal = vendaViewModel.Venda.DescontoTotal;
                    venda.VendedorId = vendaViewModel.VendedorId;
                    venda.ClienteId = vendaViewModel.ClienteId;
                    venda.Data = vendaViewModel.Venda.Data;
                    venda.DescontoTotal = vendaViewModel.Venda.DescontoTotal;

                    var vendaSalva = _vendaRepository.Salvar(venda);

                    if (vendaSalva != null)
                    {
                        foreach (var item in vendaViewModel.ProtudoEstoqueIds)
                        {
                            var itemVenda = new ItemVenda
                            {
                                ProdutoEstoqueId = int.Parse(item),
                                VendaId = vendaSalva.Id
                            };
                            _itemVendaRepository.Salvar(itemVenda);
                        }
                    }
                    dtContextTransaction.Commit();
                    return RedirectToAction(nameof(Create));
                }
                catch (Exception e)
                {
                    dtContextTransaction.Rollback();
                    return View();
                }
            }
        }

        // GET: VendaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VendaController/Edit/5
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

        // GET: VendaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VendaController/Delete/5
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

        
        public ActionResult Cadastro()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }
            
        }
    }
}
