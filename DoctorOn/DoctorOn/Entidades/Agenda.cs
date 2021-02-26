using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorOn.Entidades
{
    public class Agenda
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

        //PARA DEIXAR A ENTIDADE AGENDA DEPENDENTE DA ENTIDADE MEDICO EU TENHO QUE REFERENCIAR DENTRO DA TABELA AGENDA
        //E CRIAR UMA FK 
        public int MedicoId { get; set; }

        public virtual Medico Medico { get; set; }
    }
}