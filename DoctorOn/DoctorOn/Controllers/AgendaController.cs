using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Web.Security;
using DoctorOn.DAO;
using DoctorOn.Entidades;
using DoctorOn.Models;

using System.Net;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace DoctorOn.Controllers
{
    //[Authorize]
    public class AgendaController : Controller
    {
      
        // GET: Agenda
        //VISUALIZANDO, CRIAÇA, SALVANDO, REMOVENDO O EVENTO DO CALENDARIO
        public JsonResult GetEvents()
        {
            using (AgendamentoContext contextdb = new AgendamentoContext())
            {
                var events = contextdb.Agendas.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Agenda e)
        {
            var status = false;
            using (AgendamentoContext contextdb = new AgendamentoContext())
            {
                if (e.Id > 0)
                {
                    //Update the event
                    var v = contextdb.Agendas.Where(a => a.Id == e.Id).FirstOrDefault();
                    if (v != null)
                    {
                        v.Title = e.Title;
                        v.Observacao = e.Observacao;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    contextdb.Agendas.Add(e);
                }
                contextdb.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {
            var status = false;
            using (AgendamentoContext contextdb = new AgendamentoContext())
            {
                var v = contextdb.Agendas.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    contextdb.Agendas.Remove(v);
                    contextdb.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}