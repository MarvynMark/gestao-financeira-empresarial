using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface IProdutoEstoqueRepository
    {
        Task Salvar(ProdutoEstoque produtoEstoque);
        Task<IList<ProdutoEstoque>> GetAll();
        Task<ProdutoEstoque> GetById(int id);
        Task Editar(ProdutoEstoque produto);
        Task<bool> Remover(int id);
    }
}
