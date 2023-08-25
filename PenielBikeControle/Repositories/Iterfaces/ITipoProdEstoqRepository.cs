using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface ITipoProdEstoqRepository
    {
        Task<TipoProdutoEstoque> Salvar(TipoProdutoEstoque tipoProduto);
        Task<IList<TipoProdutoEstoque>> GetAll();
        Task<TipoProdutoEstoque> GetById(int id);
        Task<bool> Remover(int id);
        Task Editar(TipoProdutoEstoque tipoProduto);
    }
}
