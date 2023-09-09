using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PenielBikeControle.Data;
using PenielBikeControle.Mappers.Vendas;
using PenielBikeControle.Models;
using PenielBikeControle.Models.DTOs.Vendas;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Repositories.Iterfaces;
using PenielBikeControle.Utils;

namespace PenielBikeControle.Controllers
{
    public class VendasController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoEstoqueRepository _produtoEstoqueRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IItemVendaRepository _itemVendaRepository;
        private readonly IProdutoClienteRepository _produtoClienteRepository;
        private readonly VendaMapperConfiguration _mapperConfiguration;


        public VendasController(DataContext dataContext, IVendaRepository vendaRepository, IProdutoEstoqueRepository produtoEstoqueRepository, IClienteRepository clienteRepository, IFuncionarioRepository funcionarioRepository, IItemVendaRepository itemVendaRepository, IProdutoClienteRepository produtoClienteRepository, VendaMapperConfiguration mapperConfiguration)
        {
            _dataContext = dataContext;
            _vendaRepository = vendaRepository;
            _produtoEstoqueRepository = produtoEstoqueRepository;
            _clienteRepository = clienteRepository;
            _funcionarioRepository = funcionarioRepository;
            _itemVendaRepository = itemVendaRepository;
            _produtoClienteRepository = produtoClienteRepository;
            _mapperConfiguration = mapperConfiguration;
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

        // GET: VendaController/Create
        public async Task<ActionResult> Cadastro()
        {
            var vendaViewModel = await PreencheViewModel();
            return View(vendaViewModel);
        }

        // POST: VendaController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(VendaDTO vendaDTO)
        {
            using var dtContextTransaction = _dataContext.Database.BeginTransaction();
            try
            {
                var venda = _mapperConfiguration.CreateMapper().Map<Venda>(vendaDTO);

                var (ehValido, listaDeErros) = ControllerUtils.ValidaModel(venda);
                if (!ehValido)
                {
                    return ControllerUtils.RetornoJsonResult(false, "Dados inválidos!", listaDeErros);
                }

                var itensVenda = _mapperConfiguration.CreateMapper().Map<List<ItemVenda>>(vendaDTO.ItensVenda);
                if (!itensVenda.Any())
                {
                    return ControllerUtils.RetornoJsonResult(false, "Adicione ao menos um produto ao orçamento.");
                }

                var vendaSalva = await _vendaRepository.Salvar(venda);

                if (vendaSalva is not null)
                {
                    foreach (var item in itensVenda)
                    {
                        item.VendaId = vendaSalva.Id;
                        (ehValido, listaDeErros) = ControllerUtils.ValidaModel(item);
                        if (!ehValido)
                        {
                            dtContextTransaction.Rollback();
                            return ControllerUtils.RetornoJsonResult(false, "Dados inválidos!", listaDeErros);
                        }

                        await _itemVendaRepository.Salvar(item);
                    }
                    dtContextTransaction.Commit();
                    return ControllerUtils.RetornoJsonResult(true, "Venda salva com sucesso!");
                }
                else 
                {
                    return ControllerUtils.RetornoJsonResult(false, "Venda não salva.");
                }
            }
            catch (Exception ex)
            {
                dtContextTransaction.Rollback();
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }

        [HttpDelete]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Remover(int id)
        {
            try
            {
                var result = await _vendaRepository.Remover(id);
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

        private async Task<VendaViewModel> PreencheViewModel()
        {
            VendaViewModel vendaViewModel = new()
            {
                ListaDeProdutos = await _produtoEstoqueRepository.GetAll()
            };

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
                Text = $"{x.Nome} - {x.Marca} - {x.Modelo}"
            });

            vendaViewModel.Venda.Data = DateTime.Now;

            return vendaViewModel;
        }

        public async Task<ActionResult> ObterVenda(ObterVendaDTO obterVendaDTO) 
        {
            try
            {
                var venda = await _vendaRepository.GetById(obterVendaDTO.VendaId);

                if (venda is not null)
                {
                    var viewModel = _mapperConfiguration.CreateMapper().Map<VendaVisualizacaoViewModel>(venda);
                    viewModel.ModoEdicao = obterVendaDTO.ModoEdicao;

                    var model = new ModalPadraoCadastroViewModel
                    {
                        ModoEdicao = obterVendaDTO.ModoEdicao,
                        ModoVisualizacao = !obterVendaDTO.ModoEdicao,
                        ParamModel = viewModel,
                        NomePartialView = "_ModalVendaVisualizacao"
                    };
                    return PartialView("_ModalCadastroPadrao", model);
                }

                return ControllerUtils.RetornoJsonResult(false, "Venda não encontrada!");
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }
    }
}
