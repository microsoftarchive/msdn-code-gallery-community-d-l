using DependencyInjectionServices.DIServices;
using Microsoft.Practices.Unity;

namespace DependencyInjectionConsoleApp
{
    public static class UnityConfig
    {
        private static IUnityContainer _currentContainer;

      //  public static IUnityContainer CurrentContainer => _currentContainer; //in framework 4.6 (new way of getter expression). //This is Wrong ! 
        public static IUnityContainer CurrentContainer
        {

            get
            {
                //here we have to test if the _currentContainer is nullable or not
                if(_currentContainer == null)
                    _currentContainer = new UnityContainer();//We have to create an instance :)
                return _currentContainer;
            }
        }

        /// <summary>
        /// We will register all components in this method
        /// </summary>
        public static void RegisterComponents()
        {
            CurrentContainer
                .RegisterType<IDependencyInjectionServices,
                    DependencyInjectionServices.DIServices.DependencyInjectionServices>();
        }
    }
}
