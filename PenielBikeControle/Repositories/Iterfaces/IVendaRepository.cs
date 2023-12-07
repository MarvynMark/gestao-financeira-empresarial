using PenielBikeControle.Models;
using PenielBikeControle.Models.DTOs.Vendas;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface IVendaRepository
    {
        Task<Venda> Salvar(Venda venda);
        Task<Venda> GetById(int id);
        Task<IList<Venda>> GetAll();
        Task<bool> Remover(int id);
        Task<bool> Editar(EdicaoVendaDTO edicaoVendaDTO);
    }
}
