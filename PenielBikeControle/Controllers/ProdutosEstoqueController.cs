using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Repositories.Iterfaces;
using PenielBikeControle.Utils;

namespace PenielBikeControle.Controllers
{
    public class ProdutosEstoqueController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IProdutoEstoqueRepository _produtoEstoqueReposirory;
        private readonly ITipoProdEstoqRepository _tipoProdutoEstoqueRepository;
        public ProdutosEstoqueController(DataContext dataContext, IProdutoEstoqueRepository produtoEstoqueRepository, ITipoProdEstoqRepository tipoProdutoRepository)
        {
            _produtoEstoqueReposirory = produtoEstoqueRepository;
            _tipoProdutoEstoqueRepository = tipoProdutoRepository;
            _dataContext = dataContext;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                ProdutoEstoqueViewModel produtoEstoqueViewModel = new()
                {
                    Produto = new ProdutoEstoque(),
                    ListaDeProdutos = await _produtoEstoqueReposirory.GetAll()
                };

                var listaTipoProdutos = await _tipoProdutoEstoqueRepository.GetAll();

                produtoEstoqueViewModel.ListaTiposDeProduto = listaTipoProdutos.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Descricao
                });

                return View(produtoEstoqueViewModel);
            }
            catch (Exception ex)
            {
                // TODO: Retornar página de erro.
                throw;
            }   
        }

        public async Task<ActionResult> Lista()
        {
            var produtos = await _produtoEstoqueReposirory.GetAll();
            return View(produtos);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<ActionResult> Cadastro()
        {
            ProdutoEstoqueViewModel produtoEstoqueViewModel = new()
            {
                Produto = new ProdutoEstoque()
            };
            var listaDeProdutos = await _tipoProdutoEstoqueRepository.GetAll();
            produtoEstoqueViewModel.ListaTiposDeProduto = listaDeProdutos.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Descricao
            });


            return View(produtoEstoqueViewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Cadastro(ProdutoEstoqueViewModel produtoEstoqueViewModel)
        {
            var (EhValido, ListaDeErros) = ControllerUtils.ValidaModel(produtoEstoqueViewModel);
            if (!EhValido)
            {
                return ControllerUtils.RetornoJsonResult(false, "Dados inválidos!", ListaDeErros);
            }

            using var dtContexTransaction = _dataContext.Database.BeginTransaction();
            try
            {
                ProdutoEstoque produtoEstoque = new()
                {
                    Descricao = produtoEstoqueViewModel.Produto.Descricao,
                    TipoProdutoId = produtoEstoqueViewModel.TipoDeProdutoId,
                    PrecoCusto = produtoEstoqueViewModel.Produto.PrecoCusto,
                    PrecoMaoDeObra = produtoEstoqueViewModel.Produto.PrecoMaoDeObra,
                    PrecoFinal = produtoEstoqueViewModel.Produto.PrecoFinal,
                    Modelo = produtoEstoqueViewModel.Produto.Modelo,
                    Marca = produtoEstoqueViewModel.Produto.Marca,
                    Nome = produtoEstoqueViewModel.Produto.Nome,
                    QtdeEmEstoque = produtoEstoqueViewModel.Produto.QtdeEmEstoque
                };

                await _produtoEstoqueReposirory.Salvar(produtoEstoque);
                dtContexTransaction.Commit();

                return ControllerUtils.RetornoJsonResult(true, "Produto salvo com sucesso!");
            }
            catch (Exception ex)
            {
                dtContexTransaction.Rollback();
                return ControllerUtils.RetornoJsonResult(false, ex.Message);
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Editar(ProdutoEstoqueViewModel produtoEstoqueViewModel)
        {
            try
            {
                if (produtoEstoqueViewModel.Produto.Id > 0)
                {
                    var produto = new ProdutoEstoque
                    {
                        Id = produtoEstoqueViewModel.Produto.Id,
                        Nome = produtoEstoqueViewModel.Produto.Nome,
                        Descricao = produtoEstoqueViewModel.Produto.Descricao,
                        Marca = produtoEstoqueViewModel.Produto.Marca,
                        Modelo = produtoEstoqueViewModel.Produto.Modelo,
                        PrecoCusto = produtoEstoqueViewModel.Produto.PrecoCusto,
                        PrecoFinal = produtoEstoqueViewModel.Produto.PrecoFinal,
                        PrecoMaoDeObra = produtoEstoqueViewModel.Produto.PrecoMaoDeObra,
                        QtdeEmEstoque = produtoEstoqueViewModel.Produto.QtdeEmEstoque,
                        TipoProdutoId = produtoEstoqueViewModel.TipoDeProdutoId
                    };

                    await _produtoEstoqueReposirory.Editar(produto);

                    return ControllerUtils.RetornoJsonResult(true, "Produto salvo com sucesso!");
                }
                else
                {
                    return ControllerUtils.RetornoJsonResult(false, "Produto não encontrado!");
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
                var result = await _produtoEstoqueReposirory.Remover(id);
                if (result)
                {
                    return ControllerUtils.RetornoJsonResult(true, "Seu produto foi removido com sucesso!");
                }
                else
                {
                    return ControllerUtils.RetornoJsonResult(false, "Produto não removido.");
                }
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> ObterProdutoEdicao(int id)
        {
            try
            {
                var produto = await _produtoEstoqueReposirory.GetById(id);

                if (produto is not null)
                {
                    var listaProdutos = await _produtoEstoqueReposirory.GetAll();
                    var listaTiposProdutos = _tipoProdutoEstoqueRepository.GetAll().Result.Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Descricao,
                        Selected = produto.TipoProdutoId == x.Id
                    });

                    var viewModel = new ProdutoEstoqueViewModel
                    {
                        Produto = produto,
                        ListaDeProdutos = listaProdutos,
                        ListaTiposDeProduto = listaTiposProdutos,
                        TipoDeProdutoId = produto.TipoProdutoId
                    };

                    var model = new ModalPadraoCadastroViewModel
                    {
                        ModoEdicao = true,
                        ParamModel = viewModel,
                        NomePartialView = "_ModalProduto"
                    };
                    return PartialView("_ModalCadastroPadrao", model);
                }

                return ControllerUtils.RetornoJsonResult(false, "Produto não encontrado");
            }
            catch (Exception ex)
            {
                return ControllerUtils.RetornoJsonResult(ex);
            }
        }
    }
}
