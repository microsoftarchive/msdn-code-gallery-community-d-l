# Floating Action Button for Android
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Xamarin.Android
- Xamarin
## Topics
- Floating action Button Android
- Android material design
## Updated
- 06/23/2015
## Description

<h1>Floating Action Button for Android Using Xamarin in Visual Studio</h1>
<h1>Android L has introduced something called a Floating Action Button (FAB), which is basically a circle overlayed on top your application. This FAB can be clicked to do an action.&nbsp;</h1>
<p>Floating action buttons are used for a promoted action. They are distinguished by a circled icon floating above the UI and have motion behaviors that include morphing, launching, and a transferring anchor point.</p>
<p>Floating action buttons come in two sizes:</p>
<ul>
<li>Default size: For most use cases </li><li>Mini size: Only used to create visual continuity with other screen elements </li></ul>
<p>At 2014 Google I/O, Google announced a new visual language called Material Design. Material Design guides creation of user experiences that work well on different devices, with different input methods and on different platforms. Google is gradually implementing
 Material Design in their apps and products, and we can start playing with it, too.</p>
<p>One interesting new design pattern is the promoted action, implemented as a&nbsp;<a href="http://www.google.com/design/spec/patterns/promoted-actions.html">floating action button</a>. This pattern exemplifies the underlying principles of Material Design
 and is a good place to start adapting existing applications to the new version of Android.</p>
<p>You can see from Google&rsquo;s guidelines that there are many ways to apply this pattern incorrectly, as evidenced by the various &ldquo;Don&rsquo;ts&rdquo; on that page. Today, I want to show you how to implement a floating action button in Xamarin using
 Visual Studio.</p>
<p><em>Floating Action Button (FAB) is created ad seperate project and added to the sample as a package. The FAB is also give a small animation on it's click event.</em></p>
<p><em><br>
</em></p>
<p><img id="139210" src="139210-2.jpg" alt="" width="496" height="858"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>By adding the predefined project or package of FAB &nbsp;we can adda FAButton.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml">&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;floatingactionbutton</span>.Fab&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;android:<span class="xml__attr_name">id</span>=<span class="xml__attr_value">&quot;@&#43;id/fabbutton&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;android:<span class="xml__attr_name">layout_width</span>=<span class="xml__attr_value">&quot;70dp&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;android:<span class="xml__attr_name">layout_height</span>=<span class="xml__attr_value">&quot;70dp&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;android:<span class="xml__attr_name">layout_gravity</span>=<span class="xml__attr_value">&quot;bottom|right&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;android:<span class="xml__attr_name">layout_marginBottom</span>=<span class="xml__attr_value">&quot;15dp&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;android:<span class="xml__attr_name">layout_marginRight</span>=<span class="xml__attr_value">&quot;15dp&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
