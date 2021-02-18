namespace DoctorOn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelasTeste : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Medicos", "CRM", c => c.String());
            AlterColumn("dbo.Pacientes", "Cpf", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pacientes", "Cpf", c => c.Int(nullable: false));
            AlterColumn("dbo.Medicos", "CRM", c => c.Int(nullable: false));
        }
    }
}
