package org.sampleapp.services;

import java.util.ArrayList;

import org.sampleapp.dto.GroupInfo;

/**
 * The class AppParameter holds the important parameters for this application.
 * The parameters are read in from the web.xml configuration file in the
 * {@link org.sampleapp.RequestHandler#init() init} method. These parameters 
 * are used throughout the application.
 * @author Microsoft Corp
 */

public class AppParameter {
	/**
	 * The number of users shown per page.
	 */
	private static int userPerPage = 9;
	
	/**
	 * Access token received from the ACS.
	 */

	private static String accessToken = null;

	
	/**
	 * Current Data Contract Version for the REST Service. Read from the web.xml file. 
	 */
	private static String dataContractVersion = null;
	
	/**
	 * Verified domain name for the tenant, read from the web.xml file.
	 */
	private static String tenantDomainName = null;
	
	/**
	 * Protected resource is REST API Service in this case,
	 * that is the host name for this registered with ACS.
	 * Read from the web.xml file.
	 */
	private static String protectedResourceHostName = null;
	
	/**
	 * ACS Principal ID, used to get JWT token from ACS, read from the web.xml file.
	 */
	private static String protectedResourcePrincipalId = null;
	
	/**
	 * This is the host for REST Service, read from the web.xml file.
	 */
	private static String restServiceHost = null;
	
	/**
	 * The Service Principal Id for this application service principal.
	 * Read from the web.xml file.
	 */
	private static String appPrincipalId = null;
	
	/**
	 * The authentication URL for ACS, read from the web.xml file.
	 */
	private static String acsPrincipalId = null;
	
	/**
	 * The symmetric key that would be used to create the JWT Token.
	 */
	private static String symmetricKey = null;
	
	/**
	 * Tenant Context Id, read from the web.xml file. 
	 */
	private static String tenantContextId = null;
	
	/**
	 * The url of the ACS authentication service.
	 */
	private static String evoStsUrl = null;
	
	/**
	 * The protocol that would be used to connect to the WAAD Rest service.
	 */
	public static final String PROTOCOL_NAME = "https";
	
	/**
	 * This array list would hold the list of verified domain names
	 * for this tenant.
	 */
	private static ArrayList<String> verifiedDomainNames;
	
	/**
	 * This array list would hold the list of Groups 
	 * for this tenant.
	 */
	private static ArrayList<GroupInfo> allGroups;
	

	/**
	 * This arraylist would hold the list of Groups 
	 * for this tenant.
	 */
	private static ArrayList<GroupInfo> allRoles;
	
		
	/**
	 * This is the 'About' Message that would be displayed if the user clicks the 'About' Button.
	 */
	public static final String ABOUT_MESSAGE = "This is a sample Java application showing how to access the " +
				"Windows Azure Active Directory Graph API (api-version=2013-11-08)," +
				" which is a new RESTful interface allowing customers to build applications to access their Windows Azure AD tenant’s directory data";

	/**
	 * The authorization header name that would be added in the http request header.
	 */
	public static final String AUTHORIZATION_HEADER = "Authorization";
	
	
	/**
	 * The Data Contract header that would be added in the http request header.
	 */
	public static final String DATACONTRACT_HEADER = "x-ms-dirapi-data-contract-version";
	
	
	/**
	 * The Accept header field that would be added in the http request header.
	 */
	public static final String ACCEPT_HEADER = "Accept";
	
	/**
	 * The Accept Header field value that would be added in the http request header.
	 */
	public static final String ACCEPT_HEADER_VALUE = "application/json";
	
	/**
	 * Maximum retry attempt for a retryable exception from REST Service.
	 */
	public static final int MAX_RETRY_ATTEMPTS = 3;
	
	
    /**
     *  Message Id for unauthorized request.
     */
    public static final String MessageIdUnauthorized = "Authentication_Unauthorized";

    /**
     * Message id for expired tokens.
     */
    public static final String MessageIdExpired = "Authentication_ExpiredToken";

    /**
     * Message id for unknown authentication failures.
     */
    public static final String MessageIdUnknown = "Authentication_Unknown";

    /**
     * Message id for unsupported token type.
     */
    public static final String MessageIdUnsupportedToken = "Authentication_UnsupportedTokenType";

    /**
     * Message id for the data contract missing error message
     */
    public static final String MessageIdContractVersionHeaderMissing = "Headers_DataContractVersionMissing";

