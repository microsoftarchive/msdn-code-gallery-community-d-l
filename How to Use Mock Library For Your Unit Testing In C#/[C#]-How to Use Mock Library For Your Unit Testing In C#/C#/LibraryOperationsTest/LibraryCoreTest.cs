using LibraryOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace LibraryOperationsTest
{
    
    
    /// <summary>
    ///This is a test class for LibraryCoreTest and is intended
    ///to contain all LibraryCoreTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LibraryCoreTest
    {

        private LibraryCore _target;
        private Mock<IMemberManager> _mock;

        /// <summary>
        ///A test for CalculateMemberShipCost
        ///</summary>
        [TestMethod()]
        public void CalculateMemberShipCostTest()
        {
            _mock = new Mock<IMemberManager>();
            _target = new LibraryCore(_mock.Object);
            Member member = new Member()
            {
                MemberID=1,
                FirstName="Erandika",
                SecondName="Sandaruwan",
                Age=25,
                MaximumBookCanBorrow=4,
            };

            _mock.Setup(x => x.GetMember(It.IsAny<int>())).Returns(member);
    
            int memberID = 1; // TODO: Initialize to an appropriate value
            double expected = 12; // TODO: Initialize to an appropriate value
            double actual;
            actual = _target.CalculateMemberShipCost(memberID);
            Assert.AreEqual(expected, actual);
            
        }
    }
}
