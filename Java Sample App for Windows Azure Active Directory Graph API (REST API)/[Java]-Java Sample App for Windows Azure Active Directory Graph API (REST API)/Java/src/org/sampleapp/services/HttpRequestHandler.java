package org.sampleapp.services;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URISyntaxException;
import java.net.URL;

import org.json.JSONException;
import org.json.JSONObject;
import org.sampleapp.exceptions.SampleAppException;

/**
 * This class provides all the methods to send http requests to the
 * REST Endpoint.
 * @author Microsoft Corp
 *
 */

public class HttpRequestHandler {

	
	/**
	 * This method sends a http GET request to the rest end point.
	 * @param path The additional path part of the URL.
	 * @param queryOption The queries of the URL.
	 * @return The response of the request sent.
	 * @throws SampleAppException
	 */
	public static String handleRequest(String path, String queryOption) throws SampleAppException {
		BufferedReader reader = null;
		HttpURLConnection conn = null;
		String response ="";
		String queryOptionAdd = "";
		String apiVersion = AppParameter.getDataContractVersion();
				
		try {
			
			/**
			 * Construct the URI from the different parts.
			 */
			if (queryOption == null)
	        {
				queryOptionAdd = apiVersion;				
			}
			else 
			{
				queryOptionAdd = queryOption + "&" + apiVersion;				
			}
			
			URI uri = new URI(AppParameter.PROTOCOL_NAME,
					AppParameter.getRestServiceHost(), 
					"/" + AppParameter.getTenantContextId() + path,
					queryOptionAdd, 
					null);
		


			/**
			 * Get the url and open an http connection.
			 */
			URL url = uri.toURL();
			conn = (HttpURLConnection) url.openConnection();

			/**
			 * Set the appropriate header fields in the request header.
			 */
					
			conn.setRequestProperty(AppParameter.AUTHORIZATION_HEADER,
					AppParameter.getAccessToken());
			conn.setRequestProperty(AppParameter.ACCEPT_HEADER,
					AppParameter.ACCEPT_HEADER_VALUE);
			

			/**
			 * Get the reader for this connection.
			 */
			reader = new BufferedReader(new InputStreamReader(
						conn.getInputStream()));
			

			/**
			 * Read the response stream and return the equivalent string.
			 */
			
			StringBuffer stringBuf = new StringBuffer();
			String inputLine;
			
			while ((inputLine = reader.readLine()) != null) {
				stringBuf.append(inputLine);
			}			
			return stringBuf.toString();
		
		} catch (IOException e) {
			
			try {				
				/**
				 * Get the error code.
				 */
				int responseCode = conn.getResponseCode();
				
				/**
				 * Get the error stream and save the error message in the String response.
				 */
				reader = new BufferedReader(new InputStreamReader(conn.getErrorStream()));
				StringBuffer stringBuf = new StringBuffer();
				String inputLine, errorCode, errorMessage;
				while ((inputLine = reader.readLine()) != null) {
					stringBuf.append(inputLine);
				}
				response = stringBuf.toString();
				
				
				/**
				 * Try to parse the JSON String and retrieve the error code and message
				 */
				errorCode = (new JSONObject(response).optJSONObject("odata.error").optString("code"));
				/**
				* If the error is unauthorized access.
				*/
				if(responseCode == 403){
					errorMessage = (new JSONObject(response).optJSONObject("odata.error").optJSONObject("message").optString("value"));
				}				
				/**
				 * If the error is about anything else.
				 */
				else{
					errorCode = (new JSONObject(response).optJSONObject("odata.error").optString("code"));
					errorMessage = (new JSONObject(response).optJSONObject("odata.error").optJSONObject("message").optString("value"));
				}
				
				throw new SampleAppException(errorCode, errorMessage, e, response);
				
				
				
			} catch (IOException e1) {
				throw new SampleAppException(AppParameter.ErrorCodeNotReceived, AppParameter.ErrorCodeNotReceivedMessage, e1, response );
			} catch(JSONException e2){
				
				/**
				 * If the error message couldn't be successfully parsed. 
				 */
				throw new SampleAppException(AppParameter.ErrorConnectingRestService, AppParameter.ErrorConnectingRestServiceMessage, e2, response);
			}
			
		} catch (URISyntaxException e) {
			throw new SampleAppException(AppParameter.UriSyntaxException, AppParameter.UriSyntaxExceptionMessage, e, response);
		}

	}
	

