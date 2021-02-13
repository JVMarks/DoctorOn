using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorOn.Entidades
{
    public class TipoDeAtendimento
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public float Valor { get; set; }

        //chave FK
        public int AgendaId { get; set; }

        public Agenda Agenda { get; set; }

    }
}