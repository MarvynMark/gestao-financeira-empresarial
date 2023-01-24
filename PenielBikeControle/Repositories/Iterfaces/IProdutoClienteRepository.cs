using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface IProdutoClienteRepository
    {
        ProdutoCliente Salvar(ProdutoCliente produtoCliente);
        ProdutoCliente GetById(int id);
        IList<ProdutoCliente> GetAll();
    }
}
