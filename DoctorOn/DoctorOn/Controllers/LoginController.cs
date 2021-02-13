using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WebMatrix.WebData;

namespace DoctorOn.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /*
         public ActionResult Authentication(String email, String senha)
        {
            if (WebSecurity.Login(email, senha))
            {
                return RedirectToAction("Form", "Produto");
            }
            else
            {
                ModelState.AddModelError("email.Invalido", "Login ou Senha incorretos");
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index");
        }
        */

    }
}