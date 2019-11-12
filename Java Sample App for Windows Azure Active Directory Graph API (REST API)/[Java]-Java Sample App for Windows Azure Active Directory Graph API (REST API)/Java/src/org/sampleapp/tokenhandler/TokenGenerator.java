package org.sampleapp.tokenhandler;

//import java.net.URI;
//import java.net.URISyntaxException;

import org.sampleapp.exceptions.SampleAppException;
import org.sampleapp.services.AppParameter;


public class TokenGenerator {
	
	
	/**
	 * This method generates an access token for the caller.
	 * @param tenantContextId The context Id of the tenant.
	 * @param appPrincipalId Application Principal Id.
	 * @param evoStsUrl The Url of EVO STS
	 * @param symmetricKey Symmetric key for generating the self signed token.
	 * @param protectedResourcePrincipalId The Principal Id of the protected Resource.
	 * @param protectedResourceHostName The host name of the protected Resource host name.
	 * @return 
	 * @throws SampleAppException If the operation can't be successfully completed.
	 */

	
	public static String generateEvoStsToken(String tenantContextId, 
			String appId, String symmetricKey, 
			String protectedResourceHostName) throws SampleAppException{
	
//		String evoStsUrl = String.format("https://login.windows.net/%s/oauth2/token?api-version=1.0", tenantContextId);
		String evoStsUrl = String.format(AppParameter.getEvoStsUrl(), tenantContextId);
        String resource = "https://" + protectedResourceHostName;
		String token = JWTTokenHelper.getOAuthAccessTokenFromEvoSTS(evoStsUrl, appId, symmetricKey, resource);
		return token;
	}
	
}
