/**
 * 
 */
package org.sampleapp.services;

import java.util.HashMap;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.sampleapp.dto.User;
import org.sampleapp.dto.UserPageInfo;
import org.sampleapp.exceptions.SampleAppException;
import org.sampleapp.utils.SampleAppUtilities;



/**
 * This class provides all the read functionalities.
 * @author Microsoft Corp
 *
 */
public class RestAPIUserServices {
	
	/**
	 * A map that would hold the skip Tokens for different pages.
	 */
	public static HashMap<Integer, String> pageMap = null;
	
	/**
	 * This method returns a particular page of users.
	 * @param pageNumber The page number to be returned.
	 * @return A page of users
	 * @throws SampleAppException if the operation is unsuccessful.
	 */
	public static UserPageInfo getUsersPage(int pageNumber) throws SampleAppException{
		
		String response = "";
		
		/**
		 * If the pageMap is not instantiated,
		 * instantiate it.
		 */
		if(pageMap == null){
			pageMap = new HashMap<Integer, String>();
		}
		
		/**
		 * If the request is for the first page, we do not need an skip token,
		 * we just need to use the $top query option.
		 */
		if(pageNumber == 1){
			response = HttpRequestHandler.handleRequest("/users", "$top=" + AppParameter.getUserPerPage());
		}
		
		/**
		 * Again, if the required skip token is found in the page map, retrieve the skiptoken,
		 * and send the appropriate http get request using this token.
		 */
		else if(pageMap.containsKey(new Integer(pageNumber))){			
			String queryOption = String.format("$top=%d&$skiptoken=%s", AppParameter.getUserPerPage(), pageMap.get(new Integer(pageNumber)));
			response = HttpRequestHandler.handleRequest("/users", queryOption);
		}
		/**
		 * Finally, if the token can't be found in the page map, this request can not be 
		 * satisfied. However, this case can only arise if there is a bug in the application.
		 */
		else{
			throw new SampleAppException(AppParameter.internalError, AppParameter.internalErrorMessage, null, null);
		}
				
		/**
		 * Get an array of JSON Objects by parsing the response.
		 */
		JSONArray userArray = JSONDataParser.parseJSonDataCollection(response);
		
		/**
		 * Retrieve the skiptoken for the next page returned with the http response.
		 */
		String skipTokenForNextPage = JSONDataParser.parseSkipTokenForNextPage(response);
		
		/**
		 * Create a new UserPageInfo that would hold all the users and set the pageNumber
		 * with the current pageNumber.
		 */
		UserPageInfo thisPage = new UserPageInfo();	
		thisPage.setPageNumber(pageNumber);
		
		/**
		 * If the skiptoken for the next page is not empty,
		 * that is there is indeed a next page, set the hasNextPage attribute to 
		 * true and put this skiptoken to the pagemap..
		 */
		if(!skipTokenForNextPage.equalsIgnoreCase("")){
			pageMap.put(new Integer(pageNumber + 1), skipTokenForNextPage);
			thisPage.setHasNextPage(true);
		}
		
		/**
		 * Else, just set the hasNextPage to false.
		 */
		else{
			thisPage.setHasNextPage(false);
		}
		
		/**
		 * If it is the first page, then we don't have any previous page.
		 */
		if(pageNumber == 1){
			thisPage.setHasPrevPage(false);
		}
		
		/**
		 * Otherwise we do have a previous page.
		 */
		else{
			thisPage.setHasPrevPage(true);
		}
				
		/**
		 * For all the users in the JSON Array, retrieve the DisplayName, ObjectId and UserPrincipalName and add
		 * them in the UserPageInfo.
		 */
		for(int i = 0; i < userArray.length(); i++){
			try {
				thisPage.addNewUserInfo(userArray.getJSONObject(i).optString("displayName"), 
										userArray.getJSONObject(i).optString("objectId"), 
										userArray.getJSONObject(i).optString("userPrincipalName") );
							
			} catch (JSONException e) {
				throw new SampleAppException(AppParameter.ErrorParsingJSONException, e.getMessage(), e, null);
			}
		}
				
		return thisPage;
		
	}
	
	

