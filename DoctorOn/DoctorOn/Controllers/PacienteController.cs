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
    public class PacienteController : Controller
    {
        private PacienteDAO pacienteDAO;

        private AgendamentoContext contextdb = new AgendamentoContext();

        public PacienteController(PacienteDAO pacienteDAO)
        {
            this.pacienteDAO = pacienteDAO;
        }

        // GET: Paciente
        //CRIANDO A CONTA DO PACIENTE
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreatePaciente(PacienteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Paciente paciente = new Paciente
                    {
                        Nome_completo = model.Nome_completo,
                        Cpf = model.Cpf,
                        Sexo = model.Sexo,
                        Datadenacimento = model.Datadenacimento,
                        Endereco = model.Endereco,
                        Telefone = model.Telefone,
                        Nome_do_convenio = model.Nome_do_convenio,
                        Matricula_do_convenio = model.Matricula_do_convenio,
                        Usuario_Id = model.Usuario_Id,
                    };
                    pacienteDAO.CreatePaciente(paciente);
                    //WebSecurity.CreateUserAndAccount(model.Email,model.Senha);
                    return RedirectToAction("Details", "Paciente", new { id = paciente.Id });
                }
                else
                {
                    return View("Create", model);
                }
            }
            catch (MembershipPasswordException e)
            {
                ModelState.AddModelError("Paciente.Invalido", e.Message);
                return View("Create", model);
            }
        }



        //REALIZANDO O LOGIN DA CONTA DO PACIENTE
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AuthenticationPaciente(string Cpf, string Matricula_do_convenio)
        {
            if (WebSecurity.Login(Cpf, Matricula_do_convenio))
            {
                return RedirectToAction("List", "Medico");
            }
            else
            {
                ModelState.AddModelError("CRM.Invalido", "CRM ou Telefone incorretos");
                return RedirectToAction("Login");
            }
        }



        //INDEX DO PACIENTE DEVE MOSTRAR O PERFIL DO PACIENTE
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

            Paciente paciente = await contextdb.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }


        //OPÇÃO DE ATUALIZAR E DELETAR INFORMAÇÕES DE PERFIL DO PACIENTE
        public async Task<ActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = await contextdb.Pacientes.FindAsync(Id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome_completo,Cpf,Sexo,Datadenacimento,Endereco,Telefone,Nome_do_convenio,Matricula_do_convenio")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                contextdb.Entry(paciente).State = EntityState.Modified;
                await contextdb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            Paciente paciente = await contextdb.Pacientes.FindAsync(Id);
            contextdb.Pacientes.Remove(paciente);
            await contextdb.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}