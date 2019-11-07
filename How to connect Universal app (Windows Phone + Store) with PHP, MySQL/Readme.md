# How to connect Universal app (Windows Phone + Store) with PHP, MySQL
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Windows Phone
- PHP
- MySQL
- Windows Store app
## Topics
- Authentication
- Backend Operation
- Database Connectivity
- Windows Phone 8.1
## Updated
- 02/17/2015
## Description

<h1><span style="font-size:small"><strong>Applies to</strong>: Windows Phone 8.1 &ndash; Windows 8.1 (WinRT)</span></h1>
<p>Windows Phone 8.1 brings new codes and methods to serve as the basic utilities of the developers.</p>
<p>One of the basic codes for every developer is connect to a distant or local server.
<span>PHP &amp; MySQL is one of the most common</span>&nbsp;combinations to build the the server-side. phpmyadmin is the solution given to interact easily with the data in a way to visualize, edit, remove or store data in the MySQL database.&nbsp;</p>
<p>This example is about connection of a universal app ( Windows Phone and Windows Store) with PHP/MySQL:</p>
<p>This project presents one of the most common scenarios implemented by developers: Authentication.&nbsp;</p>
<h1>Building the Sample</h1>
<p>This sample is packaged as a Windows Phone 8.1 project. The C# source code can be used to a Windows 8.1 project.</p>
<p>To create a Windows Phone 8.1 project, you must be running the Windows Phone SDK 8.1 on Visual Studio 2013 (Update 3 if possible). You can download the latest version of the SDK from&nbsp;<a href="http://dev.windowsphone.com/downloadsdk">http://dev.windowsphone.com/downloadsdk</a>.</p>
<p><strong>Network capabilities</strong></p>
<p>This sample requires that network capabilities be set in the Package.appxmanifest file to allow the app to access the network at runtime. These capabilities can be set in the app manifest using Microsoft Visual Studio.</p>
<p><strong>Build the sample</strong></p>
<p>1.Start Visual Studio 2013 Update 2 and select File &gt; Open &gt; Project/Solution.</p>
<p>2.Go to the directory to which you unzipped the sample. Go to the directory named for the sample, and double-click the Visual Studio 2013 Update 2 Solution (.sln) file.</p>
<p>3.Follow the steps for the version of the sample you want</p>
<p>4.To build the Windows Phone version of the sample: Select the project in Solution Explorer.</p>
<p>5.Press Ctrl&#43;Shift&#43;B or use Build &gt; Build Solution or use Build in the menu of Visual Studio.</p>
<p>&nbsp;</p>
<p><strong>Run the sample</strong></p>
<p>The next steps depend on whether you just want to deploy the sample or you want to both deploy and run it.</p>
<p>Deploying the sample.To deploy the built Windows Phone version of the sample:</p>
<p>1.Select the project in Solution Explorer.</p>
<p>2.Use Build &gt; Deploy Solution or Build &gt; Deploy the project</p>
<h1><span>Description: The server side</span></h1>
<p>The first step is to build the database. Open Wamp Server if you are using this local server then whether you are on a local or a distant server, open your phpmyadmin. create a database &quot;mydatabase&quot; then let's create a table called &quot;user&quot; containing 3 fields:
 id, login, pwd.</p>
