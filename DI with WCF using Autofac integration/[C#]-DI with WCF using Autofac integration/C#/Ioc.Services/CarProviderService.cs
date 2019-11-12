using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Ioc.Services.Domain;

namespace Ioc.Services
{
    public class CarProviderService : ICarProviderService
    {
        /// <summary>
        /// The car provider.
        /// </summary>
        private ICarProvider provider;

        /// <summary>
        /// Initialize service instance. Car provider is injected
        /// by Autofac.
        /// </summary>
        /// <param name="provider"><see cref="ICarProvider"/> to use.</param>
        public CarProviderService(ICarProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            this.provider = provider;
        }

        public Car[] GetCarsByManufacturingYear(int year)
        {
            return provider.GetCarsByManufacturingYear(year).ToArray();
        }

        public Car[] GetCarsInPriceRange(PriceRange range)
        {
            return provider.GetCarsInPriceRange(range).ToArray();
        }

        public Car[] GetCarsByModel(CarModel model)
        {
            return provider.GetCarsByModel(model).ToArray();
        }
    }
}
