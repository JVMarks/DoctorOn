using DoctorOn.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorOn.Models
{
    public class AgendaModel
    {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Observacao { get; set; }

        [Required]
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string ThemeColor { get; set; }

        [Required]
        public Boolean IsFullDay { get; set; }

        /*
        [Required]
        public virtual Paciente Paciente { get; set; }

        [Required]
        public virtual Medico Medico { get; set; }

        [Required]
        public virtual TipoDeAtendimento TipodeAtendimento { get; set; }

        public int Id_paciente { get; set; }

        public int Id_medico { get; set; }

        public int Id_tipoDeAtendimento { get; set; }
        */

    }
}