<p><img id="133921" src="133921-1.png" alt=""></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">CREATE TABLE  `mydatabase`.`user` (
`id` INT( 3 ) NOT NULL ,
`login` VARCHAR( 10 ) NOT NULL ,
`pwd` VARCHAR( 10 ) NOT NULL ,
PRIMARY KEY (  `id` )
) ENGINE = INNODB</pre>
<div class="preview">
<pre class="mysql"><span class="sql__keyword">CREATE</span><span class="sql__keyword">TABLE</span><span class="sql__quid">`mydatabase`</span>.<span class="sql__quid">`user`</span>&nbsp;(&nbsp;
<span class="sql__quid">`id`</span><span class="sql__keyword">INT</span>(&nbsp;<span class="sql__number">3</span>&nbsp;)&nbsp;<span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>&nbsp;,&nbsp;
<span class="sql__quid">`login`</span><span class="sql__keyword">VARCHAR</span>(&nbsp;<span class="sql__number">10</span>&nbsp;)&nbsp;<span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>&nbsp;,&nbsp;
<span class="sql__quid">`pwd`</span><span class="sql__keyword">VARCHAR</span>(&nbsp;<span class="sql__number">10</span>&nbsp;)&nbsp;<span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>&nbsp;,&nbsp;
<span class="sql__keyword">PRIMARY</span><span class="sql__keyword">KEY</span>&nbsp;(&nbsp;&nbsp;<span class="sql__quid">`id`</span>&nbsp;)&nbsp;
)&nbsp;<span class="sql__keyword">ENGINE</span>&nbsp;=&nbsp;<span class="sql__keyword">INNODB</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Then, let's insert a user having as a login &quot;user&quot;and as a password &quot;user&quot;. you can do it graphically or using SQL script</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">INSERT INTO  `mydatabase`.`user` (
`id` ,
`login` ,
`pwd`
)
VALUES (
'',  'user',  'user'
);</pre>
<div class="preview">
<pre class="mysql"><span class="sql__keyword">INSERT</span><span class="sql__keyword">INTO</span><span class="sql__quid">`mydatabase`</span>.<span class="sql__quid">`user`</span>&nbsp;(&nbsp;
<span class="sql__quid">`id`</span>&nbsp;,&nbsp;
<span class="sql__quid">`login`</span>&nbsp;,&nbsp;
<span class="sql__quid">`pwd`</span>&nbsp;
)&nbsp;
<span class="sql__keyword">VALUES</span>&nbsp;(&nbsp;
<span class="sql__string">''</span>,&nbsp;&nbsp;<span class="sql__string">'user'</span>,&nbsp;&nbsp;<span class="sql__string">'user'</span>&nbsp;
);</pre>
</div>
</div>
</div>
<div class="endscriptcode">Your database is now ready to go. We have to add two PHP files in the server ( at wamp/www if you are using wamp) in order to get the data from the database.The first file is for connection to the server. if you are using wamp,
 usually the parameters to connect are the same as the file, you can change the parameters if you are working on a distant server. Here is the connect.PHP</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PHP</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">php</span>
<pre class="hidden">&lt;?php  
 $hostname_localhost =&quot;localhost&quot;;  
 $database_localhost =&quot;mydatabase&quot;;  
 $username_localhost =&quot;root&quot;;  
 $password_localhost =&quot;&quot;;  
 $con = mysql_connect($hostname_localhost,$username_localhost,$password_localhost)  
 or  
 trigger_error(mysql_error(),E_USER_ERROR);  
 ?&gt;</pre>
<div class="preview">
<pre class="php"><span class="php__start">&lt;?php</span><span class="php__keyword">$</span><span class="php__variable">hostname_localhost</span>&nbsp;=<span class="php__string2">&quot;localhost&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;<span class="php__keyword">$</span><span class="php__variable">database_localhost</span>&nbsp;=<span class="php__string2">&quot;mydatabase&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;<span class="php__keyword">$</span><span class="php__variable">username_localhost</span>&nbsp;=<span class="php__string2">&quot;root&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;<span class="php__keyword">$</span><span class="php__variable">password_localhost</span>&nbsp;=<span class="php__string2">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;<span class="php__keyword">$</span><span class="php__variable">con</span>&nbsp;=&nbsp;mysql_connect(<span class="php__keyword">$</span><span class="php__variable">hostname_localhost</span>,<span class="php__keyword">$</span><span class="php__variable">username_localhost</span>,<span class="php__keyword">$</span><span class="php__variable">password_localhost</span>)&nbsp;&nbsp;&nbsp;
&nbsp;<span class="php__keyword">or</span>&nbsp;&nbsp;&nbsp;
&nbsp;trigger_error(mysql_error(),<span class="php__const1">E_USER_ERROR</span>);&nbsp;&nbsp;&nbsp;
&nbsp;<span class="php__end">?&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;finally the login.PHP file must be uploaded at the server (or at wap/www if you are using wamp). this file gets the login and password given then checks the database and shows a message confirming or not the existence of the
 login and password given.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>PHP</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">php</span>
