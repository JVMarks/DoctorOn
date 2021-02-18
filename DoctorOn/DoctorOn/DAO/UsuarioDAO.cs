using DoctorOn.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoctorOn.DAO
{
    public class UsuarioDAO
    {
        private AgendamentoContext context;

        public UsuarioDAO(AgendamentoContext context)
        {
            this.context = context;
        }

        public void CreateAcount(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }       
    }
}