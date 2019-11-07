package org.sampleapp.exceptions;

public class SampleAppException extends Exception {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private String code;
	private String message;
	private String response;

	/**
	 * Two arguments constructor for the SampleAppException. 
	 * @param code
	 * @param message
	 * @param cause The original exception that caused this exception.
	 */
	public SampleAppException(String code, String message, Throwable cause, String response){
		super(cause);
		this.code = code;
		this.message = message;
		this.response = response;
	}
	
	/*
	 * @return the code
	 */
	public String getCode() {
		return code;
	}

	/**
	 * @param code the code to set
	 */
	public void setCode(String code) {
		this.code = code;
	}

	/**
	 * @return the message
	 */
	public String getMessage() {
		return message;
	}
	
	/**
	 * @return the response
	 */
	public String getResponse() {
		return response;
	}

	/**
	 * @param message the message to set
	 */
	public void setMessage(String message) {
		this.message = message;
	}
	

}
