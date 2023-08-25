using AutoMapper;
using PenielBikeControle.Models;
using PenielBikeControle.Models.ViewModels;

namespace PenielBikeControle.Mappers.Funcionarios
{
    public class FuncionarioMapper : Profile
    {
        public void Mapper(IMapperConfigurationExpression profile)
        {
            AdicionarFuncionarioViewModelToFuncionario(profile);
            FuncionarioToAdicionarFuncionarioViewModel(profile);
        }

        private static void AdicionarFuncionarioViewModelToFuncionario(IMapperConfigurationExpression profile)
        {
            profile.CreateMap<AdicionarFuncionarioViewModel, Funcionario>()
                .ForMember(dest => dest.Id, map => map.MapFrom(source => source.Id))
                .ForMember(dest => dest.Nome, map => map.MapFrom(source => source.Nome))
                .ForMember(dest => dest.Cpf, map => map.MapFrom(source => source.Cpf))
                .ForMember(dest => dest.Endereco, map => map.MapFrom(source => source.Endereco))
                .ForMember(dest => dest.DataDeNascimento, map => map.MapFrom(source => ConverterData(source.DataDeNascimentoStr)));
        }

        private static DateOnly ConverterData(string dataStr)
        {
            _ = DateOnly.TryParse(dataStr, out DateOnly data);
            return data;
        }

        private static void FuncionarioToAdicionarFuncionarioViewModel(IMapperConfigurationExpression profile)
        {
            profile.CreateMap<Funcionario, AdicionarFuncionarioViewModel>()
                .ForMember(dest => dest.Id, map => map.MapFrom(source => source.Id))
                .ForMember(dest => dest.Nome, map => map.MapFrom(source => source.Nome))
                .ForMember(dest => dest.Cpf, map => map.MapFrom(source => source.Cpf))
                .ForMember(dest => dest.Endereco, map => map.MapFrom(source => source.Endereco))
                .ForMember(dest => dest.DataDeNascimentoStr, map => map.MapFrom(source => source.DataDeNascimento.ToString("yyyy-MM-dd")));
        }
    }
}
