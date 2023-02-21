using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface ITipoProdEstoqRepository
    {
        Task Salvar(TipoProdutoEstoque tipoProduto);
        Task<IList<TipoProdutoEstoque>> GetAll();
        Task<TipoProdutoEstoque> GetById(int id);
    }
}
