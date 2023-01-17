using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface IClienteRepository
    {
        void Salvar(Cliente cliente);
        IList<Cliente> GetAll();
        Cliente GetById(int id);
    }
}