    /**
     * Message id for an invalid data contract version.
     */
    public static final String MessageIdInvalidDataContractVersion = "Headers_InvalidDataContractVersion";

    /**
     * Message id for the data contract missing error message
     */
    public static final String MessageIdHeaderNotSupported = "Headers_HeaderNotSupported";

    /**
     * When the company object could not be read.
     */
    public static final String MessageIdObjectNotFound = "Directory_ObjectNotFound";

    /**
     * The most generic message id, when the fault is due to a server error.
     */
    public static final String MessageIdInternalServerError = "Service_InternalServerError";

    /**
     * The replica session key provided in the request is invalid.
     */
    public static final String MessageIdInvalidReplicaSessionKey = "Request_InvalidReplicaSessionKey";

    /**
     * The replica session key provided in the request is invalid.
     */
    public static final String MessageIdBadRequest = "Request_BadRequest";

    /**
     * The replica session key provided in the request is unavailable.
     */
    public static final String MessageIdReplicaUnavailable = "Directory_ReplicaUnavailable";

    /**
     * User's data is not in the current datacenter.
     */
    public static final String MessageIdBindingRedirection = "Directory_BindingRedirection";

    /**
     * Calling principal's information could not be read from the directory.
     */
    public static final String MessageIdAuthorizationIdentityNotFound = "Authorization_IdentityNotFound";

    /**
     * Calling principal is disabled.
     */
    public static final String MessageIdAuthorizationIdentityDisabled = "Authorization_IdentityDisabled";

    /**
     * Request is denied due to insufficient privileges.
     */
    public static final String MessageIdAuthorizationRequestDenied = "Authorization_RequestDenied";

    /**
     * Encountered an internal error when trying to populate the nearest datacenter endpoints.
     */
    public static final String MessageIdBindingRedirectionInternalServerError
        = "Directory_BindingRedirectionInternalServerError";

    /**
     * The request is throttled temporarily
     */
    public static final String MessageIdThrottledTemporarily = "Request_ThrottledTemporarily";

    /**
     * The request is throttled permanently
     */
    public static final String MessageIdThrottledPermanently = "Request_ThrottledPermanently";

    /**
     * The request query was rejected because it was either invalid or unsupported.
     */
    public static final String MessageIdUnsupportedQuery = "Request_UnsupportedQuery";

    /**
     * Request is denied due to insufficient privileges.
     */
    public static final String MessageIdInvalidRequestUrl = "Request_InvalidRequestUrl";

    /**
     * Request failed because a target object could not be found.
     */
    public static final String MessageIdResourceNotFound = "Request_ResourceNotFound";

    /**
     * Request failed due to the presence of objects with duplicate values in key-valued properties.
     */
    public static final String MessageIdMultipleObjectsWithSameKeyValue = "Request_MultipleObjectsWithSameKeyValue";

    /**
     * The requested media type is not supported - the $format parameter value is not supported.
     */
    public static final String MessageIdMediaTypeNotSupported = "Request_MediaTypeNotSupported";

    /**
     * An error occured during connecting to the REST Service and the application could not get the error code..
     */
    public static final String ErrorCodeNotReceived = "Error Code Could Not Be Received!";
    
    /**
     * The Error Message that would be shown to the User if ErrorCodeNotReceived error is encountered.
     */
    public static final String ErrorCodeNotReceivedMessage = "Sorry! An Error Occured while connecting to the server." +
    		"The Client could not acquire an Error Message.";
	
    /**
     * A valid URI could not be built from the request received.
     */
    public static final String UriSyntaxException = "Uri_Build_Error";
    
    /**
     * The Error Message that would be shown to the User if UriSyntaxException error is encountered.
     */
    public static final String UriSyntaxExceptionMessage = "Sorry! An Error Occured while connecting to the server." +
    		"The Client could not acquire an Error Message.";
	
    /**
     * The http request was not successful.
     */
    public static final String ErrorConnectingRestService = "Error_Connecting_Rest_Service";
	
    /**
     * The Error Message that would be shown to the User if ErrorConnectingRestService error is encountered.
     */
    public static final String ErrorConnectingRestServiceMessage = "Sorry! Your request couldn't be successfully fulfilled. The server connection was not successful"; 

    /**
     * Error occured during generating access tokens.
     */
    public static final String ErrorGeneratingToken = "Could Not Generate Access Token";
	
