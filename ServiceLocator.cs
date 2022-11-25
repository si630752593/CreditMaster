using CreditMaster.Services;
using CreditMaster.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditMaster
{
    public class ServiceLocator
    {
        private IServiceProvider _serviceProvider;

        public MainpageViewModel MainpageViewModel =>
            _serviceProvider.GetService<MainpageViewModel>(); //依赖注入

        public ServiceLocator()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<MainpageViewModel>();
            serviceCollection.AddSingleton<IAcstuentStorage, AcstuentStorage>();
            serviceCollection.AddSingleton<ITokenService,TokenService>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }


    }
}
