using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorOn.Entidades
{
    public class Paciente
    {

        public int Id { get; set; }

        public string Nome_completo { get; set; }

        public string Cpf { get; set; }

        public Sexo Sexo { get; set; }

        public DateTime Datadenacimento { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public Nome_do_convenio Nome_do_convenio { get; set; }

        public string Matricula_do_convenio { get; set; }

      }
}