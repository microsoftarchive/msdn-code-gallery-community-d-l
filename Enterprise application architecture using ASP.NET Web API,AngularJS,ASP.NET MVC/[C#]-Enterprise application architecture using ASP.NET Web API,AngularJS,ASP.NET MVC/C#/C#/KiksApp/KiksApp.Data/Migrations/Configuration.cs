namespace KiksApp.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<KiksAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "KiksAppDbContext";
        }

        protected override void Seed(KiksAppDbContext context)
        {
            base.Seed(context);
        }
    }
}
