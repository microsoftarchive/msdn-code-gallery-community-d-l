package org.sampleapp.dto;

import java.util.ArrayList;

/**
 * The class UserPageInfo holds the data of a page of users. It also contains information whether
 * this page any next page or previous page and also the contains the page number member.
 * @author Microsoft
 */
public class UserPageInfo {
	
	/**
	 * The users hold the information of the users this page carries.
	 */
	private ArrayList<UserInfo> users;
	
	/**
	 * Whether or not this page has a next page.
	 */
	private boolean hasNextPage;
	
	/**
	 * Whether or not this page has a previous page.
	 */
	private boolean hasPrevPage;
	private int pageNumber;
	
	
	/**
	 * The constructor of the UserPageInfo class.
	 * Initializes the user List.
	 */
	public UserPageInfo(){
		users = new ArrayList<UserInfo>();
	}


	/**
	 * @return The number of users in the List.
	 */
	public int getUserNumber(){
		return this.users.size();
	}
	
	
	/**
	 * Adds a new user to the list.
	 * @param displayName The displayName of the User to be added to the List.
	 * @param objectId The ObjectId of the User to be added to the List.
	 */
	public void addNewUserInfo(String displayName, String objectId){
		users.add(new UserInfo(displayName, objectId));
	}


	
	/**
	 * Adds a new user to the list.
	 * @param displayName The displayName of the User to be added to the List.
	 * @param objectId The ObjectId of the User to be added to the List.
	 * @param userPrincipalName UserPrincipalName of the user to be added to the List.
	 */
	
	public void addNewUserInfo(String displayName, String objectId, String userPrincipalName){
		users.add(new UserInfo(displayName, objectId, userPrincipalName));
	}
	
	
	/**
	 * @param index The index of the requested user.
	 * @return Returns the DisplayName of the user at index position in the List.
	 */
	
	public String getUserDisplayName(int index){
		return this.users.get(index).getDisplayName();
	}


	/**
	 * @param index The index of the requested user.
	 * @return Returns the ObjectID of the user at index position in the List.
	 */
	
	public String getUserObjectId(int index){
		return this.users.get(index).getObjectId();
	}


	/**
	 * @param index The index of the requested user.
	 * @return Returns the UserPrincipalName of the user at index position in the List.
	 */
	
	public String getUserPrincipalName(int index){
		return this.users.get(index).getUserPrincipalName();
	}

	
	
	/**
	 * @return The hasNextPage returns true if this page has a next page. Otherwise returns false.
	 */
	public boolean isHasNextPage() {
		return hasNextPage;
	}


	/**
	 * @param hasNextPage Whether this page has a next page.
	 */
	public void setHasNextPage(boolean hasNextPage) {
		this.hasNextPage = hasNextPage;
	}


	/**
	 * @return the hasPrevPage 
	 */
	public boolean isHasPrevPage() {
		return hasPrevPage;
	}


	/**
	 * @param hasPrevPage The hasPrevPage to set to this PageInfo.
	 */
	public void setHasPrevPage(boolean hasPrevPage) {
		this.hasPrevPage = hasPrevPage;
	}


	/**
	 * @return The pageNumber of this page.
	 */
	public int getPageNumber() {
		return pageNumber;
	}


	/**
	 * @param pageNumber The pageNumber of this current page.
	 */
	public void setPageNumber(int pageNumber) {
		this.pageNumber = pageNumber;
	}
}


/**
 * 
 * @author Microsoft
 * The UserInfo class holds the essential signature attributes of a user such as
 * DisplayName, UserPrincipalName and ObjectId.
 */

class UserInfo{
	private String displayName;
	private String userPrincipalName;
	private String objectId;

	
	/**
	 * Two argument constructor of the class UserInfo.
	 * @param dName DisplayName of the User Object.
	 * @param objId ObjectId of the User Object.
	 */
	
	public UserInfo(String dName, String objId){
		this.setDisplayName(dName);
		this.setObjectId(objId);
	}
	

	/**
	 * Three argument constructor of the UserInfo.
	 * @param dName DisplayName of the User Object.
	 * @param objId ObjectId of the User Object.
	 * @param userPrinName UserPrincipalName of the User Object.
	 */
	
	public UserInfo(String dName, String objId, String userPrinName){
		this.setDisplayName(dName);
		this.setObjectId(objId);
		this.setUserPrincipalName(userPrinName);
	}
	
	/**
	 * @return The displayName of this User.
	 */
	public String getDisplayName() {
		return displayName;
	}
	/**
	 * @param displayName The displayName to set to this User.
	 */
	public void setDisplayName(String displayName) {
		this.displayName = displayName;
	}
	/**
	 * @return The userPrincipalName of this User.
	 */
	public String getUserPrincipalName() {
		return userPrincipalName;
	}
	/**
	 * @param userPrincipalName The userPrincipalName to set to this User.
	 */
	public void setUserPrincipalName(String userPrincipalName) {
		this.userPrincipalName = userPrincipalName;
	}
	/**
	 * @return The objectId of this User.
	 */
	public String getObjectId() {
		return objectId;
	}
	/**
	 * @param objectId the objectId to set to this User.
	 */
	public void setObjectId(String objectId) {
		this.objectId = objectId;
	}
}
