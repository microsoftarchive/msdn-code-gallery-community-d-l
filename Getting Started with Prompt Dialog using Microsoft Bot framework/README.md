# Getting Started with Prompt Dialog using Microsoft Bot framework
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
## Updated
- 09/15/2017
## Description

<p><span id="docs-internal-guid-5f3e8bb4-2f4b-910d-00b6-cd905b5164d5">&nbsp;</span></p>
<h1 dir="ltr">Introduction:</h1>
<p dir="ltr"><span style="font-size:small">The Bot Framework enables you to build bots that support different types of interactions with users. You can design conversations in your bot to be freeform. Your bot can also have more guided interactions where it
 provides the user choices or actions. The conversation can use simple text strings or more complex rich cards that contain text, images, and action buttons. And you can add natural language interactions, which let your users interact with your bots in a natural
 and expressive way.</span></p>
<p dir="ltr"><span style="font-size:small">Bot Builder SDK introduced prompt Dialogs that allow user to model conversations and manage conversation flow. The prompt is used whenever a bot needs input from the user. You can use prompts to ask a user for a series
 of inputs by chaining the prompts.</span></p>
<p dir="ltr"><span style="font-size:small">In this article will help you to understand how to use prompts and how you can use them to collect information from the users. We are creating sample Demo Bot for our c# corner Annual Conference 2018 registration process
 automation.</span></p>
