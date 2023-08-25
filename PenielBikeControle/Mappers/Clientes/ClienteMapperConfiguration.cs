using AutoMapper;

namespace PenielBikeControle.Mappers.Clientes
{
    public class ClienteMapperConfiguration : MapperConfiguration
    {
        public ClienteMapperConfiguration(ClienteMapper mapper) : base(mapper.Mapper)
        {
        }
    }
}