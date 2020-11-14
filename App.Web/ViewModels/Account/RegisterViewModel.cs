using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display (Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Senha")]
        [StringLength(100, ErrorMessage ="O campo {0} deve ter no mínimo{2} e  no máximo {1} caracteres", MinimumLength =8)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Confirmar senha")]
        [Compare("Password", ErrorMessage ="As senhas devem ser iguais")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Perfis de usuário : ")]
        [UIHint("List")]
        public List<SelectListItem> Roles { get; set; }

        public string Role { get; set; }

        public RegisterViewModel()
        {
            Roles = new List<SelectListItem>();
            Roles.Add(new SelectListItem() { Value = "1", Text = "Administrador" });
            Roles.Add(new SelectListItem() { Value = "2", Text = "Operador" });
            Roles.Add(new SelectListItem() { Value = "3", Text = "Usuario" });
        }
    }
}
