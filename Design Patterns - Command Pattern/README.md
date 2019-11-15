# Design Patterns - Command Pattern
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Silverlight
- ASP.NET
- Windows Forms
- WPF
- ASP.NET Web Forms
- Prism
- Unity
- Windows RT
## Topics
- Silverlight
- WPF
- Prism
- Design Patterns
- Command Pattern
## Updated
- 04/30/2013
## Description

<div><span style="color:#008000; font-size:medium"><span style="color:#800000; font-size:small">Work In Progress - I am still updating the content and samples parellel.</span></span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Problem Statement:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1. Need to issue requests to objects without knowing anything about the operation being requested or the receiver of the request (who receives the request and perform the necessary action).
</span><br>
<span style="font-size:small">2. Want to implement Redo/Undo, Previous/Next, Push/Pop and Copy/Paste operations based on the user request.</span><br>
<span style="font-size:small">3. Want an object-oriented callback. </span><br>
<span style="font-size:small">4. Want to allow the parameterization of clients with different requests.</span><br>
<span style="font-size:small">5. Want to allow saving the requests in a queue.</span><br>
<span style="font-size:small">6. Want to implement Sell/Buy Stocks or trades functionality.</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Solution:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">Instead of sending the request and required parameters directly to the receiver (who receives the request and perform the necessary action), store the request and required parameters in another object (command object) and
 let that object (command object) or the other object (Invoker) decide when and what time to pass to receiver.
</span><br>
<span style="font-size:small">So that the command may be executed immediately or use it later.</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">OR</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">Decouple the client from the request(s) as well as the object that will be handling the request.</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">OR</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">Encapsulate a request in an object. </span><br>
<span style="font-size:small">By encapsulating the request we gain the following support if needed:</span><br>
<span style="font-size:small">&bull;&nbsp;Redo and Undo operations. </span><br>
<span style="font-size:small">&bull;&nbsp;Requests can be stored in queue and executed when needed.
</span><br>
<span style="font-size:small">&bull;&nbsp;Requests can be logged.</span><br>
<span style="font-size:small">&bull;&nbsp;Composition of transactions inside an object that include the transaction atomic operations.</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Command Pattern:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">Decouple the &lsquo;object that invokes the operation&rsquo; from the &lsquo;object that knows how to perform it&rsquo;. This implementation also called as Producer - Consumer design pattern.</span></div>
<div><span style="font-size:small">&bull;&nbsp;The command pattern is used to express a request, including the call to be made and all of its required parameters, in a command object</span><br>
<span style="font-size:small">&bull;&nbsp;The command object does not contain the functionality that is to be executed.</span><br>
<span style="font-size:small">&bull;&nbsp;It contains only the information required to perform an action.
</span><br>
<span style="font-size:small">&bull;&nbsp;The main functionality is contained within receiver objects.
</span><br>
<span style="font-size:small">&bull;&nbsp;This removes the direct link between the command definitions and the functionality, promoting loose coupling.
</span><br>
<span style="font-size:small">&bull;&nbsp;Use another object called Invoker, for controlling and determining the time of execution of the command.</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">When to use Command Pattern?</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">The command pattern is more useful when application requires series of requests (store them in command object) to the same object.</span></div>
<div><span style="font-size:small">&nbsp;The command objects can be held in a queue and processed sequentially. If each command is stored on a stack after it is executed, and if the commands are reversible, this allows the implementation of a rollback or multi-level
 undo facility.</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Command Pattern Principle:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">&bull;&nbsp;The command object does not contain the main logic/functionality that is to be executed.</span><br>
