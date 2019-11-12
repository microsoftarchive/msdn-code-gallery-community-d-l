using Ninject;
using Ninject.Modules;

using RepositoryProxy;

using Client.Properties;

namespace Client
{
    class ClientModule : NinjectModule
    {
        public override void Load()
        {
            if (Settings.Default.StartOnline)
                Bind<IRepositoryProxy>().To<OnlineProxy>();
            else
                Bind<IRepositoryProxy>().To<OfflineProxy>();
        }
    }

    class ViewModelLocator
    {
        IKernel kernel;

        public ViewModelLocator()
        {
            kernel = new StandardKernel(new ClientModule());
        }

        public ViewModel ViewModel
        {
            get { return kernel.Get<ViewModel>(); }
        }
    }
}