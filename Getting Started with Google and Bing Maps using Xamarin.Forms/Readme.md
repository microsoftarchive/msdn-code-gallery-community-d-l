# Getting Started with Google and Bing Maps using Xamarin.Forms
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Bing Maps
- Xamarin.Android
- Google API
- Xamarin.iOS
- Xamarin.Forms
- Google Map
- Xamarin.Windows
- xamarin.Forms.maps
## Topics
- Using Bing Maps in Windows Phone
- Generate Google API Key
- map in xamarin.forms
- Bing Maps using xamarin.forms
- google map using xamarin.forms
- Generate Bing map API key
## Updated
- 03/01/2017
## Description

<p><span id="docs-internal-guid-5de55eb2-8b4c-38f5-23b3-416749e84c64"></span></p>
<h1 dir="ltr">Introduction</h1>
<p dir="ltr"><span style="font-size:small">Xamarin allows us to integrate maps in our all the platform mobile application. Google and Bing maps combines the power of Xamarin maps. You can show any location on the map, show different routes on the map e.t.c.
 You can refer below image for quickly learn about map implementation using &nbsp;xamarin.forms .In this Article ,I have shared very detail about xamarin forms maps implementation .</span></p>
<p dir="ltr"><span style="font-size:small"><br>
</span></p>
<p dir="ltr"><span><img src=":-s6m7oxvoy-nobakd7vytncqqqdubnocobsshuwp7jj7ju9jq42xgqlt9nf3o9c1z3dd7b5rcveeitzuuawpjq5v9dqxodtzuoe9-owi9afugikqkstqk4lyvyy3kwvgjmoibu26igyzcub-n6w" alt="" width="463" height="567"></span></p>
<h1 dir="ltr"><span>Step 1: Setup new Xamarin.Forms Application:</span></h1>
<p dir="ltr"><span style="font-size:small">Let's start with creating a new Xamarin Forms Project in Visual Studio.<br class="kix-line-break">
<br class="kix-line-break">
Open Run &gt; Type Devenev.Exe and enter &gt; New Project (Ctrl&#43;Shift&#43;N) - select Portable Blank Xaml App
</span></p>
<p dir="ltr"><span><img src=":-y_q-i5w-q_cbyzogi7gmrzvspqdrswhovbilyr-if55ysat6wslrnhayuvg4njo-lln_umqzkcsvy12mj4b_9aybir7wstwbffgrwfebfd40pyjonv-aiihw33mkxsd0rbpadwvzqggpzzrr2w" alt="http://csharpcorner.mindcrackerinc.netdna-cdn.com/article/generate-google-api-key-for-xamarin-android-application/Images/image002.jpg" width="624" height="434"></span></p>
<p dir="ltr"><span style="font-size:small">It will automatically create multiple projects like Portable, Android, iOS, UWP. You can refer to my previous article for more.</span></p>
<ul>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small"><a href="http://www.c-sharpcorner.com/article/how-to-create-first-xamarin-form-application/">How to Create Your First Xamarin.Form Application&nbsp;</a></span></p>
</li></ul>
<p dir="ltr"><strong><span style="font-size:small">Note:</span></strong></p>
<p dir="ltr"><span style="font-size:small">UWP is available in Xamarin.Forms 2.1 and above, and Xamarin.Forms.Maps is supported in Xamarin.Forms 2.2 and above so make sure update xamarin Forms nuget package
</span></p>
<h1 dir="ltr"><span>Step 2: Install Xamarin.Forms.Maps nuget Package:</span></h1>
<p dir="ltr"><span style="font-size:small">Xamarin.Forms.Maps is a cross-platform nuget package for native map APIs on each platform. Map control android will support google map ,windows and UWP apps will support bing map .</span></p>
<p dir="ltr"><span style="font-size:small">Right Click on Solution &gt; Select &ldquo;Manage nuget package for project solution &ldquo; &gt; Select Xamain.Forms.Maps &nbsp;&gt; Select all the Project &gt; Click on Install
</span></p>
<p>&nbsp;</p>
<p dir="ltr"><span><img src=":-dmsop3vxk2n_ydfhet0e6cpvaljkohtvzlp0cmdlbsq930f_bg6-aaw8brxrxn5m15bigz9f-rk4qwv6-nlcay5dvtyt2rstycys3kx5h-gecxhwvxy1sudhjkrrswgffbnj52qotcape7tc-a" alt="" width="499" height="244"></span></p>
<p>&nbsp;</p>
<h1 dir="ltr"><span>Step 3: Add Maps control in Portable library:</span></h1>
<p dir="ltr"><span style="font-size:small">You can design common xaml design to all the platform from portal library.
</span></p>
<ol>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">Add Xamarin.Forms.Maps namespace from MainPage.xaml</span></p>
</li></ol>
<div dir="ltr">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">xmlns:maps=&quot;clr-namespace:Xamarin.Forms.Maps;assembly=Xamarin.Forms.Maps&quot;</pre>
<div class="preview">
<pre class="xaml">xmlns:maps=&quot;clr-namespace:Xamarin.Forms.Maps;assembly=Xamarin.Forms.Maps&quot;</pre>
</div>
</div>
</div>
</div>
<ol>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">Add customized UI map UI Design like below and if you want show user current add
<strong>IsShowingUser=&quot;True&quot;</strong> property from map control.</span></p>
</li></ol>
<div dir="ltr">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;

&lt;ContentPage xmlns=&quot;http://xamarin.com/schemas/2014/forms&quot;

            xmlns:x=&quot;http://schemas.microsoft.com/winfx/2009/xaml&quot;

            xmlns:local=&quot;clr-namespace:DevEnvExeMyLocation&quot;

             xmlns:maps=&quot;clr-namespace:Xamarin.Forms.Maps;assembly=Xamarin.Forms.Maps&quot;

            x:Class=&quot;DevEnvExeMyLocation.MainPage&quot;&gt;

 

&lt;StackLayout VerticalOptions=&quot;StartAndExpand&quot; Padding=&quot;30&quot;&gt;

   &lt;maps:Map WidthRequest=&quot;960&quot; HeightRequest=&quot;700&quot;

       x:Name=&quot;MyMap&quot;

       IsShowingUser=&quot;True&quot;

       MapType=&quot;Street&quot;

       /&gt;

 &lt;/StackLayout&gt;


&lt;/ContentPage&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;?xml</span>&nbsp;<span class="xaml__attr_name">version</span>=<span class="xaml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xaml__attr_name">encoding</span>=<span class="xaml__attr_value">&quot;utf-8&quot;</span>&nbsp;<span class="xaml__tag_start">?&gt;</span>&nbsp;
&nbsp;
<span class="xaml__tag_start">&lt;ContentPage</span>&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://xamarin.com/schemas/2014/forms&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2009/xaml&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">local</span>=<span class="xaml__attr_value">&quot;clr-namespace:DevEnvExeMyLocation&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">maps</span>=<span class="xaml__attr_value">&quot;clr-namespace:Xamarin.Forms.Maps;assembly=Xamarin.Forms.Maps&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;DevEnvExeMyLocation.MainPage&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;
&nbsp;
<span class="xaml__tag_start">&lt;StackLayout</span>&nbsp;<span class="xaml__attr_name">VerticalOptions</span>=<span class="xaml__attr_value">&quot;StartAndExpand&quot;</span>&nbsp;<span class="xaml__attr_name">Padding</span>=<span class="xaml__attr_value">&quot;30&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;maps</span>:Map&nbsp;<span class="xaml__attr_name">WidthRequest</span>=<span class="xaml__attr_value">&quot;960&quot;</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;700&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;MyMap&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">IsShowingUser</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">MapType</span>=<span class="xaml__attr_value">&quot;Street&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;<span class="xaml__tag_end">&lt;/StackLayout&gt;</span>&nbsp;
&nbsp;
&nbsp;
<span class="xaml__tag_end">&lt;/ContentPage&gt;</span></pre>
</div>
</div>
</div>
</div>
<p dir="ltr"><span style="font-size:small">You can add following code for Zoom and center the user position from MainPage.cs file</span></p>
<div dir="ltr">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Xamarin.Forms;

using Xamarin.Forms.Maps;


namespace DevEnvExeMyLocation

{

   public partial class MainPage : ContentPage

   {

       public MainPage()

       {

           InitializeComponent();

           MyMap.MoveToRegion(

   MapSpan.FromCenterAndRadius(

       new Position(37, -122), Distance.FromMiles(1)));

       }

   }

}


</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms.Maps;&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;DevEnvExeMyLocation&nbsp;
&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;MainPage&nbsp;:&nbsp;ContentPage&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MainPage()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyMap.MoveToRegion(&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;MapSpan.FromCenterAndRadius(&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Position(<span class="cs__number">37</span>,&nbsp;-<span class="cs__number">122</span>),&nbsp;Distance.FromMiles(<span class="cs__number">1</span>)));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<h1 class="endscriptcode">&nbsp;Step 4: Generate Google map API Key</h1>
</div>
<p dir="ltr"><span style="font-size:small">Android allows us to integrate Google maps in our applications, so we need to generate an API key, using Google developer account. This article shows you how to generate Google map API key from Google developer account.
</span></p>
<p dir="ltr"><span style="font-size:small">Refer from my previous article for generate Google map API Key from
<a href="https://code.msdn.microsoft.com/Generate-Google-API-Key-be85b32a">here</a></span></p>
<p>&nbsp;</p>
<p dir="ltr"><a href="http://www.c-sharpcorner.com/article/generate-google-api-key-for-xamarin-android-application/"><span><img src=":-ek_mboc_zm973nwjeqhqy4t-u_wbohssnqdc-vyc-lxnha-gharmgmekpujdarfaac68xzdodk-9_uxypjhts7fnmohjodvf6or2cfbx_fiowwu6fwo_1gfvvq1o6k7o3ibsr4ho_7j3kgpi-g" alt="http://csharpcorner.mindcrackerinc.netdna-cdn.com/article/generate-google-api-key-for-xamarin-android-application/Images/image001.png" width="554" height="147"></span></a></p>
<h1 dir="ltr"><span>Step 5: Generate Bing Map Application Key</span></h1>
<p><span id="docs-internal-guid-d7eda309-8b53-b893-775d-470b7476ded7"></span></p>
<p dir="ltr"><span style="font-size:small">Windows allow us to integrate Bing maps in our application so we need to generate an application key using Bing developer account. This article shows you how to generate Bing map application key from Bing developer
 account.</span></p>
<p dir="ltr"><span><img src=":-440slkro0dptkhacge8drbxbvzfsv56eojeur2gpv_mfupjbwub7ecyxczuhsqgkzgz1lppgd_t5v9pin4le03hrrkqvuzi42xco-6rdnn9ts0iah0f-sg78namko_ukoacj6jgzeafygny8ww" alt="" width="624" height="257"></span></p>
<h2 dir="ltr"><span>Generate Key from Bing Map Portal:</span></h2>
<p dir="ltr"><span style="font-size:small">I have shown below steps for register Application key for windows based application using Bing maps developer portal.</span></p>
<p dir="ltr"><span style="font-size:small">Step 1: Navigate to Bing map Developer portal
<a href="https://www.bingmapsportal.com/">https://www.bingmapsportal.com/</a> and login using your Microsoft account</span></p>
<p dir="ltr"><span><img src=":-mrhausqtaizglpgzzt_lwlu9cg14e9awzaq4xnpv5w1xhxhqqgpchjthc8uf7s8ixmcj5ze7qevb1jrl3oqnndx450ifncanq6owm2k2j5pffi9qdfxs3g3toruk3pvgcwwrtr425v9fzxhtng" alt="" width="284" height="118"></span></p>
<h2 dir="ltr"><span>Step 2: Create new Bing map account :</span></h2>
<p dir="ltr"><span style="font-size:small">Provide the following basic profile information and accept Bing map terms and condition and click Create. If you already registered user, no need to do this step
</span></p>
<p dir="ltr"><span><img src=":-gmvz7-bibib4wkrddzoh_kyylpvdg8xuypmkvqrymzntjvdx6j3w59e6gkmt_jyhtbpexatc7l3o_tuove_dx58gcwzmekuypsd0szw_txzm7xdj3vy9_xyzyupnjaomi1gze5rjqismnnfp8a" alt="" width="214" height="277"></span></p>
<h2 dir="ltr"><span>Step 3: Generate Application Key:</span></h2>
<p dir="ltr"><span style="font-size:small">In Bing map Portal, Click on My Account and select My keys</span></p>
<p dir="ltr"><span><img src=":-uyyupxlq_h6e37trnfxuafj6_zeltpnk31jrfzxloe6xyxvvznwibydciqhdhbhnxupwqaecn3bflu2xvxqxgx46imml9ze7ckrebnrc5h2etqa9hrrfmwrrzcj6-pl32h6grn6xmj39-xwkta" alt="" width="166" height="144"></span></p>
<p dir="ltr"><span style="font-size:small">And click on create new application key and provide application name, key type(Basic/Enterprise), application type and click on create or You can chose already created Bing map application key</span></p>
<p dir="ltr"><span><img src=":-tmsc66wl8aapskqx-psfl0whxwdowf8mloqcomsqil1hikxjtggakvy50qspyacyidxaula3gdezvrfszz93tdm32qjscr6xt1ebh7nul9seovhkorn6c8e456ymiiqkyxdrdo2oxilfydiima" alt="" width="285" height="292"></span></p>
<h2 dir="ltr"><span>Step 4: Completed </span></h2>
<p dir="ltr"><span style="font-size:small">After successfully created application key, the new key appears below the My keys form. Copy it to a safe place or immediately add it to your app.</span></p>
<p dir="ltr"><span><img src=":-yoj509elcsq-2uafetg-cpthipwicon6ssgn1z_nk_bw9tq83k8eljnkx5oidv2r0zfas87ivpvt_waofqicanarhskjwfniwi3skcracok4h_rx8pnzrmj5zi4nlrhewztbomh7fqsrusmmvq" alt="" width="490" height="114"></span></p>
<p dir="ltr"><span style="font-size:small">I will share bing map implementation in my next article. If you have any question or feedback, please share in the comment box.</span></p>
<div></div>
<h1>Step6: Update info.plist file from iOS Project :</h1>
<p dir="ltr"><span style="font-size:small">The start from iOS 8, we need to add below two keys from info.plist file
</span></p>
<div dir="ltr">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;key&gt;NSLocationAlwaysUsageDescription&lt;/key&gt;

   &lt;string&gt;Can we use your location&lt;/string&gt;

&lt;key&gt;NSLocationWhenInUseUsageDescription&lt;/key&gt;

   &lt;string&gt;We are using your location&lt;/string&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;key</span><span class="xml__tag_start">&gt;</span>NSLocationAlwaysUsageDescription<span class="xml__tag_end">&lt;/key&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;string</span><span class="xml__tag_start">&gt;</span>Can&nbsp;we&nbsp;use&nbsp;your&nbsp;location<span class="xml__tag_end">&lt;/string&gt;</span>&nbsp;
&nbsp;
<span class="xml__tag_start">&lt;key</span><span class="xml__tag_start">&gt;</span>NSLocationWhenInUseUsageDescription<span class="xml__tag_end">&lt;/key&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;string</span><span class="xml__tag_start">&gt;</span>We&nbsp;are&nbsp;using&nbsp;your&nbsp;location<span class="xml__tag_end">&lt;/string&gt;</span></pre>
</div>
</div>
</div>
<h1 class="endscriptcode">&nbsp;Step 7: Xamarin Forms Map initialization</h1>
</div>
<p dir="ltr"><span style="font-size:small">Xamarin.Forms and Xamarin.Forms.Maps is a two different NuGet package that added to all the project .While Creating Xamarin Forms project automatically xamarin.Forms nuget package was added and &nbsp;initialization
 code was added to all the project .</span></p>
<p dir="ltr"><span style="font-size:small">We are recently added new xamarin.forms.maps nuget to our project so &nbsp;required to add initialization, after the Xamarin.Forms.Forms.Init method call.
</span></p>
<h2 dir="ltr"><span style="font-size:small">iOS</span></h2>
<p dir="ltr"><span style="font-size:small">Go to iOS project &gt; open AppDelegate.cs file &gt; in the FinishedLaunching method &gt; after global::Xamarin.Forms.Forms.Init(); &gt; Add below line code</span><span>
</span></p>
<div dir="ltr"></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Xamarin.FormsMaps.Init();</pre>
<div class="preview">
<pre class="csharp">Xamarin.FormsMaps.Init();</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">&nbsp;Android</h2>
<p>&nbsp;</p>
<p dir="ltr"><span style="font-size:small">Go to Android &nbsp;project &gt; open MainActivity.cs file &gt; in the OnCreate method &gt; after &nbsp;&nbsp;&nbsp;&nbsp;global::Xamarin.Forms.Forms.Init(this, bundle); &gt; Add below line code</span><span>
</span></p>
<div dir="ltr"></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Xamarin.FormsMaps.Init(this, bundle);</pre>
<div class="preview">
<pre class="csharp">Xamarin.FormsMaps.Init(<span class="cs__keyword">this</span>,&nbsp;bundle);</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;I believe, you already generated google API key and add below key from Property/ AndroidManifest.xml under Application Tag &nbsp;</span></div>
<p>&nbsp;</p>
<div dir="ltr"></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;meta-data android:name=&quot;com.google.android.geo.API_KEY &quot;

           android:value=&quot;Add API Key &ndash; Refer Step 4&quot; /&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;meta</span>-data&nbsp;android:<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;com.google.android.geo.API_KEY&nbsp;&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;android:<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;Add&nbsp;API&nbsp;Key&nbsp;&ndash;&nbsp;Refer&nbsp;Step&nbsp;4&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<h2 class="endscriptcode">&nbsp;Windows ( WinRT ,Windows Phone,UWP) :</h2>
<p>&nbsp;</p>
<p dir="ltr"><span style="font-size:small">Go to Windows project &gt; open MainPage.xaml.cs file &gt; in the MainPage constructor &gt; after LoadApplication() method &gt; Add below line code</span><span>
</span></p>
<div dir="ltr">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Xamarin.FormsMaps.Init(&quot;INSERT_AUTHENTICATION_TOKEN_HERE -refer step 5&quot;);

</pre>
<div class="preview">
<pre class="csharp">Xamarin.FormsMaps.Init(<span class="cs__string">&quot;INSERT_AUTHENTICATION_TOKEN_HERE&nbsp;-refer&nbsp;step&nbsp;5&quot;</span>);&nbsp;
&nbsp;</pre>
</div>
</div>
</div>
</div>
<h1 dir="ltr"><span>Step9: Enable Required Permissions:</span></h1>
<p dir="ltr"><span style="font-size:small">You'll also need to enable appropriate permissions on Android and windows project.</span></p>
<h2 dir="ltr"><span style="font-size:small">Android:</span></h2>
<p dir="ltr"><span style="font-size:small">Right-clicking on the Android project and selecting Property &gt; select on Android manifest &gt; Enable the location specified permissions android.</span></p>
<p dir="ltr"><span><img src=":-emzeotk5dhsx7qzss3vgcvun_mpmuydvgwrpep34l6anpfknfy_qhkljdjqu7nct3hjo-8wunzq3yxp065hymiithsh3blxq3jhsixzcepzt-cv9t3flfntsa_499minfjh03jl4rabyi7tysg" alt="" width="368" height="426"></span></p>
<h2 dir="ltr"><span>Windows Project:</span></h2>
<p dir="ltr"><span style="font-size:small">Open on the windows Package.appxmanifest file &nbsp;&gt; select on Capabilities &gt; Enable the location specified permissions all windows project.</span></p>
<p dir="ltr"><span><img src=":-tmxa5grr0k-x_naq-_qu8vccy9-ghpaakblyvvnzxz5g7df6dpky1iakxaao62dpjgk_xntriavhycxzuuc8mvuknt2vbcmrldoec5v99twyreic6szbbul1na4jyxscwp1bwfzpcra9aopqaa" alt="" width="557" height="355"></span></p>
<h1 dir="ltr"><span>Step10: Location Privacy Setting on Device:</span></h1>
<p dir="ltr"><span style="font-size:small">Before debug and run application you need to enable Location on all devices (iOS,Android,Windows)
</span></p>
<p dir="ltr"><span><img src=":-y7p-pgrznfrkqwa0bg_zplqo_0vwrduap1hoizklbfcbih8inukkxlfts17oztdtgs2xkgksp53fpd8c-8kpajbr-uxigz8jnari0ygrllbwvxupyu_0rijgsnh5rdd7eo9-r5ggmrbh1f6cfq" alt="" width="617" height="162"></span></p>
<h1 dir="ltr"><span>Step 11: Installing google Play Services from Android Emulator:</span></h1>
<p dir="ltr"><span style="font-size:small">Xamarin.Forms 2.2.0 on Android now depends on GooglePlayServices 29.0.0.1 for maps.</span></p>
<p dir="ltr"><span><img src=":-6vutkzctnrlfyvij8qsh-gtakhfd13rbmswrnk_o0r6_qmzezmyobz9szv7aogjjlvj1ug58tss4ijvke-l3liz1gy7yr17a8ahpo0m0ow-86p9otwsfxy5ntxlfehcp4mjkc9nr3nrx-sqj-q" alt="" width="286" height="164"></span></p>
<p dir="ltr"><span style="font-size:small">Visual Studio Emulator for Android does not include Google Play Services. This means that several APIs, including support for Google Maps, are not supported by default. To install Google Play Services, follow below
 steps </span></p>
<ol>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">Download the Google Apps package from Team Android
<a href="http://www.teamandroid.com/gapps/">http://www.teamandroid.com/gapps/</a></span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Verify Device Android Version like GApps: CyanogenMod 11 / Android 4.4 KitKat and download
</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Drag and drop the downloaded .zip package into the running android emulator and wait for installation complete
</span></p>
</li></ol>
<p dir="ltr"><span><img src=":-etmi1y4yjuxpekd34ed8ctgptmxaiabpmvo0a8fpmwftl7lfrvgtgvsmcmvqadifkxcni3wncmz8lsigvajvjjl9ovetmu0qp-gbjsmdclrsxmedyh3gjmzy09shyo8le1ragnnqerrdsx9lma" alt="" width="335" height="139"></span></p>
<ol>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">the emulator will shut down and restart. To verify installation, check that the Play Store app ,gmail,etc &nbsp;is visible in the app menu</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Now you can start use android emulator
</span></p>
</li></ol>
<h1 dir="ltr"><span>Run Application </span></h1>
<p dir="ltr"><span style="font-size:small">After complete all above steps, now you can start run all platform apps</span></p>
<p dir="ltr"><span><img src=":-k_z-b-q1v9wti8_r97kwmgkrp72epd08sfevvsauqwmat2a3vt-qncwdtgbh31dngxwgup_llrcvxjoiaycykkkpdnlup7komolxobncroavssfha0qzrs9dhe8-jksr2bygjj9fsdx3wiiadq" alt="" width="203" height="412"></span><span>
</span><span><img src=":-gpgvqgf5fxbk5pia4kspmieyc6y7dr-o-vmgnboggf95nuqjbqfq90yxrgcz9itkyrxt2b1-utfxkw5j2acig8almi7jhrfvjgoebqkmb287xv4vv5cfehnsoa8z2t3e29y0rxcyeab5tptk9a" alt="" width="211" height="412"></span><span>
</span><span><img src=":-pf_qusdqo7wl40ynqbbmk9o1go4uk1cv6vo4o1-pwitb7lioxtedaf1zf0pfrb2ov6-nugxxnliugwo-4ittly-ps7swivnch7qtr_ehqxgb7fmvpbscmbkgy3vxphaa4tpfyv5hkysfnm3cog" alt="C:\Users\DevEnvExe\AppData\Local\Microsoft\Windows\INetCacheContent.Word\Screen Shot 2017-03-02 at 12.14.44 AM.PNG" width="192" height="409"></span></p>
<p>&nbsp;</p>
<h1 dir="ltr"><span>Issues and Resolutions:</span></h1>
<p dir="ltr"><span style="font-size:small">I have shared below some implementation, Development, issues and solution</span></p>
<p dir="ltr"><span><img src=":-2uqm75nd9kllb_kkqvufq9q8lp_2uagyuezvg5por3vv8qr11e2jtrgb6tasiigt7t7ptyofwi7gfcq4wzaibohlgcgby88d0-a9lc89z9ynontdohfxlwfmwucddcw0blysqmi0w5csak7fya" alt="https://lh3.googleusercontent.com/EYy1QMBWQZlpWffrO4hZbxZBNU1tHpmXDPgC2cUPFtgQ4YSuH_Yr7LE247RKuXnaOI8n4d60Vn5vm-CwC80H1FAuTZRkMO22217p3WcLisT0dmigUVW1Lvg5gkRPjdeIPlEFcln6BG20-0rP5A" width="99" height="78"></span></p>
<h1 dir="ltr"><span>Error</span><span>:</span></h1>
<p dir="ltr"><span></span><span style="font-size:small">Building in Android: Java Out of Memory Error</span></p>
<h1 dir="ltr"><span>Solution</span><span>:</span></h1>
<p dir="ltr"><span style="font-size:small">Go to Android project options and set, Build/Android Build &gt; Advanced tab &gt; set 1G (or something) in Java heap size.</span></p>
<p dir="ltr"><span style="font-size:small">If you have any question /feedback /issue, write in the comment box
</span></p>
<div><span><br>
</span></div>
<p>&nbsp;</p>
