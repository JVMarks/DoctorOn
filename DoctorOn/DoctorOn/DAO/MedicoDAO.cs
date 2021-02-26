using DoctorOn.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorOn.DAO
{
    public class MedicoDAO
    {
        private AgendamentoContext context;

        public MedicoDAO(AgendamentoContext context)
        {
            this.context = context;
        }

        public void CreateMedic(Medico medico)
        {
            context.Medicos.Add(medico);
            context.SaveChanges();
        }

        public IList<Medico> Medic_list()
        {
            return context.Medicos.ToList();
        }
    
        public IList<Medico> FindByUser(int? Usuario_Id)
        {
            return context.Medicos.Where(m => m.Usuario_Id == Usuario_Id).ToList();
        }

        public IList<Medico> FindByMedic(int? Id)
        {
            return context.Medicos.Where(m => m.Id == Id).ToList();
        }

        public IList<Medico> FindBy(Especialidade? especialidade, int? usuario_Id)
        {
            IQueryable<Medico> findby = context.Medicos;
            if (especialidade.HasValue)
            {
                findby = findby.Where(m => m.Especialidade == especialidade);
            }
            if (usuario_Id.HasValue)
            {
                findby = findby.Where(m => m.Usuario_Id == usuario_Id);
            }

            return findby.ToList();
        }

    }
}