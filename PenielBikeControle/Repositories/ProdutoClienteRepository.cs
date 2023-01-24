using Microsoft.EntityFrameworkCore;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class ProdutoClienteRepository : IProdutoClienteRepository
    {
        private readonly DataContext _dataContext;

        public ProdutoClienteRepository(DataContext dataContext) => _dataContext = dataContext;        

        public ProdutoCliente Salvar(ProdutoCliente clienteProduto)
        {
            _dataContext.ProdutosCliente.Add(clienteProduto);
            _dataContext.SaveChanges();
            return clienteProduto;
        }
        public ProdutoCliente GetById(int id)
        {
            return _dataContext.ProdutosCliente.Include(x => x.Cliente).SingleOrDefault(x => x.Id == id);
        }
        public IList<ProdutoCliente> GetAll()
        {
            return _dataContext.ProdutosCliente.Include(x => x.Cliente).ToList();
        }
    }
}
