# Implementing Drag and Drop in Windows Forms with C#
## Requires
- Visual Studio 2002
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
## Topics
- Drag and Drop
## Updated
- 08/23/2011
## Description

<h1>Introduction</h1>
<p>This sample application demonstrates the implementation of drag and drop in a Windows Application. Although simple drag and drop functionality is fairly easy to implement in C#, this sample demonstrates how to add more sophisticated functionality, such as
 using context menus in a DragDrop event handler to give users a list of possible actions. This sample should give developers coming from a Visual Basic background who are accustomed to implementing drag and drop using the Automatic DropMode a jump start, bringing
 them up to speed quickly on the somewhat more manual approach required in C#.</p>
<ul>
</ul>
<h1>How to Use this Sample Application</h1>
<p class="Text">In order to run this sample application, run the self-extracting archive to install the sample files and then double-click the DragDrop.sln file in the Code subdirectory to open the solution in the Visual Studio .NET development environment.</p>
<p class="Text">Click the Start button on the Toolbar or press the F5 key to run the application. Click on the TextBox, NumericUpDown, or DateTimePicker controls on the left side of the screen and drag them onto the ListBox control on the right. As you drag
 the mouse over the ListBox, the RichTextBox control on the left displays information about the pending operation to demonstrate some of the data available to developers in these events. Experiment with dragging data with and without the CTRL key pressed, and
 also by dragging with the right mouse button.</p>
<h1>Description</h1>
<p class="Text">Unlike Visual Basic 6.0, which supported the concept of an Automatic DragMode on most controls, C# depends on the developer to initiate a drag event using code in the MouseDown event of the source control. This generally requires only one
 or two lines of code, and provides a lot of flexibility in determining how drag and drop operations should be handled. Any data required to process dropped data in the target control can be recorded and types of operations on that data permitted, such as Copy
 or Move, can be specified at that time. The code in the MouseDown events of the three source controls in this example (textBox1, numericUpDown1, and dateTimePicker1) is almost identical. In these events, a reference is set to the control that initiated the
 drag, as is a variable to indicate which mouse button was used. At that point, the DoDrag method is called to actually begin the drag operation, specifying the data to be dragged and the types of operations to be allowed as parameters.</p>
<p class="Text">Once the drag operation is initiated by a source control, potential target controls have to be able to respond. The first step in this process is to configure a target control to allow drops by setting the AllowDrop property to true. At this
 point, the control will raise events to notify the developer when a drop operation is being attempted over that control. (In the DragDrop sample, the listBox1 control is configured as a DragDrop target.) The first event raised on a target control is the DragEnter
 event, which is responsible for determining if a drop will be allowed. This decision is normally based on one or more factors, such as the type of data available to be dropped and the type of effects supported by the source and target controls. If the source
 control initiates a drag with support for a move or copy effect, for example, the target control must respond in the DragEnter event to notify the application which of these effects (if any) it can support. This causes the mouse cursor to change to an appropriate
 icon, reflecting the action to be carried out.</p>
<p class="Text">If the user attempts to perform a drop on a given target control by releasing the mouse button, a second event is fired. This event is the DragDrop event, which is used to actually process the data. In the DragDrop sample application, the
 action taken is to add text data dropped on the listBox1 control as a list item. The DragDrop event in this sample supports several standard DragDrop conventions, such as the use of the Ctrl key to indicate a copy rather than a move, and the ability to display
 a context menu giving the user an opportunity to select from supported actions if the right mouse button was used. Because the use of the context menu requires data to be processed from both the DragDrop event and the click events of the menu items, the majority
 of processing code has been pulled out into a separate ProcessData function, which is then called from these event handlers.</p>
