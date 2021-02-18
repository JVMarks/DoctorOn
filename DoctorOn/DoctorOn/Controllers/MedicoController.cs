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

using System.Net;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DoctorOn.Controllers
{  
    public class MedicoController : Controller
    {
        private MedicoDAO medicoDAO;

        private AgendamentoContext contextdb = new AgendamentoContext();

        public MedicoController(MedicoDAO medicoDAO)
        {
            this.medicoDAO = medicoDAO;
        }

        // GET: Medico
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateMedic(MedicoModel model)
        {
            if (ModelState.IsValid)
            {
                try{
                    Medico medico = new Medico
                    {
                        Nome_completo = model.Nome_completo,
                        Endereco = model.Endereco,
                        Telefone = model.Telefone,
                        CRM = model.CRM,
                        Especialidade = model.Especialidade
                    };
                    medicoDAO.CreateMedic(medico);
                    WebSecurity.CreateAccount(model.Telefone, model.CRM);
                    return RedirectToAction("Index", "Medico");
                }
                catch(MembershipPasswordException e)
                {
                    ModelState.AddModelError("Medico.Invalido", e.Message);
                    return View("Index", model);
                }
            }
            else
            {
                return View("Index", model);
            }
        }

        public ActionResult AuthenticationMedic(string Telefone, string CRM)
        {
            if (WebSecurity.Login(Telefone, CRM))
            {
                return RedirectToAction("index", "Medico");
            }
            else
            {
                ModelState.AddModelError("CRM.Invalido", "CRM ou Telefone incorretos");
                return View("Index");
            }
        }

        //CRUD
        public async Task<ActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = await contextdb.Medicos.FindAsync(Id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        public async Task<ActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = await contextdb.Medicos.FindAsync(Id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome_completo,Endereco,Telefone,CRM,Especialidade")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                contextdb.Entry(medico).State = EntityState.Modified;
                await contextdb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(medico);
        }

        public async Task<ActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = await contextdb.Medicos.FindAsync(Id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            Medico medico = await contextdb.Medicos.FindAsync(Id);
            contextdb.Medicos.Remove(medico);
            await contextdb.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}