<pre class="hidden">&lt;?php 
require_once('connect.php'); 
if(isset($_GET['login']) &amp;&amp; isset($_GET['pwd'])){

$login = $_GET['login'];
$password = $_GET['pwd'];

	mysql_select_db($database_localhost,$con);  
    $query_search = &quot;SELECT * FROM user where login = '$login'&quot;;  
	$query_exec = mysql_query($query_search) or die(mysql_error());  
	if($query_exec!=null){  
		while($result_array = mysql_fetch_assoc($query_exec)) {
			 $password_array = $result_array['pwd'];
		}
		if($password == $password_array){
			echo &quot;OK&quot;;
		}else{
			echo &quot;ERROR PASSWORD&quot;;
		}
	}else {
		echo &quot;ERROR LOGIN&quot;;
	}
}else{
	echo &quot;ERROR&quot;;
}
?&gt;</pre>
<div class="preview">
<pre class="php"><span class="php__start">&lt;?php</span><span class="php__keyword">require_once</span>(<span class="php__string1">'connect.php'</span>);&nbsp;&nbsp;
<span class="php__keyword">if</span>(<span class="php__keyword">isset</span>(<span class="php__global">$_GET</span>[<span class="php__string1">'login'</span>])&nbsp;&amp;&amp;&nbsp;<span class="php__keyword">isset</span>(<span class="php__global">$_GET</span>[<span class="php__string1">'pwd'</span>])){&nbsp;
&nbsp;
<span class="php__keyword">$</span><span class="php__variable">login</span>&nbsp;=&nbsp;<span class="php__global">$_GET</span>[<span class="php__string1">'login'</span>];&nbsp;
<span class="php__keyword">$</span><span class="php__variable">password</span>&nbsp;=&nbsp;<span class="php__global">$_GET</span>[<span class="php__string1">'pwd'</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mysql_select_db(<span class="php__keyword">$</span><span class="php__variable">database_localhost</span>,<span class="php__keyword">$</span><span class="php__variable">con</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="php__keyword">$</span><span class="php__variable">query_search</span>&nbsp;=&nbsp;<span class="php__string2">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;user&nbsp;where&nbsp;login&nbsp;=&nbsp;'$login'&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="php__keyword">$</span><span class="php__variable">query_exec</span>&nbsp;=&nbsp;mysql_query(<span class="php__keyword">$</span><span class="php__variable">query_search</span>)&nbsp;<span class="php__keyword">or</span><span class="php__keyword">die</span>(mysql_error());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="php__keyword">if</span>(<span class="php__keyword">$</span><span class="php__variable">query_exec</span>!=<span class="php__value">null</span>){&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="php__keyword">while</span>(<span class="php__keyword">$</span><span class="php__variable">result_array</span>&nbsp;=&nbsp;mysql_fetch_assoc(<span class="php__keyword">$</span><span class="php__variable">query_exec</span>))&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="php__keyword">$</span><span class="php__variable">password_array</span>&nbsp;=&nbsp;<span class="php__keyword">$</span><span class="php__variable">result_array</span>[<span class="php__string1">'pwd'</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="php__keyword">if</span>(<span class="php__keyword">$</span><span class="php__variable">password</span>&nbsp;==&nbsp;<span class="php__keyword">$</span><span class="php__variable">password_array</span>){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="php__keyword">echo</span><span class="php__string2">&quot;OK&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="php__keyword">else</span>{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="php__keyword">echo</span><span class="php__string2">&quot;ERROR&nbsp;PASSWORD&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}<span class="php__keyword">else</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="php__keyword">echo</span><span class="php__string2">&quot;ERROR&nbsp;LOGIN&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}<span class="php__keyword">else</span>{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="php__keyword">echo</span><span class="php__string2">&quot;ERROR&quot;</span>;&nbsp;
}&nbsp;
<span class="php__end">?&gt;</span></pre>
</div>
</div>
</div>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1>Description: Windows Phone/ Windows Store 8.1</h1>
<p>finally we get to the client side. since the procedure is the same, we will discover the code behind only once.</p>
<p>The Windows.Web.Http.HttpClient class provides the main class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.&nbsp;This is the complete url that must be checked and verified by the php file &nbsp; &nbsp; &nbsp;private
 String feedAddress = &quot;http://localhost/login.php?login=user&amp;pwd=user&quot;;</p>
<p>but the login and pwd values must be taken from the TextBoxes that the app user enters.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        private HttpClient httpClient;
        private HttpResponseMessage response;

       
        private String phpAddress = &quot;http://localhost/login.php?&quot;;

        </pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;HttpClient&nbsp;httpClient;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;HttpResponseMessage&nbsp;response;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;String&nbsp;phpAddress&nbsp;=&nbsp;<span class="cs__string">&quot;http://localhost/login.php?&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Once the button clicked, the app checks for the php file at the url. then the php file connects to the database and send the answer back to the app. the text of the answer generated by the php file (<strong>responseTex</strong>t)&nbsp;will
 appear then at the&nbsp;<strong>phpStatus.Text </strong>&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> phpAddress = &quot;http://localhost/login.php?login=&quot;&#43;tbLogin.Text&#43;&quot;&amp;pwd=&quot;&#43;tbPwd.Text;
            response = new HttpResponseMessage();

            // if 'phpAddress' value changed the new URI must be tested --------------------------------
            // if the new 'phpAddress' doesn't work, 'phpStatus' informs the user about the incorrect input.

           
            Uri resourceUri;
            if (!Uri.TryCreate(phpAddress.Trim(), UriKind.Absolute, out resourceUri))
            {
                phpStatus.Text = &quot;Invalid URI, please re-enter a valid URI&quot;;
                return;
            }
            if (resourceUri.Scheme != &quot;http&quot; &amp;&amp; resourceUri.Scheme != &quot;https&quot;)
            {
                phpStatus.Text = &quot;Only 'http' and 'https' schemes supported. Please re-enter URI&quot;;
                return;
            }
            // ---------- end of test---------------------------------------------------------------------

            string responseText;
            phpStatus.Text = &quot;Waiting for response ...&quot;;

            try
            {
                response = await httpClient.GetAsync(resourceUri);

                response.EnsureSuccessStatusCode();

                responseText = await response.Content.ReadAsStringAsync();
                

            }
            catch (Exception ex)
            {
                // Need to convert int HResult to hex string
                phpStatus.Text = &quot;Error = &quot; &#43; ex.HResult.ToString(&quot;X&quot;) &#43;
                    &quot;  Message: &quot; &#43; ex.Message;
                responseText = &quot;&quot;;
            }
            phpStatus.Text = response.StatusCode &#43; &quot; &quot; &#43; response.ReasonPhrase;

            // now 'responseText' contains the response as a verified text.
            // next 'responseText' is displayed 
            
            phpStatus.Text = responseText.ToString();</pre>
<div class="preview">
<pre class="csharp">&nbsp;phpAddress&nbsp;=&nbsp;<span class="cs__string">&quot;http://localhost/login.php?login=&quot;</span>&#43;tbLogin.Text&#43;<span class="cs__string">&quot;&amp;pwd=&quot;</span>&#43;tbPwd.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseMessage();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;if&nbsp;'phpAddress'&nbsp;value&nbsp;changed&nbsp;the&nbsp;new&nbsp;URI&nbsp;must&nbsp;be&nbsp;tested&nbsp;--------------------------------</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;if&nbsp;the&nbsp;new&nbsp;'phpAddress'&nbsp;doesn't&nbsp;work,&nbsp;'phpStatus'&nbsp;informs&nbsp;the&nbsp;user&nbsp;about&nbsp;the&nbsp;incorrect&nbsp;input.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;resourceUri;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!Uri.TryCreate(phpAddress.Trim(),&nbsp;UriKind.Absolute,&nbsp;<span class="cs__keyword">out</span>&nbsp;resourceUri))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;phpStatus.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Invalid&nbsp;URI,&nbsp;please&nbsp;re-enter&nbsp;a&nbsp;valid&nbsp;URI&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(resourceUri.Scheme&nbsp;!=&nbsp;<span class="cs__string">&quot;http&quot;</span>&nbsp;&amp;&amp;&nbsp;resourceUri.Scheme&nbsp;!=&nbsp;<span class="cs__string">&quot;https&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;phpStatus.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Only&nbsp;'http'&nbsp;and&nbsp;'https'&nbsp;schemes&nbsp;supported.&nbsp;Please&nbsp;re-enter&nbsp;URI&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;----------&nbsp;end&nbsp;of&nbsp;test---------------------------------------------------------------------</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;responseText;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;phpStatus.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Waiting&nbsp;for&nbsp;response&nbsp;...&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response&nbsp;=&nbsp;await&nbsp;httpClient.GetAsync(resourceUri);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.EnsureSuccessStatusCode();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;responseText&nbsp;=&nbsp;await&nbsp;response.Content.ReadAsStringAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Need&nbsp;to&nbsp;convert&nbsp;int&nbsp;HResult&nbsp;to&nbsp;hex&nbsp;string</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;phpStatus.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Error&nbsp;=&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ex.HResult.ToString(<span class="cs__string">&quot;X&quot;</span>)&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;Message:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ex.Message;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;responseText&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;phpStatus.Text&nbsp;=&nbsp;response.StatusCode&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;response.ReasonPhrase;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;now&nbsp;'responseText'&nbsp;contains&nbsp;the&nbsp;response&nbsp;as&nbsp;a&nbsp;verified&nbsp;text.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;next&nbsp;'responseText'&nbsp;is&nbsp;displayed&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;phpStatus.Text&nbsp;=&nbsp;responseText.ToString();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="endscriptcode">
<div class="endscriptcode">
<div class="endscriptcode"></div>
</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span><br>
</span></p>
