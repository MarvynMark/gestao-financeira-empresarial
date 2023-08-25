using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenielBikeControle.Data;
using PenielBikeControle.Mappers.Clientes;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Repositories.Iterfaces;
using PenielBikeControle.Utils;

namespace PenielBikeControle.Controllers
{
    public class ClientesController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IClienteRepository _clienteRepository;
        private readonly ClienteMapperConfiguration _mapperConfiguration;
        public ClientesController(DataContext dataContext, IClienteRepository clienteRepository, ClienteMapperConfiguration mapperConfiguration)
        {
            _clienteRepository = clienteRepository;
            _dataContext = dataContext;
            _mapperConfiguration = mapperConfiguration;
        }

        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            var clientes = await _clienteRepository.GetAll();

            var clienteViewModel = new ClienteViewModel(clientes, new AdicionarClienteViewModel());

            return View(clienteViewModel);
        }

        // POST: ClienteController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(AdicionarClienteViewModel model)
        {
            try
            {
                var cliente = _mapperConfiguration.CreateMapper().Map<Cliente>(model);

                var (EhValido, ListaDeErros) = ControllerUtils.ValidaModel(cliente);
                if (!EhValido)
                {
                    return ControllerUtils.RetornoJsonResult(false, "Dados inválidos!", ListaDeErros);
                }

                if (cliente.Id == 0) 
                {
                    await _clienteRepository.Salvar(cliente);
                }
                else 
                {
                    await _clienteRepository.Editar(cliente);
                }
                
                return ControllerUtils.RetornoJsonResult(true, "Cliente salvo com sucesso!");
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }

        [HttpDelete]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Remover(int id)
        {
            try
            {
                var result = await _clienteRepository.Remover(id);
                if (result)
                {
                    return ControllerUtils.RetornoJsonResult(true, "Seu cliente foi removido com sucesso!");
                }
                else
                {
                    return ControllerUtils.RetornoJsonResult(false, "Cliente não removido.");
                }
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> ObterClienteEdicao(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetById(id);

                if (cliente is not null)
                {
                    var viewModel = _mapperConfiguration.CreateMapper().Map<AdicionarClienteViewModel>(cliente);

                    var model = new ModalPadraoCadastroViewModel
                    {
                        ModoEdicao = true,
                        ParamModel = viewModel,
                        NomePartialView = "_ModalCliente"
                    };
                    return PartialView("_ModalCadastroPadrao", model);
                }

                return ControllerUtils.RetornoJsonResult(false, "Cliente não encontrado");
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }
    }
}
