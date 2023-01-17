using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface ITipoProdutoRepository
    {
        void Salvar(TipoProduto tipoProduto);
        IList<TipoProduto> GetAll();
        TipoProduto GetById(int id);
    }
}
