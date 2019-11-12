package org.sampleapp.tokenhandler;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.URL;
import java.net.URLConnection;
import java.net.URLEncoder;
//import java.util.Calendar;
//import java.util.Date;
//import java.util.TimeZone;

//import javax.crypto.Mac;
//import javax.crypto.spec.SecretKeySpec;


import org.sampleapp.exceptions.SampleAppException;
import org.sampleapp.services.AppParameter;
import org.json.JSONObject;

//import com.sun.org.apache.xml.internal.security.exceptions.Base64DecodingException;
//import com.sun.org.apache.xml.internal.security.utils.Base64;



/**
 * Facilitates minting a test token.
 * @author Microsoft Corp
 *
 */
public class JWTTokenHelper {
	
	
    /**
     * Grant type claim
     */ 
    private static final String claimTypeGrantType = "grant_type";

    /**
     * Assertion Claim.
     */
//    private static final String claimTypeAssertion = "assertion";

    /**
     * Resource Claim.
     */
    private static final String claimTypeResource = "resource";

    /**
     * Prefix for bearer tokens.
     */
    private static final String bearerTokenPrefix = "Bearer ";
    
    /**
     * Prefix for client id
     */
    private static final String clientIdPrefix = "client_id";
    
    /**
     * Prefix for client secret
     */
    private static final String clientSecretPrefix = "client_secret";


	/**
	 * Get an access token from EVO STS
	 * @param evoStsUrl EVO STS Url.
	 * @param assertion Assertion Token.
	 * @param resource ExpiresIn name.
	 * @return The OAuth access token.
	 * @throws SampleAppException If the operation can not be completed successfully.
	 */
	public static String getOAuthAccessTokenFromEvoSTS(String evoStsUrl,
			String clientId,String clientSecret, String resource) throws SampleAppException {
		
		String accessToken = "";
				
		URL url = null;
		
		String data = null;
		
		try {
			data = URLEncoder.encode(JWTTokenHelper.claimTypeGrantType, "UTF-8") + "=" + URLEncoder.encode("client_credentials", "UTF-8");
			data += "&" + URLEncoder.encode(JWTTokenHelper.claimTypeResource, "UTF-8") + "=" + URLEncoder.encode(resource, "UTF-8");
			data += "&" + URLEncoder.encode(JWTTokenHelper.clientIdPrefix, "UTF-8") + "=" + URLEncoder.encode(clientId, "UTF-8");
			data += "&" + URLEncoder.encode(JWTTokenHelper.clientSecretPrefix, "UTF-8") + "=" + URLEncoder.encode(clientSecret, "UTF-8");
			
			url = new URL(evoStsUrl);
			
			URLConnection conn = url.openConnection();
			
			conn.setDoOutput(true);
			
			OutputStreamWriter wr = new OutputStreamWriter(conn.getOutputStream());
			wr.write(data);
			wr.flush();
			
			BufferedReader rd = new BufferedReader(new InputStreamReader(conn.getInputStream()));
			
			String line, response = "";
			
			while((line=rd.readLine()) != null){
				response += line;
			}
			
			wr.close();
			rd.close();
			
			
			accessToken = (new JSONObject(response)).optString("access_token");						
			return String.format("%s%s", JWTTokenHelper.bearerTokenPrefix, accessToken);
			
		} catch (Exception e2) {
			throw new SampleAppException(AppParameter.ErrorGeneratingToken, AppParameter.ErrorGeneratingTokenMessage, e2, null);
		}
	}

}
