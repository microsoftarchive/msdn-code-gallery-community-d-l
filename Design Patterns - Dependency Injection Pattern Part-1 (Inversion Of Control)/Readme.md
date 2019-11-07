# Design Patterns - Dependency Injection Pattern Part-1 (Inversion Of Control)
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- .NET Framework
- .NET Framework 4.0
- Design Patterns
- Dependancy Injection
- Dependancy Injection Pattern
## Topics
- C#
- Architecture and Design
- Design Patterns
- Inversion of Control
- Dependancy Injection
- Spring.NET
- Dependancy Injection Pattern
## Updated
- 04/30/2013
## Description

<p><span style="color:#ff0000; font-size:small">Work In Progress -&nbsp;I am updating the content and samples parellel.</span></p>
<p><span style="color:#008000; font-size:medium">Targeted Audience:</span></p>
<p><span style="font-size:small">1.&nbsp;.NET Architects</span><br>
<span style="font-size:small">2.&nbsp;.NET Application Designers</span><br>
<span style="font-size:small">3.&nbsp;.NET Application Developers</span></p>
<p><span style="color:#008000; font-size:medium">Prerequisites:</span></p>
<p><span style="font-size:small">1.&nbsp;.Net technologies.</span><br>
<span style="font-size:small">2.&nbsp;Basic understanding of design patterns.</span><br>
<span style="font-size:small">3.&nbsp;Basic understanding of OOPS.</span><br>
<span style="font-size:small">4.&nbsp;Factories (Abstract Factory &amp; Factory Method).</span><br>
<span style="font-size:small">5.&nbsp;Container Pattern.</span><br>
<span style="font-size:small">6.&nbsp;SOLID principles. </span><span style="font-size:small">(Refer
<a href="http://gallery.technet.microsoft.com/OOPS-Principles-SOLID-017627d2">http://gallery.technet.microsoft.com/OOPS-Principles-SOLID-017627d2</a>)</span></p>
<p><span style="color:#008000; font-size:medium">Problem Statement:</span></p>
<p><span style="color:#808000; font-size:small"><img id="65389" src="65389-1.png" alt="" width="234" height="138"></span></p>
<p>&nbsp;</p>
<p><span style="color:#808000; font-size:small">Tight Coupling: (Compilation time)</span><br>
<span style="font-size:small">We have classes that have dependencies on services or components whose concrete type is specified at design time. In this example, ClassA has dependencies on ServiceA and ServiceB.</span></p>
<p><span style="color:#808000; font-size:small">This situation has the following problems:</span></p>
<p><span style="font-size:small">&bull;&nbsp;To replace or update the dependencies, we need to change the classes' source code.</span><br>
<span style="font-size:small">&bull;&nbsp;The concrete implementations of the dependencies have to be available at compile time.</span><br>
<span style="font-size:small">&bull;&nbsp;Classes are difficult to test in isolation because they have direct references to dependencies. I.e. dependencies cannot be replaced with stubs or mocks.</span><br>
<span style="font-size:small">&bull;&nbsp;Classes contain repetitive code for creating, locating, and managing their dependencies.</span><br>
<span style="font-size:small">&bull;&nbsp;Using Factories (Abstract Factory &amp; Factory Method) creates tight coupling and make application to re compile every time when there is any change in dependencies.</span></p>
<p><span style="color:#008000; font-size:medium">Solution:</span></p>
<p><span style="font-size:small"><img id="65390" src="65390-2.png" alt="" width="576" height="179"></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">1.&nbsp;Modular Programming - Loose Coupling&nbsp; (Run time)</span><br>
<span style="font-size:small">2.&nbsp;TDD (Test Driven Development)</span><br>
<span style="font-size:small">3.&nbsp;Follow the IoC Principle and use the Dependency Injection and Service Locator Patterns.</span></p>
<p><span style="color:#008000; font-size:medium">What is Inversion of Control (IoC)?</span><br>
<span style="font-size:small">&ldquo;Inversion&rdquo; refers to inverting or flipping the way we think about the program design in an object oriented way.</span><br>
<span style="font-size:small">Inversion of Control (IoC) is an object-oriented programming principle where the object coupling is bound at run time by an assembler object and is typically not known at compile time using static analysis.</span><br>
<span style="font-size:small">Many places it is also referred as Design Pattern, but here I would refer it as OOP principle.</span></p>
<p><span style="font-size:small">Refer OOPS SOLID Principles here <a href="http://gallery.technet.microsoft.com/OOPS-Principles-SOLID-017627d2">
http://gallery.technet.microsoft.com/OOPS-Principles-SOLID-017627d2</a></span></p>
<p><span style="font-size:small">In traditional programming, the flow of the business logic is determined by objects that are statically assigned to one another.
</span><br>
<span style="font-size:small">With Inversion of Control principle, the flow depends on the object graph that is instantiated by the assembler and is made possible by object interactions being defined through abstractions.
</span><br>
<span style="font-size:small">The binding process is achieved through dependency injection and service locator design patterns.</span></p>
<p><img id="65391" src="65391-2.png" alt="" width="576" height="179"></p>
<p><span style="font-size:small">Conceptual view of the Service Locator and Dependency Injection patterns
</span></p>
<p><span style="color:#008000; font-size:medium">IoC Implementation Ways:</span></p>
<p><span style="font-size:small">&bull;&nbsp;Using Dependency Injection (a constructor, property setter, an interface injection)</span><br>
<span style="font-size:small">&bull;&nbsp;Using a contextualized lookup</span><br>
<span style="font-size:small">&bull;&nbsp;Using a factory pattern</span><br>
<span style="font-size:small">&bull;&nbsp;Using a service locator pattern</span><br>
<span style="font-size:small">&bull;&nbsp;Using Unity Framework (Constructor, Property, Interface, Service Locator Injections)</span><br>
<span style="font-size:small">&bull;&nbsp;Using Prism Framework (Unity Framework &#43; MEF &#43; Other modular programming features)</span><br>
<span style="font-size:small">&bull;&nbsp;Using Spring.Net, Google Guice (Complicated implementations)</span></p>
<p><span style="color:#008000; font-size:medium">Dependency Injection Pattern:</span></p>
<p><span style="font-size:small">Do not instantiate the dependencies explicitly in the class.
</span><br>
<span style="font-size:small">Instead, declaratively express dependencies in the class definition.
</span><br>
<span style="font-size:small">The pattern seeks to establish a level of abstraction via a public interface and to remove dependencies on components by supplying 'plug-in' architecture. I.e. individual components are tied together by the architecture rather
 than being linked together themselves. </span><br>
<span style="font-size:small">Use a Builder object to obtain valid instances of the object's dependencies and pass them to the object during the object's creation and/or initialization. As shown below.</span></p>
<p>&nbsp;</p>
<p><img id="65392" src="65392-3.png" alt="" width="301" height="143"></p>
<p><span style="font-size:small">Conceptual view of the Dependency Injection pattern
</span></p>
<p><span style="color:#008000; font-size:medium">Main forms of dependency injection are:</span></p>
<p><span style="font-size:medium"><span style="color:#008000">Constructor injection:</span></span></p>
<p><span style="font-size:small">We use parameters of the object's constructor method to inject it with its dependencies.
</span><br>
<span style="font-size:small">Is based on the approach where the interface parameter which is referenced internally inside the class is been exposed through the constructor.</span></p>
<p><span style="color:#008000; font-size:medium">Setter injection:</span></p>
<p><span style="font-size:small">The object exposes setter properties that the builder uses to pass the dependencies to it during object initialization.</span><br>
<span style="font-size:small">It is enabling the injection of the interface implementation through the public property with set block.
</span><br>
<span style="font-size:small">It is basically approach trying to cover the downsides of constructor based approach.
</span><br>
<span style="font-size:small">A technique which is a kind of explicit defined setter type DI.
</span><br>
<span style="font-size:small">The object which would use the interface property has to support interface which defines the method which sets the interface property.</span></p>
<p><span style="color:#008000; font-size:medium">Components of Dependency Injection:</span></p>
<p><span style="font-size:small">1.&nbsp;A dependent consumer.</span><br>
<span style="font-size:small">The dependent object describes what software component it depends on to do its work.
</span><br>
<span style="font-size:small">2.&nbsp;Interface contracts.</span><br>
<span style="font-size:small">Declaration of the component's dependencies.</span><br>
<span style="font-size:small">3.&nbsp;An injector (Also referred as a provider or container)
</span><br>
<span style="font-size:small">Creates instances of classes that implement a given dependency interface on request.</span><br>
<span style="font-size:small">The injector decides what concrete classes satisfy the requirements of the dependent object, and provides them to the dependent.
</span></p>
<div class="endscriptcode"><span style="color:#008000; font-size:medium">A Simple example with Spring.NET:</span></div>
<div class="endscriptcode"><span style="color:#800000; font-size:small">&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#800000; font-size:small">If you are more interested&nbsp;in&nbsp;Dependency Injection with Unity Application Blocks, skip the below example and move to
<a href="http://code.msdn.microsoft.com/Dependency-Injection-with-d9222c2f">http://code.msdn.microsoft.com/Dependency-Injection-with-d9222c2f</a>&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#808000; font-size:small">Step1: Add Spring.NET reference to the new console application:</span></div>
<div class="endscriptcode"><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#808000; font-size:small"><img id="67770" src="67770-2.png" alt="" width="282" height="287"></span></div>
<div class="endscriptcode"><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#808000; font-size:small">Step2: Add required configuration to Config.xml as shown below:</span><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
&lt;objects xmlns=&quot;http://www.springframework.net&quot;&gt;
	
  &lt;object name=&quot;DomainObjectImplementationClass&quot; 
			singleton=&quot;false&quot; 
			type=&quot;DependencyInjectionWithSpringSample.ImplementationClass2, DependencyInjectionWithSpringSample&quot;&gt;
	
    &lt;property name=&quot;DependentClassToInject&quot;&gt;
      
			&lt;ref object=&quot;DomainObjectDependentClass&quot;/&gt;
      
		&lt;/property&gt;		
    
	&lt;/object&gt;
	
  &lt;object name=&quot;DomainObjectDependentClass&quot; 
			singleton=&quot;false&quot; 
			type=&quot;DependencyInjectionWithSpringSample.DependentClass, DependencyInjectionWithSpringSample&quot;&gt;
		
    &lt;property name=&quot;Message&quot;&gt;
      &lt;value&gt;Dependent Class - Message Property Value Injected by Spring.NET XML Configuration&lt;/value&gt;
    &lt;/property&gt;
    
	&lt;/object&gt;
	
&lt;/objects&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;?xml</span>&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;utf-8&quot;</span>&nbsp;<span class="xml__tag_start">?&gt;</span>&nbsp;
<span class="xml__tag_start">&lt;objects</span>&nbsp;<span class="xml__attr_name">xmlns</span>=<span class="xml__attr_value">&quot;http://www.springframework.net&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;object</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;DomainObjectImplementationClass&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">singleton</span>=<span class="xml__attr_value">&quot;false&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;DependencyInjectionWithSpringSample.ImplementationClass2,&nbsp;DependencyInjectionWithSpringSample&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;property</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;DependentClassToInject&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;ref</span>&nbsp;<span class="xml__attr_name">object</span>=<span class="xml__attr_value">&quot;DomainObjectDependentClass&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/property&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/object&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;object</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;DomainObjectDependentClass&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">singleton</span>=<span class="xml__attr_value">&quot;false&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;DependencyInjectionWithSpringSample.DependentClass,&nbsp;DependencyInjectionWithSpringSample&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;property</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;Message&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;value</span><span class="xml__tag_start">&gt;</span>Dependent&nbsp;Class&nbsp;-&nbsp;Message&nbsp;Property&nbsp;Value&nbsp;Injected&nbsp;by&nbsp;Spring.NET&nbsp;XML&nbsp;Configuration<span class="xml__tag_end">&lt;/value&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/property&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/object&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="xml__tag_end">&lt;/objects&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Step3: Write the C# code in .cs file as shown below.</span>&nbsp;</div>
<div class="endscriptcode"><span style="color:#808000; font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">sing System;
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
                return &quot;Implementation Class 1&quot;;
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
                    return &quot;Not Set&quot;;
            }
        }
    }   
	class Class1
	{
		[STAThread]
		static void Main()
		{
            IDomainObjectInterface IDomainObjectInterfaceObject = new ImplementationClass1();
            Console.WriteLine(&quot;My name is &quot; &#43; IDomainObjectInterfaceObject.Name);

            IDomainObjectInterfaceObject = new ImplementationClass2();
            Console.WriteLine(&quot;My name is &quot; &#43; IDomainObjectInterfaceObject.Name);

            Stream stream = new FileStream(&quot;config.xml&quot;, FileMode.Open, FileAccess.Read);
            Spring.Core.IO.InputStreamResource strm = new Spring.Core.IO.InputStreamResource(stream, &quot;Test&quot;);
            XmlObjectFactory xmlObjectFactory = new XmlObjectFactory(strm);

            IDomainObjectInterfaceObject = (IDomainObjectInterface)xmlObjectFactory.GetObject(&quot;DomainObjectImplementationClass&quot;);
            Console.WriteLine(&quot;My name is &quot; &#43; IDomainObjectInterfaceObject.Name);

            Console.ReadLine();
		}
	}
}</pre>
<div class="preview">
<pre class="csharp">sing&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spring.Objects.Factory.Xml;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;DependencyInjectionWithSpringSample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IDomainObjectInterface&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ImplementationClass1&nbsp;:&nbsp;IDomainObjectInterface&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;Implementation&nbsp;Class&nbsp;1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DependentClass&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;_message;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Message&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_message&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_message;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ImplementationClass2&nbsp;:&nbsp;IDomainObjectInterface&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;DependentClass&nbsp;_dependentClass;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DependentClass&nbsp;DependentClassToInject&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_dependentClass;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_dependentClass&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_dependentClass&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_dependentClass.Message;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;Not&nbsp;Set&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Class1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[STAThread]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IDomainObjectInterface&nbsp;IDomainObjectInterfaceObject&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ImplementationClass1();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;My&nbsp;name&nbsp;is&nbsp;&quot;</span>&nbsp;&#43;&nbsp;IDomainObjectInterfaceObject.Name);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IDomainObjectInterfaceObject&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ImplementationClass2();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;My&nbsp;name&nbsp;is&nbsp;&quot;</span>&nbsp;&#43;&nbsp;IDomainObjectInterfaceObject.Name);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stream&nbsp;stream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FileStream(<span class="cs__string">&quot;config.xml&quot;</span>,&nbsp;FileMode.Open,&nbsp;FileAccess.Read);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Spring.Core.IO.InputStreamResource&nbsp;strm&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Spring.Core.IO.InputStreamResource(stream,&nbsp;<span class="cs__string">&quot;Test&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XmlObjectFactory&nbsp;xmlObjectFactory&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XmlObjectFactory(strm);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IDomainObjectInterfaceObject&nbsp;=&nbsp;(IDomainObjectInterface)xmlObjectFactory.GetObject(<span class="cs__string">&quot;DomainObjectImplementationClass&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;My&nbsp;name&nbsp;is&nbsp;&quot;</span>&nbsp;&#43;&nbsp;IDomainObjectInterfaceObject.Name);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</span></div>
<div class="endscriptcode"><span style="color:#808000; font-size:small">Step4: Run the application and verify the output.</span></div>
<div class="endscriptcode"><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#008000; font-size:medium"><img id="67769" src="67769-1.png" alt="" width="677" height="343"></span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="color:#000000; font-size:small"><strong>Part 2:
</strong>Continue reading&nbsp;about implementing Dependency Injection with Unity Application Blocks&nbsp;here&nbsp;<a href="http://code.msdn.microsoft.com/Dependency-Injection-with-d9222c2f">http://code.msdn.microsoft.com/Dependency-Injection-with-d9222c2f</a>&nbsp;&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#000000; font-size:small">&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#000000; font-size:small"><span style="color:#000000; font-size:small">Thank you for reading my article. Drop all your questions/comments in QA tab give me your feedback with
<span style="color:#3366ff"><img id="67168" src="67168-ratings.png" alt="" width="74" height="15">
<span style="color:#000000">star rating (1 Star - Very Poor, 5&nbsp;Star -&nbsp;Very Good).
</span></span></span>
<div class="endscriptcode"><span style="color:#3366ff">&nbsp;</span></div>
<div class="endscriptcode"><span style="color:#808000; font-size:small">Visit my all other articles here
<a href="http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&f%5B0%5D.Value=Srigopal%20Chitrapu">
http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&amp;f%5B0%5D.Value=Srigopal%20Chitrapu</a></span></div>
</span></div>
<div class="endscriptcode"><span style="color:#808000; font-size:small">&nbsp;</span></div>
