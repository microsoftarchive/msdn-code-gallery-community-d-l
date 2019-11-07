# Getting Started with Test Driven Development in C#
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Test Driven Development
- Unit Test
- Unit Tests
- TDD using C#
- TDD in .NET
## Topics
- Test Driven Development
- Unit Test
- Unit Tests
- TDD using C#
- TDD in .NET
## Updated
- 04/09/2014
## Description

<h3><span style="font-size:small">Introduction</span></h3>
<p><span style="font-size:small">This sample demonstrates Test Driven Development (TDD). This sample uses a freshly created console application &amp; Unit Test project types.</span></p>
<p><span style="font-size:small">Test Driven Development is highly recommended approach to software development. In Test Driven Development, we first write unit tests, generate skeleton code so that the solution builds. Obviously all tests will fail initially
 since we have no functional code in place as yet!</span></p>
<p><span style="font-size:small">Test Driven Development also helps automate testing of business logic or any such code. In fact, automated deployments will fail if any tests fail making this approach ideal and helpful in troubleshooting deployment issues!</span></p>
<h3><span style="font-size:small">Taking Flight</span></h3>
<p><span style="font-size:small">Once we have test code in place:&nbsp;</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// verify if add returns the expected value of 0
Assert.AreEqual(0, MyMath.Add(10, -10));</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;verify&nbsp;if&nbsp;add&nbsp;returns&nbsp;the&nbsp;expected&nbsp;value&nbsp;of&nbsp;0</span>&nbsp;
Assert.AreEqual(<span class="cs__number">0</span>,&nbsp;MyMath.Add(<span class="cs__number">10</span>,&nbsp;-<span class="cs__number">10</span>));</pre>
</div>
</div>
</div>
<p class="endscriptcode"><span style="font-size:small">we will now need to write the functional code &nbsp;so that all tests pass. This does sound simple but possibly we will have to refactor our code iteratively &#43; in most situations, we will also need to
 mock certain services so that our tests execute without actually say touch the databases, etc.</span></p>
<h3 class="endscriptcode"><span style="font-size:small">To open a solution:</span></h3>
<ol>
<li><span style="font-size:small">Extract all files.<br>
&nbsp;</span> </li><li><span style="font-size:small">Start Microsoft Visual Studio 2013.<br>
&nbsp;</span> </li><li><span style="font-size:small">Navigate to the folder containing the TestDrivenDevelopmentSample.sln file, select it, and then click Open.</span>
</li></ol>
<h3><span style="font-size:small">To run the sample:</span></h3>
<div class="subSection">
<ol>
<li>
<p><span style="font-size:small">Open the&nbsp;<span>TestDrivenDevelopmentSample</span>.sln file</span></p>
</li><li>
<p><span style="font-size:small">Run all Tests to see test results!</span></p>
</li></ol>
</div>
<h3><span>See Also</span></h3>
<p><span style="font-size:small">To see a detailed tutorial on this, please see <a title="TechNet Tutorial" href="http://social.technet.microsoft.com/wiki/contents/articles/23929.getting-started-with-test-driven-development-in-c-tutorial.aspx">
this TechNet article</a>.</span></p>
