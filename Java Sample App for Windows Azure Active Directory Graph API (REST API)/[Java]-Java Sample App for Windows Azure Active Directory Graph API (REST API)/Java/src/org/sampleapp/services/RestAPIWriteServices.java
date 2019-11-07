package org.sampleapp.services;


import java.lang.reflect.Field;
import javax.servlet.http.HttpServletRequest;


import org.sampleapp.dto.User;
import org.sampleapp.exceptions.SampleAppException;


import org.json.*;
import org.sampleapp.utils.*;


/**
 * This class facilitates all the write functionalities to the REST Endpoint
 * such as creating, updating, deleting user objects, adding an user to a group/role,
 * deleting an user from a group/role.
 * @author Microsoft Corp
 *
 */
public class RestAPIWriteServices {
		

	/**
	 * This method creates a new user.
	 * @param request The httpservletrequest object that contains the description
	 * of the new object.
	 * @return 
	 * @throws SampleAppException if the operation can not be successfully created.
	 */
	public static String createUser(HttpServletRequest request) throws SampleAppException{		
		
		/**
		 * Send the http Post request to the appropriate url and
		 * using an appropriate message body.
		 */
		return HttpRequestHandler.handlRequestPostJSON(
				"/users", 
				null, 
				createJSONData(request),
				"createUser");
	}

	
	/**
	 * This method deletes an user identified by its ObjectId.
	 * @param objectId The ObjectId of the user to be deleted.
	 * @throws SampleAppException If the operation can not be done successfully.
	 */
	public static String deleteUser(String objectId) throws SampleAppException{
		return HttpRequestHandler.handleRequestDelete( 
				String.format("/users/%s", objectId), 
				null);
		
	}

	/**
	 * This method updates an user.
	 * @param request The HttpServletRequest request
	 * @throws SampleAppException if there is an error while doing this operation.
	 */
	
	public static String updateUser(HttpServletRequest request) throws SampleAppException {
		
		/**
		 * Send a patch request to the appropriate url with the request body
		 * as data.
		 */
		return HttpRequestHandler.handlRequestPostJSON(
				String.format("/users/%s", request.getParameter("ObjectId")), 
				null, 
				updateJSONData(request),
				"updateUser");			
	}


	/**
	 * This method adds or removes a role or group to a particular user 
	 * depending on the parameters.
	 * @param userId The Id of the user who should be added to the group/role.
	 * @param objectName Is it Group or Role?
	 * @param opName Whether delete or add
	 * @param objectId The object Id of the Group or the Role.
	 * @throws SampleAppException 
	 */
	public static String updateLink(String userId, String objectName,
			String opName, String groupId) throws SampleAppException {
		
		/* make the object name (e.g. TenantDetails, Roles, etc. is camel cased tenantDetails, roles */
		objectName = SampleAppUtilities.lowerCaseFirstLetter(objectName);
				
		String newKey = null;
			
		     /**
			 * If the operation is add.
			 */
		if(opName.equalsIgnoreCase("add")){		
			newKey =  addUserToGroup(userId, groupId, objectName);
		}
		
		/**
		 * If the operation is delete.
		 */
		if(opName.equalsIgnoreCase("delete")){
			String path = String.format("/%ss/%s/$links/members/%s", 
					objectName, 
					groupId,
					userId);
			
			newKey = HttpRequestHandler.handleRequestDelete(path, null);
		}
		
		return newKey;		
	}


	/**
	 * This method adds a user to a group/role.
	 * @param userId The ObjectId of the user to be added.
	 * @param groupId The ObjectId of the group/role object where to be added.
	 * @param objectName Whether user to be added in a group or a role.
	 * @throws SampleAppException If the operation can not be successfully carried out.
	 */	
	private static String addUserToGroup(
			String userId, 
			String groupId, 
			String objectName) throws SampleAppException {
		
		String newKey = null;				
			
			/**
			 * Setup the  JSON Body
			 */			
			JSONObject jsonObj=new JSONObject();
			
			String objectLink = String.format("https://%s/%s/directoryObjects/%s", 
				         AppParameter.getRestServiceHost(),
			             AppParameter.getTenantContextId(),
			             userId);
			try{
			jsonObj.put("url", objectLink);

			/**
			 * Convert the JSON object into a string.
			 */
			String data = jsonObj.toString();

			
			
			newKey = HttpRequestHandler.handlRequestPostJSON(
					String.format("/%ss/%s/$links/members", objectName, groupId), 
					null, 
					data,
					"addUserToGroup");
		
		      return newKey;
			
	     }catch(Exception e){
		   throw new SampleAppException(AppParameter.ErrorCreatingJSON,e.getMessage(), e, null);
	       }
	}
	

