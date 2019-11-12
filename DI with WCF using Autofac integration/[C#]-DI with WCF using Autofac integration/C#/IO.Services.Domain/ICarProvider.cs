using System;
using System.Collections.Generic;

namespace Ioc.Services.Domain
{
    /// <summary>
    /// Interface that defines different ways to get cars
    /// from provider.
    /// </summary>
    public interface ICarProvider
    {
        /// <summary>
        /// Get cars manufactured at provided year.
        /// </summary>
        /// <param name="year">The manufacturing year of the cars to get.</param>
        /// <returns>A enumerable of cars manufactured in provided year or empty enumerable.</returns>
        IEnumerable<Car> GetCarsByManufacturingYear(int year);

        /// <summary>
        /// Get cars in provided price range.
        /// </summary>
        /// <param name="range">The price range where price of the car should land.</param>
        /// <returns>A enumerable of cars in provided price range or empty enumerable.</returns>
        IEnumerable<Car> GetCarsInPriceRange(PriceRange range);

        /// <summary>
        /// Get cars by the provided model.
        /// </summary>
        /// <param name="model">The model of the car.</param>
        /// <returns>A enumerable of cars or empty enumerable.</returns>
        IEnumerable<Car> GetCarsByModel(CarModel model);
    }
}
