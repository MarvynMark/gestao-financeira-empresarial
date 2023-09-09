using AutoMapper;
using PenielBikeControle.Models;
using PenielBikeControle.Models.DTOs.Vendas;
using PenielBikeControle.Models.ViewModels;
using PenielBikeControle.Repositories.Iterfaces;


namespace PenielBikeControle.Mappers.Vendas
{
    public class VendaMapper : Profile
    {
        private readonly IProdutoEstoqueRepository _produtoEstoqueRepository;
        private readonly IItemVendaRepository _itemVendaRepository;

        public VendaMapper(IProdutoEstoqueRepository produtoEstoqueRepository, IItemVendaRepository itemVendaRepository)
        {
            _produtoEstoqueRepository = produtoEstoqueRepository;
            _itemVendaRepository = itemVendaRepository;
        }

        public void Mapper(IMapperConfigurationExpression profile)
        {
            VendaDtoToVenda(profile);
            VendaDtoToItensVenda(profile);
            VendaVisualizacaoViewModelToVenda(profile);
        }

        private static void VendaDtoToVenda(IMapperConfigurationExpression profile)
        {
            profile.CreateMap<VendaDTO, Venda>()
                .ForMember(dest => dest.Data, map => map.MapFrom(source => ObtemData(source.DataVenda)))
                .ForMember(dest => dest.ClienteId, map => map.MapFrom(source => source.ClienteId))
                .ForMember(dest => dest.FuncionarioId, map => map.MapFrom(source => source.FuncionarioId))
                .ForMember(dest => dest.DescontoTotal, map => map.MapFrom(source => source.Desconto))
                .ForMember(dest => dest.VendaPaga, map => map.MapFrom(source => source.VendaPaga))
                .ForMember(dest => dest.ProdutoEstoqueEntregue, map => map.MapFrom(source => source.ProdutoEntregue));
        }

        private void VendaDtoToItensVenda(IMapperConfigurationExpression profile)
        {
            profile.CreateMap<string, ItemVenda>()
                .ForMember(dest => dest.ProdutoEstoqueId, map => map.MapFrom(source => ObtemValorExato(source, 0)))
                .ForMember(dest => dest.Quantidade, map => map.MapFrom(source => ObtemValorExato(source, 1)))
                .ForMember(dest => dest.ProdutoClienteId, map => map.MapFrom(source => ObtemValor(source, 2)))
                .ForMember(dest => dest.ValorVendido, map => map.MapFrom(source => ObtemValorProduto(source)))
                .ForMember(dest => dest.ValorTotal, map => map.MapFrom(source => ObtemValorTotal(source)))
                ;
        }

        private static int? ObtemValor(string source, int index)
        {
            var convertido = int.TryParse(source.Split(';')[index], out int value);
            if (convertido)
            {
                return value;
            }
            else 
            {
                return null;
            }
        }

        private static int ObtemValorExato(string source, int index)
        {
            var convertido = int.TryParse(source.Split(';')[index], out int value);
            if (convertido)
            {
                return value;
            }
            else 
            {
                throw new Exception("Falha ao obter os dados dos produtos");
            }
        }

        private decimal ObtemValorProduto(string source)
        {
            var produtoId = ObtemValorExato(source, 0);
            var produto = _produtoEstoqueRepository.GetById(produtoId).Result;

            return produto.PrecoFinal;
        }

        private decimal ObtemValorTotal(string source)
        {
            var produtoId = ObtemValorExato(source, 0);
            var quantidade = ObtemValorExato(source, 1);

            var produto = _produtoEstoqueRepository.GetById(produtoId).Result;

            return quantidade * (produto.PrecoFinal + produto.PrecoMaoDeObra ?? 0);
        }

        private static DateTime ObtemData(string dataStr)
        {
            _ = DateTime.TryParse(dataStr, out DateTime data);
            return data;
        }

        private void VendaVisualizacaoViewModelToVenda(IMapperConfigurationExpression profile)
        {
            profile.CreateMap<Venda, VendaVisualizacaoViewModel>()
                .ForMember(dest => dest.Funcionario, map => map.MapFrom(source => source.Funcionario.Nome))
                .ForMember(dest => dest.Cliente, map => map.MapFrom(source => source.Cliente.Nome))
                .ForMember(dest => dest.DataDaVenda, map => map.MapFrom(source => source.Data.ToString()))
                .ForMember(dest => dest.VendaPaga, map => map.MapFrom(source => source.VendaPaga))
                .ForMember(dest => dest.ProdutoEntregue, map => map.MapFrom(source => source.ProdutoEstoqueEntregue))
                .ForMember(dest => dest.Desconto, map => map.MapFrom(source => source.DescontoTotal.ToString("C")))
                .AfterMap(AfterMap);
        }

        private void AfterMap(Venda source, VendaVisualizacaoViewModel dest)
        {
            var valorTotalProdutos = source.ItensDaVenda?.Sum(i => i.ValorTotal) ?? 0;
            dest.ValorTotal = (valorTotalProdutos - source.DescontoTotal).ToString("C");

            var itensVendidos = _itemVendaRepository.ObterItensVendidos(source.Id).Result;

            dest.ProdutoDoCliente = itensVendidos?.Select(i => i.ProdutoCliente?.Nome).FirstOrDefault() ?? string.Empty;
            dest.ItensVendidos = itensVendidos;
        }

    }
}