using Microsoft.AspNetCore.Mvc;
using App.Web.Models.Entities;
using App.Web.Models.Interfaces;

namespace App.Web.Controllers
{
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

        public IActionResult ListarFuncionario()
        {
            return View(_funcionario.ListaFuncionario());
        }

        public IActionResult RemoverFuncionario(int id)
        {
            _funcionario.RemoveFuncionario(id);
            return RedirectToAction("ListarFuncionario");
        }

        public IActionResult DetalharFuncionario(int id)
        {
            return View(_funcionario.GetFuncionario(id));
        }

        public IActionResult EditarFuncionario(int id)
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