using Microsoft.EntityFrameworkCore;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class FuncionarioReposytory : IFuncionarioRepository
    {
        private readonly DataContext _context;
        public FuncionarioReposytory(DataContext context) => _context = context;
        
        public async Task Salvar(Funcionario funcionario)
        {
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync(); 
        }
        public async Task<IList<Funcionario>> GetAll()
        {
            var listaDeFuncionarios = await _context.Funcionarios.ToListAsync();
            if (listaDeFuncionarios.Any())
                return listaDeFuncionarios;
            else
                return new List<Funcionario>();
        }
        public async Task<Funcionario> GetById(int id)
        {
            return await _context.Funcionarios.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
