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
                        MedicoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.MedicoId, cascadeDelete: true)
                .Index(t => t.MedicoId);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome_completo = c.String(nullable: false),
                        Endereco = c.String(nullable: false),
                        Telefone = c.String(nullable: false, maxLength: 18),
                        CRM = c.String(nullable: false, maxLength: 10),
                        Especialidade = c.Int(nullable: false),
                        Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Usuario_Id = c.Int(nullable: false),
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
            DropForeignKey("dbo.Agenda", "MedicoId", "dbo.Medicos");
            DropIndex("dbo.Agenda", new[] { "MedicoId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Medicos");
            DropTable("dbo.Agenda");
        }
    }
}
