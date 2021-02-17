using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;
using DoctorOn.DAO;
using DoctorOn.Entidades;
using DoctorOn.Models;

namespace DoctorOn.Controllers
{
    [Authorize]
    public class AgendaController : Controller
    {
        private AgendaDAO agendaDAO;
        private MedicoDAO medicoDAO;
        private PacienteDAO pacienteDAO;

        public AgendaController(AgendaDAO agendaDAO,MedicoDAO medicoDAO, PacienteDAO pacienteDAO)
        {
            this.agendaDAO = agendaDAO;
            this.medicoDAO = medicoDAO;
            this.pacienteDAO = pacienteDAO;
        }

        public ActionResult Form_Schedular()
        {
            ViewBag.Agendas = agendaDAO.Schedule_list();
            return View();
        }

        public ActionResult NewSchedular(Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                agendaDAO.Create_schedule(agenda);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Medicos = medicoDAO.Medic_list();
                return View("form_Schedular",agenda); 
            }
        }

        public ActionResult List()
        {
            IList<Agenda> agendas = agendaDAO.Schedule_list();
            return View(agendas);
        }

        // GET: Agenda
        public ActionResult Index()
        {
            return View();
        }

    }
}