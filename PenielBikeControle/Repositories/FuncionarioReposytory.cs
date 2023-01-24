using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class FuncionarioReposytory : IFuncionarioRepository
    {
        private readonly DataContext _context;
        public FuncionarioReposytory(DataContext context) => _context = context;
        
        public void Salvar(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges(); 
        }
        public IList<Funcionario> GetAll()
        {
            var listaDeFuncionarios = _context.Funcionarios.ToList();
            if (listaDeFuncionarios.Any())
                return listaDeFuncionarios;
            else
                return new List<Funcionario>();
        }
        public Funcionario GetById(int id)
        {
            return _context.Funcionarios.SingleOrDefault(x => x.Id == id);
        }
    }
}