    /**
     * The Error Message that would be shown to the User if ErrorConnectingRestService error is encountered.
     */
    public static final String ErrorGeneratingTokenMessage = "Sorry! Error Generation was not successful. Please try again."; 

    /**
     * Error occured during generating xml doc.
     */
    public static final String ErrorCreatingXML = "Could Not Generate Access Token";
    
    public static final String ErrorCreatingJSON = "Could Not Generate JSON Object";
    
    public static final String ErrorParsingJSONException = "Error! Could not parse json data.";
	
    /**
     * XML Namespace for entry
     */
    
    public static final String xmlNameSpaceforEntry = "http://www.w3.org/2005/Atom";
    
    /**
     * XML Namespace for the prefix m
     */
    
    public static final String xmlNameSpaceforM = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";
    
    
    /**
     * XML Namespace for the prefix m
     */
    public static final String xmlNameSpaceforD = "http://schemas.microsoft.com/ado/2007/08/dataservices";

    public static final String contentTypeXML = "application/xml";
    
    /**
     * This is the error code if the program meets some unexpected error.
     */
    public static final String internalError = "Internal Error!";
    
    /**
     * The error message to be shown if such error occurs.
     */
    public static final String internalErrorMessage = "Sorry, an unexpected error occured.";
    
    
    /**
     * This is the error code if there is no company administrator role found.
     */
    public static final String NoCompanyAdminRole = "No Company Admin Role!";
    
    /**
     * The error message to be shown if such error occurs.
     */
    public static final String NoCompanyAdminRoleMessage = "Sorry, No Company Administrator Role was Found.";


    
    /**
     * This method returns the number of groups.
     * @return Number of groups.
     */
    public static int getGroupNumber(){
    	return allGroups.size();
    }
    
    /**
     * This method would initialize and empty all the groups.
     */
    public static void clearGroups(){
    	if(allGroups == null){
    		allGroups = new ArrayList<GroupInfo>();
    	}
    	allGroups.clear();
    }
    
    /**
     * This method would get the group displayName at position index.
     * @param index The position of the group.
     */
    public static String getGroupDisplayName(int index){
    	return allGroups.get(index).getDisplayName();
    }
    
    /**
     * This method would get the group Object Id at position index.
     * @param index The position of the group.
     */
    public static String getGroupObjectId(int index){
    	return allGroups.get(index).getObjectId();
    }
    
    /**
     * This method adds a new group to the list.
     * @param displayName Display Name of the group to be added.
     * @param objectId Object Id of the group to be added.
     */
    public static void addNewGroup(String displayName, String objectId){
    	allGroups.add(new GroupInfo(displayName, objectId));
    }
    

    /**
     * This method returns the number of Roles.
     * @return Number of Roles.
     */
    public static int getRoleNumber(){
    	return allRoles.size();
    }
    
    /**
     * This method would initialize and empty all the Roles.
     */
    public static void clearRoles(){
    	if(allRoles == null){
    		allRoles = new ArrayList<GroupInfo>();
    	}
    	allRoles.clear();
    }
    
    /**
     * This method would get the Role displayName at position index.
     * @param index The position of the Role.
     */
    public static String getRoleDisplayName(int index){
    	return allRoles.get(index).getDisplayName();
    }
    
    /**
     * This method would get the Role Object Id at position index.
     * @param index The position of the Role.
     */
    public static String getRoleObjectId(int index){
    	return allRoles.get(index).getObjectId();
    }
    
    /**
     * This method adds a new role to the list.
     * @param displayName Display Name of the role to be added.
     * @param objectId Object Id of the role to be added.
     */
    public static void addNewRole(String displayName, String objectId){
    	allRoles.add(new GroupInfo(displayName, objectId));
    }
  
    
    
    /**
     * This method returns the number of verified domain number.
     * @return
     */
    public static int getVerifiedDomainNumber(){
    	if(verifiedDomainNames == null){
    		verifiedDomainNames = new ArrayList<String>();
    	}
    	return verifiedDomainNames.size();
    }
    
    /**
     * Add a new domain name to the list.
     * @param domainName The new domainName to be added.
     */
    public static void addNewVerifiedDomainName(String domainName){
    	if(verifiedDomainNames == null){
    		verifiedDomainNames = new ArrayList<String>();
    	}
    	verifiedDomainNames.add(domainName);
    }
    
