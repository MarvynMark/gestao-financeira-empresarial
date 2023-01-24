﻿using Microsoft.AspNetCore.Mvc;
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
            var vendas = _vendaRepository.GetAll();
            return View("ListaVendas", vendas);
        }

        // GET: VendaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VendaController/Create
        public ActionResult Cadastro()
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
            vendaViewModel.ListaDeFuncionarios = _funcionarioRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            });
            vendaViewModel.ListaProdutosCliente = _produtoClienteRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.Nome}, {x.Marca}, {x.Modelo}"
            });

            return View("CadastroVendas", vendaViewModel);
        }

        // POST: VendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(VendaViewModel vendaViewModel)
        {
            using (var dtContextTransaction = _dataContext.Database.BeginTransaction())
            {
                try
                {
                    Venda venda = new Venda();
                    venda.DescontoTotal = vendaViewModel.Venda.DescontoTotal;
                    venda.FuncionarioId = vendaViewModel.FuncionarioId;
                    venda.ClienteId = vendaViewModel.ClienteId;
                    venda.Data = vendaViewModel.Venda.Data;
                    venda.VendaPaga = vendaViewModel.Venda.VendaPaga;
                    venda.ProdutoEstoqueEntregue = vendaViewModel.Venda.ProdutoEstoqueEntregue;

                    var vendaSalva = _vendaRepository.Salvar(venda);

                    if (vendaSalva != null)
                    {
                        foreach (var item in vendaViewModel.ProtudoEstoqueIds)
                        {
                            var itemVenda = new ItemVenda
                            {
                                ProdutoEstoqueId = int.Parse(item),
                                VendaId = vendaSalva.Id,
                                ProdutoClienteId = vendaViewModel.ProdutoClienteId
                            };
                            _itemVendaRepository.Salvar(itemVenda);
                        }
                    }
                    dtContextTransaction.Commit();
                    return RedirectToAction(nameof(Cadastro));
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
    }
}