using DoctorOn.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorOn.Models
{
    public class BuscarMedicoModel
    {
        public int? Usuario_Id { get; set; }
      
        public Especialidade? Especialidade { get; set; }

        public IList<Medico> Medicos { get; set; }

        public IList<Agenda> Agendas { get; set; }

    }
}