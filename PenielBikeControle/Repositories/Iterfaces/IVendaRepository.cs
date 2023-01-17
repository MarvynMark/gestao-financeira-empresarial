using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface IVendaRepository
    {
        Venda Salvar(Venda venda);
        Venda GetById(int id);
    }
}
