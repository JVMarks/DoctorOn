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
//update-Database
//Remove-Migration TabelasTeste 
//Install-package Ninject.MVC3
//simple membership
//install-Package Microsoft.AspNet.WebPages.WebData 

namespace DoctorOn.DAO
{
    public class AgendamentoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Agenda> Agendas { get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
            modelBuilder.Entity<Agenda>().HasRequired(p => p.Medico);

       }

    }
}