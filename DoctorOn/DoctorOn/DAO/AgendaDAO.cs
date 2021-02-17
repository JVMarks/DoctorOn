using DoctorOn.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorOn.DAO
{
    public class AgendaDAO 
    {

        private AgendamentoContext context;

        public AgendaDAO(AgendamentoContext context)
        {
            this.context = context;
        }

        public void Create_schedule(Agenda agenda)
        {
            context.Agendas.Add(agenda);
            context.SaveChanges();
        }

        public IList<Agenda> Schedule_list()
        {
            return context.Agendas.ToList();
        }

    }
}