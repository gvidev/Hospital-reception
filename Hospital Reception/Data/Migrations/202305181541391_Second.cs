namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "YearsOfExperiance", c => c.Int());
            AlterColumn("dbo.Doctors", "MonthSalary", c => c.Double());
            AlterColumn("dbo.Doctors", "CreatedBy", c => c.Int());
            AlterColumn("dbo.Doctors", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Hospitals", "Floors", c => c.Int());
            AlterColumn("dbo.Hospitals", "Capacity", c => c.Int());
            AlterColumn("dbo.Hospitals", "CreatedBy", c => c.Int());
            AlterColumn("dbo.Hospitals", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Patients", "IsUrgent", c => c.Boolean());
            AlterColumn("dbo.Patients", "CreatedBy", c => c.Int());
            AlterColumn("dbo.Patients", "UpdatedBy", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "IsUrgent", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Hospitals", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Hospitals", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Hospitals", "Capacity", c => c.Int(nullable: false));
            AlterColumn("dbo.Hospitals", "Floors", c => c.Int(nullable: false));
            AlterColumn("dbo.Doctors", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Doctors", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Doctors", "MonthSalary", c => c.Double(nullable: false));
            AlterColumn("dbo.Doctors", "YearsOfExperiance", c => c.Int(nullable: false));
        }
    }
}