    /**
     * Returns the domain name at the position index.
     * @param index The position of the domain name.
     * @return The domain name to be returned.
     */
    public static String getVerifiedDomainName(int index){
    	return verifiedDomainNames.get(index);
    }
    
    
    /**
	 * @return the userPerPage
	 */
	public static int getUserPerPage() {
		return userPerPage;
	}
	
	/**
	 * @param userPerPage the userPerPage to set
	 */
	public static void setUserPerPage(int userPerPage) {
		AppParameter.userPerPage = userPerPage;
	}
	
	/**
	 * @return the accessToken
	 */
	public static String getAccessToken() {
		return accessToken;
	}
	
	/**
	 * @param accessToken the accessToken to set
	 */
	public static void setAccessToken(String accessToken) {
		AppParameter.accessToken = accessToken;
	}
	
	/**
	 * @return the dataContractVersion
	 */
	
	public static String getDataContractVersion() {
		return dataContractVersion;
	}
	
	/**
	 * @param dataContractVersion the dataContractVersion to set
	 */
	public static void setDataContractVersion(String dataContractVersion) {
		AppParameter.dataContractVersion = dataContractVersion;
	}
	
	/**
	 * @return the tenantDomainName
	 */
	public static String getTenantDomainName() {
		return tenantDomainName;
	}
	
	/**
	 * @param tenantDomainName the tenantDomainName to set
	 */
	public static void setTenantDomainName(String tenantDomainName) {
		AppParameter.tenantDomainName = tenantDomainName;
	}
	
	/**
	 * @return the restServiceHost
	 */
	public static String getRestServiceHost() {
		return restServiceHost;
	}
	
	/**
	 * @param restServiceHost the restServiceHost to set
	 */
	public static void setRestServiceHost(String restServiceHost) {
		AppParameter.restServiceHost = restServiceHost;
	}
	
	/**
	 * @return the protectedResourceHostName
	 */
	public static String getProtectedResourceHostName() {
		return protectedResourceHostName;
	}
	
	/**
	 * @param protectedResourceHostName the protectedResourceHostName to set
	 */
	public static void setProtectedResourceHostName(
			String protectedResourceHostName) {
		AppParameter.protectedResourceHostName = protectedResourceHostName;
	}
	
	/**
	 * @return the appPrincipalId
	 */
	public static String getAppPrincipalId() {
		return appPrincipalId;
	}
	
	/**
	 * @param appPrincipalId the appPrincipalId to set
	 */
	public static void setAppPrincipalId(String appPrincipalId) {
		AppParameter.appPrincipalId = appPrincipalId;
	}
	
	/**
	 * @return the acsPrincipalId
	 */
	public static String getAcsPrincipalId() {
		return acsPrincipalId;
	}
	
	/**
	 * @param acsPrincipalId the acsPrincipalId to set
	 */
	public static void setAcsPrincipalId(String acsPrincipalId) {
		AppParameter.acsPrincipalId = acsPrincipalId;
	}
	
	/**
	 * @return the symmetricKey
	 */
	public static String getSymmetricKey() {
		return symmetricKey;
	}
	
	/**
	 * @param symmetricKey the symmetricKey to set
	 */
	public static void setSymmetricKey(String symmetricKey) {
		AppParameter.symmetricKey = symmetricKey;
	}
	
	/**
	 * @return the tenantContextId
	 */
	public static String getTenantContextId() {
		return tenantContextId;
	}
	
	/**
	 * @param tenantContextId the tenantContextId to set
	 */
	public static void setTenantContextId(String tenantContextId) {
		AppParameter.tenantContextId = tenantContextId;
	}
	
	/**
	 * @return the stsUrl
	 */
	public static String getEvoStsUrl() {
		return evoStsUrl;
	}
	
	/**
	 * @param the evoStsUrl
	 */
	public static void setEvoStsUrl(String evoStsUrl) {
		AppParameter.evoStsUrl = evoStsUrl;
	}
	
	
	/**
	 * @return the protectedResourcePrincipalId
	 */
	public static String getProtectedResourcePrincipalId() {
		return protectedResourcePrincipalId;
	}
	
	/**
	 * @param protectedResourcePrincipalId the protectedResourcePrincipalId to set
	 */
	public static void setProtectedResourcePrincipalId(
			String protectedResourcePrincipalId) {
		AppParameter.protectedResourcePrincipalId = protectedResourcePrincipalId;
	}
	
	
}
