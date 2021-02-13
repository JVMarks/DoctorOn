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


    }
}