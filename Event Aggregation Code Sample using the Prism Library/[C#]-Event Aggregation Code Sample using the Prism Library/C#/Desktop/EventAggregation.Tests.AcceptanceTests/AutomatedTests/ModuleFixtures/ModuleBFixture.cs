// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;

using Core;
using Core.UIItems;
using Core.UIItems.WindowItems;
using Core.UIItems.Finders;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventAggregation.AcceptanceTests;
using Core.UIItems.ListBoxItems;
using EventAggregation.AcceptanceTests.TestInfrastructure;
using EventAggregation.AcceptanceTests.Helpers;
using System.Globalization;


namespace EventAggregation.AcceptanceTests.AutomatedTests.ModuleFixtures
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    [DeploymentItem(@".\bin\Debug")]
    [DeploymentItem(@".\EventAggregation.Tests.AcceptanceTests\bin\Debug")]
    public class ModuleBFixture : FixtureBase
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
        /// Check if each of the customer in the customer combo box has an Article view.
        /// 
        /// Repro Steps:
        /// 1. Launch the EventAgrregation QS        
        /// 2. For every customer in the customer combo box, Check if a corresponding ArticleView is 
        /// displayed on the right side of the screen.
        /// 
        /// Expected Result:
        /// Every customer in the customer combo box should have a corresponding Article view displayed.      
        /// </summary>
        [TestMethod]
        public void EachCustomerShouldHaveAnActivityView()
        {
            WPFComboBox customer;
            
            //Get the handle of the customer combo box
            customer = Window.Get<WPFComboBox>(TestDataInfrastructure.GetControlId("CustomerCombobox"));

            //For every customer in the customer combo box,check if a corresponding article view is displayed
            for (int count = 0; count < customer.Items.Count - 1; count++)
            {
               Assert.IsNotNull((Label)Window.Get(SearchCriteria.ByAutomationId(TestDataInfrastructure.GetControlId("ActivityLabel")).
                        AndByText(TestDataInfrastructure.GetTestInputData("ActivityLabelText") + customer.Items[count].Text)
                        .AndControlType(typeof(Label))));              
            }
        }

        /// <summary>
        /// Check if the selected fund is added only to the selected customer.
        /// 
        /// Repro Steps:
        /// 1. Launch the EventAggregation QS
        /// 2. Select the customer from customer dropdown. 
        /// 3. Select the fund from fund dropdown.
        /// 4. Click on Add.
        /// 5. Repeat steps 2 to 4 by changing the customer and fund.
        /// 5. Check whether the added fund has been displayed correctly in the display area.
        /// 
        /// Expected Result:
        /// Fund should get added to the selected customer.
        /// </summary>
        [TestMethod]
        public void SelectedFundIsAddedOnlyToTheSelectedCustomer()
        {
            string[] selectedCustomer = new string[2];
            string[] selectedFund = new string[2];

            const int CUSTOMERS_IN_DROPDOWN=2;

            for (int i = 0; i < CUSTOMERS_IN_DROPDOWN; i++)
            {
                //Get the handle of the Customer combo box and select customer.
                WPFComboBox customer = Window.Get<WPFComboBox>(TestDataInfrastructure.GetControlId("CustomerCombobox"));
                customer.Select(TestDataInfrastructure.GetTestInputData("Customer" + i.ToString(CultureInfo.InvariantCulture)).ToString());
                selectedCustomer[i] = customer.Items[i].Text;

                //Get the handle of the Fund combo box and select fund.
                WPFComboBox fund = Window.Get<WPFComboBox>(TestDataInfrastructure.GetControlId("FundCombobox"));
                fund.Select(TestDataInfrastructure.GetTestInputData("Fund" + i.ToString(CultureInfo.InvariantCulture)));
                selectedFund[i] = fund.Items[i].Text;

                //Get the handle of the Add button and click on it.
                Button addButton = Window.Get<Button>(TestDataInfrastructure.GetControlId("AddButton"));
                addButton.Click();
            }

            // Now validate whether the fund has been added correctly.                  
            List<AutomationElement> elements = Window.AutomationElement.FindSiblingsInTreeByName("ActivityView");
            int counter = 0;
            foreach (AutomationElement element in elements)
            {
                if (counter < CUSTOMERS_IN_DROPDOWN)
                {
                    // Find the text box and the fund text associated.
                    AutomationElement textBox = element.SearchInRawTreeByName("ActivityLabel");
                    string textBoxValue = textBox.Current.Name;
                    string expectedValue = TestDataInfrastructure.GetTestInputData("ActivityLabelText") + selectedCustomer[counter].ToString();
                    Assert.AreEqual(expectedValue, textBoxValue);

                    // Find the fund values
                    AutomationElement fund = element.SearchInRawTreeByName(selectedFund[counter].ToString());
                    Assert.AreEqual(fund.Current.Name, selectedFund[counter].ToString());
                    counter++;
                }                
            }
        }
    }
}
