# Getting Started With CocosSharp Game Development For Windows Phone
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Windows Phone
- CocosSharp
## Topics
- Windows Phone
- CocosSharp
## Updated
- 09/21/2016
## Description

<h1>Introduction</h1>
<p><img id="159353" src="159353-14.gif" alt="" width="552" height="301"></p>
<p><span>In this article let's see about CocosSharp for Windows phone.&nbsp;</span><span>CocosSharp is a 2D Game engine for C#, F# and .Net developers which is used to develop cross-platform games. For more details check this&nbsp;<a href="https://developer.xamarin.com/guides/cross-platform/game_development/cocossharp/first_game/" target="_blank">link</a>.</span></p>
<div id="pastingspan1"><span>In this article we will see&nbsp;</span>&nbsp;</div>
<div id="pastingspan1">
<ol>
<li>Prerequisites and Installation Steps </li><li>Creating first CocosSharp Project for Windows Phone </li><li>First simple Touch and Fun Game program </li></ol>
</div>
<h1><span>Building the Sample</span></h1>
<h1><strong>Prerequisites and Installation Steps</strong></h1>
<ul type="disc">
<li>Visual Studio 2015: You can download it from&nbsp;<a href="https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx" target="_blank">here</a>.
</li><li>CocosSharp Installation Steps </li></ul>
<p>To add the CocosSharp template&nbsp;in our Visual Studio first we add extensions in tools option.</p>
<p>Open Visual Studio 2015 and at the top from Tools menu select Options.</p>
<p><img id="159354" src="159354-00.png" alt="" width="305" height="470"></p>
<p>We can see our Options window has been opened .Click on &ldquo;Extensions and Updates&rdquo;. If Mobile Essentioal is not added ,Click on Add and in name we can give as &ldquo;Mobile Essential&rdquo; and in URL give the URL as http://gallery.mobileessentials.org/feed.atom
 . Click ok,</p>
<p><img id="159356" src="159356-001.png" alt="" width="549" height="309"></p>
<p>Next step is to download and install CoCosSharp Templates.<br>
<br>
Click on Tools and select Extensions and Updates from the menu.</p>
<p><img id="159357" src="159357-01.png" alt="" width="377" height="506"></p>
<p>In the Left side select Online &gt; Mobile Essential,</p>
<p><img id="159358" src="159358-1.png" alt="" width="544" height="300"></p>
<p>Now we can see CocosSharp Templates click download button.</p>
<p><img id="159359" src="159359-2.png" alt="" width="439" height="253"></p>
<p>Install the CocosSharp Templates,</p>
<p><img id="159360" src="159360-3.png" alt="" width="367" height="250"></p>
<p>After Installation .Open Visual Studio 2015 and Click on create new project and .select CoCosSharp from the left side templates.Select your CoCosSharp Development as Android, IOS or Windows. In our example we will be using for Wondows Phone.</p>
<p><img id="159361" src="159361-4.png" alt="" width="490" height="296"></p>
<p>If Xamarin is not installed install it by fallowing the steps.</p>
<p><img id="159362" src="159362-5.png" alt="" width="450" height="206"></p>
<p>Reference Link:&nbsp;<em>https://forums.xamarin.com/discussion/30701/cocossharp-project-templates-for-visual-studio</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><strong style="font-size:2em">Creating first CocosSharp Project for Windows Phone</strong></p>
<p>After installing the Visual Studio 2015 and CocosSharp templates, click Start &gt;&gt; Programs &gt;&gt; select Visual Studio 2015 &gt;&gt; Click Visual Studio 2015. Click New &gt;&gt; Project &gt;&gt; select CocosSharp &gt;&gt; Select CocosSharp Game (Windows
 Phone).</p>
<p><img id="159363" src="159363-6.png" alt="" width="502" height="304"></p>
<div>
<p>Select your project folder , give your project name and click ok.</p>
</div>
<div>
<p><span>Once our project has been created we can see MainPage.Xaml and GameLayer.CS file in the solution explorer.</span></p>
</div>
<p><img id="159364" src="159364-7.png" alt="" width="205" height="167"></p>
<div>
<h2><strong>MainPage.Xaml</strong></h2>
<p>By default the main screen name will be Mainpage.xaml.</p>
</div>
<div>
<p><span><br>
<span>Here the design page extension will be Extensible Application Markup Language (XAML). If you have worked with WPF then it will be easy to work with Universal Application as in WPF all form file will be as XAML.</span></span></p>
<h2><strong>GameLayer.CS</strong></h2>
<p>GameLayer is the main Class of CocosSharp. The program will be begins from this class and this is similar to our program class in C# Console application.</p>
<h2><strong>GameLayer() Method</strong></h2>
<p>This class has the contractor method&nbsp;GameLayer().For the layer default back color will be set in the GameLayer() method parameter we can change as per our need. When we create our first application GameLayer() method will be added with a default backcolor
 and with one lable like below code. This method is similar to ASP.NET page Init Method. Here we can see in the above code one label has been added.</p>
