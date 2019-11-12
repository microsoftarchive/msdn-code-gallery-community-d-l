# Input Validation in Xamarin Forms Behaviors
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Xamarin.Android
- Xamarin.iOS
- Xamarin
- Xamarin.Forms
- UWP
## Topics
- Validation
- behavior
- Xamarin.Forms
- Xaamrin.Form Behavior
## Updated
- 10/03/2016
## Description

<h1>Introduction</h1>
<p dir="ltr"><span style="font-size:small">Xamarin.Forms behaviors are created by deriving from the Behavior or Behavior&lt;T&gt; class,&nbsp;where&nbsp;T&nbsp;is the type of the control (Entry, DateTime, etc) to which the behavior should apply.
</span></p>
<p dir="ltr"><span style="font-size:small">In this article I will demonstrates how to create and consume Xamarin.Forms behaviors and Input Validation using xamarin Forms Behaviors.</span></p>
<p dir="ltr"><span><img src=":-hhsxeoxduelrwsbsjwraketyy4ska1gh45iavh1tll7ue0pz4ijsylo7qq8e9aom-zxzydfu2rm_rtndnu3ygtg38nbklgc_-5qo7_updrvpfvbil6d4pkazhqmnlllu07or5m7tfti6tmajpw" alt="" width="624" height="324"></span></p>
<h1 dir="ltr"><span>Why We Need Behaviors?</span></h1>
<p dir="ltr"><span style="font-size:small">Normally we will write validation code into the code-behind because it directly interacts with the API of the control so that we can create Behaviors and reuse into the different control. We can be used to provide
 a full range of functionality to controls, like below </span></p>
