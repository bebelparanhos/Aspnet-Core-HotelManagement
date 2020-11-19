
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Web.Models.Entities;


namespace App.Web.Models.Interfaces{
    public interface IFuncionario
    {
        //bool AutenticaUsuario(Funcionario usuario);
        Task SalvarFuncionario(Funcionario funcionario);
        Task<List<Funcionario>> ListaFuncionario();
       
        void RemoveFuncionario(Guid id);

        Funcionario GetFuncionario(Guid id);
        
    }
}