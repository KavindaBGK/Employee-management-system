namespace project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSchema2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "EmpID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Employees", "FName", c => c.String());
            AlterColumn("dbo.Employees", "LName", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String());
            AddPrimaryKey("dbo.Employees", "EmpID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "LName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "FName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "EmpID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Employees", "EmpID");
        }
    }
}
