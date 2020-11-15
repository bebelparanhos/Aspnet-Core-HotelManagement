using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using App.Web.Repositories;
using App.Web.Models.Entities;
using App.Web.Models.Interfaces;
using App.Web.Security;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace App.Web.Business
{
    public class FuncionarioBusiness : BaseRepository<Funcionario>,IFuncionario
    {
        public FuncionarioBusiness(ApplicationContext contexto):base(contexto)
        {
            
        }

        //private string GeraSenha(string senha)
        //{
        //    var hash = new SecurityManager(SHA512.Create());
        //    string _senha = hash.CriptografaSenha(senha);
        //    return _senha;
        //}
        public async Task SalvarFuncionario(Funcionario funcionario)
        {

            if (funcionario.FuncionarioId > 0)
            {

                dbSet.Update(funcionario);
            }
            else
            {
                //usuario.Senha = GeraSenha(usuario.Senha);
                dbSet.Add(funcionario);
            }
            await contexto.SaveChangesAsync();
        }

        //public bool AutenticaUsuario(Funcionario usuario)
        //{
        //    var login = usuario.Login;
        //    var senha = usuario.Senha;

        //    var securityManager = new SecurityManager(SHA512.Create());

        //    var usuarioAtivo = dbSet.Where(u => u.Login == login && u.Ativo == true).FirstOrDefault();

        //    bool valida = false;

        //    if (usuarioAtivo != null)
        //    {
        //        valida = securityManager.ValidaSenha(senha, usuarioAtivo.Senha);
        //    }

        //    return valida;
        //}


        public Funcionario GetFuncionario(Guid id)
        {
            return dbSet.Where(f => f.UsuarioId == id).Include(e => e.Endereco).Include(u => u.Usuario).FirstOrDefault();
        }

        public void AlteraFuncionario(Funcionario usuario)
        {
            var usuarioDb = dbSet.FirstOrDefault(u => u.FuncionarioId == usuario.FuncionarioId);

            if (usuarioDb.FuncionarioId > 0)
            {
                usuarioDb.Nome = usuario.Nome;
                usuarioDb.Email = usuario.Email;
                usuarioDb.DataDeNascimento = usuario.DataDeNascimento;
                usuarioDb.Sexo = usuario.Sexo;
                usuarioDb.CPF = usuario.CPF;

                dbSet.Update(usuarioDb);

                contexto.SaveChanges();
            }

        }

        public void RemoveFuncionario(int id)
        {
            var usuario = dbSet.Find(id);

            if (usuario != null)
            {
                usuario.Ativo = false;
                dbSet.Update(usuario);
                contexto.SaveChanges();
            }
        }

        public async Task<List<Funcionario>> ListaFuncionario()
        {
            return await dbSet.Where(i => i.Ativo == true).OrderBy(i => i.Nome).ToListAsync();
        }

    }
}