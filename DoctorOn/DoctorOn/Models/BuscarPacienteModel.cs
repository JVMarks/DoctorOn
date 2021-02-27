using DoctorOn.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorOn.Models
{
    public class BuscarPacienteModel
    {
        public int? Id { get; set; }

        public IList<Paciente> Pacientes { get; set; }

    }
}