<ul>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">Number Validation </span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Date Validation </span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Email Validation </span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Password Validation </span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Compare Validation</span></p>
</li></ul>
<h1 dir="ltr"><span>Building and Running the Application</span></h1>
<p dir="ltr"><span style="font-size:small">The Creating xamarin.Forms Behaviors application is as follow below steps
</span></p>
<p dir="ltr"><span style="font-size:small">Step 1 - Create new Xamarin Form Application
</span></p>
<p dir="ltr"><span style="font-size:small">Let's start with creating a new Xamarin Forms Project in Visual Studio.<br class="kix-line-break">
<br class="kix-line-break">
Open Run - Type Devenev.Exe and enter - New Project (Ctrl&#43;Shift&#43;N) - select Blank Xaml App (Xamarin.Forms Portable) template</span></p>
<p dir="ltr"><span><img src=":-_xsuyss59-7zzgzmyp0ukr2undqplrvcabh8rhz5-iyq09p0_p48xc8cbsw0spbkooow986qn4bvr0hodmbstgkdwc-uoeyjyx9tcjzw8o4kwxjjwwzie_5x1ao94apl2am-qr5fnxjjt4datq" alt="" width="623" height="353"></span></p>
<p dir="ltr"><span style="font-size:small">You can find my previous article for more about create new xamarin.Form application from
<a href="http://www.c-sharpcorner.com/article/how-to-create-first-xamarin-form-application/">
Here</a>.</span></p>
<p dir="ltr"><strong><span style="font-size:small">Step 2 &ndash; Create new class and inherits from the Behavior:</span></strong></p>
<p dir="ltr"><span style="font-size:small">Create a new class and inherits from the Behavior or Behavior&lt;T&gt; class .We can add behavior to any control so you can specify your control name instead of T.</span></p>
<p dir="ltr"><span><img src=":-qwixcgif_yozm4zegbuisri9kkai15chmckgbovugdxc1lwj4zvjbj0ys7v3zo3uexwfdgmragcksfjh6u8yx1wbllejd0jgxqbcuoewrfr3qxmphjxdlan5gmtaadjjo-iyxt-flgmxjyu_9w" alt="" width="338" height="299"></span></p>
<p dir="ltr"><strong><span style="font-size:small">Step 2 &ndash;Override Behavior class method:</span></strong></p>
<p dir="ltr"><span style="font-size:small">We need to override OnAttachedTo and OnDetachingFrom method from our validation class</span></p>
<p>&nbsp;</p>
<p dir="ltr"><span><img src=":-otg68zqdfa3vjckbki2qdyqix1m2i3nuv8vytbaw2r5cxphwmge8zuvojoae7tjo-vcz-1zbbs8yvdiagvjfqejjok34xl9hqv4mpc5rnd7iedozwefagkaltvw9ewytcyynib-nwmtplne7ca" alt="" width="624" height="431"></span></p>
<p>&nbsp;</p>
<p dir="ltr"><span style="font-size:small">The&nbsp;<strong>OnAttachedTo&nbsp;</strong>method is fired immediately after the behavior is attached to a control. This can be used to register event handlers or perform other setup that's required to support the
 behavior functionality.</span></p>
<p>&nbsp;</p>
<p dir="ltr"><span style="font-size:small">The&nbsp;<strong>OnDetachingFrom&nbsp;</strong>method is fired when the behavior is removed from the control. This method receives a reference to the control to which it is attached, and is used to perform any required
 cleanup.</span></p>
<p dir="ltr"><strong><span style="font-size:small">Step 3 &ndash;Validation Behavior Class:</span></strong></p>
<p dir="ltr"><strong><span style="font-size:small">3.1 &ndash; PasswordValidationBehavior:</span></strong></p>
<p dir="ltr"><span style="font-size:small">The below code is password validation behaviors. Password rule should contain at least 8 character, 1 numeric, 1 lowercase, 1 uppercase, 1 special character [eg: No1C#cornar]</span></p>
<p dir="ltr"><span style="font-size:small">The password validation behavior added into Entry control. We can re-use this behavior to Entry control.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.RegularExpressions.aspx" target="_blank" title="Auto generated link to System.Text.RegularExpressions">System.Text.RegularExpressions</a>;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;DevenvExeBehaviors&nbsp;
&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;PasswordValidationBehavior&nbsp;:&nbsp;Behavior&lt;Entry&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;passwordRegex&nbsp;=&nbsp;@<span class="cs__string">&quot;^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&amp;])[A-Za-z\d$@$!%*#?&amp;]{8,}$&quot;</span>;&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnAttachedTo(Entry&nbsp;bindable)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bindable.TextChanged&nbsp;&#43;=&nbsp;HandleTextChanged;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnAttachedTo(bindable);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;HandleTextChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;TextChangedEventArgs&nbsp;e)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsValid&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsValid&nbsp;=&nbsp;(Regex.IsMatch(e.NewTextValue,&nbsp;passwordRegex));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((Entry)sender).TextColor&nbsp;=&nbsp;IsValid&nbsp;?&nbsp;Color.Default&nbsp;:&nbsp;Color.Red;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnDetachingFrom(Entry&nbsp;bindable)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bindable.TextChanged&nbsp;-=&nbsp;HandleTextChanged;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnDetachingFrom(bindable);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}&nbsp;
&nbsp;</pre>
</div>
</div>
</div>
<p dir="ltr"><strong><span style="font-size:small">3.2 - Date Validation Behaviors:</span></strong></p>
<p dir="ltr"><span style="font-size:small">The below code is Date of birth validation behaviors. I used a date picker and restricted the max date to be&nbsp;100&nbsp;years from the current day and min date to be 1.</span></p>
<p>&nbsp;</p>
<p dir="ltr"><span style="font-size:small">The DOB validation behavior added into DatePicker control. We can re-use this behavior to Date Picker control.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;DevenvExeBehaviors&nbsp;
&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;DateValidationBehavior&nbsp;:&nbsp;Behavior&lt;DatePicker&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnAttachedTo(DatePicker&nbsp;datepicker)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;datepicker.DateSelected&nbsp;&#43;=&nbsp;Datepicker_DateSelected;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnAttachedTo(datepicker);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Datepicker_DateSelected(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;DateChangedEventArgs&nbsp;e)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DateTime&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;e.NewDate;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;year&nbsp;=&nbsp;DateTime.Now.Year;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;selyear&nbsp;=&nbsp;<span class="cs__keyword">value</span>.Year;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;result&nbsp;=&nbsp;selyear&nbsp;-&nbsp;year;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;isValid=<span class="cs__keyword">false</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(result&nbsp;&lt;=<span class="cs__number">100</span>&nbsp;&amp;&amp;&nbsp;result&nbsp;&gt;<span class="cs__number">0</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isValid&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((DatePicker)sender).BackgroundColor&nbsp;=&nbsp;isValid&nbsp;?&nbsp;Color.Default&nbsp;:&nbsp;Color.Red;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnDetachingFrom(DatePicker&nbsp;datepicker)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;datepicker.DateSelected&nbsp;-=&nbsp;Datepicker_DateSelected;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnDetachingFrom(datepicker);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}&nbsp;
&nbsp;</pre>
</div>
</div>
</div>
<p dir="ltr"><strong><span style="font-size:small">3.3 - EmailValidation Behaviors</span></strong></p>
<p dir="ltr"><span style="font-size:small">The below code is Email validation behaviors. Email validation behavior added into Entry control. We can re-use this behavior to Entry control.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.RegularExpressions.aspx" target="_blank" title="Auto generated link to System.Text.RegularExpressions">System.Text.RegularExpressions</a>;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;DevenvExeBehaviors&nbsp;
&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;EmailValidatorBehavior&nbsp;:&nbsp;Behavior&lt;Entry&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;emailRegex&nbsp;=&nbsp;@<span class="cs__string">&quot;^(?(&quot;</span><span class="cs__string">&quot;)(&quot;</span><span class="cs__string">&quot;.&#43;?(?&lt;!\\)&quot;</span><span class="cs__string">&quot;@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&amp;'\*\&#43;/=\?\^`\{\}\|~\w])*)(?&lt;=[0-9a-z])@))&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@<span class="cs__string">&quot;(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)&#43;[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$&quot;</span>;&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnAttachedTo(Entry&nbsp;bindable)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bindable.TextChanged&nbsp;&#43;=&nbsp;HandleTextChanged;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnAttachedTo(bindable);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;HandleTextChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;TextChangedEventArgs&nbsp;e)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsValid&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsValid&nbsp;=&nbsp;(Regex.IsMatch(e.NewTextValue,&nbsp;emailRegex,&nbsp;RegexOptions.IgnoreCase,&nbsp;TimeSpan.FromMilliseconds(<span class="cs__number">250</span>)));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((Entry)sender).TextColor&nbsp;=&nbsp;IsValid&nbsp;?&nbsp;Color.Default&nbsp;:&nbsp;Color.Red;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnDetachingFrom(Entry&nbsp;bindable)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bindable.TextChanged&nbsp;-=&nbsp;HandleTextChanged;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnDetachingFrom(bindable);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}&nbsp;
&nbsp;</pre>
</div>
</div>
</div>
<p dir="ltr"><strong><span style="font-size:small">3.4 - Number Validation</span></strong></p>
<p dir="ltr"><span style="font-size:small">The below code is Number validation behaviors. The Entry box will allow only numeric value.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;DevenvExeBehaviors&nbsp;
&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;NumberValidationBehavior&nbsp;:&nbsp;Behavior&lt;Entry&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnAttachedTo(Entry&nbsp;entry)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entry.TextChanged&nbsp;&#43;=&nbsp;OnEntryTextChanged;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnAttachedTo(entry);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnDetachingFrom(Entry&nbsp;entry)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entry.TextChanged&nbsp;-=&nbsp;OnEntryTextChanged;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnDetachingFrom(entry);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;OnEntryTextChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;TextChangedEventArgs&nbsp;args)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;result;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;isValid&nbsp;=&nbsp;<span class="cs__keyword">int</span>.TryParse(args.NewTextValue,&nbsp;<span class="cs__keyword">out</span>&nbsp;result);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((Entry)sender).TextColor&nbsp;=&nbsp;isValid&nbsp;?&nbsp;Color.Default&nbsp;:&nbsp;Color.Red;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="font-size:small">Step 4 &ndash;Behaviors with Parameter</strong><span style="font-size:small">:</span></div>
<p><span style="font-size:small">You can create multiple property in behaviors class and assign value in xaml controls.</span></p>
<p><strong><span style="font-size:small">Step 4.1- Max length Behaviors</span></strong></p>
<p><span style="font-size:small">You can restrict the number of characters in the Entry field as given below,</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;DevenvExeBehaviors&nbsp;
&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MaxLengthValidatorBehavior&nbsp;:&nbsp;Behavior&lt;Entry&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;BindableProperty&nbsp;MaxLengthProperty&nbsp;=&nbsp;BindableProperty.Create(<span class="cs__string">&quot;MaxLength&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">int</span>),&nbsp;<span class="cs__keyword">typeof</span>(MaxLengthValidatorBehavior),&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;MaxLength&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(<span class="cs__keyword">int</span>)GetValue(MaxLengthProperty);&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(MaxLengthProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnAttachedTo(Entry&nbsp;bindable)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bindable.TextChanged&nbsp;&#43;=&nbsp;bindable_TextChanged;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;bindable_TextChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;TextChangedEventArgs&nbsp;e)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.NewTextValue.Length&nbsp;&gt;=&nbsp;MaxLength)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((Entry)sender).Text&nbsp;=&nbsp;e.NewTextValue.Substring(<span class="cs__number">0</span>,&nbsp;MaxLength);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnDetachingFrom(Entry&nbsp;bindable)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bindable.TextChanged&nbsp;-=&nbsp;bindable_TextChanged;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}</pre>
</div>
</div>
</div>
<p dir="ltr"><strong><span style="font-size:small">Step 4.2 - Compare Validation:</span></strong></p>
<p dir="ltr"><span style="font-size:small">The&nbsp;CompareValidator&nbsp;control allows you to compare the value entered by the user into an input control, such as a Entry&nbsp;control, with the value entered into another Entry control.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.RegularExpressions.aspx" target="_blank" title="Auto generated link to System.Text.RegularExpressions">System.Text.RegularExpressions</a>;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;DevenvExeBehaviors&nbsp;
&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CompareValidationBehavior&nbsp;:&nbsp;Behavior&lt;Entry&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;BindableProperty&nbsp;TextProperty&nbsp;=&nbsp;BindableProperty.Create&lt;CompareValidationBehavior,&nbsp;<span class="cs__keyword">string</span>&gt;(tc&nbsp;=&gt;&nbsp;tc.Text,&nbsp;<span class="cs__keyword">string</span>.Empty,&nbsp;BindingMode.TwoWay);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Text&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;(<span class="cs__keyword">string</span>)GetValue(TextProperty);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetValue(TextProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnAttachedTo(Entry&nbsp;bindable)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bindable.TextChanged&nbsp;&#43;=&nbsp;HandleTextChanged;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnAttachedTo(bindable);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;HandleTextChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;TextChangedEventArgs&nbsp;e)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsValid&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsValid&nbsp;=&nbsp;&nbsp;e.NewTextValue&nbsp;==Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((Entry)sender).TextColor&nbsp;=&nbsp;IsValid&nbsp;?&nbsp;Color.Default&nbsp;:&nbsp;Color.Red;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnDetachingFrom(Entry&nbsp;bindable)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bindable.TextChanged&nbsp;-=&nbsp;HandleTextChanged;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnDetachingFrom(bindable);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}&nbsp;
&nbsp;
&nbsp;</pre>
</div>
</div>
</div>
<p dir="ltr"><strong><span style="font-size:small">Step 5 &ndash; Add Behaviors into Control:</span></strong></p>
<p dir="ltr"><span style="font-size:small">Refer below xaml code for add behaviors into entry box</span></p>
<p dir="ltr"><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Entry</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;txtpassword&quot;</span>&nbsp;<span class="xaml__attr_name">IsPassword</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__attr_name">Placeholder</span>=<span class="xaml__attr_value">&quot;Enter&nbsp;Your&nbsp;Password&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:PasswordValidationBehavior&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Entry.Behaviors&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Entry&gt;</span></pre>
</div>
</div>
</div>
<p dir="ltr"><strong><span style="font-size:small">Step 6 &ndash; Add Multiple Behaviors into Control:</span></strong></p>
<p dir="ltr"><span style="font-size:small">Refer below code for attach multiple behaviors into single entry box and pass parameter value
</span></p>
<p dir="ltr"><span>&nbsp;</span></p>
<div dir="ltr">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Entry</span>&nbsp;<span class="xaml__attr_name">IsPassword</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__attr_name">Placeholder</span>=<span class="xaml__attr_value">&quot;Enter&nbsp;same&nbsp;as&nbsp;above&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:PasswordValidationBehavior&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:CompareValidationBehavior&nbsp;<span class="xaml__attr_name">BindingContext</span>=<span class="xaml__attr_value">&quot;{x:Reference&nbsp;txtpassword}&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Text}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Entry.Behaviors&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Entry&gt;</span></pre>
</div>
</div>
</div>
</div>
<p dir="ltr"><strong><span style="font-size:small">Step 7 -UI Design</span></strong></p>
<p dir="ltr"><span style="font-size:small">You can refer below UI Design for all control and behaviors Design</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;?xml</span>&nbsp;<span class="xaml__attr_name">version</span>=<span class="xaml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xaml__attr_name">encoding</span>=<span class="xaml__attr_value">&quot;utf-8&quot;</span>&nbsp;<span class="xaml__tag_start">?&gt;</span>&nbsp;
&nbsp;
<span class="xaml__tag_start">&lt;ContentPage</span>&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://xamarin.com/schemas/2014/forms&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2009/xaml&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">local</span>=<span class="xaml__attr_value">&quot;clr-namespace:DevenvExeBehaviors&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;DevenvExeBehaviors.MainPage&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;<span class="xaml__tag_start">&lt;StackLayout</span>&nbsp;<span class="xaml__attr_name">Padding</span>=<span class="xaml__attr_value">&quot;0,20,0,0&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Name&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;Small&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>&nbsp;<span class="xaml__attr_name">Placeholder</span>=<span class="xaml__attr_value">&quot;Enter&nbsp;Your&nbsp;Name&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Age&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;Small&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>&nbsp;<span class="xaml__attr_name">Placeholder</span>=<span class="xaml__attr_value">&quot;Age&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;Small&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:MaxLengthValidatorBehavior&nbsp;&nbsp;<span class="xaml__attr_name">MaxLength</span>=<span class="xaml__attr_value">&quot;2&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:NumberValidationBehavior<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Entry.Behaviors&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Entry&gt;</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;DOB&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;Small&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DatePicker</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DatePicker</span>.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:DateValidationBehavior<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DatePicker.Behaviors&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DatePicker&gt;</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Email&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;Small&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>&nbsp;<span class="xaml__attr_name">Placeholder</span>=<span class="xaml__attr_value">&quot;Enter&nbsp;Your&nbsp;Email&nbsp;ID&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:EmailValidatorBehavior&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Entry.Behaviors&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Entry&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Password&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;Small&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;txtpassword&quot;</span>&nbsp;<span class="xaml__attr_name">IsPassword</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__attr_name">Placeholder</span>=<span class="xaml__attr_value">&quot;Enter&nbsp;Your&nbsp;Password&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:PasswordValidationBehavior&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Entry.Behaviors&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Entry&gt;</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Confirm&nbsp;Password&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;Small&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>&nbsp;<span class="xaml__attr_name">IsPassword</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__attr_name">Placeholder</span>=<span class="xaml__attr_value">&quot;Enter&nbsp;same&nbsp;as&nbsp;above&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:PasswordValidationBehavior&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:CompareValidationBehavior&nbsp;<span class="xaml__attr_name">BindingContext</span>=<span class="xaml__attr_value">&quot;{x:Reference&nbsp;txtpassword}&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Text}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Entry.Behaviors&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Entry&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Phone&nbsp;Number&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;Small&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>&nbsp;&nbsp;<span class="xaml__attr_name">Placeholder</span>=<span class="xaml__attr_value">&quot;Enter&nbsp;10&nbsp;digit&nbsp;phone&nbsp;number&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Entry</span>.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:MaxLengthValidatorBehavior&nbsp;&nbsp;<span class="xaml__attr_name">MaxLength</span>=<span class="xaml__attr_value">&quot;10&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:NumberValidationBehavior&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Entry.Behaviors&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Entry&gt;</span>&nbsp;
&nbsp;
&nbsp;<span class="xaml__tag_end">&lt;/StackLayout&gt;</span>&nbsp;
&nbsp;
&nbsp;
<span class="xaml__tag_end">&lt;/ContentPage&gt;</span></pre>
</div>
</div>
</div>
<p dir="ltr"><span style="font-size:small">You can download sample source code and run the application .
</span></p>
<p><br>
<span><img src=":-waqr9ym0yzarm-n0n6krpvu5by7bio-ln7tl0lh4qh25gavac2zjcy0hepbvlakybzvicbyhhjj3viqgswds1camywrlw2bme7ufaquh73p9cacckwh08c7rhaep-fdswsak9l6cb4vtglzl1q" alt="" width="297" height="579"><span id="docs-internal-guid-eaaa2ce9-8bac-71d7-d247-e8ad34e77181"><span><img src=":-0rmbnojjbq_mj5fhkxlwxlyfkbmm7h1luo_uhitdd_qv49bszvw8ghnam_m_1zt5to3c6uatact21y44uv_h4dgufhc1-rcl01pndre8c_kzagixdvdvbp-_fqzvwgillnabywvdgj8mwnrvtq" alt="" width="319" height="574"></span></span></span><span>
</span></p>
