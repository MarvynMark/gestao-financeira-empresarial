using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface IProdutoClienteRepository
    {
        Task<ProdutoCliente> Salvar(ProdutoCliente produtoCliente);
        Task<ProdutoCliente> GetById(int id);
        Task<IList<ProdutoCliente>> GetAll();
        Task<bool> Remover(int id);
    }
}
