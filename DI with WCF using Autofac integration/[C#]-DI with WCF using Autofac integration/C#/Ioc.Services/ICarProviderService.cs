using System;
using System.ServiceModel;

using Ioc.Services.Domain;

namespace Ioc.Services
{
    [ServiceContract]
    public interface ICarProviderService
    {
        [OperationContract]
        Car[] GetCarsByManufacturingYear(int year);

        [OperationContract]
        Car[] GetCarsInPriceRange(PriceRange range);

        [OperationContract]
        Car[] GetCarsByModel(CarModel model);
    }
}
