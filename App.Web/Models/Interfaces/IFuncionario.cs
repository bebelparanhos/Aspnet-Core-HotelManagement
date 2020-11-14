
using System.Collections.Generic;
using App.Web.Models.Entities;


namespace App.Web.Models.Interfaces{
    public interface IFuncionario
    {
        //bool AutenticaUsuario(Funcionario usuario);
        void SalvarFuncionario(Funcionario funcionario);
        IList<Funcionario> ListaFuncionario();
        void AlteraFuncionario(Funcionario funcionario);
        void RemoveFuncionario(int id);

        Funcionario GetFuncionario(int id);
    }
}