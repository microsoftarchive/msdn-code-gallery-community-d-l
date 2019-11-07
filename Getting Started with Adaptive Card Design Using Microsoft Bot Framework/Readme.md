# Getting Started with Adaptive Card Design Using Microsoft Bot Framework
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Microsoft Bot Framework
- Bots
## Topics
- Microsoft Bot Framework
- Bots
- Building Bots using Visual Studio 2017
## Updated
- 10/08/2017
## Description

<p><span id="docs-internal-guid-f08a65bf-facf-bacd-f045-c3e96432235f">&nbsp;</span></p>
<h1 dir="ltr">Introduction:</h1>
<p dir="ltr"><span style="font-size:small">The Bot Framework has supported the different type of rich cards and provides a richer interaction experience to the user. In this article, I will share about how to integrate adaptive card UI design in Bot Application.
 The <a href="http://adaptivecards.io/">Adaptive Card</a> can contain any combination of text, speech, images, buttons, and input controls.Adaptive Cards are created using the JSON format specified in Adaptive Cards schema and Microsoft provided Microsoft.AdaptiveCards
 NuGet package for &nbsp;&nbsp;.Net Developer to building these cards and handles the serialization.</span></p>
<p dir="ltr"><span><img src=":-q88cvbd35d6tvelirxdmmnbse6ybek2wqtxqnomhujyf0slzwixop1celqpcpy6gwexrevudpedqnzia3eollkibava3ggjemye_dpmclowstviexl43zxe97q33xjuakuld0jwlqvf1tncs7w" alt="" width="434" height="426"></span></p>
<h1 dir="ltr"><span>Prerequisite:</span></h1>
<p dir="ltr"><span style="font-size:small">I have explained about Bot framework Installation, deployment and implementation in the below article
</span></p>
<ol>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small"><a href="http://www.c-sharpcorner.com/article/getting-started-chatbot-using-azure-bot-service/">Getting Started with Chatbot Using Azure Bot Service</a></span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small"><a href="http://www.c-sharpcorner.com/article/getting-started-with-bots-using-visual-studio-2017/">Getting Started with Bots Using Visual Studio 2017</a></span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small"><a href="http://www.c-sharpcorner.com/article/getting-started-deploy-a-bot-to-azure-using-visual-studio-2017/">Deploying A Bot to Azure Using Visual Studio 2017</a></span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small"><a href="http://www.c-sharpcorner.com/article/how-to-create-chatbot-in-xamarin/">How to Create ChatBot In Xamarin</a></span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small"><a href="http://www.c-sharpcorner.com/article/getting-started-with-dialog-using-microsoft-bot-framework/">Getting Started with Dialog Using Microsoft Bot Framework</a></span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small"><a href="http://www.c-sharpcorner.com/article/getting-started-with-prompt-dialog-using-microsoft-bot-framework/">Getting Started with Prompt Dialog Using Microsoft Bot Framework</a></span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small"><a href="http://www.c-sharpcorner.com/article/getting-started-conversational-forms-with-formflow-using-microsoft-bot-framework/">Getting Started With Conversational Forms And FormFlow Using Microsoft Bot Framework</a></span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small"><a href="http://www.c-sharpcorner.com/article/getting-started-with-customize-a-formflow-using-microsoft-bot-framework/">Getting Started With Customizing A FormFlow Using Microsoft Bot Framework</a></span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small"><a href="http://www.c-sharpcorner.com/article/sending-bot-reply-message-with-attachment-using-bot-framework/">Sending Bot Reply Message With Attachment Using Bot Framework</a></span></p>
</li></ol>
<p>&nbsp;</p>
<h1 dir="ltr"><span>Create New Bot Application:</span></h1>
<p dir="ltr"><span style="font-size:small">Let's create a new bot application using Visual Studio 2017. Open Visual Studio &gt; Select File &gt; Create New Project (Ctrl &#43; Shift &#43;N) &gt; Select Bot application.</span></p>
<p dir="ltr"><span><img src=":-ewehgold7fueezvamx7wwpfc4ekkg2cogawx7x58pqgkjm7yndtcvqzr767qr7u2umsgx15x3jbtebueondq0jqvj9ztmiszvmxsowjlbccpzxx71xds4zkmfsrf3isfclbqo9xgsan2mmjm8g" alt="" width="624" height="331"></span></p>
<p dir="ltr"><span style="font-size:small">The Bot application template was created with all the components and all required NuGet references installed in the solutions.</span></p>
<p dir="ltr"><span><img src=":-wvbx5nztwgtujqgmwnv5f2b0n37103jf3p5kp8xkukwoipgp8hbesa-dtbblee3b1poyzkmck5vp4llejdiztvw_q2kj9fkhgomd5zwjy7wrugevqpqw4crcz73tfozg7dy1ni6gfdl5ofq5jq" alt="" width="326" height="352"></span></p>
<h1 dir="ltr"><span>Install AdaptiveCard Nuget package:</span></h1>
<p dir="ltr"><span style="font-size:small">The <a href="https://www.nuget.org/packages/Microsoft.AdaptiveCards/">
Microsoft.AdaptiveCards</a> library implements classes for building and serializing adaptive card objects and Visual studio intelligent will help us for implement Adaptive card in the bot application.</span></p>
<p dir="ltr"><span style="font-size:small">Right click on Solution &gt; Select Manage NuGet Package for Solution &gt; Search &ldquo; Microsoft AdaptiveCards&rdquo; &gt; select Project and Install the package
</span></p>
<p dir="ltr"><span><img src=":-jihb5ignidhyuhg5vfbp_lk2iacgmiqvcnyt2jnrxe7uha1ytnldfn-fbt9azezf8yuh3r3akcy6zy11pzbetckau_u68fxhu_soec5q9th8rkgrcgi_k_ejj6qyr59-etoeajyfwqlhd6ho9q" alt="" width="623" height="304"></span></p>
<h1 dir="ltr"><span>Create New AdaptiveCardDialog Class:</span></h1>
<h3 dir="ltr"><span>Step 1:</span></h3>
<p dir="ltr"><span style="font-size:small">You can Create new AdaptiveCardDialog class for a show the Adaptive dialog. Right Click on project &gt; Select Add New Item &gt; Create a class that is marked with the [Serializable] attribute (so the dialog can be
 serialized to state) and implement the IDialog interface.</span></p>
