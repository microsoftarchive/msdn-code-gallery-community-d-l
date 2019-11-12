package org.sampleapp.dto;

/**
 * 
 * class GroupInfo Holds the essential data for a single Group entry.
 * Namely, it holds the displayName and objectId of a particular group entry.
 *
 */

public class GroupInfo{
	private String displayName;
	private String ObjectId;

	/**
	 * Two arguments constructor creates a GroupInfo Object with the 
	 * specified displayName and objectId.
	 * @param dName DisplayName of the Group to be created.
	 * @param oId   ObjectId of the Group to be created.
	 */
	
	public GroupInfo(String dName, String oId){
		this.displayName = dName;
		this.ObjectId = oId;
	}
	
	/**
	 * @return the displayName
	 */
	public String getDisplayName() {
		return displayName;
	}

	/**
	 * @return the objectId
	 */
	public String getObjectId() {
		return ObjectId;
	}

}

