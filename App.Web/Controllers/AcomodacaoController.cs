using App.Web.Models.Entities;
using App.Web.Models.Interfaces;
using App.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Web.Controllers
{
    public class AcomodacaoController:Controller
    {
        private readonly IAcomodacao _iacomodacao;
        private readonly ApplicationContext _context;
        public AcomodacaoController(IAcomodacao acomodacao, ApplicationContext context)
        {
            this._iacomodacao = acomodacao;
            this._context = context;
        }

        public IActionResult CadastroAcomodacao(int id)
        {
            List<CategoriaAcomodacao> ca = new List<CategoriaAcomodacao>();
            ca = (from c in _context.CategoriaAcomodacoes select c).ToList();
            ViewBag.message = ca;

            return View(_iacomodacao.GetAcomodacao(id));

        }
        //public IActionResult MostraCadastroAcomodacao()
        //{
        //    List<CategoriaAcomodacao> ca = new List<CategoriaAcomodacao>();
        //    ca = (from c in _context.CategoriaAcomodacoes select c).ToList();
        //    ViewBag.message = ca;

        //    return View("CadastroAcomodacao");
        //}

        //public IActionResult MostraAlteraCadastro(int id)
        //{
        //    List<CategoriaAcomodacao> ca = new List<CategoriaAcomodacao>();
        //    ca = (from c in _context.CategoriaAcomodacoes select c).ToList();
        //    ViewBag.message = ca;

        //    return View("CadastroAcomodacao",_iacomodacao.GetAcomodacao(id));
        //}
        public IActionResult CadastrarAcomodacao(Acomodacao acomodacao)
        {
            _iacomodacao.SalvaAcomodacao(acomodacao);

            return RedirectToAction("ListarAcomodacao");
        }

        public IActionResult ListarAcomodacao()
        {
            return View(_iacomodacao.ListaAcomodacao());
        }
        public IActionResult DetalharAcomodacao(int id)
        { 
            return View(_iacomodacao.GetAcomodacao(id));
        }

        public IActionResult RemoverAcomodacao(int id)
        {
            _iacomodacao.RemoveAcomodacao(id);

            return View("ListarAcomodacao", _iacomodacao.ListaAcomodacao());
        }
    }
}