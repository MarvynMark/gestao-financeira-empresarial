using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Mappers.ProdutosCliente
{
    public class ProdutoClienteMapper : Profile
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoClienteRepository _produtoClienteRepository;

        public ProdutoClienteMapper(IClienteRepository clienteRepository, IProdutoClienteRepository produtoClienteRepository)
        {
            _clienteRepository = clienteRepository;
            _produtoClienteRepository = produtoClienteRepository;
        }
        public void Mapper(IMapperConfigurationExpression profile)
        {
            ProdutoClienteToAdicionarProdutoClienteViewModel(profile);
            ProdutoClienteToProdutoClienteViewModel(profile);
        }

        private void ProdutoClienteToAdicionarProdutoClienteViewModel(IMapperConfigurationExpression profile)
        {
            profile.CreateMap<ProdutoCliente, AdicionarProdutoClienteViewModel>()
               .ForMember(dest => dest.Id, map => map.MapFrom(source => source.Id))
               .ForMember(dest => dest.Nome, map => map.MapFrom(source => source.Nome))
               .ForMember(dest => dest.Marca, map => map.MapFrom(source => source.Marca))
               .ForMember(dest => dest.Modelo, map => map.MapFrom(source => source.Modelo))
               .ForMember(dest => dest.Descricao, map => map.MapFrom(source => source.Descricao))
               .ForMember(dest => dest.ClienteId, map => map.MapFrom(source => source.ClienteId))
               .AfterMap((source, dest) => ObterClientes(dest));
        }

        private void ObterClientes(AdicionarProdutoClienteViewModel dest)
        {
            var clientes = _clienteRepository.GetAll().Result;

            var clientesListItem = clientes.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            });

            dest.Clientes = clientesListItem;
        }

        private void ProdutoClienteToProdutoClienteViewModel(IMapperConfigurationExpression profile)
        {
            profile.CreateMap<ProdutoCliente, ProdutoClienteViewModel>()
               .ForPath(dest => dest.ProdutoCliente.Id, map => map.MapFrom(source => source.Id))
               .ForPath(dest => dest.ProdutoCliente.Nome, map => map.MapFrom(source => source.Nome))
               .ForPath(dest => dest.ProdutoCliente.Marca, map => map.MapFrom(source => source.Marca))
               .ForPath(dest => dest.ProdutoCliente.Modelo, map => map.MapFrom(source => source.Modelo))
               .ForPath(dest => dest.ProdutoCliente.Descricao, map => map.MapFrom(source => source.Descricao))
               .ForPath(dest => dest.ProdutoCliente.ClienteId, map => map.MapFrom(source => source.ClienteId))
               .AfterMap((source, dest) => ObterClientesEhProdutos(dest));
        }

        private void ObterClientesEhProdutos(ProdutoClienteViewModel dest)
        {
            var clientes = _clienteRepository.GetAll().Result;
            var produtos = _produtoClienteRepository.GetAll().Result;

            IEnumerable<SelectListItem> clientesListItem = new List<SelectListItem>();

            if (clientes.Any())
            {
                clientesListItem = clientes.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Nome
                });
            }

            dest.ProdutoCliente.Clientes = clientesListItem;
            dest.ProdutosCliente = produtos;
        }

    }
}