<div dir="ltr">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;

using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;

using Microsoft.Bot.Connector;

using System.IO;

using System.Web;

using System.Collections.Generic;


namespace BotAdaptiveCard.Dialogs

{

   [Serializable]

   public class AdaptiveCardDialog: IDialog&lt;object&gt;

   { </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Bot.Builder.Dialogs;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Bot.Connector;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;BotAdaptiveCard.Dialogs&nbsp;
&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;[Serializable]&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;AdaptiveCardDialog:&nbsp;IDialog&lt;<span class="cs__keyword">object</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;</pre>
</div>
</div>
</div>
<h3 class="endscriptcode">&nbsp;Step 2</h3>
</div>
<p dir="ltr"><span style="font-size:small">IDialog interface has only StartAsync() method. StartAsync() is called when the dialog becomes active. The method is passed the IDialogContext object, used to manage the conversation.</span></p>
<div dir="ltr">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public async Task StartAsync(IDialogContext context)

       {

           context.Wait(this.MessageReceivedAsync);

       }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&nbsp;StartAsync(IDialogContext&nbsp;context)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Wait(<span class="cs__keyword">this</span>.MessageReceivedAsync);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h3 class="endscriptcode">&nbsp;Step 3:</h3>
</div>
<p dir="ltr"><span style="font-size:small">Create a MessageReceivedAsync method and write following code for the welcome message and show the list of demo options dialog.</span></p>
<div dir="ltr">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">  [Serializable]

   public class AdaptiveCardDialog : IDialog&lt;object&gt;

   {

       public Task StartAsync(IDialogContext context)

       {

           context.Wait(this.MessageReceivedAsync);

           return Task.CompletedTask;

       }

       private readonly IDictionary&lt;string, string&gt; options = new Dictionary&lt;string, string&gt;

{

   { &quot;1&quot;, &quot;1. Show Demo Adaptive Card &quot; },

   { &quot;2&quot;, &quot;2. Show Demo for Adaptive Card Design with Column&quot; },

   {&quot;3&quot; , &quot;3. Input Adaptive card Design&quot; }


       };

       public async virtual Task MessageReceivedAsync(IDialogContext context, IAwaitable&lt;IMessageActivity&gt; result)

       {

           var message = await result;

           var welcomeMessage = context.MakeMessage();

           welcomeMessage.Text = &quot;Welcome to bot Adaptive Card Demo&quot;;


           await context.PostAsync(welcomeMessage);


           this.DisplayOptionsAsync(context);

       }


       public void DisplayOptionsAsync(IDialogContext context)

       {

           PromptDialog.Choice&lt;string&gt;(

               context,

               this.SelectedOptionAsync,

               this.options.Keys,

               &quot;What Demo / Sample option would you like to see?&quot;,

               &quot;Please select Valid option 1 to 6&quot;,

               6,

               PromptStyle.PerLine,

               this.options.Values);

       }

       public async Task SelectedOptionAsync(IDialogContext context, IAwaitable&lt;string&gt; argument)

