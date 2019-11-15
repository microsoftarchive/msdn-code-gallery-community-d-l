# Easy WPF Login & Navigate Tutorial. Simple WPF Examples, in code-behind or MVVM
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- Data Binding
- Authentication
- Architecture and Design
- Navigation
- Menus
- UI Layout
- Authorization
- WPF Data Binding
- Event Handling
- UI Design
- WPF Commanding
- login
- Binding
- INotifyPropertyChanged
- PropertyChanged
- Screen Lock
- Value Converters
- Relay Commands
- CanExecute
## Updated
- 03/14/2014
## Description

<h1>Introduction</h1>
<p>This tutorial project shows the basics of building a WPF appliocation. How to log in and navigate between views and controls. I show both code behind and MVVM examples to give a full overview of techniques used to authenticate, disable/enable and navigate
 around an application.</p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p>Just download, unzip, open in Visual Studio and run!</p>
<p>&nbsp;</p>
<h1>Description</h1>
<p>This project steps through the various options you have in designing a WPF application.</p>
<p>&nbsp;</p>
<h2>Example 1 - Code Behind</h2>
<p>The first example is the simplest way to lock the application with a login layer, then manipulate the UI - all from basic code-behind. This will be very familier to developers moving from WinForms to WPF.</p>
<p>MainWindow.xaml</p>
<p>This contains three main controls.</p>
<ul>
<li>A Menu control, with &quot;hard coded&quot; menu options to log off, add a control and open a new window.
</li><li>A &quot;stage&quot; to hold dynamically loaded controls </li><li>A lock layer and login form </li></ul>
<p>Before you can see the menu, a top level Grid covers the application with a lock layer and login form.</p>
<p>Once authenticated, the code behind directly hides the lock layer and login form. This allows the user to see the controls beneith. The code-behind also responds to click events from the menu items, to log off (manually show the login layer), load a control
 into the UI (directly seting the child of the &quot;Stage&quot; Border control), or open a new window.</p>
<p>&nbsp;</p>
<h2>Example 2.1 - MVVM</h2>
<p>The second example shows the same functionality above, but with a class (ViewModel) that is totally disconnected from the UI (MVVM), allowing functionality reuse, tidier code and easy re-skinning.</p>
<p>The only code behind is to assign the MainViewModel as DataContext of the Window.</p>
<p>In MVVM, the question of how to manage and navigate UIs is a contentious issue.</p>
<p>In this example I group all changes to the UI into an ApplicationController class.</p>
<p>This is a Singleton, but it has knowledge of the &quot;stage&quot; control. This means you can call it from absolutely anywhere in your application and control the views. If your application has a lot of pages or controls, you will appreciate this technique to keep
 all your navigation in one class. Otherwise your navigation can become messy and hard to follow.</p>
<h2>Example 2.2</h2>
<p>Also in this second window (Window1.xaml), is an extra menu option to add a second control. This second method shows the alternative to the &quot;Inversion of Control&quot; style of passing the stage into the ApplicationController. Another way to load controls into
 the UI is to bind the UI directly to properties of the ViewModel.</p>
<p>The login lock only covers the lower part of teh window. The MenuItems are disabled due to the their Commands' CanExecute methods. The MenuItems are enabled when the user authenticates.</p>
<p>In this example, I place a ContentControl into the Window1.xaml which binds it's Content property to a &quot;SubView&quot; property of MainViewModel. If I load something into this property from the ViewModel, it will appear in the UI. Note I load a slider and give
 it two property bindings.</p>
<p>The first is the Value property, which just runs up the visual tree to the parent control's DataContext, the ViewModel. There is also a binding in the main user control, so when you move the slider, you see all teh binding of both newly added controls work
 like magic.</p>
<p>The second Slider binding is on Slider.IsEnabled bound to IsAuthenticated of the AuthenticationViewModel. I could have set the binding to &quot;LoginVM.IsAuthenticated&quot;, which is exactly the same as my example of specifying the &quot;Source&quot;</p>
<p>&nbsp;</p>
<h2>Example 2.3</h2>
<p>The best method to generate the Menu in an MVVM context is to get the UI to generate the controls, based on data in the ViewModel. I have created a MyMenuItem class, which defines Header, Command and Children. I then bind a collection of these items and
 their children to the ItemsSource of a Menu, which is an ItemsControl. I then bind the class's properties to the control's properties in the ItemContainerStyle. The Menu is then auto-generated&nbsp;</p>
<p><img id="110634" src="http://i1.code.msdn.s-msft.com/windowsdesktop/easy-wpf-login-navigate-7a8d34a0/image/file/110634/1/bloggif_5323a39895c64.gif" alt=""></p>
<p>I hope to write this up on TechNet WIki soon, with more images and code snippets, but meanwhile I hope you find this useful.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img src="http://213.163.64.28/aniThanks1.gif" alt="" style="display:block; margin-left:auto; margin-right:auto"></p>
