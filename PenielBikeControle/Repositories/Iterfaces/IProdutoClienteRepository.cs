﻿using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface IProdutoClienteRepository
    {
        Task<ProdutoCliente> Salvar(ProdutoCliente produtoCliente);
        Task<ProdutoCliente> GetById(int id);
        Task<IList<ProdutoCliente>> GetAll();
        Task Remover(int id);
        Task Editar(ProdutoCliente produtoCliente);
    }
}