	public static String handleRequestDelete(String path, String queryOption) throws SampleAppException {
		
		BufferedReader reader = null;
		HttpURLConnection conn = null;
		String response ="";
		String queryOptionAdd = "";
		String apiVersion = AppParameter.getDataContractVersion();
				
		try {
			
			/**
			 * Construct the URI from the different parts.
			 */
			if (queryOption == null)
	        {
				queryOptionAdd = apiVersion;				
			}
			else 
			{
				queryOptionAdd = queryOption + "&" + apiVersion;				
			}
			
			URI uri = new URI(AppParameter.PROTOCOL_NAME,
					AppParameter.getRestServiceHost(), "/"
							+ AppParameter.getTenantContextId() + path,
					queryOptionAdd, null);

			/**
			 * Get the url and open an http connection.
			 */
			URL url = uri.toURL();
			System.out.println(uri.toASCIIString());
			conn = (HttpURLConnection) url.openConnection();

			/**
			 * Set the appropriate header fields in the request header.
			 */
			conn.setDoOutput(true);
			conn.setRequestMethod("DELETE");
			conn.setRequestProperty(AppParameter.AUTHORIZATION_HEADER,
					AppParameter.getAccessToken());
			conn.setRequestProperty(AppParameter.ACCEPT_HEADER,
					"application/json");
			conn.setRequestProperty("Content-Type", "application/json");

			conn.connect();

			/**
			 * Get the reader for this connection.
			 */
			reader = new BufferedReader(new InputStreamReader(
						conn.getInputStream()));
			

			/**
			 * Read the response stream.
			 */
			
			StringBuffer stringBuf = new StringBuffer();
			String inputLine;
			while ((inputLine = reader.readLine()) != null) {
				stringBuf.append(inputLine);
			}
			
			int responseCode1 = conn.getResponseCode();
			System.out.println("Response Code: " + responseCode1);
			return (Integer.toString(responseCode1));						

//			return "success";
		
		} catch (IOException e) {
			
			try {				
				/**
				 * Get the error code.
				 */
				int responseCode = conn.getResponseCode();
				System.out.println(responseCode);
				
				/**
				 * Get the error stream.
				 */
				reader = new BufferedReader(new InputStreamReader(conn.getErrorStream()));
				StringBuffer stringBuf = new StringBuffer();
				String inputLine;
				while ((inputLine = reader.readLine()) != null) {
					stringBuf.append(inputLine);
				}
				response = stringBuf.toString();
				System.out.println(response);
			
				throw new SampleAppException(Integer.toString(responseCode), e.getMessage(), e, response);
				
				
			} catch (IOException e1) {
				throw new SampleAppException(AppParameter.ErrorCodeNotReceived, AppParameter.ErrorCodeNotReceivedMessage, e1, response );
			}
			
		} catch (URISyntaxException e) {
			throw new SampleAppException(AppParameter.UriSyntaxException, AppParameter.UriSyntaxExceptionMessage, e, response);
		}

	}	
	
    public static String handlRequestPostJSON(String path, String queryOption, String data, String opName){
		
		URL url = null;
		HttpURLConnection conn = null;
		String queryOptionAdd = "";
		String apiVersion = AppParameter.getDataContractVersion();
				
		try {
			
			/**
			 * Form the request uri by specifying the individual components of the
			 * URI.
			 */
			if (queryOption == null)
	        {
				queryOptionAdd = apiVersion;				
			}
			else 
			{
				queryOptionAdd = queryOption + "&" + apiVersion;				
			}
					
			URI uri = new URI(
					AppParameter.PROTOCOL_NAME, 
					AppParameter.getRestServiceHost(), 
					"/" + AppParameter.getTenantContextId() + path,
					queryOptionAdd, 
					null);
			
			
			
			/**
			 * Open an URL Connection.
			 */
			url = uri.toURL();
			conn = (HttpURLConnection) url.openConnection();
			
			/**
			 * Set method to POST.
			 */
			conn.setRequestMethod("POST");
			
			/**
			 * Set the appropriate request header fields.
			 */
			conn.setRequestProperty(AppParameter.AUTHORIZATION_HEADER, AppParameter.getAccessToken());
			conn.setRequestProperty("Accept", "application/json");
			
			/**
			 * If the request for create an user or update an user, the appropriate content type would
			 * be application/json.
			 */
			if( opName.equalsIgnoreCase("createUser") || opName.equalsIgnoreCase("updateUser")  ){
				conn.setRequestProperty("Content-Type", "application/json");
			}
			
			/**
			 * If the operation is to add an user to a group/role,
			 * the content type should be set to "application/json".
			 */
			else if(opName.equalsIgnoreCase("addUserToGroup")){
				conn.setRequestProperty("Content-Type", "application/json");
			}
			
			
			/**
			 * If the operation is for update user, then we need to send a 
			 * PATCH request, not a POST request. Therefore, we use the X-HTTP-METHOD
			 * header field to specify that this request is intended to be used as a
			 * PATCH request.
			 */
			if(opName.equalsIgnoreCase("updateUser")){
				conn.setRequestProperty("X-HTTP-Method", "PATCH");			
			}
			

			
			/**
			 * Send the http message payload to the server.
			 */
			conn.setDoOutput(true);			
			OutputStreamWriter wr = new OutputStreamWriter(conn.getOutputStream());
			wr.write(data);
			wr.flush();
			

			/**
			 * Get the message response from the server.
			 */
			BufferedReader rd = new BufferedReader(new InputStreamReader(conn.getInputStream()));			
			String line, response = "";			
			while((line=rd.readLine()) != null){
				response += line;
			}
			
			/**
			 * Close the streams.
			 */
			wr.close();
			rd.close();
						
			int responseCode = conn.getResponseCode();
			System.out.println("Response Code: " + responseCode);
			return (Integer.toString(responseCode));
			
			
		} catch (Exception e2) {
						
			try {
				int responseCode = conn.getResponseCode();
				System.out.println("Response Code: " + responseCode);
			} catch (IOException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
			
			/**
			 * Get the error stream.
			 */
			BufferedReader reader = new BufferedReader(new InputStreamReader(conn.getErrorStream()));
			StringBuffer stringBuf = new StringBuffer();
			String inputLine;
			try {
				while ((inputLine = reader.readLine()) != null) {
					stringBuf.append(inputLine);
				}
			} catch (IOException e) {
				// TODO HANDLE THE EXCEPTION

			}
			String response = stringBuf.toString();
			System.out.println(response);
			return response;
			
		}

//		return "";
	}


	
		
		
}
