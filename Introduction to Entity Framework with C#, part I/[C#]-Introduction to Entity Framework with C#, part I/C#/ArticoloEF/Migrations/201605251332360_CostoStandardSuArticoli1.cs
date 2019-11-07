namespace ArticoloEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CostoStandardSuArticoli1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articoli", "CostoStandard");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articoli", "CostoStandard", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
