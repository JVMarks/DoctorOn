using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorOn.Entidades
{
    public class Agenda
    {
        public int Id { get; set; }

        public DateTime DataHora { get; set; }

        public string Observacao { get; set; }

        //chave FK
        public int Id_paciente { get; set; }

        public Paciente Paciente { get; set; }

        public int Id_medico { get; set; }

        public Medico Medico { get; set; }

        public int Id_tipoDeAtendimento { get; set; }

        public TipoDeAtendimento TipodeAtendimento { get; set; }

    }
}