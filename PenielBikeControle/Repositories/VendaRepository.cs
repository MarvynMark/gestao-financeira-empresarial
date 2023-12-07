using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using PenielBikeControle.Data;
using PenielBikeControle.Models;
using PenielBikeControle.Models.DTOs.Vendas;
using PenielBikeControle.Repositories.Iterfaces;

namespace PenielBikeControle.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DataContext _context;
        public VendaRepository(DataContext context) => _context = context;

        public async Task<Venda> Salvar(Venda venda)
        {
            await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task<IList<Venda>> GetAll()
        {
            var vendas = await _context.Vendas.Include(c => c.Cliente).Include(v => v.Funcionario).Include(i => i.ItensDaVenda).ToListAsync();
            if (vendas.Any())
                return vendas;
            else
                return new List<Venda>();
        }

        public async Task<Venda> GetById(int id)
        {
            return await _context.Vendas.Include(x => x.Funcionario).Include(c => c.Cliente).Include(i => i.ItensDaVenda).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Remover(int id) 
        {
            var venda = await _context.Vendas.SingleOrDefaultAsync(x => x.Id == id);

            if (venda is not null) 
            {
                venda.Removido = true;
                _context.Update(venda);
                
                var result = await _context.SaveChangesAsync();

                return result != 0;
            }
            else 
            {
                return false;
            }
        }

        public async Task<bool> Editar(EdicaoVendaDTO edicaoVendaDTO)
        {
            var venda = await _context.Vendas.SingleOrDefaultAsync(x => x.Id == edicaoVendaDTO.VendaId);

            if (venda is not null) 
            {
                venda.VendaPaga = edicaoVendaDTO.VendaPaga;
                venda.ProdutoEstoqueEntregue = edicaoVendaDTO.ProdutoEntregue;
                venda.Data = edicaoVendaDTO.DataDaVenda;
                venda.DescontoTotal = edicaoVendaDTO.Desconto;

                _context.Update(venda);
                var result = await _context.SaveChangesAsync();

                return result != 0;
            }
            else
            {
                return false;
            }   
        }
    }
}
