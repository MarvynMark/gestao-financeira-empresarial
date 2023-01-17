using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface IProdutoEstoqueRepository
    {
        void Salvar(ProdutoEstoque produtoEstoque);
        IList<ProdutoEstoque> GetAll();
        ProdutoEstoque GetById(int id);
    }
}
