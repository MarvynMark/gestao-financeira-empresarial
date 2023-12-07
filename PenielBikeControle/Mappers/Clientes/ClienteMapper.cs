using AutoMapper;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;

namespace PenielBikeControle.Mappers.Clientes
{
    public class ClienteMapper : Profile
    {
        public void Mapper(IMapperConfigurationExpression profile)
        {
            AdicionarClienteViewModelToCliente(profile);
            ClienteToAdicionarClienteViewMode(profile);
        }

        private static void AdicionarClienteViewModelToCliente(IMapperConfigurationExpression profile)
        {
            profile.CreateMap<AdicionarClienteViewModel, Cliente>()
                .ForMember(dest => dest.Id, map => map.MapFrom(source => source.Id))
                .ForMember(dest => dest.Nome, map => map.MapFrom(source => source.Nome))
                .ForMember(dest => dest.Cpf, map => map.MapFrom(source => source.Cpf))
                .ForMember(dest => dest.Telefone, map => map.MapFrom(source => source.Telefone))
                .ForMember(dest => dest.Endereco, map => map.MapFrom(source => source.Endereco))
                .ForMember(dest => dest.DataDeNascimento, map => map.MapFrom(source => ConverterData(source.DataDeNascimentoStr)));
        }

        private static object ConverterData(string dataStr)
        {
             _ = DateOnly.TryParse(dataStr, out DateOnly data);
            return data;
        }

        private static void ClienteToAdicionarClienteViewMode(IMapperConfigurationExpression profile)
        {
            profile.CreateMap<Cliente, AdicionarClienteViewModel>()
                .ForMember(dest => dest.Id, map => map.MapFrom(source => source.Id))
                .ForMember(dest => dest.Nome, map => map.MapFrom(source => source.Nome))
                .ForMember(dest => dest.Cpf, map => map.MapFrom(source => source.Cpf))
                .ForMember(dest => dest.Telefone, map => map.MapFrom(source => source.Telefone))
                .ForMember(dest => dest.Endereco, map => map.MapFrom(source => source.Endereco))
                .ForMember(dest => dest.DataDeNascimentoStr, map => map.MapFrom(source => source.DataDeNascimento.ToString("yyyy-MM-dd")));
        }
    }
}