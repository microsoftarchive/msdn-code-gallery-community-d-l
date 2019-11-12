using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CSharpDynamicUnitTest
{
    [TestClass]
    public class DynamicKeyWordUnitTest
    {
        /// <summary>
        /// Four tests for dynamic objects by attaching dynamically with Properties, Events, Functions.
        /// </summary>
        [TestMethod]
        public void DynamicallyAddPropertiesMethodsAndEvents()
        {
            Dictionary<string, dynamic> propertyValuesMapping = new Dictionary<string, dynamic>();

            //Add a property returnning 1
            propertyValuesMapping.Add("NumberOne", 1);
            //Add a StringValue returning "Hello World!"
            propertyValuesMapping.Add("StringValue", "Hello World!");
            //Add a Function returning the two numbers of double added together.
            propertyValuesMapping.Add("Add", new Func<double, double, double>((n1, n2) => n1 + n2));

            List<int> evenNumbers = new List<int>(5);

            //Define an action as a void function to be an event raised thing.
            propertyValuesMapping.Add("EventDelegate",
                new Action<int>((int num) =>
                 {
                     evenNumbers.Add(num);
                 }));

            var d = BasicDynamicSamples.DynamicObjectCreator(propertyValuesMapping);

            //Do dynamically late event trigger binding
            d.NumberCheckingLoop = new Action<int, int>((int start, int end) =>
             {
                 for (int i = start; i <= end; i++)
                 {
                     if (i % 2 == 0)
                     {
                         //Do to trigger the registered event
                         d.EventDelegate(i);
                     }
                 }
             });

            Assert.AreEqual(1, d.NumberOne);
            Assert.AreEqual("Hello World!", d.StringValue);
            Assert.AreEqual(3.0, d.Add(1.0, 2.0));
            d.NumberCheckingLoop(1, 10);
            Assert.AreEqual(5, evenNumbers.Count);
        }

        [TestMethod]
        public void DynamicallyTestForDynamicObject()
        {
            //Define a basic simple object
            dynamic d = new CustomizedDynamicObject();
            d.a = "a";
            d.b = 1;

            //Define a nest object
            dynamic nestObj = new CustomizedDynamicObject();
            nestObj.d = 1;
            nestObj.e = 2;
            nestObj.array = new int[] { 1, 2, 3, 4, 5, 6 };

            //Define an obj array
            List<dynamic> listOfDynamicTypes = new List<dynamic>();
            for (int i = 1; i < 6; i++)
            {
                dynamic dynamicArray = new CustomizedDynamicObject();
                dynamicArray.f = i;
                dynamicArray.g = i.ToString();
                listOfDynamicTypes.Add(dynamicArray);
            }
            nestObj.objArray = listOfDynamicTypes;
            d.c = nestObj;


            //Do an implicit conversion
            string result = d;
            //Fetch the result
            Assert.AreEqual("{a:'a',b:1,c:{d:1,e:2,array:[1,2,3,4,5,6],objArray:[{f:1,g:'1'},{f:2,g:'2'},{f:3,g:'3'},{f:4,g:'4'},{f:5,g:'5'}]}}", result);
        }
    }
}
