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

        public async Task<bool> Remover(int id) 
        {
            var funcionario = await _context.Funcionarios.SingleOrDefaultAsync(x => x.Id == id);

            if (funcionario is not null) 
            {
                funcionario.Removido = true;
                _context.Update(funcionario);
                
                var result = await _context.SaveChangesAsync();

                if (result != 0) 
                {
                    return true;
                }
                else 
                {
                    return false; 
                }
            }
            else 
            {
                return false;
            }
        }

        public async Task Editar(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
        }
    }
}
