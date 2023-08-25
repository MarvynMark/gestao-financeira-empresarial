using AutoMapper;

namespace PenielBikeControle.Mappers.Funcionarios
{
    public class FuncionarioMapperConfiguration : MapperConfiguration
    {
        public FuncionarioMapperConfiguration(FuncionarioMapper mapper) : base(mapper.Mapper)
        {
        }
    }
}
