namespace project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSchema3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "EmpID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Employees", "EmpID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "EmpID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "EmpID");
        }
    }
}
