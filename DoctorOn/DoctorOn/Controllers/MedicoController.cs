﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorOn.Controllers
{
    [Authorize]
    public class MedicoController : Controller
    {
        // GET: Medico
        public ActionResult Index()
        {
            return View();
        }
    }
}