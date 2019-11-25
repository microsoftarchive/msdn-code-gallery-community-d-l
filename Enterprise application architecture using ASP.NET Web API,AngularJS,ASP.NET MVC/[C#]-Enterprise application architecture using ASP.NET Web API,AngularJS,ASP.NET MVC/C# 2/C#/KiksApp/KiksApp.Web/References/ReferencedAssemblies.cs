using System.Reflection;

namespace KiksApp.Web.References
{
    public static class ReferencedAssemblies
    {
        public static Assembly Services
        {
            get { return Assembly.Load("KiksApp.Services"); }
        }

        public static Assembly Repositories
        {
            get { return Assembly.Load("KiksApp.Data"); }
        }

        public static Assembly Dto
        {
            get
            {
                return Assembly.Load("KiksApp.Dto");
            }
        }

        public static Assembly Domain
        {
            get
            {
                return Assembly.Load("KiksApp.Core");
            }
        }
    }
}
