using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
          public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {
            UsuarioService usuarioService = new UsuarioService();

            if(u.Id == 0)
            {
                usuarioService.Inserir(u);
            }
            else
            {
                usuarioService.Atualizar(u);
            }

            return RedirectToAction("Listagem");
        }
         public IActionResult Listagem(string tipoFiltro, string filtro)
        {
            FiltrosUsuario objFiltro = null;
            if(!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosUsuario();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }
            UsuarioService usuarioService = new UsuarioService();
            return View(usuarioService.ListarTodos(objFiltro));
        }

            public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this);
            UsuarioService us = new UsuarioService();
            Usuario u = us.ObterPorId(id);
            return View(u);
        }
    }
}