using App.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.ViewModels.Manager
{
    public class CadastrarFuncionarioViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataDeNascimento { get; set; }
        public Sexo Sexo{ get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "O campo {0} deve ter no mínimo{2} e  no máximo {1} caracteres", MinimumLength = 11)]
        public string CPF { get; set; }
        public string Nacionalidade { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        public SelectList Cargos { get; set; }
        public int CargoId { get; set; }

        //public List<SelectListItem> Cargos { get; set; }

        //public int Cargo { get; set; }
        //public CadastrarFuncionarioViewModel()
        //{
        //    Cargos = new List<SelectListItem>();
        //    Cargos.Add(new SelectListItem() { Value = "1", Text = "Housekeeper" });
        //    Cargos.Add(new SelectListItem() { Value = "2", Text = "Recepcionista" });
        //    Cargos.Add(new SelectListItem() { Value = "3", Text = "Gerente" });
        //}
    }
}
