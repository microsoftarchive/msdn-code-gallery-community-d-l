# Getting Started With ASP.NET Core 2.0 Identity And Role Management
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- ASP.NET Identity
- ASP.NET Core
## Topics
- ASP.NET Identity
- ASP.NET Core
- ASP.NET Core 2.0
## Updated
- 03/21/2018
## Description

<h1>Introduction</h1>
<p>In this article, we will see in detail how to use ASP.NET Core Identity in MVC Application for creating user roles and displaying the menu depending on user roles.</p>
<p>Here, we will see how to:</p>
<ul>
<li>Create default admin users </li><li>Create default admin role </li><li>Redirect unauthenticated users to a login page </li><li>Display Admin Page menu only for Authorized Admin User </li></ul>
<p>ASP.NET Identity allows us to add login functionality to our system. Here, in this demo, we will be using SQL Server to store the user details and profile data. We will use ASP.NET Identity for new user registration, login, and to maintain the user profile
 data. If we talk about the login, the important part is whether the logged in user is authenticated and also authorized to view the pages.</p>
<h1><strong>Authentication and Authorization</strong></h1>
<h2><strong>Authentication</strong></h2>
<p>Check for the Valid User. Here, the question is how to check whether a user is valid or not. When a user comes to a website for the first time, he/she will register for that website. All their information, like username, password, email, and so on will be
 stored in the website database. When a user enters his/her userID and password, the information will be checked with the database. If the user has entered the same userID and Password as in the database, then he or she is a valid user and will be redirected
 to the website's home page. If the user entered UserID or Password that does not match the database, then the login page will give a message, something like &ldquo;Enter valid Username or Password&rdquo;. The entire process of checking whether the user is
 valid or not for accessing the website is called Authentication.&nbsp;</p>
<h2>Authorization</h2>
<p>Once the user is authenticated, they need to be redirected to the appropriate page by his/her role. For example, when an Admin is logged in, then need to be redirected to the Admin Page. If an Accountant is logged in, then he/she needs to be redirected to
 his Accounts page.</p>
