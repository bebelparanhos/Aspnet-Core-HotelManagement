using Microsoft.AspNetCore.Mvc;
using App.Web.Models.Entities;
using App.Web.Models.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace App.Web.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
     {
        private readonly IFuncionario _funcionario;

        public FuncionarioController(IFuncionario funcionario)
        {
            _funcionario = funcionario;
        }

        //public IActionResult CadastroUsuario(int id)
        //{

        //    return View(_funcionario.GetUsuario(id));
        //}  

        //public IActionResult CadastrarUsuario(Funcionario usuario)
        //{
        //   _funcionario.SalvaUsuario(usuario);
        //    return RedirectToAction("Login", "Secure");
        //}     
        
        public async Task<IActionResult> ListarFuncionario()
        {
            var dados = await _funcionario.ListaFuncionario();
            return View(dados);
        }

        public IActionResult RemoverFuncionario(Guid id)
        {
            _funcionario.RemoveFuncionario(id);
            return RedirectToAction("ListarFuncionario");
        }

        public IActionResult DetalharFuncionario(Guid id)
        {
            return View(_funcionario.GetFuncionario(id));
        }

        public IActionResult EditarFuncionario(Guid id)
        {
            var usuario = _funcionario.GetFuncionario(id);
            return RedirectToAction("CadastrarFuncionario", "Manager", usuario);
            //return View();
        }

        //public IActionResult AlterarUsuario(Funcionario usuario)
        //{
        //    _funcionario.AlteraUsuario(usuario);
        //    return RedirectToAction("ListarUsuario");
        //}
    }
}