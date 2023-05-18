namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        Age = c.Int(nullable: false),
                        Specialization = c.String(maxLength: 20),
                        PhoneNumber = c.String(maxLength: 10),
                        YearsOfExperiance = c.Int(nullable: false),
                        MonthSalary = c.Double(nullable: false),
                        Hospital_Id = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        Hospital_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.Hospital_Id1)
                .Index(t => t.Hospital_Id1);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HospitalName = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        AddressNumber = c.Int(nullable: false),
                        City = c.String(maxLength: 20),
                        ContactNumber = c.String(maxLength: 10),
                        Email = c.String(maxLength: 60),
                        Floors = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        Age = c.Int(nullable: false),
                        PhoneNumber = c.String(maxLength: 10),
                        IsUrgent = c.Boolean(nullable: false),
                        AppointmentDate = c.DateTime(),
                        Doctor_Id = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        Doctor_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id1)
                .Index(t => t.Doctor_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "Doctor_Id1", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "Hospital_Id1", "dbo.Hospitals");
            DropIndex("dbo.Patients", new[] { "Doctor_Id1" });
            DropIndex("dbo.Doctors", new[] { "Hospital_Id1" });
            DropTable("dbo.Patients");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Doctors");
        }
    }
}
