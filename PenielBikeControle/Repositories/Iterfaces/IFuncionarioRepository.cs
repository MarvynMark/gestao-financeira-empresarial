﻿using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface IFuncionarioRepository
    {
        Task Salvar(Funcionario funcionario);
        Task<IList<Funcionario>> GetAll();
        Task<Funcionario> GetById(int id);
        Task<bool> Remover(int id);
        Task Editar(Funcionario funcionario);
    }
}
