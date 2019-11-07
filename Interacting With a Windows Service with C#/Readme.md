# Interacting With a Windows Service with C#
## Requires
- Visual Studio 2002
## License
- Apache License, Version 2.0
## Technologies
- Windows Service
## Topics
- Interaction with Windows Service
## Updated
- 08/23/2011
## Description

<h1>Introduction</h1>
<p class="Text">The .NET Framework provides the ServiceController class for interacting and controlling Windows Services on a local or remote machine. An instance of the ServiceController class will allow an application to connect to and manipulate an existing
 service simply by providing the machine name and service name.</p>
<p class="Text">The following example is an application that launches a Windows Form to allow the user to interact and manipulate the IIS Admin service on the local machine. The application works by placing an icon in the System Tray.</p>
<h1>How to Use</h1>
<p class="Text">To see this example in action, run the self-extracting archive to install the sample files, then open the solution and build it. When the application starts, an icon should appear in the status area. Right-clicking this icon will open a context
 menu that enables you to show the Windows Service control form or exit the application. To view the code open the solution in Visual Studio .NET.</p>
<p class="AlertText">Note&nbsp;&nbsp;&nbsp;This sample interacts with Internet Information Services (IIS), and assumes that IIS is installed on the local machine.</p>
<h1>Description</h1>
<p class="Text">This application interacts with a Windows Service. This documentation will focus on how to effectively control a Windows Service. For information on how to use the System Tray, see the SystemTray sample.</p>
<p class="Text">In this example, there are two forms: SystemTray.cs and WSControllerForm.cs. The WSControllerForm contains the code to interact with the Windows Service. A ServiceController component has been added to this form.</p>
<p class="Text">The form contains three buttons to allow the user to start, stop, or pause the IIS Admin service.</p>
<p class="Text">In the WSControllerForm_Load event, the application loops through the available services on the local machine to determine if the IIS Admin Service is installed. An array of type ServiceController is created of available services on the local
 machine by calling the static GetServices method of the ServiceController class. Next, the WSControllerForm_Load event loops through this array checking each service&rsquo;s name until it finds the IISADMIN service. If it exists, the ServiceName property of
 the WSController instance is set, and the helper function SetButtonStatus is called. If not, then a message box appears to inform the user, that the IIS Admin Service is not installed.</p>
<p class="Text">The SetButtonStatus method checks the current status of the IIS Admin service by checking the status property of WSController. Then the enabled property of each command button is set accordingly.</p>
<p class="Text">In the click event for the ButtonStart button, the current status for the service is checked. If the service status equals &ldquo;Paused&rdquo;, then the event procedure calls the Continue method. If the service status equals &ldquo;Stopped&rdquo;,
 then the event procedure checks for all services, which IIS is dependent upon and ensures these services are running.</p>
<p class="Text">The ServicesDependedOn property of the ServiceController class returns an array of type ServiceController. This example is set up this way to demonstrate how gain access to each service in the Service Controller array. Likely, the application
 would be better designed to start each of these services automatically, or at least collect all of the display names and prompt the user only one time.</p>
<p class="Text">The WaitForStatus method pauses the thread of execution until the status reaches the desired status or times out.</p>
<p class="Text">Once all of the services are started, then the procedure continues by starting the IIS Admin service.</p>
<p class="Text">The ButtonStop_Click event procedure is designed similarly to the ButtonStart_Click event procedure, with the exception that instead of returning an array of services for which IIS Admin is dependent upon; it returns and checks an array of
 dependent services. The DependentServices property of ServiceController also returns an array of type ServiceController. This procedure also highlights the boolean property of CanStop. Not all Windows Services implement the same functionality. The ServiceController
 class offers a couple of boolean properties, which allow the developer to interrogate the service to determine what functionality is implemented. Other properties are CanPauseAndContinue and CanShutdown.</p>
<p class="Text">The ButtonPause_Click event procedure checks to see if the service is able to pause and continue, and then calls the Pause method of the ServiceController class.</p>
