namespace DoctorOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelasTeste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DataHora = c.DateTime(nullable: false),
                        Observacao = c.String(),
                        PacienteId = c.Int(nullable: false),
                        MedicoId = c.Int(nullable: false),
                        TipoDeAtendimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.Id)
                .ForeignKey("dbo.Pacientes", t => t.PacienteId, cascadeDelete: true)
                .ForeignKey("dbo.TipoDeAtendimentoes", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome_completo = c.String(),
                        Endereco = c.String(),
                        Telefone = c.String(),
                        CRM = c.Int(nullable: false),
                        Especialidade = c.Int(nullable: false),
                        AgendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome_completo = c.String(),
                        Cpf = c.Int(nullable: false),
                        Sexo = c.Int(nullable: false),
                        Datadenacimento = c.DateTime(nullable: false),
                        Endereco = c.String(),
                        Telefone = c.String(),
                        Nome_do_convenio = c.Int(nullable: false),
                        Matricula_do_convenio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoDeAtendimentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Valor = c.Single(nullable: false),
                        AgendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agenda", "Id", "dbo.TipoDeAtendimentoes");
            DropForeignKey("dbo.Agenda", "PacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Agenda", "Id", "dbo.Medicos");
            DropIndex("dbo.Agenda", new[] { "PacienteId" });
            DropIndex("dbo.Agenda", new[] { "Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.TipoDeAtendimentoes");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Medicos");
            DropTable("dbo.Agenda");
        }
    }
}
