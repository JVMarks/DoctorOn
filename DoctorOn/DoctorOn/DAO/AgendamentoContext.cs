using DoctorOn.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

//Pacotes 
//install-package EntityFramework
//Enable-Migrations
//add-migration TabelasTeste
// update-Database
//Install-package Ninject.MVC3

namespace DoctorOn.DAO
{
    public class AgendamentoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Agenda> Agendas { get; set; }

        public DbSet<TipoDeAtendimento> TipoDeAtendimentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Medico>().HasRequired(p => p.Agenda);

            modelBuilder.Entity<Agenda>().HasRequired(d => d.Medico);
            modelBuilder.Entity<Agenda>().HasRequired(p => p.Paciente);
            modelBuilder.Entity<Agenda>().HasRequired(t => t.TipodeAtendimento);

            //modelBuilder.Entity<TipoDeAtendimento>().HasRequired(m => m.Agenda);
        }

    }
}