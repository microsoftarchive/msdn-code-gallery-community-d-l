package org.sampleapp.utils;

import java.lang.reflect.Field;
import org.sampleapp.exceptions.SampleAppException;
import org.sampleapp.services.AppParameter;
import org.sampleapp.services.HttpRequestHandler;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/**
 * This is a simple utility class for the java sample application.
 * Provides simple utility functions for the whole project.
 * @author Microsoft Corp
 *
 */
public class SampleAppUtilities {
	

	/**
	 * This is a generic method that copies the simple attribute values from an argument jsonObject to an argument
	 * generic object.
	 * @param jsonObject The jsonObject from where the attributes are to be copied.
	 * @param destObject The object where the attributes should be copied into.
	 * @throws SampleAppException Throws a SampleAppException when the operation are unsuccessful.
	 */
    public static <T> void copyAttrFromJSONObject(JSONObject jsonObject, T destObject) throws SampleAppException{
    	/**
    	 * Get the list of all the field names.
    	 */
    	Field[] fieldList = destObject.getClass().getDeclaredFields();
		
    	/**
    	 * For all the declared field.
    	 */
    	for(int i = 0; i < fieldList.length; i++){
    		/**
    		 * If the field is of type String, that is
    		 * if it is a simple attribute.
    		 */
    		if(fieldList[i].getType().equals(String.class)){
				try {
					/**
					 * Invoke the corresponding set method of the destObject using
					 * the argument taken from the jsonObject.
					 */
					destObject.getClass().getMethod(
							String.format("set%s",capitalizeFirstLetter(fieldList[i].getName())), 
							new Class[]{String.class}).
					invoke(destObject, 
						//	new Object[]{jsonObject.optString(capitalizeFirstLetter(fieldList[i].getName()))});
					     	new Object[]{jsonObject.optString(lowerCaseFirstLetter(fieldList[i].getName()))});
				} catch (Exception e) {
					throw new SampleAppException(
							AppParameter.internalError, AppParameter.internalErrorMessage, e, null);
				} 

    		}
    	}
    }
    
    /**
     * This method lowerCases the first character of the string.
     * @param string The string to be first character lowerCased
     * @return The new first charater lowerCased string.
     */
	public static String lowerCaseFirstLetter(String string) {
		/**
		 * If the string is empty or null,
		 * return the string itself.
		 */
		if(string.trim().isEmpty() || (string == null)){
			return string;
		}else{
			/**
			 * If not, then lower case the first character and return the String.
			 */
			return Character.toLowerCase(string.charAt(0)) + string.substring(1);
		}
			
	}
	
	
    /**
     * This method capitalizes the first character of the string.
     * @param string The string to be capitalized.
     * @return The new capitalized string.
     */
	public static String capitalizeFirstLetter(String string) {
		/**
		 * If the string isempty or null,
		 * return the string itself.
		 */
		if(string.trim().isEmpty() || (string == null)){
			return string;
		}else{
			/**
			 * If not, then capitalize the first character and return the String.
			 */
			return Character.toUpperCase(string.charAt(0)) + string.substring(1);
		}
			
	}



	/**
	 * This method does all the initializes, such as get all
	 * the verified Domains, all the groups, roles etc.
	 * @throws SampleAppException
	 */
	public static void initApp() throws SampleAppException{
		/**
		 * Get the tenant Verified Domain Names.
		 */
		getTenantVerifiedDomainNames();
		
		/**
		 * Get all the groups.
		 */
		getAllGroups();
		
		/**
		 * Get all the Roles.
		 */	
		getAllRoles();
	}
	

	/**
	 * This method gets all the Roles from the REST and put them
	 * in {@link org.sampleapp.services.AppParameter AppParameter} class.
	 * @throws SampleAppException if the operation is not successful.
	 */	
	private static void getAllRoles() throws SampleAppException {

		/**
		 * Get the group information.
		 */
		String response = HttpRequestHandler.handleRequest("/roles", null);

		try {

			/**
			 * Clear if there is any existing groups.
			 */
			AppParameter.clearRoles();

			/**
			 * Get the JSONArray that holds the groups.
			 */
			JSONArray roles = (new JSONObject(response)).getJSONArray("value");
			/**
			 * Retrieve each of the group's display name and object id and add
			 * it in the appropriate data structure.
			 */
			for (int i = 0; i < roles.length(); i++) {
				AppParameter.addNewRole(
						roles.getJSONObject(i).optString("displayName"), 
						roles.getJSONObject(i).optString("objectId"));
			}
			
		} catch (JSONException e) {
			throw new SampleAppException(
					AppParameter.ErrorParsingJSONException, e.getMessage(), e, null);
		}

	}




	/**
	 * This method gets all the Groups from the REST and put them
	 * in {@link org.sampleapp.services.AppParameter AppParameter} class.
	 * @throws SampleAppException if the operation is not successful.
	 */
	public static void getAllGroups() throws SampleAppException {
		
		/**
		 * Get the group information.
		 */
		String response = HttpRequestHandler.handleRequest("/groups",null);
		
		try {
			
			/**
			 * Clear if there is any existing groups.
			 */
			AppParameter.clearGroups();
			
			/**
			 * Get the JSONArray that holds the groups.
			 */
			JSONArray groups = (new JSONObject(response)).getJSONArray("value");
			
			/**
			 * Retrieve each of the group's display name and object id and add it in the appropriate data structure.
			 */
			for(int i = 0; i < groups.length(); i++){
				AppParameter.addNewGroup(groups.getJSONObject(i).optString("displayName"), groups.getJSONObject(i).optString("objectId"));
			}
			
		} catch (JSONException e) {
			throw new SampleAppException(AppParameter.ErrorParsingJSONException, e.getMessage(), e, null);
		}
				
	}


	/**
	 * This method gets all the verified domain names from the REST and put them
	 * in {@link org.sampleapp.services.AppParameter AppParameter} class.
	 * @throws SampleAppException if the operation is not successful.
	 */
	public static void getTenantVerifiedDomainNames() throws SampleAppException {
		/**
		 * Make the request to get the tenant details info.
		 */
		String response = HttpRequestHandler.handleRequest("/tenantDetails", null);

		/**
		 * Retrieve each verified domain name and put it into the verified
		 * domain list in {@link org.sampleapp.services.AppParameter
		 * AppParameter} class.
		 */
		try {
			
			JSONArray verifiedDomains = ((new JSONObject(response))
					.getJSONArray("value"))
					.getJSONObject(0)
					.getJSONArray("verifiedDomains");
					
			for (int i = 0; i < verifiedDomains.length(); i++) {
				AppParameter.addNewVerifiedDomainName(verifiedDomains
						.getJSONObject(i).optString("name"));
			}
		} catch (JSONException e) {
			throw new SampleAppException(
					AppParameter.ErrorParsingJSONException, e.getMessage(), e, null);
		}

		for (int i = 0; i < AppParameter.getVerifiedDomainNumber(); i++) {
			System.out.println(AppParameter.getVerifiedDomainName(i));
		}

	}
}
