# Grouping and Checkboxes in WPF
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
## Topics
- User Interface
- WPF Basics
- radio button customization
## Updated
- 03/11/2011
## Description

<p><span style="font-size:medium"><strong>Grouping Checkboxes</strong></span></p>
<p><em><span style="font-size:small">All the benefits of a radio button with the three &quot;state-ness&quot; of a checkbox and the layout flexability of WPF</span></em></p>
<p>&nbsp;</p>
<p>If you have done any with WPF radio buttons you know that WPF has given us greater flexibility to define radio groups. In WinForms radio button groups were constrained to the parent panel. This meant if you wanted radio buttons to be mutually exclusive,
 that is you can only have one selected at a time, they all had to live within the same parent layout panel.</p>
<p>In WPF you don&rsquo;t have this limitation, when you specify a group name for a radio button it will be mutually exclusive to any other radio button that has the same group name within the visual tree. This gives you greater flexibility with how you layout
 your radio groups.</p>
<p>The problem is you can&rsquo;t &ldquo;un-select&rdquo; a radio button once it has been checked. I set out to find a solution that would give me mutual exclusivity and the ability to have an unchecked state for my entire group, that is nothing in the group
 is selected.</p>
<p>Enter the grouping checkboxes. What I wanted was the check / uncheck behavior of checkbox (really of the base toggle&nbsp; button) with the functionality of a radio button.</p>
<p>&nbsp;</p>
<p>For further reading see my blog post here:&nbsp;<a href="http://www.bradcunningham.net/2009/09/grouping-and-checkboxes-in-wpf.html">http://www.bradcunningham.net/2009/09/grouping-and-checkboxes-in-wpf.html</a></p>
<p>&nbsp;</p>
<p>(This is the most requested page on my blog and my most requested sample so I am publishing it here for the communities use)</p>