<p dir="ltr"><span><img id="178592" src="178592-demo.gif" alt="" width="531" height="1002"><br>
</span></p>
<p dir="ltr"><span><img src=":--sn7dtilb9nbxzljkhvmb19t3k0-1ggsjzyygbqhrtgjbtcg2rze_wndjjjgb1yoxgv5rbgsexx32u_6qklogzfymzlqsrh85pgq2xrvclijjinorns7ajhvwx6ymoy0iyfugahiqvv1d2vcaw" alt="" width="624" height="308"></span></p>
<h1 dir="ltr"><span>Prerequisite:</span></h1>
<p dir="ltr"><span style="font-size:small">I have explained about Bot framework Installation, deployment and implementation the below article
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
</li></ol>
<h1 dir="ltr"><span>Create New Bot Service:</span></h1>
<p dir="ltr"><span style="font-size:small">Let&rsquo;s create a new bot service application using Visual Studio 2017. Open Visual Studio &gt; Select File &gt; Create New Project (Ctrl &#43; Shift &#43;N) &gt; Select Bot application
</span></p>
<p dir="ltr"><span><img src=":-pfmvnvbyso02wg7448ik2hderxiivg4dbtuhe9sr8xyihawq3b3zmsuvybs6aoozqvrsw2gq9434smdlgg-ikf77atbhsgrpe91db6aao-9uxaofgmlxt755pbxgwgvpqetfg7np2mg9-n9tiw" alt="" width="497" height="346"></span></p>
<p dir="ltr"><span style="font-size:small">The Bot application template was created with all the components and all required NuGet references installed in the solutions and add new annualplanDialog class to the project.</span></p>
<p dir="ltr"><span><img src=":-p38muoyx14dt-rsbnuhbh56v9ofi5qqk2dct2drf412vvjn8zjhmumkboydgjxcpycdgic-kkqifcm_gxohazwj6hlvrhsanescljrzjljwqrv_396ejdfjmyydipgvx8vypsnsmcxn_rhqvwa" alt="" width="352" height="435"></span></p>
<p dir="ltr"><span style="font-size:small">In this Solution, we have three main class MessagesController.cs , RootDialog.cs and AnnualPlanDialog class . Let us start discussing here.</span></p>
<h1 dir="ltr"><span>RootDialog Class</span><span>:</span></h1>
<h3 dir="ltr"><span>Step 1:</span></h3>
<p dir="ltr"><span style="font-size:small">You can create / Edit the RootDialog class, create a class that is marked with the [Serializable] attribute (so the dialog can be serialized to state) and implement the IDialog interface.</span></p>
<p>&nbsp;</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Bot.Builder.Dialogs;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Bot.Connector;&nbsp;
&nbsp;
[Serializable]&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;RootDialog&nbsp;:&nbsp;IDialog&lt;<span class="cs__keyword">object</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<table>
<tbody>
</tbody>
</table>
<p><span id="docs-internal-guid-5f3e8bb4-2f4b-910d-00b6-cd905b5164d5"><br>
</span></p>
<h3 dir="ltr"><span>Step 2:</span></h3>
<p dir="ltr"><span style="font-size:small">IDialog interface has only StartAsync() methond. StartAsync() is called when the dialog becomes active. The method is passed the IDialogContext object, used to manage the conversation.</span></p>
<p>&nbsp;</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&nbsp;StartAsync(IDialogContext&nbsp;context)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<table>
<tbody>
</tbody>
</table>
<h1><span id="docs-internal-guid-5f3e8bb4-2f4b-910d-00b6-cd905b5164d5"><br>
</span></h1>
<h1 dir="ltr"><span>Step 3: &nbsp;Design Title and Image for Welcome:</span></h1>
<p dir="ltr"><span style="font-size:small">Create a method with hero card and return the attachment. The Hero card is a multipurpose card, it is having single title, subtitle, large image, button and a &quot;tap action &ldquo;. The following code added for C# Corner
 annual conference 2018 registration welcome message using Bot Hero card.</span></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Design&nbsp;Title&nbsp;with&nbsp;Image&nbsp;and&nbsp;About&nbsp;US&nbsp;link</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Attachment&nbsp;GetHeroCard()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;heroCard&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HeroCard&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title&nbsp;=&nbsp;<span class="cs__string">&quot;Annual&nbsp;Conference&nbsp;2018&nbsp;Registrtion&nbsp;&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Subtitle&nbsp;=&nbsp;<span class="cs__string">&quot;DELHI,&nbsp;13&nbsp;-&nbsp;15&nbsp;APRIL&nbsp;2018&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;<span class="cs__string">&quot;The&nbsp;C#&nbsp;Corner&nbsp;Annual&nbsp;Conference&nbsp;2018&nbsp;is&nbsp;a&nbsp;three-day&nbsp;annual&nbsp;event&nbsp;for&nbsp;software&nbsp;professionals&nbsp;and&nbsp;developers.&nbsp;First&nbsp;day&nbsp;is&nbsp;exclusive&nbsp;for&nbsp;C#&nbsp;Corner&nbsp;MVPs&nbsp;only.&nbsp;The&nbsp;second&nbsp;day&nbsp;is&nbsp;open&nbsp;to&nbsp;the&nbsp;public,&nbsp;and&nbsp;includes&nbsp;presentations&nbsp;from&nbsp;many&nbsp;top&nbsp;names&nbsp;in&nbsp;the&nbsp;industry.&nbsp;The&nbsp;third&nbsp;day&nbsp;events&nbsp;are,&nbsp;again,&nbsp;exclusively&nbsp;for&nbsp;C#&nbsp;Corner&nbsp;MVPs&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Images&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;CardImage&gt;&nbsp;{&nbsp;<span class="cs__keyword">new</span>&nbsp;CardImage(<span class="cs__string">&quot;https://lh3.googleusercontent.com/-fnwLMmJTmdk/WaVt5LR2OZI/AAAAAAAAG90/qlltsHiSdZwVdOENv1yB25kuIvDWCMvWACLcBGAs/h120/annuvalevent.PNG&quot;</span>)&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Buttons&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;CardAction&gt;&nbsp;{&nbsp;<span class="cs__keyword">new</span>&nbsp;CardAction(ActionTypes.OpenUrl,&nbsp;<span class="cs__string">&quot;About&nbsp;US&quot;</span>,&nbsp;<span class="cs__keyword">value</span>:&nbsp;<span class="cs__string">&quot;http://conference.c-sharpcorner.com/&quot;</span>)&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;heroCard.ToAttachment();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p dir="ltr"><span><br>
<span style="font-size:small">Welcome banner its look like below &nbsp;</span></span></p>
<p dir="ltr"><span><img src=":-fzfvv8sqzzjuqzvmf3gvlgfhbzlaumnakjgulchm0fabpfrn6f8aozuy5i8rb56xcof4miz0xofwdliehdbcgfucvoyvuclzozacaq1769rl4dgjhcxrvxq9hdodwgivjampm6qbi-w-8llsua" alt="" width="426" height="524"></span></p>
<h1 dir="ltr"><span>Step 4: Custom Prompt Dialog:</span></h1>
<p dir="ltr"><span style="font-size:small">The custom prompts a dialog for asking the user to select a registration plan, which he/she is interested. Like below Design .</span></p>
<p dir="ltr"><span><img src=":-tdw5cl0ajvjh2u9wqlm4eqsivex9erinkexkms8tl7zxmikh9alfdwvbzuq2thztc4dh8vvphuz2ycvnibondp2teiz3lap7p7qiugk8jznrab5kckqkc7exvwfpp82mvrljqdniv4jj5j7wia" alt="" width="435" height="278"></span></p>
<p dir="ltr"><span style="font-size:small">Define the enum for different type pass. it&rsquo;s a prompt list item
</span></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">enum</span>&nbsp;AnnuvalConferencePass&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EarlyBird,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Regular,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DelegatePass,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CareerandJobAdvice,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p><span id="docs-internal-guid-5f3e8bb4-2f4b-910d-00b6-cd905b5164d5"><br>
</span></p>
<p dir="ltr"><span style="font-size:small">Create a method ShowAnnuvalConferenceTicket with Prompt Dialog choice like below
</span></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;async&nbsp;Task&nbsp;ShowAnnuvalConferenceTicket(IDialogContext&nbsp;context,&nbsp;IAwaitable&lt;IMessageActivity&gt;&nbsp;activity)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;message&nbsp;=&nbsp;await&nbsp;activity;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PromptDialog.Choice(&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context:&nbsp;context,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resume:&nbsp;ChoiceReceivedAsync,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options:&nbsp;(IEnumerable&lt;AnnuvalConferencePass&gt;)Enum.GetValues(<span class="cs__keyword">typeof</span>(AnnuvalConferencePass)),&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;prompt:&nbsp;<span class="cs__string">&quot;Hi.&nbsp;Please&nbsp;Select&nbsp;Annuval&nbsp;Conference&nbsp;2018&nbsp;Pass&nbsp;:&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;retry:&nbsp;<span class="cs__string">&quot;Selected&nbsp;plan&nbsp;not&nbsp;avilabel&nbsp;.&nbsp;Please&nbsp;try&nbsp;again.&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;promptStyle:&nbsp;PromptStyle.Auto&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<table>
<tbody>
<tr>
<td>
<p dir="ltr">&nbsp;</p>
</td>
</tr>
</tbody>
</table>
<p><span id="docs-internal-guid-5f3e8bb4-2f4b-910d-00b6-cd905b5164d5">&nbsp;</span></p>
<p dir="ltr"><span style="font-size:small">The PropmptDialog. choice method has different parameter, you can refer below for parameter and uses</span></p>
<ol>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">Context - user context message</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Resume - its Resume handler, what next process</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Options - list of prompt item </span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Retry - What to show on retry.</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Attempts -The number of times to retry.</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">PromptStyle - Style of the prompt Prompt Style</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Descriptions - Descriptions to display for choices.</span></p>
</li></ol>
<p dir="ltr"><span style="font-size:small">When the user selects an option, the ChoiceReceivedAsync method will be called.</span></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;async&nbsp;Task&nbsp;ChoiceReceivedAsync(IDialogContext&nbsp;context,&nbsp;IAwaitable&lt;AnnuvalConferencePass&gt;&nbsp;activity)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AnnuvalConferencePass&nbsp;response&nbsp;=&nbsp;await&nbsp;activity;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Call&lt;<span class="cs__keyword">object</span>&gt;(<span class="cs__keyword">new</span>&nbsp;AnnualPlanDialog(response.ToString()),&nbsp;ChildDialogComplete);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p><span id="docs-internal-guid-5f3e8bb4-2f4b-910d-00b6-cd905b5164d5"><br>
</span></p>
<p dir="ltr"><span style="font-size:small">if its bot conversation is completed, the ChildDialogComplete method will execute for show thanks message
</span></p>
<p>&nbsp;</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;async&nbsp;Task&nbsp;ChildDialogComplete(IDialogContext&nbsp;context,&nbsp;IAwaitable&lt;<span class="cs__keyword">object</span>&gt;&nbsp;response)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;context.PostAsync(<span class="cs__string">&quot;Thanks&nbsp;for&nbsp;select&nbsp;C#&nbsp;Corner&nbsp;bot&nbsp;for&nbsp;Annual&nbsp;Conference&nbsp;2018&nbsp;Registrion&nbsp;.&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Done(<span class="cs__keyword">this</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<table>
<tbody>
</tbody>
</table>
<p><span id="docs-internal-guid-5f3e8bb4-2f4b-910d-00b6-cd905b5164d5"><br>
</span></p>
<h1 dir="ltr"><span>Step 3:</span></h1>
<p dir="ltr"><span style="font-size:small">You can wait for a message from the conversation, call context.Wait(&lt;method name&gt;) and pass it the method you called when the message is received. When ShowAnnuvalConferenceTicket () is called, it's passed the
 dialog context and an IAwaitable of type IMessageActivity. To get the message, await the result.</span></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&nbsp;StartAsync(IDialogContext&nbsp;context)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Show&nbsp;the&nbsp;title&nbsp;with&nbsp;background&nbsp;image&nbsp;and&nbsp;Details</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;message&nbsp;=&nbsp;context.MakeMessage();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;attachment&nbsp;=&nbsp;GetHeroCard();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.Attachments.Add(attachment);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;context.PostAsync(message);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Show&nbsp;the&nbsp;list&nbsp;of&nbsp;plan</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Wait(<span class="cs__keyword">this</span>.ShowAnnuvalConferenceTicket);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<h1 class="endscriptcode">&nbsp;AnnualPlanDialog :</h1>
<p></p>
<p dir="ltr"><span style="font-size:small">Create a new class file for registration prompt dialog and implement IDialog interface. In resume parameter, we can specify which dialog method to be called next after the user has responded. The response from the
 user is passed to the subsequent dialog methods and called to the following class.</span></p>
<p dir="ltr"><span style="font-size:small">In this class , Bot will collect all the user information one by one using prompt dialog like below
</span></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;BotPromptDialog.Dialogs&nbsp;
&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;[Serializable]&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;AnnualPlanDialog&nbsp;:&nbsp;IDialog&lt;<span class="cs__keyword">object</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;name;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;email;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;phone;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;plandetails;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;AnnualPlanDialog(<span class="cs__keyword">string</span>&nbsp;plan)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;plandetails&nbsp;=&nbsp;plan;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&nbsp;StartAsync(IDialogContext&nbsp;context)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;context.PostAsync(<span class="cs__string">&quot;Thanks&nbsp;for&nbsp;Select&nbsp;&quot;</span>&#43;&nbsp;plandetails&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;Plan&nbsp;,&nbsp;Can&nbsp;I&nbsp;Help&nbsp;for&nbsp;Registrtion&nbsp;?&nbsp;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Wait(MessageReceivedAsync);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;async&nbsp;Task&nbsp;MessageReceivedAsync(IDialogContext&nbsp;context,&nbsp;IAwaitable&lt;IMessageActivity&gt;&nbsp;activity)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;await&nbsp;activity;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(response.Text.ToLower().Contains(<span class="cs__string">&quot;yes&quot;</span>))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PromptDialog.Text(&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context:&nbsp;context,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resume:&nbsp;ResumeGetName,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;prompt:&nbsp;<span class="cs__string">&quot;Please&nbsp;share&nbsp;your&nbsp;good&nbsp;name&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;retry:&nbsp;<span class="cs__string">&quot;Sorry,&nbsp;I&nbsp;didn't&nbsp;understand&nbsp;that.&nbsp;Please&nbsp;try&nbsp;again.&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Done(<span class="cs__keyword">this</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;async&nbsp;Task&nbsp;ResumeGetName(IDialogContext&nbsp;context,&nbsp;IAwaitable&lt;<span class="cs__keyword">string</span>&gt;&nbsp;Username)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;response&nbsp;=&nbsp;await&nbsp;Username;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name&nbsp;=&nbsp;response;&nbsp;;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PromptDialog.Text(&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context:&nbsp;context,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resume:&nbsp;ResumeGetEmail,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;prompt:&nbsp;<span class="cs__string">&quot;Please&nbsp;share&nbsp;your&nbsp;Email&nbsp;ID&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;retry:&nbsp;<span class="cs__string">&quot;Sorry,&nbsp;I&nbsp;didn't&nbsp;understand&nbsp;that.&nbsp;Please&nbsp;try&nbsp;again.&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;async&nbsp;Task&nbsp;ResumeGetEmail(IDialogContext&nbsp;context,&nbsp;IAwaitable&lt;<span class="cs__keyword">string</span>&gt;&nbsp;UserEmail)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;response&nbsp;=&nbsp;await&nbsp;UserEmail;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;email&nbsp;=&nbsp;response;&nbsp;;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PromptDialog.Text(&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context:&nbsp;context,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resume:&nbsp;ResumeGetPhone,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;prompt:&nbsp;<span class="cs__string">&quot;Please&nbsp;share&nbsp;your&nbsp;Mobile&nbsp;Number&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;retry:&nbsp;<span class="cs__string">&quot;Sorry,&nbsp;I&nbsp;didn't&nbsp;understand&nbsp;that.&nbsp;Please&nbsp;try&nbsp;again.&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;async&nbsp;Task&nbsp;ResumeGetPhone(IDialogContext&nbsp;context,&nbsp;IAwaitable&lt;<span class="cs__keyword">string</span>&gt;&nbsp;mobile)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;response&nbsp;=&nbsp;await&nbsp;mobile;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;phone&nbsp;=&nbsp;response;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;context.PostAsync(String.Format(<span class="cs__string">&quot;Hello&nbsp;{0}&nbsp;,Congratulation&nbsp;:)&nbsp;Your&nbsp;&nbsp;C#&nbsp;Corner&nbsp;Annual&nbsp;Conference&nbsp;2018&nbsp;Registrion&nbsp;Successfullly&nbsp;completed&nbsp;with&nbsp;Name&nbsp;=&nbsp;{0}&nbsp;Email&nbsp;=&nbsp;{1}&nbsp;Mobile&nbsp;Number&nbsp;{2}&nbsp;.&nbsp;You&nbsp;will&nbsp;get&nbsp;Confirmation&nbsp;email&nbsp;and&nbsp;SMS&quot;</span>,&nbsp;name,&nbsp;email,&nbsp;phone));&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Done(<span class="cs__keyword">this</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p><span style="font-size:small">After execute above code, the output look like below</span></p>
<p dir="ltr"><span><img src=":-ikiecbkzhq1sz9eblrwoyilx6h2gdls2oi-sgdrxbc1ejtv22meamjuxwis8eajyb2gcwdaeasdojg4sfyueiqdoxwop7u0oesvwsfunztjytz6gpkdwoqihpmfl-9r-uicfgwf0m3jooywgvg" alt="" width="543" height="675"></span></p>
<h1 dir="ltr"><span>MessagesController Class :</span></h1>
<p dir="ltr"><span style="font-size:small">The RootDialog class is added to the conversation in the MessageController class via the Post() method. In the Post() method, the call to Conversation.SendAsync() creates an instance of the RootDialog, adds it to the
 dialog stack to make it the active dialog, calling the RootDialog.StartAsync() from Post method</span></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[BotAuthentication]&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MessagesController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;POST:&nbsp;api/Messages</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Receive&nbsp;a&nbsp;message&nbsp;from&nbsp;a&nbsp;user&nbsp;and&nbsp;reply&nbsp;to&nbsp;it</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;HttpResponseMessage&gt;&nbsp;Post([FromBody]Activity&nbsp;activity)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(activity.Type&nbsp;==&nbsp;ActivityTypes.Message)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;Conversation.SendAsync(activity,&nbsp;()&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;Dialogs.RootDialog());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HandleSystemMessage(activity);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;Request.CreateResponse(HttpStatusCode.OK);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;response;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Activity&nbsp;HandleSystemMessage(Activity&nbsp;message)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(message.Type&nbsp;==&nbsp;ActivityTypes.DeleteUserData)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Implement&nbsp;user&nbsp;deletion&nbsp;here</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;If&nbsp;we&nbsp;handle&nbsp;user&nbsp;deletion,&nbsp;return&nbsp;a&nbsp;real&nbsp;message</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(message.Type&nbsp;==&nbsp;ActivityTypes.ConversationUpdate)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Handle&nbsp;conversation&nbsp;state&nbsp;changes,&nbsp;like&nbsp;members&nbsp;being&nbsp;added&nbsp;and&nbsp;removed</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Use&nbsp;Activity.MembersAdded&nbsp;and&nbsp;Activity.MembersRemoved&nbsp;and&nbsp;Activity.Action&nbsp;for&nbsp;info</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Not&nbsp;available&nbsp;in&nbsp;all&nbsp;channels</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(message.Type&nbsp;==&nbsp;ActivityTypes.ContactRelationUpdate)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Handle&nbsp;add/remove&nbsp;from&nbsp;contact&nbsp;lists</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Activity.From&nbsp;&#43;&nbsp;Activity.Action&nbsp;represent&nbsp;what&nbsp;happened</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(message.Type&nbsp;==&nbsp;ActivityTypes.Typing)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Handle&nbsp;knowing&nbsp;tha&nbsp;the&nbsp;user&nbsp;is&nbsp;typing</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(message.Type&nbsp;==&nbsp;ActivityTypes.Ping)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<table>
<colgroup><col width="623"></colgroup>
<tbody>
<tr>
<td>
<p dir="ltr"><span>&nbsp;&nbsp;<br>
</span></p>
</td>
</tr>
</tbody>
</table>
<p><span id="docs-internal-guid-5f3e8bb4-2f4b-910d-00b6-cd905b5164d5"><br>
</span></p>
<h1 dir="ltr"><span>Run Bot Application:</span></h1>
<p dir="ltr"><span style="font-size:small">The emulator is a desktop application that lets we test and debug our bot on localhost. Now, you can click on &quot;Run the application&quot; in Visual studio and execute in the browser.</span></p>
<h1 dir="ltr"><span><br class="kix-line-break">
</span><span><img src=":-gm9gu8p6hq83xqbbhtbdteacqytuua1lsdk_hj8s9eu4kotqqermb9vdwush58nuwp1mgshwynisz4mbf2gcvqvfe2s6gdq8ky8-1i8gdywnnn0fj3u4apprtkpdipbhqbkdqr4rtx2nnb4z9g" alt="" width="624" height="199"></span><span><br class="kix-line-break">
</span><span><br class="kix-line-break">
</span><span>Test Application on Bot Emulator</span></h1>
<p dir="ltr"><span style="font-size:small">You can follow the below steps for test your bot application.</span></p>
<ol>
<li dir="ltr">
<p dir="ltr"><span style="font-size:small">Open Bot Emulator.</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">Copy the above localhost url and paste it in emulator e.g. - http://localHost:3979</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">You can append the /api/messages in the above url; e.g. - http://localHost:3979/api/messages.</span></p>
</li><li dir="ltr">
<p dir="ltr"><span style="font-size:small">You won't need to specify Microsoft App ID and Microsoft App Password for localhost testing, so click on &quot;Connect&quot;.</span></p>
</li></ol>
<p dir="ltr"><span><img src=":-va-r_sztkmq8pxh6rc42vqptk6ma2vlwkmq0zkbopxkju1em7jktok1brlm_saz5mo2w40aapn713tkxlppgop2-cw_qwhueagys6ml5wtxngu4tx96narocgfyg7kq0slipkcuq5ga2f0ijpg" alt="" width="454" height="837"></span></p>
<h1 dir="ltr"><span>Summary:</span></h1>
<p dir="ltr"><span style="font-size:small">In this article, how to use prompts and how you can use them to collect information from the users. If you have any questions/ feedback/ issues, please write in the comment box.</span></p>
<p>&nbsp;</p>
