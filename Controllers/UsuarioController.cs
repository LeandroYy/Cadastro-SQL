using Microsoft.AspNetCore.Mvc;
using Projetos.CrudMvc.Models;
using Projetos.CrudMvc.Repositorio;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace crudmvc.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio; 
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            _usuarioRepositorio.Adicionar(usuario);
            return RedirectToAction("Index");
        }

    }
}