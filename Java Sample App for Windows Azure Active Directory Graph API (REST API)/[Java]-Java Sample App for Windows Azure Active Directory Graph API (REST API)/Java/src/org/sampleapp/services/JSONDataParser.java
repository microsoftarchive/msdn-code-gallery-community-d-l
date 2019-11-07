package org.sampleapp.services;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.sampleapp.exceptions.SampleAppException;

/**
 * This class provides the methods to parse JSON Data from a JSON Formatted String.
 * @author Microsoft Corp
 *
 */
public class JSONDataParser {

	/**
	 * This method parses an JSON Array out of a collection of JSON Objects within
	 * a string.
	 * @param jSonData The JSON String that holds the collection.
	 * @return An JSON Array that would contains all the collection object.
	 * @throws SampleAppException 
	 */
	public static JSONArray parseJSonDataCollection(String jSonData) throws SampleAppException{
		JSONArray jArray = null;
		/**
		 * Retrieve the JSON Array from the string.
		 */
		try {
			jArray = new JSONObject(jSonData).getJSONArray("value");
		} catch (JSONException e) {
			/**
			 * If there is a JSON Parsing error, throw a new SampleAppException.
			 */
			throw new SampleAppException(AppParameter.ErrorParsingJSONException, e.getMessage(), e, null);
		}

		return jArray;
	}

	
	/**
	 * This method parses the skip token from a json formatted string.
	 * @param jsonData The JSON Formatted String.
	 * @return The skipToken.
	 * @throws SampleAppException 
	 */
	public static String parseSkipTokenForNextPage(String jsonData) throws SampleAppException {
		String skipToken = "";
		
		try {
			/**
			 * Parse the skip token out of the string.
			 */
			skipToken = new JSONObject(jsonData).optString("odata.nextLink");
			
			if(!skipToken.equalsIgnoreCase("")){
				/**
				 * Remove the unnecessary prefix from the skip token.
				 */
				int index = skipToken.indexOf("$skiptoken=") + ( new String("$skiptoken=") ).length();
				skipToken = skipToken.substring(index);
			}
			
		} catch (JSONException e) {
			throw new SampleAppException(AppParameter.ErrorParsingJSONException, e.getMessage(), e, null);
		}
		
		return skipToken;
	}


	/**
	 * This method parses a JSON Object out of a formatted JSON String.
	 * @param jSonData The JSON Formatted String.
	 * @return An JSON Object that would contains the JSON object.
	 * @throws SampleAppException 
	 */	
	public static JSONObject parseJSonDataMultipleObjects(String jsonData) throws SampleAppException {
		JSONObject  jsonObject = null;
		
		try {	
			 jsonObject = new JSONObject(jsonData).getJSONObject("value");
		} catch (JSONException e) {
			throw new SampleAppException(AppParameter.ErrorParsingJSONException, e.getMessage(), e, null);
		}
		return jsonObject;
	}
	
	public static JSONObject parseJSonDataSingleObject(String jsonData) throws SampleAppException {
		JSONObject  jsonObject = null;
		
		try {
			 jsonObject = new JSONObject(jsonData);
		} catch (JSONException e) {
			throw new SampleAppException(AppParameter.ErrorParsingJSONException, e.getMessage(), e, null);
		}
		return jsonObject;
	}

}
