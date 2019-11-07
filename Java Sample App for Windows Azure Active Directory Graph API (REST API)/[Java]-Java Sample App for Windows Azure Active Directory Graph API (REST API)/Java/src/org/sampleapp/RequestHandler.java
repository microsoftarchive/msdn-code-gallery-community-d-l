package org.sampleapp;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.sampleapp.dto.Group;
import org.sampleapp.dto.Role;
import org.sampleapp.dto.User;
import org.sampleapp.dto.UserPageInfo;
import org.sampleapp.exceptions.SampleAppException;
import org.sampleapp.services.AppParameter;
import org.sampleapp.services.RestAPIGroupServices;
import org.sampleapp.services.RestAPIUserServices;
import org.sampleapp.services.RestAPIWriteServices;
import org.sampleapp.tokenhandler.TokenGenerator;
import org.sampleapp.utils.SampleAppUtilities;

/**
 * This servlet works as the controller of this web application. All the user
 * http requests are caught by this servlet and dispatched to the appropriate
 * business logic. Again, this servlet redirects the users to the appropriate
 * views, i.e., jsp pages based on the user request.
 * 
 * @author Microsoft Corp
 */
public class RequestHandler extends HttpServlet {
	private static final long serialVersionUID = 1L;

	/**
	 * Constructor of the RequestHandler Class. Does nothing.
	 * 
	 * @see HttpServlet#HttpServlet()
	 */
	public RequestHandler() {
		super();
	}

	/**
	 * This method initializes all the application specific parameters from the
	 * xml configuration file to the appropriate variables in the
	 * {@link org.sampleapp.services.AppParameter AppParameter} class. This
	 * method also generates an access token and initializes the acessToken
	 * parameter in the AppParameter class.
	 */
	public void init() {

		/** Load the initial parameters from the xml configuration file to the
		 *  appropriate fields in the AppParameter class.
		 */  
		AppParameter.setDataContractVersion(this.getServletConfig()
				.getInitParameter("DataContractVersion"));
		AppParameter.setAcsPrincipalId(this.getServletConfig()
				.getInitParameter("AcsPrincipalId"));
		AppParameter.setAppPrincipalId(this.getServletConfig()
				.getInitParameter("AppPrincipalId"));
		AppParameter.setProtectedResourceHostName(this.getServletConfig()
				.getInitParameter("ProtectedResourceHostName"));
		AppParameter.setRestServiceHost(this.getServletConfig()
				.getInitParameter("RestServiceHost"));
		AppParameter.setSymmetricKey(this.getServletConfig().getInitParameter(
				"SymmetricKey"));
		AppParameter.setTenantDomainName(this.getServletConfig()
				.getInitParameter("TenantDomainName"));
		AppParameter.setTenantContextId(this.getServletConfig()
				.getInitParameter("TenantContextId"));
		AppParameter.setEvoStsUrl(this.getServletConfig().getInitParameter(
				"EvoStsUrl"));
		AppParameter.setProtectedResourcePrincipalId(this
				.getInitParameter("ProtectedResourcePrincipalId"));

		// If there is no predefined Access Token, generate an access token and
		// set it to the accessToken field in AppParameter.
		if (AppParameter.getAccessToken() == null) {
			try {
				AppParameter.setAccessToken(TokenGenerator.generateEvoStsToken(
				AppParameter.getTenantContextId(),
				AppParameter.getAppPrincipalId(),
				AppParameter.getSymmetricKey(),
				AppParameter.getProtectedResourceHostName()));

			} catch (SampleAppException e) {
				e.getCause().printStackTrace();
				System.out.println("Can not generate Access Token");
				System.exit(1);
			}
		}
		
		try {
			SampleAppUtilities.initApp();
		} catch (SampleAppException e) {
			e.printStackTrace();
		}

	}

	/**
	 * This is the overridden version of the doGet Method. This method catches
	 * all the get http requests and dispatches them to the appropriate
	 * background services depending on the request. Finally, this method
	 * redirects the users to the appropriate view, i.e., the JSP page based on
	 * the user request.
	 * 
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
	 *      response)
	 * @param request
	 *            The Http Request object
	 * @param response
	 *            The Http Response object
	 * @exception ServletException
	 *                Throws the ServletException
	 * @exception IOException
	 *                Throws the IOException
	 */
	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		response.setContentType("text/html");

