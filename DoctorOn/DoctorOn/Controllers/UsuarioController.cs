using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Web.Security;
using DoctorOn.DAO;
using DoctorOn.Entidades;
using DoctorOn.Models;

namespace DoctorOn.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        private UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }

        public ActionResult Index()
        {
            return View();
        }

        //REALIZAR O CADASTRO DE USUARIO
        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult CreateAcount(UsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(model.Email,model.Senha);
                    return RedirectToAction("Login", "Usuario");
                }
                catch (MembershipPasswordException e)
                {
                    ModelState.AddModelError("usuario.Invalido", e.Message);
                    return View("Create", model);
                }
            }
            else
            {
                return View("Create", model);
            }

        }




        //REALIZAR O LOGIN DO USUARIO
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Authentication(String Email, String Senha)
        {
            if (WebSecurity.Login(Email, Senha))
            {
                return RedirectToAction("Index", "Usuario");
            }
            else
            {
                ModelState.AddModelError("email.Invalido", "Login ou Senha incorretos");
                return View("Login", "Usuario");
            }
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }


    }
}