	private static String createJSONData(HttpServletRequest request) throws SampleAppException {
		try{
			
			/**
			 * Setup the  JSON Body
			 */
			  JSONObject jsonObj=new JSONObject();

					
			/**
			 * Get all the field names of the Class User.
			 */
			Field[] allFields = User.class.getDeclaredFields();
			
			for(int i = 0; i < allFields.length; i++){
				/**
				 * If this is a simple field, that is of type String.
				 */
				if(allFields[i].getType().equals(String.class)){
										
					/**
					 * If a parameter by this field name is passed to the servlet and
					 * if the passed value is not empty.
					 */
					if ((request.getParameter(allFields[i].getName()) != null)&& !(request.getParameter(allFields[i].getName())).trim().isEmpty()) {
						/**
						 * Create an entry by this fieldName and inserts the value
						 * passed into the servlet request.
						 */
						  jsonObj.put( SampleAppUtilities.lowerCaseFirstLetter((allFields[i].getName()).toString()), request.getParameter(allFields[i].getName()));
					}
				}
			}		
			
			/**
			 * Add the other minimum required properties to create a new user
			 * 
			 */
			
			// set mailNickname value
			String[] mailNickName = (request.getParameter("UserPrincipalName")).split("@",2);
			jsonObj.put("mailNickname", mailNickName[0]);
			
			// Set the password
			String password = request.getParameter("Password");
			String forceChangePasswordNextLogin = request.getParameter("ForcePasswordChangeOnNextLogon");
			
			if (password != null && forceChangePasswordNextLogin != null )
			{
			  if (password.length() > 0)
			  {
				JSONObject pswdObject = new JSONObject();
				pswdObject.put("password", password);
				pswdObject.put("forceChangePasswordNextLogin", forceChangePasswordNextLogin);
				
				jsonObj.put("passwordProfile",pswdObject);
			  }
			}
			
			/**
			 * Convert the JSON object to a string and return it.
			 */
			
			String jsonText = jsonObj.toString();
			return jsonText;
			
			
		}catch(Exception e){
			throw new SampleAppException(AppParameter.ErrorCreatingJSON,e.getMessage(), e, null);
			
		}
	}
	
	private static String updateJSONData(HttpServletRequest request) throws SampleAppException {
		try{
			
			/**
			 * Setup the  JSON Body
			 */
			  JSONObject jsonObj=new JSONObject();

					
			/**
			 * Get all the field names of the Class User.
			 */
			Field[] allFields = User.class.getDeclaredFields();
			
			for(int i = 0; i < allFields.length; i++){
				/**
				 * If this is a simple field, that is of type String.
				 */
				if(allFields[i].getType().equals(String.class)){
										
					/**
					 * If a parameter by this field name is passed to the servlet and
					 * if the passed value is not empty.
					 */
					if ((request.getParameter(allFields[i].getName()) != null)&& !(request.getParameter(allFields[i].getName())).trim().isEmpty()) {
						/**
						 * Create an entry by this fieldName and inserts the value
						 * passed into the servlet request.
						 */
						  jsonObj.put( SampleAppUtilities.lowerCaseFirstLetter((allFields[i].getName()).toString()), request.getParameter(allFields[i].getName()));
					}
				}
			}		
			
			
			// Update the Password if it was part of Update request
			String password = request.getParameter("Password");
			String forceChangePasswordNextLogin = request.getParameter("ForcePasswordChangeOnNextLogon");
			
			if (password != null && forceChangePasswordNextLogin != null )
			{
			  if (password.length() > 0)
			  {
				JSONObject pswdObject = new JSONObject();
				pswdObject.put("password", password);
				pswdObject.put("forceChangePasswordNextLogin", forceChangePasswordNextLogin);
				
				jsonObj.put("passwordProfile",pswdObject);
			  }
			}
			
			/**
			 * Convert the JSON object to a string and return it.
			 */			
			String jsonText = jsonObj.toString();
			return jsonText;
			
			
		}catch(Exception e){
			throw new SampleAppException(AppParameter.ErrorCreatingJSON,e.getMessage(), e, null);
			
		}
	}
	
	
}
