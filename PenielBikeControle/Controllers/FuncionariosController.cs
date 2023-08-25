using Microsoft.AspNetCore.Mvc;
using PenielBikeControle.Data;
using PenielBikeControle.Mappers.Funcionarios;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Repositories.Iterfaces;
using PenielBikeControle.Utils;

namespace PenielBikeControle.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly FuncionarioMapperConfiguration _mapperConfiguration;
        public FuncionariosController(DataContext dataContext, IFuncionarioRepository funcionarioRepository, FuncionarioMapperConfiguration mapperConfiguration)
        {
            _funcionarioRepository = funcionarioRepository;
            _dataContext = dataContext;
            _mapperConfiguration = mapperConfiguration;
        }

        // GET: VendedoresController
        public async Task<ActionResult> Index()
        {
            var funcionarios = await _funcionarioRepository.GetAll();

            var funcionarioViewModel = new FuncionarioViewModel(funcionarios, new AdicionarFuncionarioViewModel());

            return View(funcionarioViewModel);
        }

        // POST: VendedoresController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(AdicionarFuncionarioViewModel funcionarioViewModel)
        {
            using var dtContextTransaction = _dataContext.Database.BeginTransaction();
            try
            {
                var funcionario = _mapperConfiguration.CreateMapper().Map<Funcionario>(funcionarioViewModel);

                var (EhValido, ListaDeErros) = ControllerUtils.ValidaModel(funcionario);
                if (!EhValido)
                {
                    return ControllerUtils.RetornoJsonResult(false, "Dados inválidos!", ListaDeErros);
                }

                if (funcionario.Id == 0) 
                {
                    await _funcionarioRepository.Salvar(funcionario);
                }
                else 
                {
                    await _funcionarioRepository.Editar(funcionario);
                }
                
                dtContextTransaction.Commit();
                return ControllerUtils.RetornoJsonResult(true, "Funcionário salvo com sucesso!");
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
                var result = await _funcionarioRepository.Remover(id);
                if (result)
                {
                    return ControllerUtils.RetornoJsonResult(true, "Funcionário foi removido com sucesso!");
                }
                else
                {
                    return ControllerUtils.RetornoJsonResult(false, "Funcioário não removido.");
                }
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }

        
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> ObterFuncionarioEdicao(int id)
        {
            try
            {
                var funcionario = await _funcionarioRepository.GetById(id);

                if (funcionario is not null)
                {
                    var viewModel = _mapperConfiguration.CreateMapper().Map<AdicionarFuncionarioViewModel>(funcionario);

                    var model = new ModalPadraoCadastroViewModel
                    {
                        ModoEdicao = true,
                        ParamModel = viewModel,
                        NomePartialView = "_ModalFuncionario"
                    };
                    return PartialView("_ModalCadastroPadrao", model);
                }

                return ControllerUtils.RetornoJsonResult(false, "Funcionário não encontrado");
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }
    }
}
