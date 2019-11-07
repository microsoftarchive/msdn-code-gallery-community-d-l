# Graphs the Mandelbrot Set Fractal
## Requires
- Visual Studio 2008
## License
- MIT
## Technologies
- Graphics
- C#
- Visual Studio 2008
- Windows Forms
- Visual C#
## Topics
- C#
- Numerical Computing
## Updated
- 04/01/2015
## Description

<h1>Introduction</h1>
<p><em>This application graphs the Mandelbrot set fractal utilizing user defined parameters. A fractal is a self-similar curve.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>This project should easily build using Visual Studio 2008. The project uses the minimum number of references.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The Mandelbrot set along with the Julia set are among the most famous of classical fractals. Fractals are seen everywhere from the shapes of plants and trees, the clouds of Earth's atmosphere, and the coastlines of Earth's countries and continents. The
 user can select six parameters to adjust the shape of the fractal. The default parameters yield a nice image as shown in the following picture. The parameters are the x and y minima and maxima, the number of iterations to be performed and the number of picture
 elements. The number of pixels is limited to 220. Although the property of self-similarity has a long mathematical history it was not until the 1960s that computers were utilized to make beuatiful drawings of fractals. Benoit Mandelbrot was one of the first
 computer generated fractal innovators.<br>
</em></p>
<p><em><img id="135729" src="135729-mandelbrot.jpg" alt="" width="784" height="465"> &nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class MandelbrotForm : Form
    {
        private double xMinimum, xMaximum;
        private double yMinimum, yMaximum;
        private int iterations, pixels;
        private Brush brush;
        private Complex bottomLeft;

        public MandelbrotForm()
        {
            InitializeComponent();
            panel1.Paint &#43;= new PaintEventHandler(panel1_Paint);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xMinimum = Convert.ToDouble(textBox1.Text);
            xMaximum = Convert.ToDouble(textBox2.Text);
            yMinimum = Convert.ToDouble(textBox3.Text);
            yMaximum = Convert.ToDouble(textBox4.Text);
            iterations = Convert.ToInt32(textBox5.Text);
            pixels = Convert.ToInt32(textBox6.Text);

            if (pixels &gt; 220)
            {
                pixels = 220;
                textBox6.Text = Convert.ToString(pixels);
                System.Windows.Forms.MessageBox.Show(
                    &quot;pixels being set to maximum of 220&quot;,
                    &quot;Number Warning&quot;, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            bottomLeft = new Complex(xMinimum, yMinimum);
            brush = new SolidBrush(SystemColors.WindowText);
            panel1.Invalidate();
        }

        bool PrintPixel(double c1, double c2)
        {
            bool testValue = false;
            int count = 0;
            Complex c = new Complex(c1, c2), z = new Complex();

            while (count &lt; iterations)
            {
                count&#43;&#43;;
                z = z * z &#43; c;
                testValue = Complex.abs(z) &lt; 2.0;

                if (!testValue)
                    break;
            }

            return testValue;
        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            double scale = 100.0 * (xMaximum - xMinimum) / pixels;
            int width = panel1.Width - 1;
            int height = panel1.Height - 1;
            Graphics g = e.Graphics;

            for (int ct1 = -2 * pixels; ct1 &lt; 2 * pixels; ct1&#43;&#43;)
            {
                for (int ct2 = -2 * pixels; ct2 &lt; 2 * pixels; ct2&#43;&#43;)
                {
                    double x = ct1 * scale &#43; bottomLeft.Real;
                    double y = ct2 * scale &#43; bottomLeft.Imag;

                    if (PrintPixel(x, y))
                        g.FillEllipse(brush,
                            ct1 &#43; width / 2 &#43; 128,
                            ct2 &#43; height / 2,
                            2,
                            2);
                }
            }
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Drawing;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows.Forms;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Mandelbrot&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;MandelbrotForm&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;xMinimum,&nbsp;xMaximum;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;yMinimum,&nbsp;yMaximum;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;iterations,&nbsp;pixels;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Brush&nbsp;brush;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Complex&nbsp;bottomLeft;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MandelbrotForm()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;panel1.Paint&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PaintEventHandler(panel1_Paint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xMinimum&nbsp;=&nbsp;Convert.ToDouble(textBox1.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xMaximum&nbsp;=&nbsp;Convert.ToDouble(textBox2.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yMinimum&nbsp;=&nbsp;Convert.ToDouble(textBox3.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yMaximum&nbsp;=&nbsp;Convert.ToDouble(textBox4.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iterations&nbsp;=&nbsp;Convert.ToInt32(textBox5.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixels&nbsp;=&nbsp;Convert.ToInt32(textBox6.Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(pixels&nbsp;&gt;&nbsp;<span class="cs__number">220</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixels&nbsp;=&nbsp;<span class="cs__number">220</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox6.Text&nbsp;=&nbsp;Convert.ToString(pixels);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Windows.Forms.MessageBox.Show(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;pixels&nbsp;being&nbsp;set&nbsp;to&nbsp;maximum&nbsp;of&nbsp;220&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Number&nbsp;Warning&quot;</span>,&nbsp;MessageBoxButtons.OK,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBoxIcon.Warning);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bottomLeft&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Complex(xMinimum,&nbsp;yMinimum);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;brush&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SolidBrush(SystemColors.WindowText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;panel1.Invalidate();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;PrintPixel(<span class="cs__keyword">double</span>&nbsp;c1,&nbsp;<span class="cs__keyword">double</span>&nbsp;c2)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;testValue&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;count&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Complex&nbsp;c&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Complex(c1,&nbsp;c2),&nbsp;z&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Complex();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(count&nbsp;&lt;&nbsp;iterations)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;count&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;z&nbsp;=&nbsp;z&nbsp;*&nbsp;z&nbsp;&#43;&nbsp;c;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;testValue&nbsp;=&nbsp;Complex.abs(z)&nbsp;&lt;&nbsp;<span class="cs__number">2.0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!testValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;testValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;panel1_Paint(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;System.Windows.Forms.PaintEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;scale&nbsp;=&nbsp;<span class="cs__number">100.0</span>&nbsp;*&nbsp;(xMaximum&nbsp;-&nbsp;xMinimum)&nbsp;/&nbsp;pixels;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;width&nbsp;=&nbsp;panel1.Width&nbsp;-&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;height&nbsp;=&nbsp;panel1.Height&nbsp;-&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Graphics&nbsp;g&nbsp;=&nbsp;e.Graphics;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;ct1&nbsp;=&nbsp;-<span class="cs__number">2</span>&nbsp;*&nbsp;pixels;&nbsp;ct1&nbsp;&lt;&nbsp;<span class="cs__number">2</span>&nbsp;*&nbsp;pixels;&nbsp;ct1&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;ct2&nbsp;=&nbsp;-<span class="cs__number">2</span>&nbsp;*&nbsp;pixels;&nbsp;ct2&nbsp;&lt;&nbsp;<span class="cs__number">2</span>&nbsp;*&nbsp;pixels;&nbsp;ct2&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;x&nbsp;=&nbsp;ct1&nbsp;*&nbsp;scale&nbsp;&#43;&nbsp;bottomLeft.Real;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;y&nbsp;=&nbsp;ct2&nbsp;*&nbsp;scale&nbsp;&#43;&nbsp;bottomLeft.Imag;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(PrintPixel(x,&nbsp;y))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.FillEllipse(brush,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ct1&nbsp;&#43;&nbsp;width&nbsp;/&nbsp;<span class="cs__number">2</span>&nbsp;&#43;&nbsp;<span class="cs__number">128</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ct2&nbsp;&#43;&nbsp;height&nbsp;/&nbsp;<span class="cs__number">2</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">2</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Complex.cs - a minimal complex number class. Remember Visual Studio 2008 did not have a predefined Complex class.<br>
</em></li><li><em><em>MandelbrotForm.cs - the main and only form of the application.</em></em>
</li><li><em>Program.cs - the Visual Studio 2008 generated application source code class.</em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on fractals, and the Mandelbrot and Julia sets in particular, search the Internet.<br>
</em></p>
