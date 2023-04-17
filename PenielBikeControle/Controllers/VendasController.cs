using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Repositories.Iterfaces;


namespace PenielBikeControle.Controllers
{
    public class VendasController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoEstoqueRepository _protudoEstoqueRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IItemVendaRepository _itemVendaRepository;
        private readonly IProdutoClienteRepository _produtoClienteRepository;


        public VendasController(DataContext dataContext, IVendaRepository vendaRepository, IProdutoEstoqueRepository protudoEstoqueRepository, IClienteRepository clienteRepository, IFuncionarioRepository funcionarioRepository, IItemVendaRepository itemVendaRepository, IProdutoClienteRepository produtoClienteRepository)
        {
            _dataContext = dataContext;
            _vendaRepository = vendaRepository;
            _protudoEstoqueRepository = protudoEstoqueRepository;
            _clienteRepository = clienteRepository;
            _funcionarioRepository = funcionarioRepository;
            _itemVendaRepository = itemVendaRepository;
            _produtoClienteRepository = produtoClienteRepository;
        }


        // GET: VendaController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Lista()
        {
            try
            {
                var vendas = await _vendaRepository.GetAll();
                return View(vendas);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // GET: VendaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VendaController/Create
        public async Task<ActionResult> Cadastro()
        {
            var vendaViewModel = await PreencheViewModel();
            return View(vendaViewModel);
        }

        // POST: VendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cadastro(VendaViewModel vendaViewModel)
        {
            // TODO: Criar validação de dados
            //if (!ModelState.IsValid) 
            //{
            //    return View(await PreencheViewModel());
            //}
            using (var dtContextTransaction = _dataContext.Database.BeginTransaction())
            {
                try 
                {
                    decimal descontoTotal = 0;
                    Venda venda = new Venda();
                    venda.DescontoTotal = vendaViewModel.Venda.DescontoTotal;
                    venda.FuncionarioId = vendaViewModel.FuncionarioId;
                    venda.ClienteId = vendaViewModel.ClienteId;
                    venda.Data = vendaViewModel.Venda.Data;
                    venda.VendaPaga = vendaViewModel.Venda.VendaPaga;
                    venda.ProdutoEstoqueEntregue = vendaViewModel.Venda.ProdutoEstoqueEntregue;

                    if (!String.IsNullOrEmpty(vendaViewModel.DescontoTotal))
                    {
                        decimal.TryParse(vendaViewModel.DescontoTotal, out descontoTotal);
                        venda.DescontoTotal = descontoTotal;
                    }

                    var vendaSalva = await _vendaRepository.Salvar(venda);

                    if (vendaSalva != null)
                    {
                        foreach (var item in vendaViewModel.QtdeProdutosInput)
                        {
                            var prodQtde = int.Parse(item.Split(';')[0]);
                            var prodId = int.Parse(item.Split(';')[1]);
                            var produtoVendido = await _protudoEstoqueRepository.GetById(prodId);
                            if (produtoVendido != null)
                            {
                                var itemVenda = new ItemVenda
                                {
                                    ProdutoEstoqueId = prodId,
                                    VendaId = vendaSalva.Id,
                                    ProdutoClienteId = vendaViewModel.ProdutoClienteId,
                                    Quantidade = prodQtde,
                                    ValorVendido = produtoVendido.PrecoFinal
                                };
                                await _itemVendaRepository.Salvar(itemVenda);
                            }
                        }
                    }
                    dtContextTransaction.Commit();
                    return RedirectToAction(nameof(Cadastro));
                }
                catch (Exception e)
                {
                    dtContextTransaction.Rollback();
                    // TODO: Tratar erro personalizado
                    return RedirectToAction(nameof(Cadastro));
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

        private async Task<VendaViewModel> PreencheViewModel()
        {
            VendaViewModel vendaViewModel = new VendaViewModel();
            
            vendaViewModel.ListaDeProdutos = await _protudoEstoqueRepository.GetAll();
            var listaClientes = await _clienteRepository.GetAll();
            vendaViewModel.ListaDeClientes = listaClientes.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            });
            var listaFuncionarios = await _funcionarioRepository.GetAll();
            vendaViewModel.ListaDeFuncionarios = listaFuncionarios.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            });
            var listaProdutosCliente = await _produtoClienteRepository.GetAll();
            vendaViewModel.ListaProdutosCliente = listaProdutosCliente.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.Nome}, {x.Marca}, {x.Modelo}"
            });

            vendaViewModel.Venda.Data = DateTime.Now;

            return vendaViewModel;
        }
    }
}
