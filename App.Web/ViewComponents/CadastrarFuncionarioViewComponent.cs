using App.Web.Models.Entities;
using App.Web.Models.Interfaces;
using App.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.ViewComponents
{
    public class CadastrarFuncionarioViewComponent: ViewComponent
    {
        private readonly ApplicationContext _context;
        private readonly IFuncionario _funcionario;
        public CadastrarFuncionarioViewComponent(ApplicationContext context, IFuncionario funcionario)
        {
            _context = context;
            _funcionario = funcionario;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var dados = await _funcionario.ListaFuncionario();
        //    return View(dados);
        //}

        public async Task<IViewComponentResult> InvokeAsync(Funcionario funcionario)
        {
            
            await _funcionario.SalvarFuncionario(funcionario);
            return View();
        }

    }
}
