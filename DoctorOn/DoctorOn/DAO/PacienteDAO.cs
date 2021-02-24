using DoctorOn.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorOn.DAO
{
    public class PacienteDAO
    {
        private AgendamentoContext context;

        public PacienteDAO(AgendamentoContext context)
        {
            this.context = context;
        }

        public void CreatePaciente(Paciente paciente)
        {
            context.Pacientes.Add(paciente);
            context.SaveChanges();
        }

        /*
        public void Edit(Paciente paciente)
        {
            context.Pacientes.Find(paciente);
            context.SaveChanges();
        }

        public void Delete(Paciente paciente)
        {
            context.Pacientes.Remove(paciente);
            context.SaveChanges();
        }*/

    }
}