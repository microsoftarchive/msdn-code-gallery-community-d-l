using System;


namespace DependencyInjectionServices.DIServices
{
    public class DependencyInjectionServices : IDependencyInjectionServices
    {
        public void DisplayMessage(string message)
        {
           Console.WriteLine(message);
        }
    }
}
