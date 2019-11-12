namespace ContosoUniversity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOfficeHoursColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "OfficeHours", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "OfficeHours");
        }
    }
}
