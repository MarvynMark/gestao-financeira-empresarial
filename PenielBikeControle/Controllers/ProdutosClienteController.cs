using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PenielBikeControle.Data;
using PenielBikeControle.Mappers.ProdutosCliente;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Repositories.Iterfaces;
using PenielBikeControle.Utils;

namespace PenielBikeControle.Controllers
{
    public class ProdutosClienteController : Controller
    {
        private readonly IProdutoClienteRepository _produtoClienteRepository;
        private readonly ProdutoClienteMapperConfiguration _mapperConfiguration;

        public ProdutosClienteController(IProdutoClienteRepository produtoClienteRepository, ProdutoClienteMapperConfiguration mapperConfiguration)
        {
            _produtoClienteRepository = produtoClienteRepository;
            _mapperConfiguration = mapperConfiguration;
        }

        public ActionResult Index()
        {
            var produtoClienteViewModel = _mapperConfiguration.CreateMapper().Map<ProdutoClienteViewModel>(new ProdutoCliente());
            return View(produtoClienteViewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(ProdutoCliente produtoCliente)
        {
            try
            {
                var (ehValido, listaDeErros) = ControllerUtils.ValidaModel(produtoCliente);
                if (!ehValido)
                {
                    return ControllerUtils.RetornoJsonResult(false, "Dados inválidos!", listaDeErros);
                }

                if (produtoCliente.Id == 0) 
                {
                    await _produtoClienteRepository.Salvar(produtoCliente);
                } 
                else 
                {
                    await _produtoClienteRepository.Editar(produtoCliente);
                }

                return ControllerUtils.RetornoJsonResult(true, "Produto do Cliente salvo com sucesso!");
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
                await _produtoClienteRepository.Remover(id);
                return ControllerUtils.RetornoJsonResult(true, "Sua venda foi removida com sucesso!");
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> ObterProdutoClienteEdicao(int id)
        {
            try
            {
                var produtoCliente = await _produtoClienteRepository.GetById(id);

                if (produtoCliente is not null)
                {
                    var viewModel = _mapperConfiguration.CreateMapper().Map<AdicionarProdutoClienteViewModel>(produtoCliente);

                    var model = new ModalPadraoCadastroViewModel
                    {
                        ModoEdicao = true,
                        ParamModel = viewModel,
                        NomePartialView = "_ModalProdutoCliente"
                    };
                    return PartialView("_ModalCadastroPadrao", model);
                }

                return ControllerUtils.RetornoJsonResult(false, "Produto do cliente não encontrado");
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }
    }
}
