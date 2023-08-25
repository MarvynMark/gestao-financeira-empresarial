using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Repositories.Iterfaces;
using PenielBikeControle.Utils;

namespace PenielBikeControle.Controllers
{
    public class TipoProdutoEstoqueController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ITipoProdEstoqRepository _tipoProdutoRepository;

        public TipoProdutoEstoqueController(DataContext dataContext, ITipoProdEstoqRepository tipoProdutoRepository)
        {
            _dataContext = dataContext;
            _tipoProdutoRepository = tipoProdutoRepository;
        }

        // GET: TipoProdutoController
        public async Task<ActionResult> Index()
        {
            var tiposDeProdutos = await _tipoProdutoRepository.GetAll();
            var viewModel = new TipoProdutoViewModel(tiposDeProdutos, new TipoProdutoEstoque());

            return View(viewModel);
        }

        // POST: TipoProdutoController/Create
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<JsonResult> Salvar(TipoProdutoEstoque tipoProduto)
        {
            
            try
            {
                if (tipoProduto is not null && !String.IsNullOrEmpty(tipoProduto.Descricao))
                {
                    
                    if (tipoProduto.Id == 0) 
                    {
                        await _tipoProdutoRepository.Salvar(tipoProduto);
                    }
                    else 
                    {
                        await _tipoProdutoRepository.Editar(tipoProduto);
                    }

            
                    return ControllerUtils.RetornoJsonResult(true, "Tipo de Produto salvo com sucesso!");
                }
                else
                {
                    return ControllerUtils.RetornoJsonResult(false, "Informe a descrição do Tipo do Produto.");
                }
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
                var result = await _tipoProdutoRepository.Remover(id);
                if (result)
                {
                    return ControllerUtils.RetornoJsonResult(true, "Tipo de Produto foi removido com sucesso!");
                }
                else
                {
                    return ControllerUtils.RetornoJsonResult(false, "Tipo de Produto não removido.");
                }
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> ObterTipoProdutoEdicao(int id)
        {
            try
            {
                var tipoProduto = await _tipoProdutoRepository.GetById(id);

                if (tipoProduto is not null)
                {
                    var model = new ModalPadraoCadastroViewModel
                    {
                        ModoEdicao = true,
                        ParamModel = tipoProduto,
                        NomePartialView = "_ModalTipoProduto"
                    };
                    return PartialView("_ModalCadastroPadrao", model);
                }

                return ControllerUtils.RetornoJsonResult(false, "Tipo de Produto não encontrado");
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }
    }
}