<h1><span>Building the Sample</span></h1>
<h1><em><strong>Prerequisites</strong></em></h1>
<p>Make sure you have installed all the prerequisites in your computer. If not, then download and install them all, one by one.</p>
<ol>
<li>First, download and install Visual Studio 2017 from this&nbsp;<a href="https://www.visualstudio.com/" target="_blank">link</a>
</li><li>SQL Server 2014 or above </li></ol>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<h1>Step 1: Create a Database</h1>
<p>Firstly, we will create a database and set the connection string in appsettings.json file for DefaultConnection with our new database connection. We will be using this database for ASP.NET Core Identity table creation.<br>
Create Database: Run the following script to create our database.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;MASTER&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
--&nbsp;<span class="js__num">1</span>)&nbsp;Check&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;Database&nbsp;Exists&nbsp;.If&nbsp;the&nbsp;database&nbsp;is&nbsp;exist&nbsp;then&nbsp;drop&nbsp;and&nbsp;create&nbsp;<span class="js__operator">new</span>&nbsp;DB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
IF&nbsp;EXISTS&nbsp;(SELECT&nbsp;[name]&nbsp;FROM&nbsp;sys.databases&nbsp;WHERE&nbsp;[name]&nbsp;=&nbsp;<span class="js__string">'InventoryDB'</span>&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
DROP&nbsp;DATABASE&nbsp;InventoryDB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
CREATE&nbsp;DATABASE&nbsp;InventoryDB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
USE&nbsp;InventoryDB&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
GO&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>After running the DB Script, we can see that the Database has been created and tables have not yet been created.</p>
<p><img id="192973" src="192973-4.png" alt="" width="205" height="101"></p>
<h1>Step 2: Create your ASP.NET Core&nbsp;</h1>
<p>After installing our Visual Studio 2017, click Start, then Programs and select Visual Studio 2017 - Click Visual Studio 2017. Click New, then Project, select Web and then select ASP.NET Core Web Application. Enter your project name and click.</p>
<p><img id="192974" src="192974-1.png" alt="" width="604" height="351"></p>
<p>Select Web Application (Model-View-Controller) and click on the Change Authentication.</p>
<p><img id="192975" src="192975-2.png" alt="" width="487" height="314"></p>
<p>Select Individual User Accounts and click ok to create your project.</p>
<p><img id="192976" src="192976-3.png" alt="" width="462" height="278"></p>
<h2>Updating appsettings.json</h2>
<p>In appsettings.json file, we can find the DefaultConnection Connection string. Here, in connection string, change your SQL Server Name, UID and PWD to create and store all user details in one database.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js"><span class="js__string">&quot;ConnectionStrings&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;DefaultConnection&quot;</span>:&nbsp;&quot;Server=&nbsp;YOURSERVERNAME;Database=InventoryDB;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;user&nbsp;id=&nbsp;YOURSQLUSERID;password=YOURSQLPASSWORD;Trusted_Connection=True;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MultipleActiveResultSets=true&quot;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>,</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="192977" src="192977-5.png" alt="" width="1047" height="163"></div>
<p>&nbsp;</p>
<h1>Step 3: Add Identity Service in Startup.cs</h1>
<p>fileBy default, in your ASP.NET Core application, the Identity Service will be added in Startup.cs file /ConfigureServices method. You can also additionally add the password strength while the user registers and also set the default login page/logout page
 and also AccessDenaiedPath by using the following code:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">services.AddIdentity&lt;ApplicationUser,&nbsp;IdentityRole&gt;()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.AddEntityFrameworkStores&lt;ApplicationDbContext&gt;()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.AddDefaultTokenProviders();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Password&nbsp;Strength&nbsp;Setting</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.Configure&lt;IdentityOptions&gt;(options&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Password&nbsp;settings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Password.RequireDigit&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Password.RequiredLength&nbsp;=&nbsp;<span class="js__num">8</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Password.RequireNonAlphanumeric&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Password.RequireUppercase&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Password.RequireLowercase&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Password.RequiredUniqueChars&nbsp;=&nbsp;<span class="js__num">6</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Lockout&nbsp;settings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Lockout.DefaultLockoutTimeSpan&nbsp;=&nbsp;TimeSpan.FromMinutes(<span class="js__num">30</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Lockout.MaxFailedAccessAttempts&nbsp;=&nbsp;<span class="js__num">10</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Lockout.AllowedForNewUsers&nbsp;=&nbsp;true;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;User&nbsp;settings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.User.RequireUniqueEmail&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Setting&nbsp;the&nbsp;Account&nbsp;Login&nbsp;page</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.ConfigureApplicationCookie(options&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Cookie&nbsp;settings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Cookie.HttpOnly&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.ExpireTimeSpan&nbsp;=&nbsp;TimeSpan.FromMinutes(<span class="js__num">30</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.LoginPath&nbsp;=&nbsp;<span class="js__string">&quot;/Account/Login&quot;</span>;&nbsp;<span class="js__sl_comment">//&nbsp;If&nbsp;the&nbsp;LoginPath&nbsp;is&nbsp;not&nbsp;set&nbsp;here,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;ASP.NET&nbsp;Core&nbsp;will&nbsp;default&nbsp;to&nbsp;/Account/Login</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.LogoutPath&nbsp;=&nbsp;<span class="js__string">&quot;/Account/Logout&quot;</span>;&nbsp;<span class="js__sl_comment">//&nbsp;If&nbsp;the&nbsp;LogoutPath&nbsp;is&nbsp;not&nbsp;set&nbsp;here,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;ASP.NET&nbsp;Core&nbsp;will&nbsp;default&nbsp;to&nbsp;/Account/Logout</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.AccessDeniedPath&nbsp;=&nbsp;<span class="js__string">&quot;/Account/AccessDenied&quot;</span>;&nbsp;<span class="js__sl_comment">//&nbsp;If&nbsp;the&nbsp;AccessDeniedPath&nbsp;is&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;not&nbsp;set&nbsp;here,&nbsp;ASP.NET&nbsp;Core&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;will&nbsp;default&nbsp;to&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;/Account/AccessDenied</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.SlidingExpiration&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Here is how we have added the ASP.NET Core Identity Services in our ConfigureService method looks like:</div>
<p><img id="192978" src="192978-5_1.png" alt="" width="547" height="335"></p>
<p>&nbsp;</p>
<h1>Step 4: Register and Create your First User</h1>
<p>Now our ASP.NET Core web application is ready for user to register in our website and also user can login to our system after registration. We will be doing the Authorization by adding role to user in next steps. Build and run your application to register
 your first default Admin user.</p>
<p><img id="192979" src="192979-6.png" alt="" width="478" height="264"></p>
<p>Click on the Register link to register our first User.</p>
<p><img id="192980" src="192980-7.png" alt="" width="455" height="364"></p>
<h2>Migration</h2>
<p>When we click on the Register button, we can see the below page. Don&rsquo;t panic with this page as for the first time run we need to do the Migration, just click on the Apply Migrations button.</p>
<p><img id="192981" src="192981-8.png" alt="" width="437" height="265"></p>
<p>We can see the confirmation as Migration Applied and click on Try refreshing the page message.</p>
<p><img id="192982" src="192982-9.png" alt="" width="409" height="300"></p>
<p>Refresh the page and we can see the newly registered user has been logged into our web site.</p>
<p><img id="192983" src="192983-12.png" alt="" width="548" height="110"></p>
<h2>Refresh the Database</h2>
<p>When we refresh our database, we can see all the Identity tables have been created.</p>
<p><img id="192984" src="192984-10.png" alt="" width="243" height="240"></p>
<p>We can check the aspNetUsers table to find the newly created user details. We can also see the ASPNetRoles and ASPNetUserRoles have no records as we have not yet created any roles or added user for the roles. In the next step, we will add a new role as &ldquo;Admin&rdquo;
 and we will add the newly register user as Admin.</p>
<p><img id="192985" src="192985-11.png" alt="" width="488" height="260"></p>
<h1>Step 5: Create Role and Assign User for Role</h1>
<p>We use the below method to create a new Role as &ldquo;Admin&rdquo; and we will assign the recently registered as &ldquo;Admin&rdquo; to our website. Open Startup.cs file and add this method in your Startup.cs file.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;async&nbsp;Task&nbsp;CreateUserRoles(IServiceProvider&nbsp;serviceProvider)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;RoleManager&nbsp;=&nbsp;serviceProvider.GetRequiredService&lt;RoleManager&lt;IdentityRole&gt;&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;UserManager&nbsp;=&nbsp;serviceProvider.GetRequiredService&lt;UserManager&lt;ApplicationUser&gt;&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IdentityResult&nbsp;roleResult;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Adding&nbsp;Admin&nbsp;Role</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;roleCheck&nbsp;=&nbsp;await&nbsp;RoleManager.RoleExistsAsync(<span class="js__string">&quot;Admin&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!roleCheck)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//create&nbsp;the&nbsp;roles&nbsp;and&nbsp;seed&nbsp;them&nbsp;to&nbsp;the&nbsp;database</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;roleResult&nbsp;=&nbsp;await&nbsp;RoleManager.CreateAsync(<span class="js__operator">new</span>&nbsp;IdentityRole(<span class="js__string">&quot;Admin&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;<span class="js__sl_comment">//Assign&nbsp;Admin&nbsp;role&nbsp;to&nbsp;the&nbsp;main&nbsp;User&nbsp;here&nbsp;we&nbsp;have&nbsp;given&nbsp;our&nbsp;newly&nbsp;registered&nbsp;</span>&nbsp;
&nbsp;<span class="js__sl_comment">//login&nbsp;id&nbsp;for&nbsp;Admin&nbsp;management</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ApplicationUser&nbsp;user&nbsp;=&nbsp;await&nbsp;UserManager.FindByEmailAsync(<span class="js__string">&quot;syedshanumcain@gmail.com&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;User&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ApplicationUser();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;UserManager.AddToRoleAsync(user,&nbsp;<span class="js__string">&quot;Admin&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;From Startup.cs file, we can find the Configure method. Call our CreateUserRoles method from this Configure method. When we build and run our application, we can see new Role as &ldquo;Admin&rdquo; will be created in ASPNetRole
 table.</div>
<div class="endscriptcode"><img id="192987" src="192987-13.png" alt="" width="479" height="224"></div>
<p>&nbsp;</p>
<p>When we build and run the application, we can see the New Role has been added in the ASPNetRoles table and also, we can see as our default User has been assigned with the Admin Role.</p>
<p><img id="192988" src="192988-14.png" alt="" width="456" height="197"></p>
<h1>Step 6: Create Admin Page and Set Authorization</h1>
<p>Now we have an Admin user for our ASP.NET Core web application. As a next step, let's create one new page and set Authorization for this page as only Logged in and Admin user alone can view this page. For doing this, we create a new Controller named as Admin.</p>
<h2>Creating Admin Controller</h2>
<p>Right click Controller folder and click Add New Controller, select MVC Controller &ndash; Empty and click Add.</p>
<p><img id="192990" src="192990-15.png" alt="" width="427" height="245"></p>
<p>Enter your Controller name as Admin and click Add.</p>
<p><img id="192991" src="192991-16.png" alt="" width="392" height="106"></p>
<p>From the controller, Right Click the Index and click Add View. Click the Add Button to create our View page.</p>
<p><img id="192994" src="192994-17.png" alt="" width="385" height="260"></p>
<p>We can see our Admin Controller and Admin View has been created.</p>
<p><img id="192993" src="192993-19.png" alt="" width="183" height="303"></p>
<p>Open the&nbsp;<em>Admin/Index.cshtml</em>&nbsp;page to design for your need. Here, I have added simple text like below:</p>
<p><img id="192995" src="192995-18.png" alt="" width="385" height="163"></p>
<p><span>Next, we create a new Menu to display the Admin Page. For creating our new Menu, open the&nbsp;</span><em>_Layout.cshtml</em><span>from&nbsp;</span><em>Views/Shared</em><span>&nbsp;folder. Add the menu like the below image:</span></p>
<p><img id="192996" src="192996-20.png" alt="" width="482" height="102"></p>
<p>Now we have created the Admin Page and also added the menu for our Admin. We have created this page only for the Admin user and other users or non-logged in users should not see this page. What will happen If we run our application.</p>
<p>We can see as new menu &ldquo;Admin Page&rdquo; has been created and it's open to all now. This means that anyone can click on the link and view the content of that page.</p>
<p><img id="192997" src="192997-21.png" alt="" width="632" height="165"></p>
<p>&nbsp;</p>
<p>Here, we can see as we can view the Admin page with our Login.</p>
<p><img id="192998" src="192998-22.png" alt="" width="525" height="124"></p>
<h2>Set Authorization</h2>
<p>To avoid this, we use the Authorization in our Admin page controller. Open our Admin Controller and add the below line of code:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">[Authorize(Roles&nbsp;=&nbsp;<span class="js__string">&quot;Admin&quot;</span>)]&nbsp;
public&nbsp;IActionResult&nbsp;Index()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View();&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><img id="192999" src="192999-23.png" alt="" width="308" height="116"></p>
<p>&nbsp;</p>
<p>If we run our application and click on the Admin page, it will automatically redirect to Log in page.</p>
<p><img id="193000" src="193000-26.png" alt="" width="490" height="311"></p>
<p><span>Note only the Admin Role Members will be able to view the admin page as we have set the Authorization only for the Admin Roles. If you want to add more Roles, we can use the comma like the below code:</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">[Authorize(Roles&nbsp;=&nbsp;<span class="js__string">&quot;Admin,SuperAdmin,Manager&quot;</span>)]</pre>
</div>
</div>
</div>
<h1 class="endscriptcode">&nbsp;Step 7: Show Hide Menu by User Role</h1>
<p>&nbsp;</p>
<p>Now let&rsquo;s go one step forward as to show the Admin Menu only for the Logged in Admin users. To do this, we open our Layout.cshtml from Views/Shared folder and edit the newly added menu like the below code. Here, in this code, first we check whether
 the user is Authenticated, means Logged in, and then we check whether the user has Authorization to view the menu.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@<span class="js__statement">if</span>&nbsp;(User.Identity.IsAuthenticated)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@<span class="js__statement">if</span>&nbsp;(User.IsInRole(<span class="js__string">&quot;Admin&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;a&nbsp;asp-area=<span class="js__string">&quot;&quot;</span>&nbsp;asp-controller=<span class="js__string">&quot;Admin&quot;</span>&nbsp;asp-action=<span class="js__string">&quot;Index&quot;</span>&gt;Admin&nbsp;Page&lt;/a&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/li&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="193001" src="193001-25_0.png" alt="" width="391" height="145"></div>
<div class="endscriptcode"><span>Run the application and we can see by default the &ldquo;Admin Page&rdquo; will not be displayed in our top menu. Logged in Admin Role user alone can view the menu.</span></div>
<div class="endscriptcode"><img id="193002" src="193002-6.png" alt="" width="478" height="204"></div>
<p>&nbsp;</p>
<p>Let&rsquo;s try this by&nbsp;Login with our Admin user which we created initially.</p>
<p><img id="193000" src="193000-26.png" alt="" width="490" height="311"></p>
<p>After Log in, we can see that the Admin user can view the Admin Page menu now.</p>
<p>&nbsp;</p>
<p><img id="193003" src="193003-27.png" alt="" width="479" height="159"></p>
<p>Let&rsquo;s try with creating a normal user as we register new user now.</p>
<p><img id="193004" src="193004-28.png" alt="" width="275" height="233"></p>
<p><span>After the registration, we can see that for this user, we didn&rsquo;t add the &ldquo;Admin&amp;rdquorole and he has no access to view the Admin Page.</span></p>
<p><img id="193005" src="193005-29.png" alt="" width="559" height="177"></p>
<p>&nbsp;</p>
<p><span>Reference Link:&nbsp;</span><a href="https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?tabs=visual-studio%2Caspnetcore2x">https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?tabs=visual-studio%2Caspnetcore2x</a></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span>ASPNETCoreUserIdentity.zip - 2018/03/20</span> </li></ul>
<h1>More Information</h1>
<p><em>Firstly, create a sample InventoryDB database in your SQL Server. In the appsettings.json file, change the DefaultConnection connection string with your SQL Server Connections. In Startup.cs file, add all the code as we discussed in this article. In
 the next article, we will see in detail how to perform User Role management and customize the User Registration/Login Page in ASP.NET Core 2.0.</em></p>
