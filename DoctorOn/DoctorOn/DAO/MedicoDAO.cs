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

    }
}