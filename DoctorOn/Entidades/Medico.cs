using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorOn.Entidades
{
    public class Medico
    {
        public int Id { get; set; }

        public string Nome_completo { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public int CRM { get; set; }

        public Especialidade Especialidade { get; set; }

        //CRIAÇÃO DA FK
        public int Id_Agenda { get; set; }

        public virtual Agenda Agenda { get; set; }
    }
}