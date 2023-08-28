using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface IClienteRepository
    {
        Task Salvar(Cliente cliente);
        Task<IList<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task Remover(int id);
        Task Editar(Cliente cliente);
    }
}
