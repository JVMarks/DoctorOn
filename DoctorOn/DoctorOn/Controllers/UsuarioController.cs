using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WebMatrix.WebData;
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

        /*
        public ActionResult CreateAcount(UsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    WebSecurity.CreateUserAndAccount(model.Email,model.Senha);
                    return RedirectToAction("index", "Agenda");
                }
                catch (MembershipPasswordException e)
                {
                    ModelState.AddModelError("usuario.Invalido", e.Message);
                    return View("Index", model);
                }
            }
            else
            {
                return View("Index", model);
            }

        }
        */

    }
}