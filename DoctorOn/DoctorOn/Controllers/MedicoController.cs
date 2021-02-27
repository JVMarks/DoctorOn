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
    //[Authorize]
    public class MedicoController : Controller
    {
        private MedicoDAO medicoDAO;
        private AgendaDAO agendaDAO;

        private AgendamentoContext contextdb = new AgendamentoContext();

        public MedicoController(MedicoDAO medicoDAO, AgendaDAO agendaDAO)
        {
            this.medicoDAO = medicoDAO;
            this.agendaDAO = agendaDAO;
        }

        // GET: Medico
        //CRIANDO A CONTA MEDICO
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateMedic(MedicoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Medico medico = new Medico
                    {
                        Nome_completo = model.Nome_completo,
                        Endereco = model.Endereco,
                        Telefone = model.Telefone,
                        CRM = model.CRM,
                        Especialidade = model.Especialidade,
                        Usuario_Id = model.Usuario_Id,
                    };
                    medicoDAO.CreateMedic(medico);
                    //WebSecurity.CreateUserAndAccount(model.Email,model.Senha);
                    return RedirectToAction("Details", "Medico", new { id = medico.Id });
                }
                catch (MembershipPasswordException e)
                {
                    ModelState.AddModelError("Medico.Invalido", e.Message);
                    return View("Create", model);
                }
            }
            else
            {
                return View("Create", model);
            }
        }




        //REALIZANDO O LOGIN DA CONTA MEDICO
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AuthenticationMedic(string Telefone, string CRM)
        {
            if (WebSecurity.Login(Telefone, CRM))
            {
                return RedirectToAction("Details", "Medico");
            }
            else
            {
                ModelState.AddModelError("CRM.Invalido", "CRM ou Telefone incorretos");
                return RedirectToAction("Login");
            }
        }

        //LISTA DE MEDICOS
        public ActionResult List()
        { 
            IList<Medico> medicos = medicoDAO.Medic_list();
            return View(medicos);
        }

        //BUSCAR POR MEDICO
        public ActionResult FindByMedic(BuscarMedicoModel model)
        {
            //model.Medicos = medicoDAO.Medic_list();
            model.Agendas = agendaDAO.Schedule_list();
            model.Medicos = medicoDAO.FindBy(model.Especialidade, model.Usuario_Id);
            return View(model);
        }


        //INDEX DO MEDICO POSSUI OS DETALTHES DO MEDICO JUNTO COM SUA AGENDA 
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = await contextdb.Medicos.FindAsync(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }





        //OPÇÃO DE ATUALIZAR E DELETAR INFORMAÇÕES DE PERFIL DO MEDICO
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = await contextdb.Medicos.FindAsync(id);
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