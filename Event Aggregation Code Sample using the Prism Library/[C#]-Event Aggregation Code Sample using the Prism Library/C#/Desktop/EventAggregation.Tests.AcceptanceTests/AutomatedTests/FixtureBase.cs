// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventAggregation.AcceptanceTests.ApplicationObserver;
using Core;
using Core.UIItems.WindowItems;
using EventAggregation.AcceptanceTests.TestInfrastructure;
using System.Collections.Specialized;
using EventAggregation.AcceptanceTests.Helpers;
using Core.Configuration;
using System.Globalization;

namespace EventAggregation.AcceptanceTests
{
    public abstract class FixtureBase : IStateObserver
    {
        private Application app;
        private Window window;

        public Window Window
        {
            get { return window; }
        }      

        public void TestInitialize()
        {
            SetupWhiteConfigParameters();

            // Instantiate and initiate the diagnosis process. Diagnosis steps are included
            // to identify the successful launch of the application window without any unexpected
            // exceptions.
            StateDiagnosis.Instance.StartDiagnosis(this);

            app = Application.Launch(ConfigHandler.GetValue("EventAggregationApp"));
            window = app.GetWindow("Shell", Core.Factory.InitializeOption.NoCache);

            //Stop the diagnosis.
            StateDiagnosis.Instance.StopDiagnosis(this);
        }

        /// <summary>
        /// TestCleanup performs clean-up activities after each test method execution
        /// </summary>
        public void TestCleanup()
        {
            if (null != app)
            {
                app.Kill();
            }
        }

        private static void SetupWhiteConfigParameters()
        {
            NameValueCollection collection = ConfigHandler.GetConfigSection("White/Core");

            Type coreAppXmlConfigType = CoreAppXmlConfiguration.Instance.GetType();
            foreach (string property in collection.Keys)
            {
                if (coreAppXmlConfigType.GetProperty(property).PropertyType.Equals(typeof(Int32)))
                {
                    coreAppXmlConfigType.GetProperty(property).SetValue(CoreAppXmlConfiguration.Instance, Convert.ToInt32(collection[property],CultureInfo.InvariantCulture), null);
                }
            }
        }

        #region IStateObserver Members

        public void Notify()
        {
            TestCleanup();
        }

        #endregion
    }
}
