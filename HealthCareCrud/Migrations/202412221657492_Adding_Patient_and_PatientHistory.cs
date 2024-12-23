namespace HealthCareCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_Patient_and_PatientHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientHistories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IssueDetails = c.String(),
                        Patient_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Patients", t => t.Patient_ID)
                .Index(t => t.Patient_ID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientHistories", "Patient_ID", "dbo.Patients");
            DropIndex("dbo.PatientHistories", new[] { "Patient_ID" });
            DropTable("dbo.Patients");
            DropTable("dbo.PatientHistories");
        }
    }
}
