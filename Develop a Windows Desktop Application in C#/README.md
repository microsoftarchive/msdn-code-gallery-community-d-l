# Develop a Windows Desktop Application in C#
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- WPF
- Windows Desktop App Development
## Topics
- WPF
- desktop
## Updated
- 04/25/2016
## Description

<p><span style="font-size:medium">Let&rsquo;s create a Windows Desktop Application in C# using WPF (Windows Presentation Foundation)!</span></p>
<p><span style="font-size:medium">Simply create a WPF Application Project in Microsoft Visual Studio;</span></p>
<p><span style="font-size:medium"><img class="aligncenter" src="-untitled_zpsbdtixiho.png" alt="" width="624" height="351"></span></p>
<p><span style="font-size:medium">When you press OK to create the project. You&rsquo;ll get a screen like here;</span></p>
<p><span style="font-size:medium"><img class="aligncenter" src="-untitled_zpsor6bw3or.png" alt="" width="624" height="351"></span></p>
<p><span style="font-size:medium">The WPF is little bit interesting. It has visual interface. Its mean to run on the Desktop. And If you run the application, you&rsquo;ll get the screen like shown below and staying open until you close it down;</span></p>
<p><span style="font-size:medium"><img class="aligncenter" src="-untitled_zpserk0tgvh.png" alt="" width="624" height="351"></span></p>
<p><span style="font-size:medium">:: The WPF Application starts with two files that have extensions of &ldquo;.xaml&rdquo;! The XAML is stands for Extensible Application Markup Language (<strong>XAML</strong>). It is a declarative language. Used to define User
 Interface. All the Modern Windows 10 UI is based upon XAML.</span></p>
<p><span style="font-size:medium">Microsoft Visual C# always associate with the XAML file or User Interface Definition. C# file stay behind as the Code Behind File with the file extension &ldquo;.cs&rdquo;. This is where you put the logic of your application!</span></p>
<p><span style="font-size:medium"><img class="aligncenter" src="-untitled_zpsgoxagbbk.png" alt="" width="624" height="351"></span></p>
<p><span style="font-size:medium">Now Back to the XAML file and create a visual control by either Toolbox or by code.</span></p>
<ol>
<li><span style="font-size:medium">Create TextBlock by using code or by dragging from Toolbox.</span>
</li></ol>
<p><span style="font-size:medium"><img class="aligncenter" src="-untitled_zps6cbtorkm.png" alt="" width="624" height="351"></span></p>
<p><span style="font-size:medium">Now to come to the property explorer, you will get everything to customize the text block!</span></p>
<p><span style="font-size:medium">So here at property explorer we change the Text in the common category and change the text property inside the Text category.</span></p>
<p><span style="font-size:medium">Now run the application and you will get the output.</span></p>
<p><span style="font-size:medium"><img class="aligncenter" src="-untitled_zps7cwzn9sx.png" alt="" width="624" height="351"></span></p>
<p><span style="font-size:medium">In order to manage the text block control from backend, we need to give it a name in properties.</span></p>
<p><span style="font-size:medium">Now go to logical file, the .cs file on backend shows the C# code where you need to create the logic of your application.</span></p>
<p><span style="font-size:medium">So to affect the appearance of the application, add someone by calling the TextBlock name like here.</span></p>
<p><span style="font-size:medium">txtHello.Text = &quot;Hello from C#!&quot;;</span></p>
<p><span style="font-size:medium">And now when we run the application, it will show us output from that;</span></p>
<p><span style="font-size:medium"><img class="aligncenter" src="-untitled_zpsxsl9gnuu.png" alt="" width="624" height="351"></span></p>
<p><span style="font-size:medium">So as you observed, the value we&rsquo;re sending from our logical C# code is over riding the value that we set in our XAML code!</span></p>
<p>&nbsp;</p>
<p><span style="font-size:medium">So that's how we can write an Application in WPF through Visual C#!</span></p>
<h1><span>:: Orignal Blog Reference; &nbsp;</span><a href="http://www.sajidalikhan.com/blog/development/microsoft/windows/Navigation_UWP.html" target="_blank">http://justsajid.com/skills/develop-a-windows-desktop-application-in-csharp/</a></h1>
