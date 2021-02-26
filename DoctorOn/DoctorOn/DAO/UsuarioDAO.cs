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

        public IList<Usuario> FindByUser(int? Id)
        {
            return context.Usuarios.Where(m => m.Id == Id).ToList();
        }

        public void BuscaPorId(string Email)
        {
            context.Usuarios.SqlQuery(Email).SingleOrDefaultAsync();
        }

    }
}