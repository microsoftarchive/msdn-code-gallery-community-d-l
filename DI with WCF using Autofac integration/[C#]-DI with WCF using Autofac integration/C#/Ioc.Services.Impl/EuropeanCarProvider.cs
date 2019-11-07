using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using Ioc.Services.Domain;

namespace Ioc.Services.Impl
{
    /// <summary>
    /// Class that implements <see cref="ICarProvider"/> interface
    /// to provide european cars.
    /// </summary>
    public class EuropeanCarProvider : ICarProvider
    {
        private XElement document;

        public EuropeanCarProvider()
        {
            string xmldata = Properties.Resources.european_cars;

            document = XElement.Parse(xmldata);
        }

        /// <summary>
        /// Get cars manufactured at provided year.
        /// </summary>
        /// <param name="year">The manufacturing year of the cars to get.</param>
        /// <returns>A enumerable of cars manufactured in provided year or empty enumerable.</returns>
        public IEnumerable<Car> GetCarsByManufacturingYear(int year)
        {
            var query = document.Elements()
                                .Where(x => x.Element("manufacturingYear").Value == year.ToString());

            return Read(query).ToArray();
        }

        /// <summary>
        /// Get cars in provided price range.
        /// </summary>
        /// <param name="range">The price range where price of the car should land.</param>
        /// <returns>A enumerable of cars in provided price range or empty enumerable.</returns>
        public IEnumerable<Car> GetCarsInPriceRange(PriceRange range)
        {
            var query = document.Elements()
                                .Where(x => Convert.ToDouble(x.Element("price").Value) >= range.MinPrice)
                                .Where(x => Convert.ToDouble(x.Element("price").Value) <= range.MaxPrice);

            return Read(query).ToArray();
        }

        /// <summary>
        /// Get cars by the provided model.
        /// </summary>
        /// <param name="model">The model of the car.</param>
        /// <returns>A enumerable of cars or empty enumerable.</returns>
        public IEnumerable<Car> GetCarsByModel(CarModel model)
        {
            var query = document.Elements()
                                .Where(x => x.Element("model").Value.ToLower() == model.ToString().ToLower());

            return Read(query);
        }

        /// <summary>
        /// Reads the XML data.
        /// </summary>
        /// <param name="query">The enumerable of XML elements to read and convert.</param>
        /// <returns>A enumerable of cars.</returns>
        private IEnumerable<Car> Read(IEnumerable<XElement> query)
        {
            foreach (var element in query)
            {
                string register = element.Element("register").Value;
                string color = element.Element("color").Value;
                CarModel model = (CarModel)Enum.Parse(typeof(CarModel), element.Element("model").Value, true);
                double price = Convert.ToDouble(element.Element("price").Value);
                string manufacturer = element.Element("manufacturer").Value;
                int manufacturingYear = Convert.ToInt32(element.Element("manufacturingYear").Value);
                string name = element.Element("name").Value;

                Car car = new Car()
                {
                    Register = register,
                    Color = color,
                    Model = model,
                    ModelName = name,
                    Manufacturer = manufacturer,
                    ManufacturingYear = manufacturingYear,
                    Price = price
                };

                yield return car;
            }

            yield break;
        }
    }
}
