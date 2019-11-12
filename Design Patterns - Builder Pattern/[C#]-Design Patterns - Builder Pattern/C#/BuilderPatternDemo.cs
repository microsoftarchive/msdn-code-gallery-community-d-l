using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderPatternDemo
{
    // Product - The main object that will be created by the Director using Builder
    public class Pizza
    {
        public string Sauce = string.Empty;
        public string Topping = string.Empty;
    }

    // Builder - Abstract interface for creating objects (the product)
    abstract class PizzaBuilder
    {
        protected Pizza pizza;

        public Pizza GetPizza()
        {
            return pizza;
        }

        public void CreateNewPizzaProduct()
        {
            pizza = new Pizza();
        }

        public abstract void BuildSauce();
        public abstract void BuildTopping();
    }
    
    // Concrete Builder - Provides implementation for Builder; An object able to construct other objects.
    // Constructs and assembles parts to build the objects
    class ChesePizzaBuilder : PizzaBuilder
    {
        public override void BuildSauce()
        {
            pizza.Sauce = "Chese";
        }

        public override void BuildTopping()
        {
            pizza.Topping = "Green Pepper";
        }
    }
    // Concrete Builder - Provides implementation for Builder; An object able to construct other objects.
    // Constructs and assembles parts to build the objects
    class SpicyPizzaBuilder : PizzaBuilder
    { 
        public override void BuildSauce()
        {
            pizza.Sauce = "Hot Sauce";
        }

        public override void BuildTopping()
        {
            pizza.Topping = "Red Pepper , Jalapeno";
        }
    }

    // Director - Responsible for managing the correct sequence of object creation.
    // Receives a Concrete Builder as a parameter and performs the necessary operations on it.
    class Cook
    {
        private PizzaBuilder _pizzaBuilderObject;
        
        // Step 1. Construct the builder object for the given concrete object
        public void SetPizzaBuilder(PizzaBuilder pizzaBuilderObject)
        {
            _pizzaBuilderObject = pizzaBuilderObject;
        }
        
        // Step 2. Call required methods from the builder class
        // Step 3. Call required methods from the concrete builder classes
        public void ConstructPizza()
        {
            //Calling builder object's method.
            _pizzaBuilderObject.CreateNewPizzaProduct();
            
            //Calling Concrete object's methods.
            _pizzaBuilderObject.BuildSauce();
            _pizzaBuilderObject.BuildTopping();
        }
        
        // Step 4. Return the product after creating it based on the builder and concrete objects.
        public Pizza GetPizza()
        {
            return _pizzaBuilderObject.GetPizza();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Create an instance for Builder and initialize with Concrete builder - ChesePizzaBuilder.
            PizzaBuilder chesePizzaBuilder = new ChesePizzaBuilder();

            // 2. Create an instance for Director.
            Cook cook = new Cook();
                        
            // 3. By using Director instance, call the concrete object methods.
            cook.SetPizzaBuilder(chesePizzaBuilder);
            cook.ConstructPizza();
            
            // 4. Create and get the product, by using the Director.
            Pizza chesePizzaProduct = cook.GetPizza();

            // 5. Deliver the product.
            Console.WriteLine("Chese Pizza prepared by using " + chesePizzaProduct.Topping + " and " + chesePizzaProduct.Sauce);

            // 1. Create an instance for Builder and initialize with Concrete builder - SpicyPizzaBuilder.
            PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();

            // 2. Use same Director instance.
            // 3. And pass the new concrete Builder instance.
            cook.SetPizzaBuilder(spicyPizzaBuilder);
            cook.ConstructPizza();

            // 4. Create and get the product, by using the Director.
            Pizza spicyPizzaProduct = cook.GetPizza();

            // 5. Deliver the product.
            Console.WriteLine("Spicy Pizza prepared by using " + spicyPizzaProduct.Topping + " and " + spicyPizzaProduct.Sauce);

            Console.ReadLine();
        }
    }
}