<span style="font-size:small">&bull;&nbsp;Command object contains only the information required to perform an action.
</span><br>
<span style="font-size:small">&bull;&nbsp;The main logic/functionality is contained within receiver objects.</span></div>
<div><span style="font-size:small">&bull;&nbsp;Interface separation (the invoker is isolated from the receiver).</span><br>
<span style="font-size:small">&bull;&nbsp;Time separation (stores a ready-to-go processing request that&rsquo;s to be stated later).</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><strong><span style="font-size:small">Note:</span></strong></div>
<div><span style="font-size:small">1. Should not use command just as a link between the receiver and the actions that carry out the request.</span><br>
<span style="font-size:small">2. Do not implement everything in the command itself, without sending anything to the receiver.</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Command Pattern Terms:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">Command (Command &ndash; Request or Collection of Requests)</span><br>
<span style="font-size:small">&bull;&nbsp;Declares an interface/ abstract class for executing the operation(s)</span><br>
<span style="font-size:small">&bull;&nbsp;It defines a protected field that holds the Receiver that is linked to the command, which is usually set via a constructor.
</span><br>
<span style="font-size:small">&bull;&nbsp;The class also defines an abstract method that is used by the Invoker to execute commands.</span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">ConcreteCommand (Optional)</span><br>
<span style="font-size:small">&bull;&nbsp;Defines a binding/link between a Receiver object and receiver&rsquo;s action
</span><br>
<span style="font-size:small">&bull;&nbsp;Extends the Command interface, Implements Execute method by invoking the corresponding operation(s) on Receiver</span><br>
<span style="font-size:small">&bull;&nbsp;Concrete command classes are subclasses of Command. In addition to implementing the Execute method, they contain all of the information that is required to correctly perform the action using the linked Receiver object.</span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">Client (Application)</span><br>
<span style="font-size:small">&bull;&nbsp;Creates a Command or ConcreteCommand object and sets/links the receiver.</span><br>
<span style="font-size:small">&bull;&nbsp;Also provides all the necessary information required to call the method at a later time.</span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">Invoker (Controls the request - Optional)</span><br>
<span style="font-size:small">&bull;&nbsp;It initiates the execution of commands and asks the command to carry out the request.</span><br>
<span style="font-size:small">&bull;&nbsp;Decides when the method should be called.</span><br>
<span style="font-size:small">&bull;&nbsp;The invoker could be controlled by the Client object. However, the invoker may be disconnected from the client. For example, the client could create a queue of commands that are executed periodically by a timed event.</span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">Receiver (Target of the request)</span><br>
<span style="font-size:small">&bull;&nbsp;The main logic will be implemented here and it knows how to perform the necessary actions.</span><br>
<span style="font-size:small">&bull;&nbsp;It contains the methods that are executed when one or more commands are invoked.
</span><br>
<span style="font-size:small">&bull;&nbsp;This allows the actual functionality to be held separately to the Command definitions.</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">How Command Patter Works?</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">1.&nbsp;When the application (client) has to perform a command, it creates the command and sent it to the invoker.
</span><br>
<span style="font-size:small">2.&nbsp;The Invoker takes the command and places it in a queue, and it calls the execute method of the command and adds it to a list containing all the commands.
</span><br>
<span style="font-size:small">3.&nbsp;The execute method of the command delegate the call to the receiver object.
</span><br>
<span style="font-size:small">4.&nbsp;When undo operations are performed the invoker uses the list with all executed commands and calls for each one the unexecuted method. The redo operation works in the same manner.</span><br>
<span style="font-size:small">5.&nbsp;The ConcreteCommand (optional) that is in charge of the requested command sending its result to the Receiver.</span></div>
<div><span style="font-size:small"><span style="color:#008000; font-size:medium">
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium"><img id="65899" src="http://i1.gallery.technet.s-msft.com/design-patterns-command-1d009834/image/file/65899/1/2.png" alt="" width="557" height="353">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Command Pattern Implementation Example:</span></div>
<div>&nbsp;</div>
<div><span style="color:#000000; font-size:small">For E.g In a restaurant scenario, the waiter (Invoker) takes the order from the customer on his pad.
</span></div>
<div><span style="color:#000000; font-size:small">The order is then queued for the order cook and gets to the cook (Receiver) where it is processed.</span></div>
<div><span style="color:#000000; font-size:small">Refer the code comments below and follow the steps.</span></div>
</span></span></div>
<p><span style="font-size:small"><span style="color:#008000; font-size:medium">&nbsp;</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Input.aspx" target="_blank" title="Auto generated link to System.Windows.Input">System.Windows.Input</a>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;CommandPatternDemo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Receiver&nbsp;-&nbsp;The&nbsp;main&nbsp;logic&nbsp;will&nbsp;be&nbsp;implemented&nbsp;here&nbsp;and&nbsp;it&nbsp;knows&nbsp;how&nbsp;to&nbsp;perform&nbsp;the&nbsp;necessary&nbsp;actions.&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;In&nbsp;Restaurant&nbsp;scenario&nbsp;e.g.&nbsp;-&nbsp;The&nbsp;Cook&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Receiver&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Action()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;The&nbsp;Main&nbsp;operations&nbsp;performed&nbsp;here.&nbsp;Receiver.Action()&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Command&nbsp;-&nbsp;Declares&nbsp;an&nbsp;interface/&nbsp;abstract&nbsp;class&nbsp;for&nbsp;executing&nbsp;the&nbsp;operation(s).&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;In&nbsp;Restaurant&nbsp;scenario&nbsp;e.g.&nbsp;-&nbsp;A&nbsp;single&nbsp;order&nbsp;or&nbsp;multiple&nbsp;orders&nbsp;stored&nbsp;in&nbsp;collection&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">abstract</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Command&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//A&nbsp;protected&nbsp;field&nbsp;that&nbsp;holds&nbsp;the&nbsp;Receiver&nbsp;that&nbsp;is&nbsp;linked&nbsp;to&nbsp;the&nbsp;command,&nbsp;which&nbsp;is&nbsp;usually&nbsp;set&nbsp;via&nbsp;a&nbsp;constructor.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;Receiver&nbsp;receiver;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Command(Receiver&nbsp;receiver)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.receiver&nbsp;=&nbsp;receiver;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">abstract</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Execute();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ConcreteCommand&nbsp;-&nbsp;Defines&nbsp;a&nbsp;binding/link&nbsp;between&nbsp;a&nbsp;Receiver&nbsp;object&nbsp;and&nbsp;Receiver's&nbsp;action&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Extends&nbsp;the&nbsp;Command&nbsp;interface,&nbsp;Implements&nbsp;Execute&nbsp;method&nbsp;by&nbsp;invoking&nbsp;the&nbsp;corresponding&nbsp;operation(s)&nbsp;on&nbsp;Receiver&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;In&nbsp;Restaurant&nbsp;scenario&nbsp;e.g.&nbsp;-&nbsp;Pizza&nbsp;Order,&nbsp;Burger&nbsp;Order&nbsp;etc&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;ConcreteCommand&nbsp;:&nbsp;Command&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Constructor&nbsp;takes&nbsp;the&nbsp;linked&nbsp;Receiver&nbsp;object,&nbsp;the&nbsp;same&nbsp;receiver&nbsp;object&nbsp;(called&nbsp;linked&nbsp;receiver)&nbsp;might&nbsp;be&nbsp;used&nbsp;by&nbsp;other&nbsp;concrete&nbsp;commands&nbsp;which&nbsp;will&nbsp;be&nbsp;passed&nbsp;from&nbsp;client.&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ConcreteCommand(Receiver&nbsp;receiver)&nbsp;:&nbsp;<span class="cs__keyword">base</span>(receiver)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Execute()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;receiver.Action();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Invoker&nbsp;-&nbsp;Asks&nbsp;the&nbsp;command&nbsp;to&nbsp;carry&nbsp;out&nbsp;the&nbsp;request.&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Decides&nbsp;when&nbsp;the&nbsp;method&nbsp;should&nbsp;be&nbsp;called.&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;In&nbsp;Restaurant&nbsp;scenario&nbsp;e.g.&nbsp;-&nbsp;The&nbsp;Waiter&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Invoker&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Command&nbsp;_commandObject;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SetCommand(Command&nbsp;commandObject)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>._commandObject&nbsp;=&nbsp;commandObject;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ExecuteCommand()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_commandObject.Execute();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Client&nbsp;-&nbsp;Creates&nbsp;a&nbsp;ConcreteCommand&nbsp;object&nbsp;and&nbsp;sets&nbsp;its&nbsp;receiver.&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Instantiates&nbsp;the&nbsp;command&nbsp;object&nbsp;and&nbsp;provides&nbsp;the&nbsp;information&nbsp;required&nbsp;to&nbsp;call&nbsp;the&nbsp;method&nbsp;at&nbsp;a&nbsp;later&nbsp;time.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;In&nbsp;Restaurant&nbsp;scenario&nbsp;e.g.&nbsp;-&nbsp;The&nbsp;Customer&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Client&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;receiver,&nbsp;command,&nbsp;and&nbsp;invoker&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Receiver&nbsp;ReceiverObject&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Receiver();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Creates&nbsp;a&nbsp;ConcreteCommand&nbsp;object&nbsp;and&nbsp;sets&nbsp;its&nbsp;receiver&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Instantiates&nbsp;the&nbsp;command&nbsp;object&nbsp;and&nbsp;provides&nbsp;the&nbsp;information&nbsp;required&nbsp;to&nbsp;call&nbsp;the&nbsp;method&nbsp;at&nbsp;a&nbsp;later&nbsp;time.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Command&nbsp;CommandObject&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ConcreteCommand(ReceiverObject);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Invoker&nbsp;-&nbsp;Asks&nbsp;the&nbsp;command&nbsp;to&nbsp;carry&nbsp;out&nbsp;the&nbsp;request.&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Decides&nbsp;when&nbsp;the&nbsp;method&nbsp;should&nbsp;be&nbsp;called.&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Invoker&nbsp;InvokerObject&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Invoker();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InvokerObject.SetCommand(CommandObject);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InvokerObject.ExecuteCommand();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Wait&nbsp;for&nbsp;user&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Read();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small"><span style="color:#008000; font-size:medium">Related Patterns:
</span>(Will be&nbsp;explained in detail in their respective articles later)</span></div>
<p>&nbsp;<span style="color:#808000; font-size:small">Composite Pattern:</span></p>
<div><span style="font-size:small">For adding new commands to the application we can use the composite pattern to group existing commands in another new command called Composite commands</span><br>
<span style="font-size:small">This way, macros can be created from existing commands.</span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">Chain of Responsibility Pattern:</span></div>
<div><span style="font-size:small">&bull;&nbsp;Chain of Responsibility, Command, Mediator, and Observer, address how we can decouple senders and receivers, but with different trade-offs.
</span><br>
<span style="font-size:small">&bull;&nbsp;Command normally specifies a sender-receiver connection with a subclass.</span><br>
<span style="font-size:small">&bull;&nbsp;Chain of Responsibility can use Command to represent requests as objects.</span></div>
<div><span style="color:#808000; font-size:small">&nbsp;</span></div>
<div><span style="color:#808000; font-size:small">Memento Pattern:</span></div>
<div><span style="font-size:small">&bull;&nbsp;Command and Memento act as magic tokens to be passed around and invoked at a later time.
</span><br>
<span style="font-size:small">&bull;&nbsp;In Command, the token represents a request; in Memento, it represents the internal state of an object at a particular time.
</span><br>
<span style="font-size:small">&bull;&nbsp;Polymorphism is important to Command, but not to Memento because its interface is so narrow that a memento can only be passed as a value.</span><br>
<span style="font-size:small">&bull;&nbsp;Command can use Memento to maintain the state required for an undo operation.</span><br>
<span style="font-size:small">&bull;&nbsp;A Command that must be copied before being placed on a history list acts as a Prototype.</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Advantages of Command Pattern:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">Queue up requests for action at a later time.</span><br>
<span style="font-size:small">Create a log of requests, for possible re-application after returning the system to a backup check point following a crash</span><br>
<span style="font-size:small">Bundle up a series of plodding detailed requests into a larger transaction (macro) that makes the business intention clearer from the client's perspective</span><br>
<span style="font-size:small">Flexibility where we can provide some runtime configuration to the commands which are issued</span><br>
<span style="font-size:small">Transfer of the command to a different process for handling</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Reference Links:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small"><a href="http://en.wikipedia.org/wiki/Command_pattern">http://en.wikipedia.org/wiki/Command_pattern</a>
</span><br>
<span style="font-size:small"><a href="http://blogs.microsoft.co.il/blogs/gilf/archive/2008/06/23/command-pattern.aspx">http://blogs.microsoft.co.il/blogs/gilf/archive/2008/06/23/command-pattern.aspx</a></span><br>
<span style="font-size:small"><a href="http://sourcemaking.com/design_patterns/command">http://sourcemaking.com/design_patterns/command</a></span><br>
<span style="font-size:small"><a href="http://sourcemaking.com/design_patterns/command/c%2523">http://sourcemaking.com/design_patterns/command/c%2523</a></span><br>
<span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/system.windows.input.navigationcommands.aspx">http://msdn.microsoft.com/en-us/library/system.windows.input.navigationcommands.aspx</a></span><br>
<span style="font-size:small"><a href="http://www.oodesign.com/command-pattern.html">http://www.oodesign.com/command-pattern.html</a></span><br>
<span style="font-size:small"><a href="http://www.codeproject.com/Articles/186192/Command-Design-Pattern">http://www.codeproject.com/Articles/186192/Command-Design-Pattern</a></span></div>
<div>&nbsp;</div>
<div><span style="color:#008000; font-size:medium">Different Types of Commands:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">ApplicationCommands - Cut, Copy, and Paste.</span><br>
<span style="font-size:small">EditingCommands &ndash; Toggle Bold, Italic and decrease/increase Font Size.</span><br>
<span style="font-size:small">NavigationCommands &ndash; Previous/Next Page and Search.</span><br>
<span style="font-size:small">MediaCommands &ndash; Play, pause, increase/decrease volume.</span><br>
<span style="font-size:small">ComponentCommands - These commands have a lot in common with some of the other libraries like NavigationCommands and EditingCommands since they include things like MoveDown and ExtendSelectionLeft.</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Command Pattern used in WPF:</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">WPF introduces routed commands, which combine the command pattern with event processing. As a result the command object no longer contains a reference to the target object nor a reference to the application code. Instead,
 invoking the command object's execute command results in a (so called Executed Routed Event) which during the event's tunneling or bubbling may encounter a (so called binding) object which identifies the target and the application code, which is executed at
 that point.</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="color:#008000; font-size:medium">Few WPF Commands in <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Input.aspx" target="_blank" title="Auto generated link to System.Windows.Input">System.Windows.Input</a> Namespace</span></div>
