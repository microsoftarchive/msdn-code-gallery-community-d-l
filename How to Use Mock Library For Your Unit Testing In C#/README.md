# How to Use Mock Library For Your Unit Testing In C#
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Moq Framework
## Topics
- Unit Testing
- Mock
## Updated
- 11/06/2011
## Description

<p>In this tutorial I assume that you have basic knowledge of writing unit testing with Visual Studio.Also note that here we will not use TDD&nbsp; approach to implement our example.<br>
<br>
</p>
<div class="MsoNormal">Normally in software development life cycle as a software developers we have to test &nbsp;every possible methods which we have written.In this point Unit test come out. In Unit testing we are ensure that our method works in expected
 way.To ensure that our method should be independent from others. To ensure this isolation we can use mock objects.</div>
<div class="MsoNormal"></div>
<div class="MsoNormal">Think that we have method call &quot;A&quot; inside &quot;A&quot; method we call another method called &quot;B&quot; and get the return object from &nbsp;&quot;B&quot;&nbsp; to carry out further operation in our method &quot;A&quot;. But since we are unit testing method &quot;A&quot; we can
 not depend on method &quot;B&quot;. We want to test behavior of our method working as expected way.What the mock doing is,It allow us to create a mock object ( fake object) which is similar to the&nbsp; return object of method &quot;B&quot;. So our method &quot;A&quot; will accept this
 fake object as return object of method &quot;B&quot; and it will carry out further operation in method &quot;A&quot;. Here remember that we have to use dependency injection design pattern heavily to success this.</div>