	/**
	 * This method gets an particular user identified by its user ID.
	 * @param objectId ObjectId of the user to be retrieved.
	 * @return An user object populated with the relevant attributes.
	 * @throws SampleAppException If an exception occurs during the process.
	 */
	public static User getUser(String objectId) throws SampleAppException{
				
		/**
		 * Create the additional path and also we don't have any query option
		 * for this operation. Invoke the handleRequest method and get the 
		 * response in a String object.		
		 */
		String response = HttpRequestHandler.handleRequest(
				String.format("/users/%s", objectId), 
				null);
		
		/**
		 * Get a JSONObject that would hold the attributes of the user.
		 */		
		JSONObject userObject = JSONDataParser.parseJSonDataSingleObject(response);	
		
		/**
		 * Creates a new user object and get the data copied over from the JSONObject
		 * to this object.
		 */
		User user = new User();
		SampleAppUtilities.copyAttrFromJSONObject(userObject, user);
		
		/**
		 * Get the manager of this user and set them in the user object.
		 */
		JSONObject manager = getManager(userObject.optString("objectId"));
		if(manager != null){
			user.setManager(manager.optString("displayName"), manager.optString("objectId"));
		}
		
		/**
		 * Get the directReport objects of this user and populate them
		 * in the user object.
		 */
		JSONArray directReports = getDirectReports(userObject.optString("objectId"));
		for(int i = 0; i < directReports.length(); i++ ){
			user.addNewDirectReport(directReports.optJSONObject(i).optString("displayName"), directReports.optJSONObject(i).optString("objectId"));
		}
		
		/**
		 * Get the list of all objects of which this user is a member.
		 */
		JSONArray groups = getMembersOf(userObject.optString("objectId"));
		for(int i = 0; i < groups.length(); i++){
			
			/**
			 * If this particular object is of type group,
			 * add it to the user object as a group.
			 */
			if(groups.optJSONObject(i).optString("objectType").equalsIgnoreCase("group")){
				user.addNewGroup(groups.optJSONObject(i).optString("displayName"), groups.optJSONObject(i).optString("objectId"));
			}
			
			/**
			 * If this particular object is of type role,
			 * add it to the user object as a role.
			 */
			else if(groups.optJSONObject(i).optString("objectType").equalsIgnoreCase("role")){
				user.addNewRole(groups.optJSONObject(i).optString("displayName"), groups.optJSONObject(i).optString("objectId"));
			}
		}
		
		return user;
	}

	
	/**
	 * This method returns the list of all objects of which a particular user is a member.
	 * @param objectID ObjectId of the member user.
	 * @return An array of JSON Object containing the list of MemberOf objects.
	 * @throws SampleAppException If the operation can not be carried out successfully.
	 */
	private static JSONArray getMembersOf(String objectID) throws SampleAppException {
		
		/**
		 * Send a particular http get request and receive the request.
		 */
		String response = HttpRequestHandler.handleRequest(
				String.format("/users/%s/memberOf", objectID), 
				null);

		JSONArray groups = null;
		
		try {
			/**
			 * Retrieve the json array and set it to groups.
			 */
		   //	groups = (new JSONObject(response)).getJSONObject("d").getJSONArray("results");
			groups = (new JSONObject(response)).getJSONArray("value");
		} catch (JSONException e) {
			new SampleAppException(
					AppParameter.ErrorParsingJSONException, 
					e.getMessage(), 
					e, null);
		}			
		
		return groups;
	}



	/**
	 * This method would return the list of Direct Reports an particular user identified by
	 * ObjectId has.
	 * @param objectID The ObjectId of the User.
	 * @return The list of Direct Reports.
	 * @throws SampleAppException Throws an exception if the operation can't be performed successfully.
	 */
	private static JSONArray getDirectReports(String objectID) throws SampleAppException {
		
		/**
		 * Send the http request, and get the response.
		 */
		String response = HttpRequestHandler.handleRequest(
				String.format("/users/%s/directReports", objectID), 
				null);
		
		
		JSONArray dReports = null;
		
		try {
			
			/**
			 * Retrieve the json array and set it to dReports.
			 */
			dReports = (new JSONObject(response)).getJSONArray("value");
		} catch (JSONException e) {
			throw new SampleAppException(
					AppParameter.ErrorParsingJSONException, 
					e.getMessage(), 
					e, response);
		}
		
		return dReports;
	}
	
	
	
	/**
	 * This method returns an JSON Object containing the information of a manager of a
	 * particular object identified by its ObjectId.
	 * @param objectID The objectId of the user whose manager is to be returned.
	 * @return The information of the manager in a JSON Object.
	 * @throws SampleAppException If the operation can not be performed successfully.
	 */
	private static JSONObject getManager(String objectID) throws SampleAppException{
		
		JSONObject object = null;
		try {
			/**
			 * Send the http request and get the response.
			 */
			String response = HttpRequestHandler.handleRequest(
					String.format("/users/%s/manager", objectID), 
					null);
			object = new JSONObject(response); 
		} catch (SampleAppException e) {
			/**
			 * If this is a MessageIdResourceNofFound exception, then it simply means
			 * the manager does not exist. So, return null.
			 */
			if(e.getCode().equalsIgnoreCase(AppParameter.MessageIdResourceNotFound)){
				return null;
			}
			
			/**
			 * Else, this is some other exception, therefore can't be ignored.
			 */
			else{
				throw e;
			}
		} catch (JSONException e) {
			/**
			 * If there is an exception parsing JSON data, throw a new sample application.
			 */
			throw new SampleAppException(
					AppParameter.ErrorParsingJSONException, 
					e.getMessage(), 
					e, null);
		}
		return object;

	}