<div><span style="font-size:small">&nbsp;</span></div>
<div><span style="font-size:small">NavigationCommands</span><br>
<span style="font-size:small">MediaCommands </span><br>
<span style="font-size:small">ApplicationCommands </span><br>
<span style="font-size:small">ComponentCommands </span><br>
<span style="font-size:small">EditingCommands </span><br>
<span style="font-size:small">RoutedCommand </span><br>
<span style="font-size:small">RoutedUICommand</span></div>
<div><span style="color:#008000; font-size:medium">&nbsp;</span></div>
<div><span style="font-size:small">Read more about WPF Routed Events at <a href="http://code.msdn.microsoft.com/WPFSilverlight-Routed-49a16914">
http://code.msdn.microsoft.com/WPFSilverlight-Routed-49a16914</a></span></div>
<div><span style="font-size:small">Read more about WPF Routed Commands at <a href="http://code.msdn.microsoft.com/WPFSilverlight-Routed-d0defafe">
http://code.msdn.microsoft.com/WPFSilverlight-Routed-d0defafe</a>&nbsp; </span></div>
<div class="endscriptcode">
<div class="endscriptcode">
<div class="endscriptcode">&nbsp;
<div class="endscriptcode"></div>
<span style="color:#0000ff; font-size:small"><span style="color:#000000; font-size:small">
<div class="endscriptcode"><span style="color:#000000; font-size:small">Thank you for reading my article. Drop all your questions/comments in QA tab give me your feedback with
<span style="color:#3366ff"><img id="67168" src="http://i1.code.msdn.s-msft.com/oops-principles-solid-7a4e69bf/image/file/67168/1/ratings.png" alt="" width="74" height="15">
<span style="color:#000000">star rating (1 Star - Very Poor, 5&nbsp;Star -&nbsp;Very Good).
</span></span></span></div>
<div class="endscriptcode"><span style="color:#3366ff">&nbsp;</span></div>
</span>
<div class="endscriptcode"><span style="color:#808000; font-size:small">Visit my all other articles here
<a href="http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&f%5B0%5D.Value=Srigopal%20Chitrapu">
http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=User&amp;f%5B0%5D.Value=Srigopal%20Chitrapu</a></span></div>
</span></div>
</div>
</div>
<div></div>
<div>&nbsp;&nbsp;</div>
