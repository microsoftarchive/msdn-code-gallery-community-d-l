# Household Budget Calculator
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- vb2008
## Topics
- GDI+
- Serialization
- Attributes
- Properties
- Classes
- Transformations
## Updated
- 07/16/2015
## Description

<p>This is a Household Budget Calculator that demonstrates how to use a PropertyGrid with Classes and Attributes, Serializing Classes, and how to use GDI&#43; with Transformations.</p>
<p><br>
The PropertyGrid shows how to use expandable Properties and also how to add an image to your Properties in the PropertyGrid. All this is achieved with ExpandableObjectConverter Attributes and UITypeEditor Classes and Attributes.</p>
<p><br>
The GDI&#43; aspect of the application demonstrates how to use Transformations to draw a 3D effect Histogram. The Graphics object provides three methods for adding transformations to the output: TranslateTransform, ScaleTransform, and RotateTransform.</p>
<p><br>
This example uses two of those Transformations, ScaleTransform and TranslateTransform to flip the drawing origin vertically and scale the drawing to fit the PictureBox.These Transformations enable easy calculations when drawing a Histogram.<br>
When you use big scale factors, the lines are scaled greatly and may look really ugly. To compensate, you can make a custom Pen with a line width 0, which GDI&#43; always draws one pixel wide, even when it is scaled.</p>
<p>Any feedback on this article would be appreciated. Just post any questions, suggestions, or comments in the Questions and Answers section of this page...</p>
<p>&nbsp;</p>
<p><img src="57928-30-05-2012%2015.06.38.jpg" alt="" width="1007" height="457"></p>