		int retryRemaining = AppParameter.MAX_RETRY_ATTEMPTS;

		/**
		 * Receive the operation from the Request Object.
		 */
		String reqReceived = request.getParameter("op");
		
		while (retryRemaining > 0) {
			try {
				switch (reqReceived) {

				/**
				 * If allusers request is received. Invoke the getUserPage
				 * method with the parameter pageNumber. Put the returned page
				 * into the session object and redirect user to the showUserPage
				 * view.
				 */
				case "allusers":
					UserPageInfo userPageInfo = null;
					try {
						userPageInfo = RestAPIUserServices.getUsersPage(Integer.parseInt(request.getParameter("pageNumber")));
					} catch (NumberFormatException e) {
						throw new SampleAppException("Invalid Page Number", "The requested Page Number is Invalid.", null, null);
					}

					request.getSession().setAttribute("userPage", userPageInfo);
					response.sendRedirect("showUserPage.jsp");
					return;

					/**
					 * getuser is the 'get a single user' request. Comes with
					 * the parameter ObjectId: the ObjectId of the user
					 * requested.
					 */
				case "getuser":
					User user = RestAPIUserServices.getUser(request
							.getParameter("ObjectId"));
					request.getSession().setAttribute("userDetails", user);
					response.sendRedirect("showSingleUser.jsp");
					return;

					/**
					 * getgroup is the 'get a single group' request. Comes with
					 * the parameter ObjectId: the ObjectId of the group
					 * requested.
					 */

				case "getgroup":
					Group group = RestAPIGroupServices.getGroup(request
							.getParameter("ObjectId"));
					request.getSession().setAttribute("groupDetails", group);
					response.sendRedirect("showSingleGroup.jsp");
					return;

					/**
					 * getGroupMembers is the 'get all the members of a group'
					 * request. Comes with the parameter groupId: the ObjectId
					 * of the group whose members are requested.
					 */
				case "getGroupMembers":
					UserPageInfo groupPageInfo = RestAPIGroupServices
							.getGroupMembers(request.getParameter("groupId"));
					request.getSession().setAttribute("groupMemberPage",
							groupPageInfo);
					response.sendRedirect("showGroupMembers.jsp");
					return;

					/**
					 * getRoleMembers is the 'get all the members of a Role'
					 * request. Comes with the parameter roleId: the ObjctId of
					 * the role whose members are requested.
					 */
				case "getRoleMembers":
					UserPageInfo rolePageInfo = RestAPIGroupServices
							.getRoleMembers(
									request.getParameter("roleId"));
					request.getSession().setAttribute("groupMemberPage",
							rolePageInfo);
					response.sendRedirect("showGroupMembers.jsp");
					return;

					/**
					 * getrole is the 'get a single role' request. Comes with
					 * the parameter roleId: the ObjectId of the role requested.
					 */
				case "getrole":
					Role role = RestAPIGroupServices.getRole(
							request.getParameter("roleId"));
					request.getSession().setAttribute("roleDetails", role);
					response.sendRedirect("showSingleRole.jsp");
					return;

					/**
					 * queryUser is the 'Query user objects with parameters'.
					 * Comes with the parameters attributName, searchString and
					 * operator name. Here, an user x is part of the result set
					 * if 'x.attributeName operatorName searchString' is
					 * satisfied. For example, if attributeName = DisplayName,
					 * operator=eq and searchString="John Doe", then an user x
					 * would be in the result set if and only if the condition
					 * "x.DisplayName eq 'John Doe'" holds.
					 */
				case "queryUser":
					UserPageInfo queryUsers = RestAPIUserServices.queryUsers(
							request.getParameter("attributeName"),
							request.getParameter("opName"),
							request.getParameter("searchString"));

					/**
					 * If the result set is empty, just give the user a message
					 * and return.
					 */

					if (queryUsers.getUserNumber() <= 0) {
						request.getSession()
								.setAttribute("message",
										"Sorry, your query did not return any results.<br> Please try again.<br>");
						response.sendRedirect("showMessage.jsp");
						return;
					}

					request.getSession().setAttribute("userPage", queryUsers);
					response.sendRedirect("showAllUsers.jsp");
					return;

					/**
					 * signInBlockedUser is the 'request for all the blocked
					 * users'. Here, an user is blocked if and only if the
					 * AccountEnabled attribute of that user is set to false.
					 */
				case "signInBlockedUser":
					UserPageInfo signInBlockedUsers = RestAPIUserServices
							.queryUsers("accountEnabled", "eq", "false");
					request.getSession().setAttribute("userPage",
							signInBlockedUsers);
					response.sendRedirect("showAllUsers.jsp");
					return;

					/**
					 * This is the request for all the Company Administrators.
					 * An user is an company Administrator if he is a member of
					 * the Role 'Company Administrator'.
					 */
				case "companyAdmin":
					UserPageInfo companyAdmins = RestAPIUserServices
							.queryCompanyAdmins();
					request.getSession().setAttribute("groupMemberPage",
							companyAdmins);
					response.sendRedirect("showGroupMembers.jsp");
					return;

					/**
					 * Just print a short About message to the user.
					 */
				case "about":
					request.getSession().setAttribute("message",
							AppParameter.ABOUT_MESSAGE);
					response.sendRedirect("showMessage.jsp");
					return;
					
				/**
				 * The request for creating user.	
				 */
				case "createUser":
					response.sendRedirect("createUser.jsp");
					return;
					
					/**
					 * The request for creating user.	
					 */
				case "deleteUser":
					request.getSession().setAttribute("message",RestAPIWriteServices.deleteUser(request.getParameter("ObjectId")));
					request.getSession().setAttribute("message", "User Successfully Deleted.");
					response.sendRedirect("showSuccessWriteMessage.jsp");					
					return;
					
					
					/**
					 * The request is not familiar. Just show an Error Message
					 * to the user.
					 */
				default:
					request.getSession().setAttribute("message",
							"Error: Unknown Request Encountered!");
					response.sendRedirect("showMessage.jsp");
					return;
				}
			} catch (SampleAppException e) {
				
			
				if ((e.getResponse()).contains("Authorization_RequestDenied")){
					{
						request.getSession().setAttribute("message",
								"Error:" + e.getCode() + "! " + e.getMessage() + "\n" + e.getResponse() );
						response.sendRedirect("showMessage.jsp");
						retryRemaining = 0;
						return;
					}
				}
				
				/**
				 * We take different actions based on different type of
				 * exceptions.
				 */
				switch (e.getCode()) {

				/**
				 * For the following long list of exceptions, there is nothing
				 * too much we can do. So, we do not prefer to retry. We just
				 * want to display an error message to the user and exit.
				 */
				case AppParameter.MessageIdAuthorizationIdentityDisabled:
				case AppParameter.MessageIdAuthorizationIdentityNotFound:
				case AppParameter.MessageIdAuthorizationRequestDenied:
				case AppParameter.MessageIdBadRequest:
				case AppParameter.MessageIdBindingRedirectionInternalServerError:
				case AppParameter.MessageIdContractVersionHeaderMissing:
				case AppParameter.MessageIdHeaderNotSupported:
				case AppParameter.MessageIdInternalServerError:
				case AppParameter.MessageIdInvalidDataContractVersion:
				case AppParameter.MessageIdInvalidReplicaSessionKey:
				case AppParameter.MessageIdInvalidRequestUrl:
				case AppParameter.MessageIdMediaTypeNotSupported:
				case AppParameter.MessageIdMultipleObjectsWithSameKeyValue:
				case AppParameter.MessageIdObjectNotFound:
				case AppParameter.MessageIdResourceNotFound:
				case AppParameter.MessageIdThrottledPermanently:
				case AppParameter.MessageIdUnknown:
				case AppParameter.MessageIdUnsupportedQuery:
				case AppParameter.MessageIdUnsupportedToken:
					retryRemaining = 0;
					break;

				/**
				 * This means the replica we are trying to go to is unavailable,
				 * retry will possibly go to another replica and work.
				 */
				case AppParameter.MessageIdReplicaUnavailable:
					retryRemaining--;
					break;

				/**
				 * This means that the tenant is throttled temporarily, the
				 * error message will display back off time, the user of this
				 * application should wait that time and retry.
				 */
				case AppParameter.MessageIdThrottledTemporarily:
					retryRemaining = 0;
					break;

				case AppParameter.MessageIdUnauthorized:
				case AppParameter.MessageIdExpired:
					try {
				
						/**
						 * Try to generate a new Access Token and try again.
						 */
						
						AppParameter.setAccessToken(TokenGenerator.generateEvoStsToken(
								AppParameter.getTenantContextId(),
								AppParameter.getAppPrincipalId(),
								AppParameter.getSymmetricKey(),
								AppParameter.getProtectedResourceHostName()));
												
						retryRemaining--;
						break;
					} catch (SampleAppException e1) {
						request.getSession().setAttribute("message",
										e1.getCode() + " " + e1.getCause().getMessage());
						response.sendRedirect("showMessage.jsp");
						return;
					}

				default:
					retryRemaining--;
					break;

				}
				/**
				 * If there is no retryRemaining left, Just return an error
				 * message to the user and return from the servlet.
				 */
				if (retryRemaining == 0) {
					request.getSession().setAttribute("message",
							"Error:" + e.getCode() + "! " + e.getMessage());
					response.sendRedirect("showMessage.jsp");
					return;
				}
			}

		}
	}

	/**
	 * This is the overridden doPost method. This method would receive all the create objects
	 * requests such as create user, create group etc. Upon receiving a request, this method
	 * would dispatch the request to the appropriate business logic and finally redirect the user
	 * to the appropriate view page.
	 * @param request This is the http request object.
	 * @param response This is the http response object. 
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponseresponse)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response){
		
		response.setContentType("text/html");
		
		String sessionKey = "";
		int retryRemaining = AppParameter.MAX_RETRY_ATTEMPTS;
		/**
		 * Retrieve the operation requested.
		 */
		String op = request.getParameter("op");
		
		while(retryRemaining-- > 0){
			try{
				switch(op){
					/**
					 * If createUser request is received.
					 */
				case "createUser":
					/**
					 * If the request is successfully carried out,
					 * send a success message to the user.
					 */
					String result = null;
					result = RestAPIWriteServices.createUser(request);
					if (result.contains("odata.error")){
						request.getSession().setAttribute("message","error processing request " + result);
						response.sendRedirect("showSuccessWriteMessage.jsp");
						return;
					}
					request.getSession().setAttribute("message", String.format("User %s Successfully Created.", request.getParameter("DisplayName")));
					response.sendRedirect("showSuccessWriteMessage.jsp");	
					return;

					/**
					 * If the request is update User.
					 */
				case "updateUser":
					result = null;
					result = RestAPIWriteServices.updateUser(request);
					if (result.contains("odata.error")){
						request.getSession().setAttribute("message","error processing request " + result);
						response.sendRedirect("showSuccessWriteMessage.jsp");
						return;
					}
					request.getSession().setAttribute("message", String.format("User %s Successfully Updated.", request.getParameter("DisplayName")));
					response.sendRedirect("showSuccessWriteMessage.jsp");
					return;
					
					/**
					 * The request is for updating (add/delete) a group/role etc.
					 */
				case "updateLink":
					String userId = request.getParameter("userId");
					String objectName = request.getParameter("objectName");
					String opName = request.getParameter("opName");
					String groupId = request.getParameter("instanceName");
					
					result = RestAPIWriteServices.updateLink(userId, objectName, opName, groupId);
					if (result.contains("odata.error")){
						request.getSession().setAttribute("message","error processing request " + result);
						response.sendRedirect("showSuccessWriteMessage.jsp");
						return;
					}			
					request.getSession().setAttribute( "message", String.format("%s was successfully updated.", objectName) );
					response.sendRedirect("showSuccessWriteMessage.jsp");
					return;				
				}	
			} catch (IOException | SampleAppException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}	
	}
}
