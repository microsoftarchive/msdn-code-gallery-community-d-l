using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleArch.Model;
using SampleArch.Repository;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
namespace SampleArch.Test.Repositories
{
    [TestClass]
    public class CountryRepositoryTestWithDB
    {
     
        TestContext databaseContext;
        CountryRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
          
            databaseContext = new TestContext();
            objRepo = new CountryRepository(databaseContext);
           
        }

        [TestMethod]
        public void Country_Repository_Get_ALL()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("US", result[0].Name);
            Assert.AreEqual("India", result[1].Name);
            Assert.AreEqual("Russia", result[2].Name);
        }

        [TestMethod]
        public void Country_Repository_Create()
        {
            //Arrange
            Country c = new Country() {Name  = "UK" };

            //Act
            var result = objRepo.Add(c);
            databaseContext.SaveChanges();

            var lst = objRepo.GetAll().ToList();

            //Assert

            Assert.AreEqual(4, lst.Count);
            Assert.AreEqual("UK", lst.Last().Name); 
        }
    }
}
