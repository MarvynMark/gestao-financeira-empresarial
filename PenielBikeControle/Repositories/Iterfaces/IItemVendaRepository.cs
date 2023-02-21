using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface IItemVendaRepository
    {
        Task Salvar(ItemVenda itemVenda);
    }
}