</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Define a label variable  
        CCLabel label;  
  
        public GameLayer() : base(CCColor4B.Blue)  
        {  
  
            // create and initialize a Label  
            label = new CCLabel(&quot;Hello CocosSharp&quot;, &quot;MarkerFelt&quot;, 22, CCLabelFormat.SpriteFont);  
  
            // add the label as a child to this Layer  
            AddChild(label);  
  
        }  </pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;Define&nbsp;a&nbsp;label&nbsp;variable&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CCLabel&nbsp;label;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;GameLayer()&nbsp;:&nbsp;base(CCColor4B.Blue)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;create&nbsp;and&nbsp;initialize&nbsp;a&nbsp;Label&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;CCLabel(<span class="js__string">&quot;Hello&nbsp;CocosSharp&quot;</span>,&nbsp;<span class="js__string">&quot;MarkerFelt&quot;</span>,&nbsp;<span class="js__num">22</span>,&nbsp;CCLabelFormat.SpriteFont);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;add&nbsp;the&nbsp;label&nbsp;as&nbsp;a&nbsp;child&nbsp;to&nbsp;this&nbsp;Layer&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddChild(label);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2><strong>AddedToScene() Method</strong></h2>
<p>This class has another override method AddedToScene().In this method we create events for our layer for example we can see by default this method will be initialized an event for OnTouchesEnded mobile phone Touch(in normal emulator it will be used as mouse
 Click release event),</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">protected override void AddedToScene()  
        {  
            base.AddedToScene();  
  
            // Use the bounds to layout the positioning of our drawable assets  
            var bounds = VisibleBoundsWorldspace;  
  
            // position the label on the center of the screen  
            label.Position = bounds.Center;    
            // Register for touch events  
            var touchListener = new CCEventListenerTouchAllAtOnce();  
            touchListener.OnTouchesEnded = OnTouchesEnded;  
            AddEventListener(touchListener, this);  
        }  </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span><span class="cs__keyword">override</span><span class="cs__keyword">void</span>&nbsp;AddedToScene()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.AddedToScene();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Use&nbsp;the&nbsp;bounds&nbsp;to&nbsp;layout&nbsp;the&nbsp;positioning&nbsp;of&nbsp;our&nbsp;drawable&nbsp;assets&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bounds&nbsp;=&nbsp;VisibleBoundsWorldspace;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;position&nbsp;the&nbsp;label&nbsp;on&nbsp;the&nbsp;center&nbsp;of&nbsp;the&nbsp;screen&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label.Position&nbsp;=&nbsp;bounds.Center;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Register&nbsp;for&nbsp;touch&nbsp;events&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;touchListener&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CCEventListenerTouchAllAtOnce();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;touchListener.OnTouchesEnded&nbsp;=&nbsp;OnTouchesEnded;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddEventListener(touchListener,&nbsp;<span class="cs__keyword">this</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2><strong>OnTouchesEnded() Event</strong></h2>
<p>This event will be triggered whenever someone touch the mobile and take the finger from mobile. This is similar to MouseUp event.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">void OnTouchesEnded(List&lt;CCTouch&gt; touches, CCEvent touchEvent)  
        {  
            if (touches.Count &gt; 0)  
            {  
                // Perform touch handling here  
            }  
        }  </pre>
<div class="preview">
<pre class="js"><span class="js__operator">void</span>&nbsp;OnTouchesEnded(List&lt;CCTouch&gt;&nbsp;touches,&nbsp;CCEvent&nbsp;touchEvent)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(touches.Count&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Perform&nbsp;touch&nbsp;handling&nbsp;here&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Here is how the default GameLayer class will be look.</span></div>
<p><img id="159365" src="159365-9.png" alt="" width="560" height="378"></p>
<p>&nbsp;</p>
<div>
<h2><strong>Run the Program</strong></h2>
</div>
<div>
<p><span>Select our Emulator to display our output and click run.</span></p>
<p><img id="159367" src="159367-8.png" alt="" width="520" height="211"></p>
<div>
<p>When we run the program we can see the output in emulator.</p>
</div>
<div>
<p><span>Here we can see our layer Back color is set as blue and label is displayed in the center of the screen.</span></p>
</div>
<p><span><br>
</span></p>
</div>
<p><img id="159366" src="159366-10.png" alt="" width="488" height="263"></p>
<h1><strong>First simple Touch and Fun Game program</strong></h1>
<p>Now let&rsquo;s see how to create our simple Touch and Fun Game program by adding images in our layer.</p>
<p><span>click Start &gt;&gt; Programs &gt;&gt; select Visual Studio 2015 &gt;&gt; Click Visual Studio 2015. Click New &gt;&gt; Project &gt;&gt; select CocosSharp &gt;&gt;</span>&nbsp;Select CocosSharp Game (Windows Phone).</p>
<p><img id="159363" src="159363-6.png" alt="" width="502" height="304"></p>
<p>Select your project folder , give your project name and click ok.</p>
<h2><strong>Add Images</strong></h2>
<p><span>In this program we will be adding image to our layer and in when user touch the windows phone or clicks on emulator we will move then image upside and down.For this first we will create some image by our self and add the images to our project.</span></p>
<p><span>To add image right click on Content folder from solution .Click Add&gt; Select Existing Item &gt;Select your image and add to the content folder.</span></p>
<p><img id="159368" src="159368-11.png" alt="" width="539" height="297"></p>
<p><span>In our example program we have added two images one as square and one as ball.</span></p>
<p><img id="159369" src="159369-12.png" alt="" width="169" height="199"></p>
<div>
<p>For image rendering we will be using CCSprite Class .to know more about CCSprite class check this&nbsp;<a href="https://developer.xamarin.com/api/type/CocosSharp.CCSprite/" target="_blank">link</a>.</p>
</div>
<div>
<h2><strong>Adding Images to Layers</strong></h2>
<p><span>First we declare label, CCSprite variable. In this example for the layer we have set the back color as white.<br>
</span><br>
We set the label Color as blue. To add image in our CCSprite class we pass the image name as method parameter. We add the image to the layer and similarly we add two images.&nbsp;</p>
</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Define a label variable  
        CCLabel label;  
        //Define CCSprite Variable  
        CCSprite paddleSprite;  
        CCSprite paddleSpriteball;  
        //Define boolean variable for image reach to top check  
  
        Boolean reachedtop = false;  
        public GameLayer() : base(CCColor4B.White)  
        {  
  
            // create and initialize a Label  
            label = new CCLabel(&quot;Welcome to Shanu CocosSharp Game for Windows&quot;, &quot;MarkerFelt&quot;, 22, CCLabelFormat.SpriteFont);  
            label.Color = CCColor3B.Blue;  
            // add the label as a child to this Layer  
            AddChild(label);  
  
  
            paddleSprite = new CCSprite(&quot;squre&quot;);  
            paddleSprite.PositionX = 100;  
            paddleSprite.PositionY = 100;  
  
            paddleSpriteball = new CCSprite(&quot;ball&quot;);  
            paddleSpriteball.PositionX = 620;  
            paddleSpriteball.PositionY = 620;  
  
            AddChild(paddleSprite);  
            AddChild(paddleSpriteball);  
            
  
        }  </pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;Define&nbsp;a&nbsp;label&nbsp;variable&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CCLabel&nbsp;label;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Define&nbsp;CCSprite&nbsp;Variable&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CCSprite&nbsp;paddleSprite;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CCSprite&nbsp;paddleSpriteball;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Define&nbsp;boolean&nbsp;variable&nbsp;for&nbsp;image&nbsp;reach&nbsp;to&nbsp;top&nbsp;check&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">Boolean</span>&nbsp;reachedtop&nbsp;=&nbsp;false;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;GameLayer()&nbsp;:&nbsp;base(CCColor4B.White)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;create&nbsp;and&nbsp;initialize&nbsp;a&nbsp;Label&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;CCLabel(<span class="js__string">&quot;Welcome&nbsp;to&nbsp;Shanu&nbsp;CocosSharp&nbsp;Game&nbsp;for&nbsp;Windows&quot;</span>,&nbsp;<span class="js__string">&quot;MarkerFelt&quot;</span>,&nbsp;<span class="js__num">22</span>,&nbsp;CCLabelFormat.SpriteFont);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label.Color&nbsp;=&nbsp;CCColor3B.Blue;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;add&nbsp;the&nbsp;label&nbsp;as&nbsp;a&nbsp;child&nbsp;to&nbsp;this&nbsp;Layer&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddChild(label);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSprite&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;CCSprite(<span class="js__string">&quot;squre&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSprite.PositionX&nbsp;=&nbsp;<span class="js__num">100</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSprite.PositionY&nbsp;=&nbsp;<span class="js__num">100</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSpriteball&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;CCSprite(<span class="js__string">&quot;ball&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSpriteball.PositionX&nbsp;=&nbsp;<span class="js__num">620</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSpriteball.PositionY&nbsp;=&nbsp;<span class="js__num">620</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddChild(paddleSprite);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddChild(paddleSpriteball);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>We set one image at the bottom left and another image as top right. When we run we can see the output in our emulator like this.</span></div>
<p><img id="159370" src="159370-13.png" alt="" width="547" height="267"></p>
<p>&nbsp;</p>
<p><span>Now we have added image to our layer and also added welcome text in center of the screen.</span><br>
<br>
<span>Next step is to create an event on Touch to move the image.</span></p>
<h2><strong>Touch Event to Move Image</strong></h2>
<p><span>In touch end event we check for image position and increment the xValue and yValue to move up for one image and decrement the xValue and yValue to move down of another image.Once the image reach to top or bottom we reverse the process for continues
 image movement of upside and down.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">void OnTouchesEnded(List&lt;CCTouch&gt; touches, CCEvent touchEvent)  
        {  
            if (touches.Count &gt; 0)  
            {  
                // Perform touch handling here  
                if(paddleSprite.PositionY &gt; 620)  
                {  
                    reachedtop = true;  
                }  
               else if(paddleSprite.PositionY &lt;100)  
                 {  
                    reachedtop = false;  
                }  
  
                if (reachedtop ==false)  
                {  
                    if (paddleSprite.PositionY &gt;= 80 &amp;&amp; paddleSprite.PositionY &lt;= 620)  
                    {  
                        paddleSprite.PositionX = paddleSprite.PositionX &#43; 20;  
                        paddleSprite.PositionY = paddleSprite.PositionX &#43; 20;  
  
  
                        paddleSpriteball.PositionX = paddleSpriteball.PositionX - 20;  
                        paddleSpriteball.PositionY = paddleSpriteball.PositionX - 20;  
                    }  
                }  
                else  
                {  
                    paddleSprite.PositionX = paddleSprite.PositionX - 20;  
                    paddleSprite.PositionY = paddleSprite.PositionX - 20;  
  
  
                    paddleSpriteball.PositionX = paddleSpriteball.PositionX &#43; 20;  
                    paddleSpriteball.PositionY = paddleSpriteball.PositionX &#43; 20;  
                }               
               }                 
            }  </pre>
<div class="preview">
<pre class="js"><span class="js__operator">void</span>&nbsp;OnTouchesEnded(List&lt;CCTouch&gt;&nbsp;touches,&nbsp;CCEvent&nbsp;touchEvent)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(touches.Count&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Perform&nbsp;touch&nbsp;handling&nbsp;here&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(paddleSprite.PositionY&nbsp;&gt;&nbsp;<span class="js__num">620</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reachedtop&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__statement">if</span>(paddleSprite.PositionY&nbsp;&lt;<span class="js__num">100</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reachedtop&nbsp;=&nbsp;false;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(reachedtop&nbsp;==false)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(paddleSprite.PositionY&nbsp;&gt;=&nbsp;<span class="js__num">80</span>&nbsp;&amp;&amp;&nbsp;paddleSprite.PositionY&nbsp;&lt;=&nbsp;<span class="js__num">620</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSprite.PositionX&nbsp;=&nbsp;paddleSprite.PositionX&nbsp;&#43;&nbsp;<span class="js__num">20</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSprite.PositionY&nbsp;=&nbsp;paddleSprite.PositionX&nbsp;&#43;&nbsp;<span class="js__num">20</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSpriteball.PositionX&nbsp;=&nbsp;paddleSpriteball.PositionX&nbsp;-&nbsp;<span class="js__num">20</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSpriteball.PositionY&nbsp;=&nbsp;paddleSpriteball.PositionX&nbsp;-&nbsp;<span class="js__num">20</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSprite.PositionX&nbsp;=&nbsp;paddleSprite.PositionX&nbsp;-&nbsp;<span class="js__num">20</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSprite.PositionY&nbsp;=&nbsp;paddleSprite.PositionX&nbsp;-&nbsp;<span class="js__num">20</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSpriteball.PositionX&nbsp;=&nbsp;paddleSpriteball.PositionX&nbsp;&#43;&nbsp;<span class="js__num">20</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paddleSpriteball.PositionY&nbsp;=&nbsp;paddleSpriteball.PositionX&nbsp;&#43;&nbsp;<span class="js__num">20</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><span>When we run the program in emulator or in windows phone we can see the output like below image.</span></p>
<p>&nbsp;</p>
<p><img id="159353" src="159353-14.gif" alt="" width="552" height="301"></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em><em><span>CocosSharpGameWnd.zip</span>.</em></em> </li></ul>
<h1>More Information</h1>
<p><em>Download all the&nbsp;Prerequisites and fallow the Installation Steps to intall.</em></p>