	/**
	 * This method returns the results of a query for users.
	 * @param attributeName The attribute on which the queries are made of.
	 * @param opName The operator name that would be applied to the attribute.
	 * @param searchString The string that would be searched for this attribute.
	 * @return A page of users satisfying this query criteria.
	 * @throws SampleAppException If the operation can not be carried out successfully.
	 */

	public static UserPageInfo queryUsers(
			String attributeName, 
			String opName, 
			String searchString
			) throws SampleAppException {
		
		/**
		 * This object would hold all the user information.
		 */
		UserPageInfo thisPage = new UserPageInfo();
		
		if(attributeName.trim().isEmpty() || opName.trim().isEmpty() || 
				searchString.trim().isEmpty() || (attributeName == null) || 
				(opName == null) || (searchString == null)){
				/**
				 * If any of the arguments are empty or null, throw an exception. In the ideal case,
				 * this case should never happen since this case should be taken care of in the client
				 * side. 	
				 */
				throw new SampleAppException(AppParameter.internalError, AppParameter.internalErrorMessage, null, null);
				}
		
		/**
		 * Build the queryOption.
		 */
		String queryOption = null;
		/**
		 * If this is an account Enabled query.
		 */

		if(attributeName.trim().equalsIgnoreCase("AccountEnabled")){
			queryOption = String.format("$filter=%s %s %s", SampleAppUtilities.lowerCaseFirstLetter(attributeName), opName, searchString);
		}
		else if(opName.trim().equalsIgnoreCase("startswith")){
			queryOption = String.format("$filter=startswith(%s,'%s')", SampleAppUtilities.lowerCaseFirstLetter(attributeName), searchString);
		}
		else{
			/**
			 * If this is an general query.
			 */
			queryOption = String.format("$filter=%s %s '%s'", SampleAppUtilities.lowerCaseFirstLetter(attributeName), opName, searchString);
		}

		/**
		 * Send the query with the built queryOption.
		 */
		String response = HttpRequestHandler.handleRequest("/users", queryOption);
		JSONArray users = JSONDataParser.parseJSonDataCollection(response);
		
		/**
		 * Get the DisplayName, ObjectId, UserPrincipalName from the JSON Array and populate them
		 * in the page object.
		 */
		for(int i = 0; i < users.length(); i++){
			try {
				thisPage.addNewUserInfo(users.getJSONObject(i).optString("displayName"), 
										users.getJSONObject(i).optString("objectId"), 
										users.getJSONObject(i).optString("userPrincipalName") );
							
			} catch (JSONException e) {
				throw new SampleAppException(
						AppParameter.ErrorParsingJSONException,
						e.getMessage(),
						e, null);
			}
		}
		return thisPage;
	}



	/**
	 * This method returns the list of company administrators.
	 * @return A list of company administrators.
	 * @throws SampleAppException If the operation can not be done successfully.
	 */
	public static UserPageInfo queryCompanyAdmins() throws SampleAppException {
		String companyAdminRoleId = getCompanyAdminRoleId();
		/**
		 * If no such Administrator Role exists, handle the error.
		 */
		if(companyAdminRoleId == null){
			throw new SampleAppException(AppParameter.NoCompanyAdminRole, AppParameter.NoCompanyAdminRoleMessage, null, null);
		}
		
		/**
		 * Get the list of users that belong to the role identified by the 
		 * companyAdminRoleId.
		 */
		UserPageInfo thisPage = RestAPIGroupServices.getRoleMembers(companyAdminRoleId);
		
		return thisPage;
	}



	/**
	 * This method returns  the Object Id of the "Company Administrator" Role. 
	 * @return The Object Id of the company Administrator Role.
	 * @throws SampleAppException
	 */
	public static String getCompanyAdminRoleId() throws SampleAppException {
		String response = HttpRequestHandler.handleRequest("/roles", null);
		JSONArray allRoles = JSONDataParser.parseJSonDataCollection(response);
		for(int i = 0; i < allRoles.length(); i++){
			if(allRoles.optJSONObject(i).optString("displayName").equalsIgnoreCase("Company Administrator")){
				return allRoles.optJSONObject(i).optString("objectId");
			}
		}
		return null;
	}
	
}
