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
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Observacao = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        ThemeColor = c.String(),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome_completo = c.String(nullable: false),
                        Endereco = c.String(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 17),
                        CRM = c.String(nullable: false, maxLength: 10),
                        Especialidade = c.Int(nullable: false),
                        Id_Agenda = c.Int(nullable: false),
                        Agenda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agenda", t => t.Agenda_Id)
                .Index(t => t.Agenda_Id);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome_completo = c.String(nullable: false),
                        Cpf = c.String(nullable: false, maxLength: 12),
                        Sexo = c.Int(nullable: false),
                        Datadenacimento = c.DateTime(nullable: false),
                        Endereco = c.String(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 17),
                        Nome_do_convenio = c.Int(nullable: false),
                        Matricula_do_convenio = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoDeAtendimentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Valor = c.Single(nullable: false),
                        Id_agenda = c.Int(nullable: false),
                        Agenda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agenda", t => t.Agenda_Id)
                .Index(t => t.Agenda_Id);
            
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
            DropForeignKey("dbo.TipoDeAtendimentoes", "Agenda_Id", "dbo.Agenda");
            DropForeignKey("dbo.Medicos", "Agenda_Id", "dbo.Agenda");
            DropIndex("dbo.TipoDeAtendimentoes", new[] { "Agenda_Id" });
            DropIndex("dbo.Medicos", new[] { "Agenda_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.TipoDeAtendimentoes");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Medicos");
            DropTable("dbo.Agenda");
        }
    }
}
