using AutoMapper;

namespace PenielBikeControle.Mappers.Vendas
{
    public class VendaMapperConfiguration : MapperConfiguration
    {
        public VendaMapperConfiguration(VendaMapper mapper) : base(mapper.Mapper)
        {
            
        }
    }
}