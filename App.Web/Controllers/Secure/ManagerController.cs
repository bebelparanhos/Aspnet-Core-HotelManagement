using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Web.Models.Entities;
using App.Web.Models.Interfaces;
using App.Web.Repositories;
using App.Web.ViewModels.Account;
using App.Web.ViewModels.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace App.Web.Controllers.Secure
{
    public class ManagerController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IFuncionario _funcionario;
        private readonly ApplicationContext _context;

        public ManagerController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IFuncionario funcionario, ApplicationContext context)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._funcionario = funcionario;
            this._context = context;
        }
        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if(user == null)
            {
                throw new ApplicationException($"Não foi possível carregar o usuário com ID '{_userManager.GetUserId(User)}'");
            }

            var model = new IndexViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsEmailConfirmed = user.EmailConfirmed,
                StatusMessage = StatusMessage
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new ApplicationException($"Não foi possível carregar o usuário com ID '{_userManager.GetUserId(User)}'");
            }

            var email = user.Email;

            if(email != model.Email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new ApplicationException($"Erro inesperado ao atribuir um email para o usuário com ID '{user.Id}'");
                }
            }

            var phoneNumber = user.PhoneNumber;

            if (phoneNumber != model.PhoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);

                if (!setPhoneResult.Succeeded)
                {
                    throw new ApplicationException($"Erro inesperado ao atribuir um telefone para o usuário com ID '{user.Id}'");
                }
            }

            StatusMessage = "Seu perfil foi atualizado";

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);

            if(user == null)
            {
                throw new ApplicationException($"Não foi possivel carregar o usuário com ID {_userManager.GetUserId(User)}");
            }

            var model = new ChangePasswordViewModel { StatusMessage = StatusMessage };
            
            return View(model);
                
         }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new ApplicationException($"Não foi possivel carregar o usuário com ID {_userManager.GetUserId(User)}");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);

                }

                return View(model);

            }

            await _signInManager.SignInAsync(user, isPersistent: false);

            StatusMessage = "Sua senha foi alterada com sucesso";

            return RedirectToAction(nameof(ChangePassword));
        }

        [HttpGet]
        public IActionResult CadastrarFuncionario(Usuario usuario, string returnUrl = null)
        {

            var model = new FuncionarioViewModel();

            ViewData["ReturnUrl"] = returnUrl;


            var cargo = _context.Cargos.Select(c => new { c.CargoId, c.Descricao }).ToList();
            model.Cargos = new SelectList(cargo, "CargoId", "Descricao");

            var funcionario = _funcionario.GetFuncionario(usuario.Id);

            if (funcionario != null)
            {
                
                model.Email = funcionario.Email;
                model.Nome = funcionario.Nome;
                model.DataDeNascimento = funcionario.DataDeNascimento;
                model.Sexo = funcionario.Sexo;
                model.CPF = funcionario.CPF;
                model.CargoId = funcionario.CargoId;
                
                model.Nacionalidade = funcionario.Nacionalidade;
                model.Logradouro = funcionario.Endereco.Logradouro;
                model.Numero = funcionario.Endereco.Numero;
                model.Complemento = funcionario.Endereco.Complemento;
                model.Bairro = funcionario.Endereco.Bairro;
                model.Cidade = funcionario.Endereco.Cidade;
                model.Estado = funcionario.Endereco.Estado;
                model.Pais = funcionario.Endereco.Pais;
                model.Telefone = funcionario.Endereco.Telefone;
            }
            else
            {

                model.Email = _userManager.Users.Where(u => u.Email == usuario.Email).FirstOrDefault().ToString();
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CadastrarFuncionario(FuncionarioViewModel model, string returnUrl = null)
        {

            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                var funcionario = _funcionario.GetFuncionario(user.Id);

                if(funcionario != null)
                {
                    funcionario.Nome = model.Nome;
                    funcionario.DataDeNascimento = model.DataDeNascimento;
                    funcionario.Sexo = model.Sexo;
                    funcionario.CPF = model.CPF;
                    funcionario.CargoId = model.CargoId;
                    funcionario.Nacionalidade = model.Nacionalidade;
                    funcionario.Email = model.Email;
                    funcionario.Endereco.Logradouro = model.Logradouro;
                    funcionario.Endereco.Numero = model.Numero;
                    funcionario.Endereco.Complemento = model.Complemento;
                    funcionario.Endereco.Bairro = model.Bairro;
                    funcionario.Endereco.Cidade = model.Cidade;
                    funcionario.Endereco.Estado = model.Estado;
                    funcionario.Endereco.Pais = model.Pais;
                    funcionario.Endereco.Telefone = model.Telefone;
                }
                else
                {
                    funcionario = new Funcionario
                    {
                        Nome = model.Nome,
                        Email = model.Email,
                        DataDeNascimento = model.DataDeNascimento,
                        Sexo = model.Sexo,
                        CPF = model.CPF,
                        CargoId = model.CargoId,
                        Nacionalidade = model.Nacionalidade,
                        Usuario = user,
                        Endereco = new Endereco
                        {
                            Logradouro = model.Logradouro,
                            Numero = model.Numero,
                            Complemento = model.Complemento,
                            Bairro = model.Bairro,
                            Cidade = model.Cidade,
                            Estado = model.Estado,
                            Pais = model.Pais,
                            Telefone = model.Telefone
                        }
                    };
                }

                await _funcionario.SalvarFuncionario(funcionario);

                StatusMessage = "Cadastro efetuado com sucesso";

                //return RedirectToAction("Index", "Home");
                return RedirectToAction("ListarFuncionario", "Funcionario", await _funcionario.ListaFuncionario());
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro");

                return View(model);
            }

        }
    }
}
