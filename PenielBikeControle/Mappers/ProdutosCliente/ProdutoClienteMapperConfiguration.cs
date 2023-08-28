using AutoMapper;

namespace PenielBikeControle.Mappers.ProdutosCliente
{
    public class ProdutoClienteMapperConfiguration : MapperConfiguration
    {
        public ProdutoClienteMapperConfiguration(ProdutoClienteMapper mapper) : base(mapper.Mapper)
        {
        }
    }
}