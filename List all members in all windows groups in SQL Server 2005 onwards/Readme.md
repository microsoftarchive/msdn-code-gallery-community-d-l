# List all members in all windows groups in SQL Server 2005 onwards
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- SQL
- SQL Server
- SQL Server 2008
## Topics
- Security
## Updated
- 12/04/2014
## Description

<p>this is new script please use this script.</p>
<p>&nbsp;</p>
<p>This will help to get the permissions in following combinations</p>
<p>1)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; per login per database</p>
<p>2)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; per login all databases (multiple databases)</p>
<p>3)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; all logins per database</p>
<p>4)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; all logins and all databases</p>
<p>&nbsp;</p>
<p><a id="130774" href="/List-all-members-in-all-c3f8224f/file/130774/1/Login_without_public_with_guest_permissions_v82_20141204.sql">Login_without_public_with_guest_permissions_v82_20141204.sql</a></p>
<h1>Introduction</h1>
<p><em>This script to list all members in group in sql server instance. this works from sql server 2005 onwards.</em></p>
<p>&nbsp;</p>
<p><em>xp_logininfo 'doamin\domain groupname','members' list members of all users under this group.</em></p>
<p><em>xp_logininfo 'domain\doamin user','all' lists all groups this user member of.</em></p>
<p>&nbsp;</p>
<p><em>The login run this script requires membership in the <strong>sysadmin</strong> fixed server role.</em></p>
<p><em>Grant execute xp_logininfo to <strong>public</strong> fixed database role in the
<strong>master</strong> database.<br>
</em></p>
<p>&nbsp;</p>
<p>reference:<a href="http://technet.microsoft.com/en-us/library/ms190369.aspx">http://technet.microsoft.com/en-us/library/ms190369.aspx</a></p>
<p>If <span class="parameter">account_name </span>is specified, <strong>xp_logininfo</strong> reports the highest privilege level of the specified Windows user or group. If a Windows user has access as both a system administrator and as a domain user, it
 will be reported as a system administrator. If the user is a member of multiple Windows groups of equal privilege level, only the group that was first granted access to SQL Server is reported.</p>
<p>If <span class="parameter">account_name</span> is a valid Windows user or group that is not associated with a SQL Server login, an empty result set is returned. If
<span class="parameter">account_name</span> cannot be identified as a valid Windows user or group, an error message is returned.</p>
<p>If <span class="parameter">account_name</span> and <strong>all</strong> are specified, all permission paths for the Windows user or group are returned. If
<span class="parameter">account_name </span>is a member of multiple groups, all of which have been granted access to SQL Server, multiple rows are returned. The
<strong>admin</strong> privilege rows are returned before the <strong>user</strong> privilege rows, and within a privilege level rows are returned in the order in which the corresponding SQL Server logins were created.</p>
<p>If <span class="parameter">account_name</span> and <strong>members</strong> are specified, a list of the next-level members of the group is returned. If
<span class="parameter">account_name</span> is a local group, the listing can include local users, domain users, and groups. If
<span class="parameter">account_name</span> is a domain account, the list is made up of domain users. SQL Server must connect to the domain controller to retrieve group membership information. If the server cannot contact the domain controller, no information
 will be returned.</p>
<p><span><span class="input">xp_logininfo</span> </span>only returns information from Active Director global groups, not universal groups.</p>
<p><span style="font-size:20px; font-weight:bold">&nbsp;</span></p>
