using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleArch.Model;
using SampleArch.Repository;
using SampleArch.Service;

namespace SampleArch.Test.Services
{
    [TestClass]
    public class CountryServiceTest
    {
        private Mock<ICountryRepository> _mockRepository;
        private ICountryService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<Country> listCountry;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<ICountryRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new CountryService(_mockUnitWork.Object, _mockRepository.Object);
            listCountry = new List<Country>() {
             new Country() { Id = 1, Name = "US" },
             new Country() { Id = 2, Name = "India" },
             new Country() { Id = 3, Name = "Russia" }
            };
        }

        [TestMethod]
        public void Country_Get_All()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetAll()).Returns(listCountry);

            //Act
            List<Country> results = _service.GetAll() as List<Country>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }


        [TestMethod]
        public void Can_Add_Country()
        {
            //Arrange
            int Id = 1;
            Country emp = new Country() { Name = "UK" };
            _mockRepository.Setup(m => m.Add(emp)).Returns((Country e) =>
            {
                e.Id = Id;
                return e;
            });
           

            //Act
            _service.Create(emp);

            //Assert
            Assert.AreEqual(Id, emp.Id);
            _mockUnitWork.Verify(m => m.Commit(), Times.Once);
        }





















        /////////// dummy 

        /// <summary>
        /// dummy start here
        /// </summary>

        public class RetObj {
        
        }

        public interface IObject
        {
            RetObj AnotherMethod();
        }

        public RetObj MyMethod(IObject obj)
        {
            var ret = obj.AnotherMethod();
            return ret;
        }


        public void Test() {
            
            //Arrange           
            Mock<IObject> _mockObj = new Mock<IObject>();

            var dummyVal = new RetObj(); 
            _mockObj.Setup(x => x.AnotherMethod()).Returns(dummyVal);

            //Act
            var result = MyMethod(_mockObj.Object);


            //Assert
            Assert.Equals(dummyVal, result);         
        }





    }
}
