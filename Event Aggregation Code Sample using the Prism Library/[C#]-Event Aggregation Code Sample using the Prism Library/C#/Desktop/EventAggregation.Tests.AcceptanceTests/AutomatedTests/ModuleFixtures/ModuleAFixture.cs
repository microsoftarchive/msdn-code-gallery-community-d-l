// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventAggregation.AcceptanceTests;
using Core.UIItems.ListBoxItems;
using EventAggregation.AcceptanceTests.TestInfrastructure;
using Core.UIItems;
using Core.UIItems.WindowItems;
using Core.UIItems.Finders;


namespace EventAggregation.AcceptanceTests.AutomatedTests.ModuleFixtures
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    [DeploymentItem(@".\bin\Debug")]
    [DeploymentItem(@".\EventAggregation.Tests.AcceptanceTests\bin\Debug")]
    public class ModuleAFixture : FixtureBase
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            base.TestInitialize();
        }

        /// <summary>
        /// TestCleanup performs clean-up activities after each test method execution
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            base.TestCleanup();
        }

        /// <summary>
        /// Check if the add button click adds the selected fund to the selected customer.
        /// 
        /// Repro Steps:
        /// 1. Launch the EventAgrregation QS
        /// 2. Select a customer in the Customer combo box.
        /// 3. Select a fund in the Fund combo box.
        /// 4. Click on the add button
        /// 5. Check for the content displayed in the ArticleView displayed on the right side of the screen.
        /// 
        /// Expected Result:
        /// On clicking the Add button, the selected fund should be added to the Activity view of the
        /// selected customer.        
        /// </summary>
        [TestMethod]
        public void AddFundToCustomer()
        {
            
            WPFComboBox customer;
            WPFComboBox fund;
            Button addButton;
            Label activityLabel;
           
            //Get the handle of the Customer combo box and select Customer1
            customer = Window.Get<WPFComboBox>(TestDataInfrastructure.GetControlId("CustomerCombobox"));
            customer.Select(TestDataInfrastructure.GetTestInputData("DefaultCustomer").ToString());

            //Get the handle of the Fund combo box and select FundA
            fund = Window.Get<WPFComboBox>(TestDataInfrastructure.GetControlId("FundCombobox"));
            fund.Select(TestDataInfrastructure.GetTestInputData("DefaultFund"));

            //Get the handle of the Add button and click on it
            addButton = Window.Get<Button>(TestDataInfrastructure.GetControlId("AddButton"));
            addButton.Click();

            //Get the handle of the Activity Label 
            activityLabel = Window.Get<Label>(TestDataInfrastructure.GetControlId("ActivityLabel"));          
                      
            //Check if the selected fund is added to the Activity View of the selected customer.
            Assert.AreEqual(activityLabel.Text, TestDataInfrastructure.GetTestInputData("Customer1ActivityLabelText"));
            Assert.IsNotNull((Label)Window.Get(SearchCriteria.ByText(TestDataInfrastructure.GetTestInputData("DefaultFund"))
                                                             .AndControlType(typeof(Label))));
        }

        /// <summary>
        /// Check if the add button click adds the selected funds to the selected customer.
        /// 
        /// Repro Steps:
        /// 1. Launch the EventAgrregation QS
        /// 2. Select a customer in the Customer combo box.
        /// 3. Select a fund in the Fund combo box.
        /// 4. Click on the add button        
        /// 5. Select another fund in the Fund combo box.
        /// 6. Click on the add button again.
        /// 7. Check if the ArticleView of the selected customer displays the added funds.
        /// 
        /// Expected Result:
        /// The ArticleView of the selected customer should display all the added funds.        
        /// </summary>
        [TestMethod]
        public void AddMultipleFundsToACustomer()
        {

            WPFComboBox customer;
            WPFComboBox fund;
            Button addButton;
            Label activityLabel;

            //Get the handle of the Customer combo box and select Customer1
            customer = Window.Get<WPFComboBox>(TestDataInfrastructure.GetControlId("CustomerCombobox"));
            customer.Select(TestDataInfrastructure.GetTestInputData("DefaultCustomer").ToString());

            //Get the handle of the Fund combo box and select FundA
            fund = Window.Get<WPFComboBox>(TestDataInfrastructure.GetControlId("FundCombobox"));
            fund.Select(TestDataInfrastructure.GetTestInputData("DefaultFund"));

            //Get the handle of the Add button and click on it
            addButton = Window.Get<Button>(TestDataInfrastructure.GetControlId("AddButton"));
            addButton.Click();

            //select FundB in the Fund combo box and click on Add button
            fund.Select(TestDataInfrastructure.GetTestInputData("AnotherFund"));
            addButton.Click();

            //Get the handle of the Activity Label 
            activityLabel = Window.Get<Label>(TestDataInfrastructure.GetControlId("ActivityLabel"));

            //Check if the Activity View of the selected customer displays all the added funds.
            Assert.AreEqual(activityLabel.Text, TestDataInfrastructure.GetTestInputData("Customer1ActivityLabelText"));
            Assert.IsNotNull((Label)Window.Get(SearchCriteria.ByText(TestDataInfrastructure.GetTestInputData("DefaultFund"))
                                                             .AndControlType(typeof(Label))));
            Assert.IsNotNull((Label)Window.Get(SearchCriteria.ByText(TestDataInfrastructure.GetTestInputData("AnotherFund"))
                                                            .AndControlType(typeof(Label))));
        }

        /// <summary>
        /// Check if the repeated add button click keeps on adding the selected fund to the selected customer repeatedly.
        /// 
        /// Repro Steps:
        /// 1. Launch the EventAgrregation QS
        /// 2. Select a customer in the Customer combo box.
        /// 3. Select a fund in the Fund combo box.
        /// 4. Click on the add button
        /// 5. Click on the add button again.
        /// 6. Click on the add button again.
        /// 7. Check if the selected fund is added thrice to the ArticleView of the selected customer.
        /// 
        /// Expected Result:
        /// For every Add button click, the selected fund should be added to the ArticleView of the selected customer.
        /// </summary>
        [TestMethod]
        public void SelectedCustomerAndFundRepeatedAddButtonClick()
        {
            WPFComboBox customer;
            WPFComboBox fund;
            Button addButton;
            Label activityLabel;
            //Configure the number of Add button clicks
            int numberOfAddClicks = 3;

            //Get the handle of the Customer combo box and select Customer1
            customer = Window.Get<WPFComboBox>(TestDataInfrastructure.GetControlId("CustomerCombobox"));
            customer.Select(TestDataInfrastructure.GetTestInputData("DefaultCustomer").ToString());

            //Get the handle of the Fund combo box and select FundA
            fund = Window.Get<WPFComboBox>(TestDataInfrastructure.GetControlId("FundCombobox"));
            fund.Select(TestDataInfrastructure.GetTestInputData("DefaultFund"));

            //Get the handle of the Add button and click on it
            addButton = Window.Get<Button>(TestDataInfrastructure.GetControlId("AddButton"));

            //click the add button thrice
            addButton.Click();
            addButton.Click();
            addButton.Click();

            //Get the hanlde of the Activity Label
            activityLabel = Window.Get<Label>(TestDataInfrastructure.GetControlId("ActivityLabel"));

            //check if the Article view displays the selected customer
            Assert.AreEqual(activityLabel.Text, TestDataInfrastructure.GetTestInputData("Customer1ActivityLabelText"));

            //For every Add button click, Check if the selected fund is added to the selected customer repeatedly.
            for (int count = 0; count < numberOfAddClicks; count++)
            {
                Assert.IsNotNull((Label)Window.Get(SearchCriteria.ByText(TestDataInfrastructure.GetTestInputData("DefaultFund"))
                                                                 .AndControlType(typeof(Label))));
            }
        }

    }
}
