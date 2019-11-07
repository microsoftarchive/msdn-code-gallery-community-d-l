using System;
using System.Collections.Generic;
using System.Windows.Input;


namespace CommandPatternDemo
{
    // Receiver - The main logic will be implemented here and it knows how to perform the necessary actions. 
    // In Restaurant scenario e.g. - The Cook 
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("The Main operations performed here. Receiver.Action()");
        }
    }

    // Command - Declares an interface/ abstract class for executing the operation(s). 
    // In Restaurant scenario e.g. - A single order or multiple orders stored in collection 
    abstract class Command
    {
        //A protected field that holds the Receiver that is linked to the command, which is usually set via a constructor.  
        protected Receiver receiver;

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    // ConcreteCommand - Defines a binding/link between a Receiver object and Receiver's action  
    // Extends the Command interface, Implements Execute method by invoking the corresponding operation(s) on Receiver 
    // In Restaurant scenario e.g. - Pizza Order, Burger Order etc 
    class ConcreteCommand : Command
    {
        // Constructor takes the linked Receiver object, the same receiver object (called linked receiver) might be used by other concrete commands which will be passed from client. 
        public ConcreteCommand(Receiver receiver)
            : base(receiver)
        {
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    // Invoker - Asks the command to carry out the request. 
    // Decides when the method should be called. 
    // In Restaurant scenario e.g. - The Waiter 
    class Invoker
    {
        private Command _commandObject;

        public void SetCommand(Command commandObject)
        {
            this._commandObject = commandObject;
        }

        public void ExecuteCommand()
        {
            _commandObject.Execute();
        }
    }

    // Client - Creates a ConcreteCommand object and sets its receiver. 
    // Instantiates the command object and provides the information required to call the method at a later time.  
    // In Restaurant scenario e.g. - The Customer 
    class Client
    {
        static void Main()
        {
            // Create receiver, command, and invoker  
            Receiver ReceiverObject = new Receiver();

            //Creates a ConcreteCommand object and sets its receiver 
            //Instantiates the command object and provides the information required to call the method at a later time.  
            Command CommandObject = new ConcreteCommand(ReceiverObject);

            // Invoker - Asks the command to carry out the request. 
            // Decides when the method should be called. 
            Invoker InvokerObject = new Invoker();
            InvokerObject.SetCommand(CommandObject);
            InvokerObject.ExecuteCommand();

            // Wait for user  
            Console.Read();
        }
    }
}