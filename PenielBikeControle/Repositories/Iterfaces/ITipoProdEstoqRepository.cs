using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface ITipoProdEstoqRepository
    {
        void Salvar(TipoProdutoEstoque tipoProduto);
        IList<TipoProdutoEstoque> GetAll();
        TipoProdutoEstoque GetById(int id);
    }
}