<div class="MsoNormal"></div>
<div class="MsoNormal">Here to implement mock objects I use open source library called Moq. You can download it from
<a href="http://code.google.com/p/moq/" target="_blank">here</a>. Now we will implement the example application using Mock.</div>
<div class="MsoNormal"></div>
<div class="MsoNormal">Think that in a library system we want to calculate membership cost per year and it will depend on the number of books he borrow per one time.</div>
<div class="MsoNormal"></div>
<div class="MsoNormal">1. Start Visula Studio and create new Class Library called LibraryOperations.</div>
<div class="separator" style="clear:both; text-align:center"><a href="http://4.bp.blogspot.com/-jymJ5LN9fB0/TrSdv-mQDTI/AAAAAAAAAXY/keX1hOnO4C0/s1600/mock1.JPG" style="margin-left:1em; margin-right:1em"><img src="-mock1.jpg" border="0" alt="" width="400" height="243"></a></div>
<div class="MsoNormal"></div>
<p>&nbsp;2. Delete the Class1 and Create new class called Member as bellow.<br>
<br>
</p>
&lt;!-- .csharpcode, .csharpcode pre { font-size: small; color: black; font-family: Consolas, &quot;Courier New&quot;, Courier, Monospace; background-color: #ffffff; /*white-space: pre;*/ } .csharpcode pre { margin: 0em; } .csharpcode .rem { color: #008000; } .csharpcode
 .kwrd { color: #0000ff; } .csharpcode .str { color: #006080; } .csharpcode .op { color: #0000c0; } .csharpcode .preproc { color: #cc6633; } .csharpcode .asp { background-color: #ffff00; } .csharpcode .html { color: #800000; } .csharpcode .attr { color: #ff0000;
 } .csharpcode .alt { background-color: #f4f4f4; width: 100%; margin: 0em; } .csharpcode .lnum { color: #606060; } --&gt;
<p>&nbsp;</p>
<pre class="csharpcode"><span class="kwrd">namespace</span> LibraryOperations
{
    <span class="kwrd">public</span> <span class="kwrd">class</span> Member
    {
        <span class="kwrd">public</span> <span class="kwrd">int</span> MemberID { get; set; }
        <span class="kwrd">public</span> <span class="kwrd">string</span> FirstName { get; set; }
        <span class="kwrd">public</span> <span class="kwrd">string</span> SecondName { get; set; }
        <span class="kwrd">public</span> <span class="kwrd">int</span> MaximumBookCanBorrow { get; set; }
        <span class="kwrd">public</span> <span class="kwrd">int</span> Age { get; set; }
    }
}</pre>
<p><br>
3. Now create a interface called IMemberManager which is contain all the method required to handle library member. But here we implement only one method.<br>
<br>
</p>
&lt;!-- .csharpcode, .csharpcode pre { font-size: small; color: black; font-family: Consolas, &quot;Courier New&quot;, Courier, Monospace; background-color: #ffffff; /*white-space: pre;*/ } .csharpcode pre { margin: 0em; } .csharpcode .rem { color: #008000; } .csharpcode
 .kwrd { color: #0000ff; } .csharpcode .str { color: #006080; } .csharpcode .op { color: #0000c0; } .csharpcode .preproc { color: #cc6633; } .csharpcode .asp { background-color: #ffff00; } .csharpcode .html { color: #800000; } .csharpcode .attr { color: #ff0000;
 } .csharpcode .alt { background-color: #f4f4f4; width: 100%; margin: 0em; } .csharpcode .lnum { color: #606060; } --&gt;
<p>&nbsp;</p>
<pre class="csharpcode"><span class="kwrd">namespace</span> LibraryOperations
{
    <span class="kwrd">public</span> <span class="kwrd">interface</span> IMemberManager
    {
        Member GetMember(<span class="kwrd">int</span> memberID);
    }
}</pre>
<pre class="csharpcode"> </pre>
<p>4.Implement the class called MemeberManager which is inherite from IMemberManager interface.But here we are not going to implement the method body. And you will see the reason soon.<br>
<br>
</p>
&lt;!-- .csharpcode, .csharpcode pre { font-size: small; color: black; font-family: Consolas, &quot;Courier New&quot;, Courier, Monospace; background-color: #ffffff; /*white-space: pre;*/ } .csharpcode pre { margin: 0em; } .csharpcode .rem { color: #008000; } .csharpcode
 .kwrd { color: #0000ff; } .csharpcode .str { color: #006080; } .csharpcode .op { color: #0000c0; } .csharpcode .preproc { color: #cc6633; } .csharpcode .asp { background-color: #ffff00; } .csharpcode .html { color: #800000; } .csharpcode .attr { color: #ff0000;
 } .csharpcode .alt { background-color: #f4f4f4; width: 100%; margin: 0em; } .csharpcode .lnum { color: #606060; } --&gt;
<p>&nbsp;</p>
<pre class="csharpcode"><span class="kwrd">using</span> System;

<span class="kwrd">namespace</span> LibraryOperations
{
    <span class="kwrd">public</span> <span class="kwrd">class</span> MemberManager:IMemberManager
    {
        <span class="kwrd">public</span> Member GetMember(<span class="kwrd">int</span> memberID)
        {
            <span class="kwrd">throw</span> <span class="kwrd">new</span> NotImplementedException();
        }
    }
}</pre>
<p><br>
5. Now we create a class called LibraryCore and it has a public method called CalculateMemberShipCost. You can see implementation of this class bellow.<br>
<br>
</p>
&lt;!-- .csharpcode, .csharpcode pre { font-size: small; color: black; font-family: Consolas, &quot;Courier New&quot;, Courier, Monospace; background-color: #ffffff; /*white-space: pre;*/ } .csharpcode pre { margin: 0em; } .csharpcode .rem { color: #008000; } .csharpcode
 .kwrd { color: #0000ff; } .csharpcode .str { color: #006080; } .csharpcode .op { color: #0000c0; } .csharpcode .preproc { color: #cc6633; } .csharpcode .asp { background-color: #ffff00; } .csharpcode .html { color: #800000; } .csharpcode .attr { color: #ff0000;
 } .csharpcode .alt { background-color: #f4f4f4; width: 100%; margin: 0em; } .csharpcode .lnum { color: #606060; } --&gt;
<p>&nbsp;</p>
<pre class="csharpcode"><span class="kwrd">namespace</span> LibraryOperations
{
    <span class="kwrd">public</span> <span class="kwrd">class</span> LibraryCore
    {
        <span class="kwrd">private</span> <span class="kwrd">readonly</span> IMemberManager _memberManager;

        <span class="kwrd">public</span> LibraryCore(IMemberManager memberManager)
        {
            <span class="kwrd">this</span>._memberManager = memberManager;
        }

        <span class="kwrd">public</span> <span class="kwrd">double</span> CalculateMemberShipCost(<span class="kwrd">int</span> memberID)
        {
            <span class="kwrd">double</span> membershipCost = 0;
            Member member = _memberManager.GetMember(memberID);
            membershipCost = 10 &#43; member.MaximumBookCanBorrow * 0.5;
            <span class="kwrd">return</span> membershipCost;
        }
    }
}</pre>
<p><br>
Note that here we used Dependency Injection design pattern.This will allow us to create a loose couple class. So we can inject the any type of object which is implement from IMemberManager interface to class constructor.This is the main thing we use to test
 our method using Mock.<br>
<br>
&nbsp; 6. Now add the Unit Test project called LibraryOperationsTest to your solution.&nbsp;
<br>
<br>
</p>
<div class="separator" style="clear:both; text-align:center"><a href="http://1.bp.blogspot.com/-uFCgpSzl9-s/TrSopwZbiJI/AAAAAAAAAXg/gO6w_42pWYs/s1600/moq2.JPG" style="margin-left:1em; margin-right:1em"><img src="-moq2.jpg" border="0" alt="" width="640" height="387"></a></div>
<p>Delete UnitTest1.cs class from your test project.<br>
<br>
7. Now go to LibraryCore class and right click on CalculateMemberShipCost method name and select Create Unit Tests.<br>
<br>
</p>
<div class="separator" style="clear:both; text-align:center"><a href="http://2.bp.blogspot.com/-flx-7wWDfOQ/TrSqGw_az-I/AAAAAAAAAXo/4U6bfJGTR9I/s1600/moq3.JPG" style="margin-left:1em; margin-right:1em"><img src="-moq3.jpg" border="0" alt="" width="640" height="340"></a></div>
<p><br>
Now Create Unit Tests window will appear. You can select that you want to test in this class and you can select the Out put Test project that the test class want to add.Also you can add any wanted Assembly that you want to use for unit testing.(Here I will
 not add the our moq library here.Because i rather like to add it using add reference option.If you like you can add it in here).Now click on OK button and VS will create&nbsp; LibraryCoreTest.cs for you.<br>
<br>
</p>
<div class="separator" style="clear:both; text-align:center"><a href="http://3.bp.blogspot.com/-4K6YggPvPpI/TrSr9W1v0NI/AAAAAAAAAXw/OqEZhN9tseU/s1600/moq4.JPG" style="margin-left:1em; margin-right:1em"><img src="-moq4.jpg" border="0" alt="" width="640" height="475"></a></div>
<p><br>
8. Now we will add Moq.dll to our TestProject using add reference option. Note that here I'm using 4.0 version since I'm using .Net framework 4.Now we will implement our LibraryCoreTest class as bellow.<br>
<br>
</p>
&lt;!-- .csharpcode, .csharpcode pre { font-size: small; color: black; font-family: Consolas, &quot;Courier New&quot;, Courier, Monospace; background-color: #ffffff; /*white-space: pre;*/ } .csharpcode pre { margin: 0em; } .csharpcode .rem { color: #008000; } .csharpcode
 .kwrd { color: #0000ff; } .csharpcode .str { color: #006080; } .csharpcode .op { color: #0000c0; } .csharpcode .preproc { color: #cc6633; } .csharpcode .asp { background-color: #ffff00; } .csharpcode .html { color: #800000; } .csharpcode .attr { color: #ff0000;
 } .csharpcode .alt { background-color: #f4f4f4; width: 100%; margin: 0em; } .csharpcode .lnum { color: #606060; } --&gt;
<p>&nbsp;</p>
<pre class="csharpcode"><span class="kwrd">using</span> LibraryOperations;
<span class="kwrd">using</span> <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.VisualStudio.TestTools.UnitTesting.aspx" target="_blank" title="Auto generated link to Microsoft.VisualStudio.TestTools.UnitTesting">Microsoft.VisualStudio.TestTools.UnitTesting</a>;
<span class="kwrd">using</span> System;
<span class="kwrd">using</span> Moq;

<span class="kwrd">namespace</span> LibraryOperationsTest
{
    
    
    <span class="rem">/// &lt;summary&gt;</span>
    <span class="rem">///This is a test class for LibraryCoreTest and is intended</span>
    <span class="rem">///to contain all LibraryCoreTest Unit Tests</span>
    <span class="rem">///&lt;/summary&gt;</span>
    [TestClass()]
    <span class="kwrd">public</span> <span class="kwrd">class</span> LibraryCoreTest
    {

        <span class="kwrd">private</span> LibraryCore _target;
        <span class="kwrd">private</span> Mock&lt;IMemberManager&gt; _mock;

        <span class="rem">/// &lt;summary&gt;</span>
        <span class="rem">///A test for CalculateMemberShipCost</span>
        <span class="rem">///&lt;/summary&gt;</span>
        [TestMethod()]
        <span class="kwrd">public</span> <span class="kwrd">void</span> CalculateMemberShipCostTest()
        {
            _mock = <span class="kwrd">new</span> Mock&lt;IMemberManager&gt;();
            _target = <span class="kwrd">new</span> LibraryCore(_mock.Object);
            Member member = <span class="kwrd">new</span> Member()
            {
                MemberID=1,
                FirstName=<span class="str">&quot;Erandika&quot;</span>,
                SecondName=<span class="str">&quot;Sandaruwan&quot;</span>,
                Age=25,
                MaximumBookCanBorrow=4,
            };

            _mock.Setup(x =&gt; x.GetMember(It.IsAny&lt;<span class="kwrd">int</span>&gt;())).Returns(member);
    
            <span class="kwrd">int</span> memberID = 1; 
            <span class="kwrd">double</span> expected = 12; 
            <span class="kwrd">double</span> actual;
            actual = _target.CalculateMemberShipCost(memberID);
            Assert.AreEqual(expected, actual);  
        }
    }
}
</pre>
<p><br>
Here first we create a mock object using IMemberManager interface and we pass it to LibraryCore constructor.Since we are using dependency Injection in LibraryCore class we can perform this operation.<br>
<br>
<br>
</p>
&lt;!-- .csharpcode, .csharpcode pre { font-size: small; color: black; font-family: Consolas, &quot;Courier New&quot;, Courier, Monospace; background-color: #ffffff; /*white-space: pre;*/ } .csharpcode pre { margin: 0em; } .csharpcode .rem { color: #008000; } .csharpcode
 .kwrd { color: #0000ff; } .csharpcode .str { color: #006080; } .csharpcode .op { color: #0000c0; } .csharpcode .preproc { color: #cc6633; } .csharpcode .asp { background-color: #ffff00; } .csharpcode .html { color: #800000; } .csharpcode .attr { color: #ff0000;
 } .csharpcode .alt { background-color: #f4f4f4; width: 100%; margin: 0em; } .csharpcode .lnum { color: #606060; } --&gt;
<p>&nbsp;</p>
<pre class="csharpcode">            Mock&lt;IMemberManager&gt; _mock = <span class="kwrd">new</span> Mock&lt;IMemberManager&gt;();
            LibraryCore _target = <span class="kwrd">new</span> LibraryCore(_mock.Object);
</pre>
<p><br>
Then we Create&nbsp; a Member object and tell the assing that object to _mock object. Here you can pass any integer type parameter to our GetMember method and Mock framwork will return&nbsp; member object that we created in all the time when we are calling
 to the GetMember method.<br>
<br>
</p>
&lt;!-- .csharpcode, .csharpcode pre { font-size: small; color: black; font-family: Consolas, &quot;Courier New&quot;, Courier, Monospace; background-color: #ffffff; /*white-space: pre;*/ } .csharpcode pre { margin: 0em; } .csharpcode .rem { color: #008000; } .csharpcode
 .kwrd { color: #0000ff; } .csharpcode .str { color: #006080; } .csharpcode .op { color: #0000c0; } .csharpcode .preproc { color: #cc6633; } .csharpcode .asp { background-color: #ffff00; } .csharpcode .html { color: #800000; } .csharpcode .attr { color: #ff0000;
 } .csharpcode .alt { background-color: #f4f4f4; width: 100%; margin: 0em; } .csharpcode .lnum { color: #606060; } --&gt;
<p>&nbsp;</p>
<pre class="csharpcode">            Member member = <span class="kwrd">new</span> Member()
            {
                MemberID=1,
                FirstName=<span class="str">&quot;Erandika&quot;</span>,
                SecondName=<span class="str">&quot;Sandaruwan&quot;</span>,
                Age=25,
                MaximumBookCanBorrow=4,
            };

            _mock.Setup(x =&gt; x.GetMember(It.IsAny&lt;<span class="kwrd">int</span>&gt;())).Returns(member);
</pre>
<p><br>
So other part of our method we can implement in normal way and if we run the unit test now we will get successfully message like this.<br>
<br>
</p>
<div class="separator" style="clear:both; text-align:center"><a href="http://2.bp.blogspot.com/-MdTiHaI_VV8/TrS2ekqhECI/AAAAAAAAAX4/OkfqgyHpt64/s1600/moq5.JPG" style="margin-left:1em; margin-right:1em"><img src="-moq5.jpg" border="0" alt="" width="640" height="174"></a></div>
<p><br>
Happy Coding :)<br>
<br>
Download Source Code <a href="http://www.4shared.com/file/Fi0gXs9E/LibraryOperations.html" target="_blank">
here</a>.<br>
<br>
<br>
<br>
<br>
</p>
