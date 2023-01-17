using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface IVendedorRepository
    {
        void Salvar(Vendedor vendedor);
        IList<Vendedor> GetAll();
        Vendedor GetById(int id);
    }
}
