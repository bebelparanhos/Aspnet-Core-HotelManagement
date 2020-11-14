using Microsoft.AspNetCore.Mvc;
using App.Web.Models.Entities;
using App.Web.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace App.Web.Controllers
{
    public class SecureController : Controller
    {


        //private readonly IFuncionario _usuario;


        //public SecureController(IFuncionario usuario)
        //{
        //    this._usuario = usuario;

        //}

        public IActionResult Login()
        {
            return View();
        }

        //public IActionResult Autenticar(Funcionario usuario)
        //{
        //    var usuarioValido = _usuario.AutenticaUsuario(usuario);
        //    if (usuarioValido)
        //        return RedirectToAction("Index", "Home");
        //    else
        //        return RedirectToAction("Login", "Secure");
        //}
    }
}