       {

           var message = await argument;


           var replyMessage = context.MakeMessage();


           Attachment attachment = null;


           switch (message)

           {

               case &quot;1&quot;:

                   attachment = CreateAdapativecard();

                   replyMessage.Attachments = new List&lt;Attachment&gt; { attachment };

                   break;

               case &quot;2&quot;:

                   attachment = CreateAdapativecardWithColumn();

                   replyMessage.Attachments = new List&lt;Attachment&gt; { attachment };

                   break;

               case &quot;3&quot;:

                   replyMessage.Attachments = new List&lt;Attachment&gt; { CreateAdapativecardWithColumn(), CreateAdaptiveCardwithEntry() };

                   break;


           }

          


           await context.PostAsync(replyMessage);


           this.DisplayOptionsAsync(context);

       }

</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;[Serializable]&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;AdaptiveCardDialog&nbsp;:&nbsp;IDialog&lt;<span class="cs__keyword">object</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Task&nbsp;StartAsync(IDialogContext&nbsp;context)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Wait(<span class="cs__keyword">this</span>.MessageReceivedAsync);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Task.CompletedTask;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;IDictionary&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">string</span>&gt;&nbsp;options&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">string</span>&gt;&nbsp;
&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__string">&quot;1&quot;</span>,&nbsp;<span class="cs__string">&quot;1.&nbsp;Show&nbsp;Demo&nbsp;Adaptive&nbsp;Card&nbsp;&quot;</span>&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__string">&quot;2&quot;</span>,&nbsp;<span class="cs__string">&quot;2.&nbsp;Show&nbsp;Demo&nbsp;for&nbsp;Adaptive&nbsp;Card&nbsp;Design&nbsp;with&nbsp;Column&quot;</span>&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{<span class="cs__string">&quot;3&quot;</span>&nbsp;,&nbsp;<span class="cs__string">&quot;3.&nbsp;Input&nbsp;Adaptive&nbsp;card&nbsp;Design&quot;</span>&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;<span class="cs__keyword">virtual</span>&nbsp;Task&nbsp;MessageReceivedAsync(IDialogContext&nbsp;context,&nbsp;IAwaitable&lt;IMessageActivity&gt;&nbsp;result)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;message&nbsp;=&nbsp;await&nbsp;result;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;welcomeMessage&nbsp;=&nbsp;context.MakeMessage();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;welcomeMessage.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Welcome&nbsp;to&nbsp;bot&nbsp;Adaptive&nbsp;Card&nbsp;Demo&quot;</span>;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;context.PostAsync(welcomeMessage);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.DisplayOptionsAsync(context);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DisplayOptionsAsync(IDialogContext&nbsp;context)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PromptDialog.Choice&lt;<span class="cs__keyword">string</span>&gt;(&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.SelectedOptionAsync,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.options.Keys,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;What&nbsp;Demo&nbsp;/&nbsp;Sample&nbsp;option&nbsp;would&nbsp;you&nbsp;like&nbsp;to&nbsp;see?&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Please&nbsp;select&nbsp;Valid&nbsp;option&nbsp;1&nbsp;to&nbsp;6&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">6</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PromptStyle.PerLine,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.options.Values);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&nbsp;SelectedOptionAsync(IDialogContext&nbsp;context,&nbsp;IAwaitable&lt;<span class="cs__keyword">string</span>&gt;&nbsp;argument)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;message&nbsp;=&nbsp;await&nbsp;argument;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;replyMessage&nbsp;=&nbsp;context.MakeMessage();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Attachment&nbsp;attachment&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(message)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;1&quot;</span>:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;attachment&nbsp;=&nbsp;CreateAdapativecard();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;replyMessage.Attachments&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Attachment&gt;&nbsp;{&nbsp;attachment&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;2&quot;</span>:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;attachment&nbsp;=&nbsp;CreateAdapativecardWithColumn();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;replyMessage.Attachments&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Attachment&gt;&nbsp;{&nbsp;attachment&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;3&quot;</span>:&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;replyMessage.Attachments&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Attachment&gt;&nbsp;{&nbsp;CreateAdapativecardWithColumn(),&nbsp;CreateAdaptiveCardwithEntry()&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;context.PostAsync(replyMessage);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.DisplayOptionsAsync(context);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;After user enter the first message,
</span>bot<span style="font-size:small"> will reply welcome message and list of demo option and wait for user input like below</span></div>
</div>
<p dir="ltr"><span><img src=":-wm9gfzd2olu6h11r4-9ag14qc7heyhz_w-velpwz6f1jdvm8xwjmh2rzkthk4s2rm_xzauouks3lxqcefzxjwqxvtgs_w49hkhoc1hx99kz8_bxcqw6uw4o73fcedfaynkxh2fa1ykvxzdkgkq" alt="" width="525" height="265"></span></p>
<h1 dir="ltr"><span>Step 4: Design Adaptive Card </span></h1>
<p dir="ltr"><span style="font-size:small">The Adaptive Cards are created using JSON, but with the Microsoft.AdaptiveCards NuGet we can create them by composing card objects. We can create AdaptiveCard objects and attach to the attachment and post message to
 a message</span></p>
<p dir="ltr"><span><img src=":-jr9c_vye6houjxkd2pnmuyzib1kh_qqfigrbdyhu6mhz3jodhotpsuchxq5bqp2eega0l64dbel3e_j9-y_9hpm_qfzpknp3qnuupn5opg8qh-qpnzn1elan03v-mvfvnec-gd7le60zhbax7q" alt="" width="266" height="323"></span></p>
<p dir="ltr"><span style="font-size:small">The following code showing design the welcome message with image, textblock and speech.</span></p>
<div dir="ltr">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> public Attachment CreateAdapativecard()

       {


           AdaptiveCard card = new AdaptiveCard();


           // Specify speech for the card.

           card.Speak = &quot;Suthahar J is a Technical Lead and C# Corner MVP. He has extensive 10&#43; years of experience working on different technologies, mostly in Microsoft space. His focus areas are  Xamarin Cross Mobile Development ,UWP, SharePoint, Azure,Windows Mobile , Web , AI and Architecture. He writes about technology at his popular blog http://devenvexe.com&quot;;

           // Body content

           card.Body.Add(new Image()

           {

               Url = &quot;https://i1.social.s-msft.com/profile/u/avatar.jpg?displayname=j%20suthahar&amp;size=extralarge&amp;version=88034ca2-9db8-46cd-b767-95d17658931a&quot;,

               Size = ImageSize.Small,

               Style = ImageStyle.Person,

               AltText = &quot;Suthahar Profile&quot;


           });


           // Add text to the card.

           card.Body.Add(new TextBlock()

           {

               Text = &quot;Technical Lead and C# Corner MVP&quot;,

               Size = TextSize.Large,

               Weight = TextWeight.Bolder

           });


           // Add text to the card.

           card.Body.Add(new TextBlock()

           {

               Text = &quot;jssutahhar@gmail.com&quot;

           });


           // Add text to the card.

           card.Body.Add(new TextBlock()

           {

               Text = &quot;97XXXXXX12&quot;

           });


           // Create the attachment with adapative card.

           Attachment attachment = new Attachment()

           {

               ContentType = AdaptiveCard.ContentType,

               Content = card

           };

           return attachment;

       }

</pre>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;Attachment&nbsp;CreateAdapativecard()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AdaptiveCard&nbsp;card&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AdaptiveCard();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Specify&nbsp;speech&nbsp;for&nbsp;the&nbsp;card.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;card.Speak&nbsp;=&nbsp;<span class="cs__string">&quot;Suthahar&nbsp;J&nbsp;is&nbsp;a&nbsp;Technical&nbsp;Lead&nbsp;and&nbsp;C#&nbsp;Corner&nbsp;MVP.&nbsp;He&nbsp;has&nbsp;extensive&nbsp;10&#43;&nbsp;years&nbsp;of&nbsp;experience&nbsp;working&nbsp;on&nbsp;different&nbsp;technologies,&nbsp;mostly&nbsp;in&nbsp;Microsoft&nbsp;space.&nbsp;His&nbsp;focus&nbsp;areas&nbsp;are&nbsp;&nbsp;Xamarin&nbsp;Cross&nbsp;Mobile&nbsp;Development&nbsp;,UWP,&nbsp;SharePoint,&nbsp;Azure,Windows&nbsp;Mobile&nbsp;,&nbsp;Web&nbsp;,&nbsp;AI&nbsp;and&nbsp;Architecture.&nbsp;He&nbsp;writes&nbsp;about&nbsp;technology&nbsp;at&nbsp;his&nbsp;popular&nbsp;blog&nbsp;http://devenvexe.com&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Body&nbsp;content</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;card.Body.Add(<span class="cs__keyword">new</span>&nbsp;Image()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Url&nbsp;=&nbsp;<span class="cs__string">&quot;https://i1.social.s-msft.com/profile/u/avatar.jpg?displayname=j%20suthahar&amp;size=extralarge&amp;version=88034ca2-9db8-46cd-b767-95d17658931a&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Size&nbsp;=&nbsp;ImageSize.Small,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Style&nbsp;=&nbsp;ImageStyle.Person,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AltText&nbsp;=&nbsp;<span class="cs__string">&quot;Suthahar&nbsp;Profile&quot;</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;text&nbsp;to&nbsp;the&nbsp;card.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;card.Body.Add(<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;<span class="cs__string">&quot;Technical&nbsp;Lead&nbsp;and&nbsp;C#&nbsp;Corner&nbsp;MVP&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Size&nbsp;=&nbsp;TextSize.Large,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Weight&nbsp;=&nbsp;TextWeight.Bolder&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;text&nbsp;to&nbsp;the&nbsp;card.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;card.Body.Add(<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;<span class="cs__string">&quot;jssutahhar@gmail.com&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;text&nbsp;to&nbsp;the&nbsp;card.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;card.Body.Add(<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;<span class="cs__string">&quot;97XXXXXX12&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;the&nbsp;attachment&nbsp;with&nbsp;adapative&nbsp;card.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Attachment&nbsp;attachment&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Attachment()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContentType&nbsp;=&nbsp;AdaptiveCard.ContentType,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Content&nbsp;=&nbsp;card&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;attachment;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;The above code will generate adaptive card and reply to the user</span></div>
</div>
<p dir="ltr"><span><img src=":-afclyidjqympyl2abjnixk-_nrowe9b55qh0x8jvdtuhhljwajvy7lsgdzl0dotakqsufgbkotgqdbmijhzu3xser2g3cl4rbp_shd-wndaskxuy4nwvub6htfnamqxv-3nwzanhrflfjlavtq" alt="" width="371" height="180"></span></p>
<p>&nbsp;</p>
<h1 dir="ltr"><span>Step 5: Design Adaptive Card with Column:</span></h1>
<p dir="ltr"><span style="font-size:small">The Adaptive Cards contain many elements that allow to design UI content in a common and consistent way.
</span></p>
<ol>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">Container - A Container is a CardElement which contains a list of CardElements that are logically grouped.</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">ColumnSet and Column - The columnSet element adds the ability to have a set of Column objects and align the column object.</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">FactSet - The FactSet element is displayed row and column like a tabular form.</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">TextBlock - The TextBlock element allows for the inclusion of text, we can modify font sizes, weight and color.</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">ImageSet and Image - The ImageSet allows for the inclusion of a collection images like a photo set, and the Image element allows for the inclusion of images.</span></p>
</li></ol>
<p dir="ltr"><span><img src=":-n7izar8jm5rowjle9e2cqgabjrej2rg2z9vjb80x-hxkh1zb_ivwkzl6odebohilpx3xxpw3hrbzafsre1jy06xamg4pchbkncwoki3tgblj5xpomx-t6elziqvonlpy0_jbbfrfsfpltnivqg" alt="" width="407" height="517"></span></p>
<p><span style="font-size:small">The following code showing, adding multiple columns and design the UI Adaptive Card</span></p>
<div dir="ltr">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public Attachment CreateAdapativecardWithColumn()

       {

           AdaptiveCard card = new AdaptiveCard()

           {

               Body = new List&lt;CardElement&gt;()

   {

       // Container

       new Container()

       {

           Speak = &quot;&lt;s&gt;Hello!&lt;/s&gt;&lt;s&gt;Suthahar J is a Technical Lead and C# Corner MVP. He has extensive 10&#43; years of experience working on different technologies, mostly in Microsoft space. His focus areas are  Xamarin Cross Mobile Development ,UWP, SharePoint, Azure,Windows Mobile , Web , AI and Architecture. He writes about technology at his popular blog http://devenvexe.com&lt;/s&gt;&quot;,

           Items = new List&lt;CardElement&gt;()

           {

               // first column

               new ColumnSet()

               {

                   Columns = new List&lt;Column&gt;()

                   {

                       new Column()

                       {

                           Size = ColumnSize.Auto,

                           Items = new List&lt;CardElement&gt;()

                           {

                               new Image()

                               {

                                   Url = &quot;https://i1.social.s-msft.com/profile/u/avatar.jpg?displayname=j%20suthahar&amp;size=extralarge&amp;version=88034ca2-9db8-46cd-b767-95d17658931a&quot;,

                                   Size = ImageSize.Small,

                                   Style = ImageStyle.Person

                               }

                           }

                       },

                       new Column()

                       {

                           Size = &quot;300&quot;,


                           Items = new List&lt;CardElement&gt;()

                           {

                               new TextBlock()

                               {

                                   Text =  &quot;Suthahar Jegatheesan MCA&quot;,

                                   Weight = TextWeight.Bolder,

                                   IsSubtle = true

                               },

                                new TextBlock()

                               {

                                   Text =  &quot;jssuthahar@gmail.com&quot;,

                                   Weight = TextWeight.Lighter,

                                   IsSubtle = true

                               },

                                 new TextBlock()

                               {

                                   Text =  &quot;97420XXXX2&quot;,

                                   Weight = TextWeight.Lighter,

                                   IsSubtle = true

                               },

                                  new TextBlock()

                               {

                                   Text =  &quot;http://www.devenvexe.com&quot;,

                                   Weight = TextWeight.Lighter,

                                   IsSubtle = true

                               }


                           }

                       }

                   }


               },

               // second column

               new ColumnSet()

               {

                    Columns = new List&lt;Column&gt;()

                   {

                         new Column()

                       {

                           Size = ColumnSize.Auto,

                           Separation =SeparationStyle.Strong,

                           Items = new List&lt;CardElement&gt;()

                           {

                               new TextBlock()

                               {

                                   Text = &quot;Suthahar J is a Technical Lead and C# Corner MVP. He has extensive 10&#43; years of experience working on different technologies, mostly in Microsoft space. His focus areas are  Xamarin Cross Mobile Development ,UWP, SharePoint, Azure,Windows Mobile , Web , AI and Architecture. He writes about technology at his popular blog http://devenvexe.com&quot;,

                                   Wrap = true

                               }

                           }

                       }

                   }

               }

           }

       }

    },


           };

           Attachment attachment = new Attachment()

           {

               ContentType = AdaptiveCard.ContentType,

               Content = card

           };

           return attachment;


       }

</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;Attachment&nbsp;CreateAdapativecardWithColumn()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AdaptiveCard&nbsp;card&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AdaptiveCard()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Body&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;CardElement&gt;()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Container</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Container()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Speak&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;s&gt;Hello!&lt;/s&gt;&lt;s&gt;Suthahar&nbsp;J&nbsp;is&nbsp;a&nbsp;Technical&nbsp;Lead&nbsp;and&nbsp;C#&nbsp;Corner&nbsp;MVP.&nbsp;He&nbsp;has&nbsp;extensive&nbsp;10&#43;&nbsp;years&nbsp;of&nbsp;experience&nbsp;working&nbsp;on&nbsp;different&nbsp;technologies,&nbsp;mostly&nbsp;in&nbsp;Microsoft&nbsp;space.&nbsp;His&nbsp;focus&nbsp;areas&nbsp;are&nbsp;&nbsp;Xamarin&nbsp;Cross&nbsp;Mobile&nbsp;Development&nbsp;,UWP,&nbsp;SharePoint,&nbsp;Azure,Windows&nbsp;Mobile&nbsp;,&nbsp;Web&nbsp;,&nbsp;AI&nbsp;and&nbsp;Architecture.&nbsp;He&nbsp;writes&nbsp;about&nbsp;technology&nbsp;at&nbsp;his&nbsp;popular&nbsp;blog&nbsp;http://devenvexe.com&lt;/s&gt;&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Items&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;CardElement&gt;()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;first&nbsp;column</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;ColumnSet()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Columns&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Column&gt;()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Column()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Size&nbsp;=&nbsp;ColumnSize.Auto,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Items&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;CardElement&gt;()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Image()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Url&nbsp;=&nbsp;<span class="cs__string">&quot;https://i1.social.s-msft.com/profile/u/avatar.jpg?displayname=j%20suthahar&amp;size=extralarge&amp;version=88034ca2-9db8-46cd-b767-95d17658931a&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Size&nbsp;=&nbsp;ImageSize.Small,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Style&nbsp;=&nbsp;ImageStyle.Person&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Column()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Size&nbsp;=&nbsp;<span class="cs__string">&quot;300&quot;</span>,&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Items&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;CardElement&gt;()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;&nbsp;<span class="cs__string">&quot;Suthahar&nbsp;Jegatheesan&nbsp;MCA&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Weight&nbsp;=&nbsp;TextWeight.Bolder,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsSubtle&nbsp;=&nbsp;<span class="cs__keyword">true</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;&nbsp;<span class="cs__string">&quot;jssuthahar@gmail.com&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Weight&nbsp;=&nbsp;TextWeight.Lighter,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsSubtle&nbsp;=&nbsp;<span class="cs__keyword">true</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;&nbsp;<span class="cs__string">&quot;97420XXXX2&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Weight&nbsp;=&nbsp;TextWeight.Lighter,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsSubtle&nbsp;=&nbsp;<span class="cs__keyword">true</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;&nbsp;<span class="cs__string">&quot;http://www.devenvexe.com&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Weight&nbsp;=&nbsp;TextWeight.Lighter,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsSubtle&nbsp;=&nbsp;<span class="cs__keyword">true</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;second&nbsp;column</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;ColumnSet()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Columns&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Column&gt;()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Column()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Size&nbsp;=&nbsp;ColumnSize.Auto,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Separation&nbsp;=SeparationStyle.Strong,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Items&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;CardElement&gt;()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;<span class="cs__string">&quot;Suthahar&nbsp;J&nbsp;is&nbsp;a&nbsp;Technical&nbsp;Lead&nbsp;and&nbsp;C#&nbsp;Corner&nbsp;MVP.&nbsp;He&nbsp;has&nbsp;extensive&nbsp;10&#43;&nbsp;years&nbsp;of&nbsp;experience&nbsp;working&nbsp;on&nbsp;different&nbsp;technologies,&nbsp;mostly&nbsp;in&nbsp;Microsoft&nbsp;space.&nbsp;His&nbsp;focus&nbsp;areas&nbsp;are&nbsp;&nbsp;Xamarin&nbsp;Cross&nbsp;Mobile&nbsp;Development&nbsp;,UWP,&nbsp;SharePoint,&nbsp;Azure,Windows&nbsp;Mobile&nbsp;,&nbsp;Web&nbsp;,&nbsp;AI&nbsp;and&nbsp;Architecture.&nbsp;He&nbsp;writes&nbsp;about&nbsp;technology&nbsp;at&nbsp;his&nbsp;popular&nbsp;blog&nbsp;http://devenvexe.com&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Wrap&nbsp;=&nbsp;<span class="cs__keyword">true</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Attachment&nbsp;attachment&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Attachment()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContentType&nbsp;=&nbsp;AdaptiveCard.ContentType,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Content&nbsp;=&nbsp;card&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;attachment;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;The above code will generate following card design and reply the message</span></div>
</div>
<p dir="ltr"><span><img src=":-vydsqutnkxyadobhbklnudwu4d2frp0bgrbmz-jf90kfaapwzlobontm1g5xvgtqcafjttyce-nc-ly9evyj7nvouvtyxnxqwb1rcwexzlxqauhxgju_cue8zbp8p9vttulfzt4yduhcny3dow" alt="" width="352" height="278"></span></p>
<h1 dir="ltr"><span>Step 6: Adaptive Card Design with Input Control:</span></h1>
<p dir="ltr"><span style="font-size:small">The Adaptive Cards can include input controls for collecting information from the user, it will support following input control is : Text, Date, Time, Number and for selecting options(choiceset) and toggle .</span></p>
<p dir="ltr"><span style="font-size:small">The following sample code included collecting basic information from the users with action button
</span></p>
<ol>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">Input.Text &ndash; Collect the text content from the user</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Input.Date - &nbsp;Collect a Date from the user</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Input.Time - Collect a Time from the user</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Input.Number - Collect a Number from the user</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Input.ChoiceSet - provide the user a set of choices and have them pick</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Input.ToggleChoice - provide the user a single choice between two items and have them pick</span></p>
</li></ol>
<div dir="ltr">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public Attachment CreateAdaptiveCardwithEntry()

       {

           var card = new AdaptiveCard()

           {

               Body = new List&lt;CardElement&gt;()

   {

           // Hotels Search form

         

           new TextBlock() { Text = &quot;Please Share your detail for contact:&quot; },

           new TextInput()

           {

               Id = &quot;Your Name&quot;,

               Speak = &quot;&lt;s&gt;Please Enter Your Name&lt;/s&gt;&quot;,

               Placeholder = &quot;Please Enter Your Name&quot;,

               Style = TextInputStyle.Text

           },

           new TextBlock() { Text = &quot;When your Free&quot; },

           new DateInput()

           {

               Id = &quot;Free&quot;,

               Placeholder =&quot;Your free Date&quot;

           },

           new TextBlock() { Text = &quot;Your Experence&quot; },

           new NumberInput()

           {

               Id = &quot;No of Year experence&quot;,

               Min = 1,

               Max = 20,

           },

           new TextBlock() { Text = &quot;Email&quot; },

           new TextInput()

           {

               Id = &quot;Email&quot;,

               Speak = &quot;&lt;s&gt;Please Enter Your email&lt;/s&gt;&quot;,

               Placeholder = &quot;Please Enter Your email&quot;,

               Style = TextInputStyle.Text

           },

            new TextBlock() { Text = &quot;Phone&quot; },

           new TextInput()

           {

               Id = &quot;Phone&quot;,

               Speak = &quot;&lt;s&gt;Please Enter Your phone&lt;/s&gt;&quot;,

               Placeholder = &quot;Please Enter Your Phone&quot;,

               Style = TextInputStyle.Text

           },

   },

               Actions = new List&lt;ActionBase&gt;()

   {

       new SubmitAction()

       {

           Title = &quot;Contact&quot;,

           Speak = &quot;&lt;s&gt;Contact&lt;/s&gt;&quot;,

           

       }

   }

           };

           Attachment attachment = new Attachment()

           {

               ContentType = AdaptiveCard.ContentType,

               Content = card

           };

           return attachment;

       }

</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;Attachment&nbsp;CreateAdaptiveCardwithEntry()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;card&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AdaptiveCard()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Body&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;CardElement&gt;()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Hotels&nbsp;Search&nbsp;form</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;{&nbsp;Text&nbsp;=&nbsp;<span class="cs__string">&quot;Please&nbsp;Share&nbsp;your&nbsp;detail&nbsp;for&nbsp;contact:&quot;</span>&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;TextInput()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Id&nbsp;=&nbsp;<span class="cs__string">&quot;Your&nbsp;Name&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Speak&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;s&gt;Please&nbsp;Enter&nbsp;Your&nbsp;Name&lt;/s&gt;&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Placeholder&nbsp;=&nbsp;<span class="cs__string">&quot;Please&nbsp;Enter&nbsp;Your&nbsp;Name&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Style&nbsp;=&nbsp;TextInputStyle.Text&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;{&nbsp;Text&nbsp;=&nbsp;<span class="cs__string">&quot;When&nbsp;your&nbsp;Free&quot;</span>&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;DateInput()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Id&nbsp;=&nbsp;<span class="cs__string">&quot;Free&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Placeholder&nbsp;=<span class="cs__string">&quot;Your&nbsp;free&nbsp;Date&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;{&nbsp;Text&nbsp;=&nbsp;<span class="cs__string">&quot;Your&nbsp;Experence&quot;</span>&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;NumberInput()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Id&nbsp;=&nbsp;<span class="cs__string">&quot;No&nbsp;of&nbsp;Year&nbsp;experence&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Min&nbsp;=&nbsp;<span class="cs__number">1</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Max&nbsp;=&nbsp;<span class="cs__number">20</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;{&nbsp;Text&nbsp;=&nbsp;<span class="cs__string">&quot;Email&quot;</span>&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;TextInput()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Id&nbsp;=&nbsp;<span class="cs__string">&quot;Email&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Speak&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;s&gt;Please&nbsp;Enter&nbsp;Your&nbsp;email&lt;/s&gt;&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Placeholder&nbsp;=&nbsp;<span class="cs__string">&quot;Please&nbsp;Enter&nbsp;Your&nbsp;email&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Style&nbsp;=&nbsp;TextInputStyle.Text&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;TextBlock()&nbsp;{&nbsp;Text&nbsp;=&nbsp;<span class="cs__string">&quot;Phone&quot;</span>&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;TextInput()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Id&nbsp;=&nbsp;<span class="cs__string">&quot;Phone&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Speak&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;s&gt;Please&nbsp;Enter&nbsp;Your&nbsp;phone&lt;/s&gt;&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Placeholder&nbsp;=&nbsp;<span class="cs__string">&quot;Please&nbsp;Enter&nbsp;Your&nbsp;Phone&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Style&nbsp;=&nbsp;TextInputStyle.Text&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Actions&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;ActionBase&gt;()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;SubmitAction()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title&nbsp;=&nbsp;<span class="cs__string">&quot;Contact&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Speak&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;s&gt;Contact&lt;/s&gt;&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Attachment&nbsp;attachment&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Attachment()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContentType&nbsp;=&nbsp;AdaptiveCard.ContentType,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Content&nbsp;=&nbsp;card&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;attachment;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;The above code will return following adaptive card design</span></div>
</div>
<p dir="ltr"><span><img src=":-ug-klmlip22023-lxv9p4owuz2edtn2q7wcn8ne5ubwbz9bo5pyf4vi1omj2niuqiid9ko1dxprhdawjjrpytfe2wqzwsavzlgd-x97z01x65zj8nk-wzsguyv2vnwwg34_klqmx7fbqirejfg" alt="" width="376" height="650"></span></p>
<h1 dir="ltr"><span>Run Bot Application</span></h1>
<p dir="ltr"><span style="font-size:small">The emulator is a desktop application that lets us test and debug our bot on localhost. Now, you can click on &quot;Run the application&quot; in Visual studio and execute in the browser</span><span><br class="kix-line-break">
</span><span><br class="kix-line-break">
</span><span><img src=":-mfbxfkkym8dkqvbha0ae6s3qtnzp_fku3fixsnh8opnpqb0-v9giwevgjgrdogr51tfv8dutcfgpzidjecjrji54ewbsg2q5pzyxi8wtcrmyxa1jhz9776yynltoclrtkr0rz_zrtxvwh_4mfa" alt="" width="624" height="223"></span></p>
<h1 dir="ltr"><span>Test Application on Bot Emulator</span></h1>
<p dir="ltr"><span style="font-size:small">You can follow the below steps to test your bot application.</span></p>
<ol>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">Open Bot Emulator.</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Copy the above localhost url and paste it in emulator e.g. - http://localHost:3979</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">You can append the /api/messages in the above url; e.g. - http://localHost:3979/api/messages.</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">You won't need to specify Microsoft App ID and Microsoft App Password for localhost testing, so click on &quot;Connect&quot;.</span><span><br class="kix-line-break">
</span><span><br class="kix-line-break">
</span><span><img src=":-ug-klmlip22023-lxv9p4owuz2edtn2q7wcn8ne5ubwbz9bo5pyf4vi1omj2niuqiid9ko1dxprhdawjjrpytfe2wqzwsavzlgd-x97z01x65zj8nk-wzsguyv2vnwwg34_klqmx7fbqirejfg" alt="" width="376" height="650"></span></p>
</li></ol>
<h1 dir="ltr"><span>Summary</span></h1>
<p dir="ltr"><span style="font-size:small">In this article, you&nbsp;learned how to create a Bot application using Visual Studio 2017 and create adaptive design and input from using bot framework. If you have any questions/feedback/ issues, please write in
 the comment box.</span></p>
<p><br>
<br>
</p>
