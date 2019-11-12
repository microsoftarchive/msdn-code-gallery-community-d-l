using System;
using System.IO;
using Spring.Objects.Factory.Xml;

namespace DependencyInjectionWithSpringSample
{
    public interface IDomainObjectInterface
    {
        string Name
        {
            get;
        }
    }    
    public class ImplementationClass1 : IDomainObjectInterface
    {       
        public string Name
        {
            get
            {
                return "Implementation Class 1";
            }
        }
    }
    public class DependentClass
    {
        private string _message;
        public string Message
        {
            set 
            { 
                _message = value; 
            }
            get 
            { 
                return _message; 
            }
        }
    }
    public class ImplementationClass2 : IDomainObjectInterface
    {
        private DependentClass _dependentClass;   
        public DependentClass DependentClassToInject
        {
            get
            {
                return _dependentClass;
            }
            set
            {
                _dependentClass = value;
            }
        }
        public string Name
        {
            get
            {
                if (_dependentClass != null)
                    return _dependentClass.Message;
                else
                    return "Not Set";
            }
        }
    }   
	class Class1
	{
		[STAThread]
		static void Main()
		{
            IDomainObjectInterface IDomainObjectInterfaceObject = new ImplementationClass1();
            Console.WriteLine("My name is " + IDomainObjectInterfaceObject.Name);

            IDomainObjectInterfaceObject = new ImplementationClass2();
            Console.WriteLine("My name is " + IDomainObjectInterfaceObject.Name);

            Stream stream = new FileStream("config.xml", FileMode.Open, FileAccess.Read);
            Spring.Core.IO.InputStreamResource strm = new Spring.Core.IO.InputStreamResource(stream, "Test");
            XmlObjectFactory xmlObjectFactory = new XmlObjectFactory(strm);

            IDomainObjectInterfaceObject = (IDomainObjectInterface)xmlObjectFactory.GetObject("DomainObjectImplementationClass");
            Console.WriteLine("My name is " + IDomainObjectInterfaceObject.Name);

            Console.ReadLine();
		}
	}
}