# How to programmatically synthesizes mouse motion and button clicks...
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- Synthesizes Mouse Motion
- Win Form
## Topics
- C#
- Win Form
- API user32.dll
## Updated
- 05/29/2019
## Description

<h1>Introduction</h1>
<p>Added logic - if use key &quot;A&quot; programm will move mouse &#43;/- 3px each 5 minutes.</p>
<p><span style="background-color:#ffff00">It prevent computer go to sleep (simulate activities).&nbsp;</span></p>
<p>This small Window Form application which explains how to programmatically synthesizes mouse motion and button clicks.</p>
<p>It uses the <strong>mouse_event</strong> from user32.dll</p>
<p>If you need to Win32 API, and application (for example) will hold WCF service - choose Win Form application ...</p>
<p>&nbsp;</p>
<p>Please see below three useful links:</p>
<p><a href="http://www.pinvoke.net/default.aspx/user32.mouse_event">http://www.pinvoke.net/default.aspx/user32.mouse_event</a></p>
<p><a href="https://msdn.microsoft.com/en-us/library/windows/desktop/ms646260(v=vs.85).aspx">https://msdn.microsoft.com/en-us/library/windows/desktop/ms646260(v=vs.85).aspx</a></p>
<p>&nbsp;</p>
<p><img id="222127" src="222127-mousemove.png" alt="" width="226" height="238"></p>
<p>Use arrow &quot;Left&quot;, &quot;Right&quot;, &quot;Up&quot;, &quot;Down&quot; for move Mouse Cursor, Use &quot;L&quot; for simulate Left Press, &quot;R&quot; for simulate &quot;R&quot; press... If you press &quot;L&quot; or &quot;R&quot; application lost focus... you will need focus again ...</p>
<p>&nbsp;</p>
<p>For simulate press, button use this approach&nbsp;</p>
<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; mouse_event(MOUSEEVENTF_LEFTDOWN, 0u, 0u, 0u, (UIntPtr)0);&nbsp;</p>
<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Thread.Sleep(100);&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</p>
<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; mouse_event(MOUSEEVENTF_LEFTUP, 0u, 0u, 0u, (UIntPtr)0);</p>
<p>&nbsp;</p>
<p>If you use &nbsp;mouse_event(<strong>MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP</strong>&nbsp;, 0u, 0u, 0u, (UIntPtr)0);
<strong>some application will not be working correctly</strong> - example Media Player ...</p>
<p>&nbsp;</p>
<p>For simulate Left Press and Move Use combination ...&nbsp;</p>
<p>mouse_event(MOUSEEVENTF_MOVE &#43; MOUSEEVENTF_LEFTDOWN &#43; ...</p>
<p>when moving will be doen execute below ... &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</p>
<p>mouse_event(MOUSEEVENTF_LEFTUP, 0u, 0u, 0u, (UIntPtr)0);</p>
<p>Thanks...</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace WindowsFormsMouse
{
    public partial class formMouse : Form
    {
        public formMouse()
        {
            InitializeComponent();
        }


        [DllImport(&quot;user32.dll&quot;, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_HWHEEL = 0x01000;

        //http://www.pinvoke.net/default.aspx/user32.mouse_event
        //https://msdn.microsoft.com/en-us/library/windows/desktop/ms646260(v=vs.85).aspx

        private void MoveCursor(string Direction)
        {
            // Set the Current cursor, move the cursor's Position,
 
            // mouse_event moves in a coordinate system where
            // (0, 0) is in the upper left corner and
            // (65535,65535) is in the lower right corner.

            // Get the current mouse coordinates and convert
            // them into this new system.
            
            int X = 0; // Cursor.Position.X;
            int Y = 0; // Cursor.Position.Y;
           
            uint action = 0;

            if (Direction == &quot;Up&quot;)      { action =  MOUSEEVENTF_MOVE ; Y = -3;  X = 0; }
            else if (Direction == &quot;Down&quot;) { action =  MOUSEEVENTF_MOVE ; Y =  3;  X = 0; }
            else if (Direction == &quot;Left&quot;) { action =  MOUSEEVENTF_MOVE ; Y = 0 ;  X = -3; }
            else if (Direction == &quot;Right&quot;) { action =  MOUSEEVENTF_MOVE ; Y = 0 ;  X =  3; }

            else if (Direction == &quot;L&quot;) 
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0u, 0u, 0u, (UIntPtr)0);
                Thread.Sleep(100);
                mouse_event(MOUSEEVENTF_LEFTUP, 0u, 0u, 0u, (UIntPtr)0);
                return;
            }
            else if (Direction == &quot;R&quot;)
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0u, 0u, 0u, (UIntPtr)0);
                Thread.Sleep(100);
                mouse_event(MOUSEEVENTF_RIGHTUP, 0u, 0u, 0u, (UIntPtr)0);
                return;
            }
           
            else return;

            // mouse_event(MOUSEEVENTF_ABSOLUTE &#43; MOUSEEVENTF_MOVE &#43; MOUSEEVENTF_LEFTDOWN &#43; MOUSEEVENTF_LEFTUP .... 
            mouse_event(action, (uint)X, (uint)Y, (uint)0, (UIntPtr)0);

        }

        // Below just for example : how to manage &quot;Mouse' by Key  ...
        
        private void formMouse_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    MoveCursor(&quot;Down&quot;);
                    break;
                case Keys.Up:
                    MoveCursor(&quot;Up&quot;);
                    break;
                case Keys.Left:
                    MoveCursor(&quot;Left&quot;);
                    break;
                case Keys.Right:
                    MoveCursor(&quot;Right&quot;);
                    break;
                case Keys.L:
                    MoveCursor(&quot;L&quot;);
                    break;
                case Keys.R:
                    MoveCursor(&quot;R&quot;);
                    break;
            }
        }


    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Drawing;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows.Forms;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Runtime.InteropServices;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WindowsFormsMouse&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;formMouse&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;formMouse()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[DllImport(<span class="cs__string">&quot;user32.dll&quot;</span>,&nbsp;CharSet&nbsp;=&nbsp;CharSet.Auto,&nbsp;CallingConvention&nbsp;=&nbsp;CallingConvention.StdCall)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">extern</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;mouse_event(<span class="cs__keyword">uint</span>&nbsp;dwFlags,&nbsp;<span class="cs__keyword">uint</span>&nbsp;dx,&nbsp;<span class="cs__keyword">uint</span>&nbsp;dy,&nbsp;<span class="cs__keyword">uint</span>&nbsp;dwData,&nbsp;UIntPtr&nbsp;dwExtraInfo);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">uint</span>&nbsp;MOUSEEVENTF_ABSOLUTE&nbsp;=&nbsp;0x8000;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">uint</span>&nbsp;MOUSEEVENTF_LEFTDOWN&nbsp;=&nbsp;0x0002;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">uint</span>&nbsp;MOUSEEVENTF_LEFTUP&nbsp;=&nbsp;0x0004;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">uint</span>&nbsp;MOUSEEVENTF_MIDDLEDOWN&nbsp;=&nbsp;0x0020;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">uint</span>&nbsp;MOUSEEVENTF_MIDDLEUP&nbsp;=&nbsp;0x0040;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">uint</span>&nbsp;MOUSEEVENTF_MOVE&nbsp;=&nbsp;0x0001;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">uint</span>&nbsp;MOUSEEVENTF_RIGHTDOWN&nbsp;=&nbsp;0x0008;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">uint</span>&nbsp;MOUSEEVENTF_RIGHTUP&nbsp;=&nbsp;0x0010;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">uint</span>&nbsp;MOUSEEVENTF_XDOWN&nbsp;=&nbsp;0x0080;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">uint</span>&nbsp;MOUSEEVENTF_XUP&nbsp;=&nbsp;0x0100;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">uint</span>&nbsp;MOUSEEVENTF_WHEEL&nbsp;=&nbsp;0x0800;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">uint</span>&nbsp;MOUSEEVENTF_HWHEEL&nbsp;=&nbsp;0x01000;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//http://www.pinvoke.net/default.aspx/user32.mouse_event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//https://msdn.microsoft.com/en-us/library/windows/desktop/ms646260(v=vs.85).aspx</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;MoveCursor(<span class="cs__keyword">string</span>&nbsp;Direction)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;the&nbsp;Current&nbsp;cursor,&nbsp;move&nbsp;the&nbsp;cursor's&nbsp;Position,</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;mouse_event&nbsp;moves&nbsp;in&nbsp;a&nbsp;coordinate&nbsp;system&nbsp;where</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;(0,&nbsp;0)&nbsp;is&nbsp;in&nbsp;the&nbsp;upper&nbsp;left&nbsp;corner&nbsp;and</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;(65535,65535)&nbsp;is&nbsp;in&nbsp;the&nbsp;lower&nbsp;right&nbsp;corner.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;the&nbsp;current&nbsp;mouse&nbsp;coordinates&nbsp;and&nbsp;convert</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;them&nbsp;into&nbsp;this&nbsp;new&nbsp;system.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;X&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;<span class="cs__com">//&nbsp;Cursor.Position.X;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;Y&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;<span class="cs__com">//&nbsp;Cursor.Position.Y;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">uint</span>&nbsp;action&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Direction&nbsp;==&nbsp;<span class="cs__string">&quot;Up&quot;</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;action&nbsp;=&nbsp;&nbsp;MOUSEEVENTF_MOVE&nbsp;;&nbsp;Y&nbsp;=&nbsp;-<span class="cs__number">3</span>;&nbsp;&nbsp;X&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(Direction&nbsp;==&nbsp;<span class="cs__string">&quot;Down&quot;</span>)&nbsp;{&nbsp;action&nbsp;=&nbsp;&nbsp;MOUSEEVENTF_MOVE&nbsp;;&nbsp;Y&nbsp;=&nbsp;&nbsp;<span class="cs__number">3</span>;&nbsp;&nbsp;X&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(Direction&nbsp;==&nbsp;<span class="cs__string">&quot;Left&quot;</span>)&nbsp;{&nbsp;action&nbsp;=&nbsp;&nbsp;MOUSEEVENTF_MOVE&nbsp;;&nbsp;Y&nbsp;=&nbsp;<span class="cs__number">0</span>&nbsp;;&nbsp;&nbsp;X&nbsp;=&nbsp;-<span class="cs__number">3</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(Direction&nbsp;==&nbsp;<span class="cs__string">&quot;Right&quot;</span>)&nbsp;{&nbsp;action&nbsp;=&nbsp;&nbsp;MOUSEEVENTF_MOVE&nbsp;;&nbsp;Y&nbsp;=&nbsp;<span class="cs__number">0</span>&nbsp;;&nbsp;&nbsp;X&nbsp;=&nbsp;&nbsp;<span class="cs__number">3</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(Direction&nbsp;==&nbsp;<span class="cs__string">&quot;L&quot;</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mouse_event(MOUSEEVENTF_LEFTDOWN,&nbsp;0u,&nbsp;0u,&nbsp;0u,&nbsp;(UIntPtr)<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thread.Sleep(<span class="cs__number">100</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mouse_event(MOUSEEVENTF_LEFTUP,&nbsp;0u,&nbsp;0u,&nbsp;0u,&nbsp;(UIntPtr)<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(Direction&nbsp;==&nbsp;<span class="cs__string">&quot;R&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mouse_event(MOUSEEVENTF_RIGHTDOWN,&nbsp;0u,&nbsp;0u,&nbsp;0u,&nbsp;(UIntPtr)<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thread.Sleep(<span class="cs__number">100</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mouse_event(MOUSEEVENTF_RIGHTUP,&nbsp;0u,&nbsp;0u,&nbsp;0u,&nbsp;(UIntPtr)<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;mouse_event(MOUSEEVENTF_ABSOLUTE&nbsp;&#43;&nbsp;MOUSEEVENTF_MOVE&nbsp;&#43;&nbsp;MOUSEEVENTF_LEFTDOWN&nbsp;&#43;&nbsp;MOUSEEVENTF_LEFTUP&nbsp;....&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mouse_event(action,&nbsp;(<span class="cs__keyword">uint</span>)X,&nbsp;(<span class="cs__keyword">uint</span>)Y,&nbsp;(<span class="cs__keyword">uint</span>)<span class="cs__number">0</span>,&nbsp;(UIntPtr)<span class="cs__number">0</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Below&nbsp;just&nbsp;for&nbsp;example&nbsp;:&nbsp;how&nbsp;to&nbsp;manage&nbsp;&quot;Mouse'&nbsp;by&nbsp;Key&nbsp;&nbsp;...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;formMouse_KeyDown(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;KeyEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(e.KeyCode)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;Keys.Down:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MoveCursor(<span class="cs__string">&quot;Down&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;Keys.Up:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MoveCursor(<span class="cs__string">&quot;Up&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;Keys.Left:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MoveCursor(<span class="cs__string">&quot;Left&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;Keys.Right:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MoveCursor(<span class="cs__string">&quot;Right&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;Keys.L:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MoveCursor(<span class="cs__string">&quot;L&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;Keys.R:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MoveCursor(<span class="cs__string">&quot;R&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
