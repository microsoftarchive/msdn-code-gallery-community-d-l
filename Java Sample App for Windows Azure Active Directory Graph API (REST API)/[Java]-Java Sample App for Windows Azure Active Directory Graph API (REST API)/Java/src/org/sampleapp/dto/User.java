package org.sampleapp.dto;

import java.util.ArrayList;

import javax.xml.bind.annotation.XmlRootElement;

/**
 * The User Class holds together all the members of a WAAD User entity and all the access methods and set methods
 * to access or set any particular member attribute of such an object instance. 
 * @author Microsoft Corp 
 */

@XmlRootElement
public class User{
	/**
	 * The following are the individual private members of a User object that holds
	 * a particular simple attribute of an User object.
	 */
	public String ObjectId;
	private String ObjectReference;
	private String ObjectType;
	private String AccountEnabled;
	private String City;
	private String Country;
	private String Department;
	private String DirSyncEnabled;
	private String DisplayName;
	private String FacsimileTelephoneNumber;
	private String GivenName;
	private String ImmutableId;
	private String JobTitle;
	private String LastDirSyncTime;
	private String Mail;
	private String MailnickName;
	private String Mobile;
	private String PasswordPolicies;
	private String PhysicalDeliveryOfficeName;
	private String PostalCode;
	private String PreferredLanguage;
	private String State;
	private String StreetAddress;
	private String Surname;
	private String TelephoneNumber;
	private String UsageLocation;
	private String UserPrincipalName;
	
	/**
	 * manager member variable holds the essential info of the manager of this user
	 * such as DisplayName, ObjectId etc. 
	 */
	private UserInfo manager;
	
	/**
	 * The arraylist directReports holds a list of directReports entity of this user. Each Direct Report
	 * contains the DisplayName and the Object Id of that direct reports entry.
	 */
	private ArrayList<DirectReport> directReports;

	/**
	 * The arraylist groups holds a list of group entity this user belongs to. 
	 */
	private ArrayList<GroupInfo> groups;

	/**
	 * The arraylist roles holds a list of role entity this user belongs to. 
	 */
	private ArrayList<GroupInfo> roles;
	
	/**
	 * The constructor for the User class. Initializes the dynamic lists and manager variables.
	 */
	public User(){
		directReports = new ArrayList<DirectReport>();
		groups = new ArrayList<GroupInfo>();
		roles = new ArrayList<GroupInfo>();
		manager = null;
	}
	
	
	/**
	 * @return The objectId of this user.
	 */
	public String getObjectId() {
		return ObjectId;
	}
	
	/**
	 * @param Set ObjectId of a User object.
	 */
	public void setObjectId(String objectId) {
		ObjectId = objectId;
	}
	
	/**
	 * @return The immutableId of this user.
	 */
	public String getImmutableId() {
		return ImmutableId;
	}
	
	/**
	 * @param Set the ImmutableId of a user object.
	 */
	public void setImmutableId(String immutableId) {
		ImmutableId = immutableId;
	}

	/**
	 * @return The objectReference of this User.
	 */
	public String getObjectReference() {
		return ObjectReference;
	}

	/**
	 * @param objectReference The objectReference to set to this User object.
	 */
	public void setObjectReference(String objectReference) {
		ObjectReference = objectReference;
	}

	/**
	 * @return The objectType of this User.
	 */
	public String getObjectType() {
		return ObjectType;
	}

	/**
	 * @param objectType The objectType to set to this User object.
	 */
	public void setObjectType(String objectType) {
		ObjectType = objectType;
	}

	/**
	 * @return The userPrincipalName of this User.
	 */
	public String getUserPrincipalName() {
		return UserPrincipalName;
	}

	/**
	 * @param userPrincipalName The userPrincipalName to set to this User object.
	 */
	public void setUserPrincipalName(String userPrincipalName) {
		UserPrincipalName = userPrincipalName;
	}

	
	/**
	 * @return The usageLocation of this User.
	 */
	public String getUsageLocation() {
		return UsageLocation;
	}

	/**
	 * @param usageLocation The usageLocation to set to this User object.
	 */
	public void setUsageLocation(String usageLocation) {
		UsageLocation = usageLocation;
	}

	/**
	 * @return The telephoneNumber of this User.
	 */
	public String getTelephoneNumber() {
		return TelephoneNumber;
	}

	/**
	 * @param telephoneNumber The telephoneNumber to set to this User object.
	 */
	public void setTelephoneNumber(String telephoneNumber) {
		TelephoneNumber = telephoneNumber;
	}

	/**
	 * @return The surname of this User.
	 */
	public String getSurname() {
		return Surname;
	}

	/**
	 * @param surname The surname to set to this User Object.
	 */
	public void setSurname(String surname) {
		Surname = surname;
	}

	/**
	 * @return The streetAddress of this User.
	 */
	public String getStreetAddress() {
		return StreetAddress;
	}

	/**
	 * @param streetAddress The streetAddress to set to this User.
	 */
	public void setStreetAddress(String streetAddress) {
		StreetAddress = streetAddress;
	}

	/**
	 * @return The state of this User.
	 */
	public String getState() {
		return State;
	}

	/**
	 * @param state The state to set to this User object.
	 */
	public void setState(String state) {
		State = state;
	}

	/**
	 * @return The preferredLanguage of this User.
	 */
	public String getPreferredLanguage() {
		return PreferredLanguage;
	}

	/**
	 * @param preferredLanguage The preferredLanguage to set to this User.
	 */
	public void setPreferredLanguage(String preferredLanguage) {
		PreferredLanguage = preferredLanguage;
	}

	/**
	 * @return The postalCode of this User.
	 */
	public String getPostalCode() {
		return PostalCode;
	}

	/**
	 * @param postalCode The postalCode to set to this User.
	 */
	public void setPostalCode(String postalCode) {
		PostalCode = postalCode;
	}

	/**
	 * @return The physicalDeliveryOfficeName of this User.
	 */
	public String getPhysicalDeliveryOfficeName() {
		return PhysicalDeliveryOfficeName;
	}

	/**
	 * @param physicalDeliveryOfficeName The physicalDeliveryOfficeName to set to this User Object.
	 */
	public void setPhysicalDeliveryOfficeName(String physicalDeliveryOfficeName) {
		PhysicalDeliveryOfficeName = physicalDeliveryOfficeName;
	}

	/**
	 * @return The passwordPolicies of this User.
	 */
	public String getPasswordPolicies() {
		return PasswordPolicies;
	}

	/**
	 * @param passwordPolicies The passwordPolicies to set to this User object.
	 */
	public void setPasswordPolicies(String passwordPolicies) {
		PasswordPolicies = passwordPolicies;
	}

	/**
	 * @return The mobile of this User.
	 */
	public String getMobile() {
		return Mobile;
	}

	/**
	 * @param mobile The mobile to set to this User object.
	 */
	public void setMobile(String mobile) {
		Mobile = mobile;
	}

	/**
	 * @return The mail of this User.
	 */
	public String getMail() {
		return Mail;
	}
	
	/**
	 * @param mail The mail to set to this User object.
	 */
	public void setMail(String mail) {
		Mail = mail;
	}

	/**
	 * @return The mail of this User.
	 */
	public String getMailnickName() {
		return MailnickName;
	}
	
	/**
	 * @param mail The mail to set to this User object.
	 */
	public void setMailnickName(String mailnNickName) {
		MailnickName = mailnNickName;
	}
	
	/**
	 * @return The jobTitle of this User.
	 */
	public String getJobTitle() {
		return JobTitle;
	}

	/**
	 * @param jobTitle The jobTitle to set to this User Object.
	 */
	public void setJobTitle(String jobTitle) {
		JobTitle = jobTitle;
	}

	/**
	 * @return The givenName of this User.
	 */
	public String getGivenName() {
		return GivenName;
	}

	/**
	 * @param givenName The givenName to set to this User.
	 */
	public void setGivenName(String givenName) {
		GivenName = givenName;
	}

	/**
	 * @return The facsimileTelephoneNumber of this User.
	 */
	public String getFacsimileTelephoneNumber() {
		return FacsimileTelephoneNumber;
	}

	/**
	 * @param facsimileTelephoneNumber The facsimileTelephoneNumber to set to this User Object.
	 */
	public void setFacsimileTelephoneNumber(String facsimileTelephoneNumber) {
		FacsimileTelephoneNumber = facsimileTelephoneNumber;
	}

	/**
	 * @return The displayName of this User.
	 */
	public String getDisplayName() {
		return DisplayName;
	}

	/**
	 * @param displayName The displayName to set to this User Object.
	 */
	public void setDisplayName(String displayName) {
		DisplayName = displayName;
	}

	/**
	 * @return The dirSyncEnabled of this User.
	 */
	public String getDirSyncEnabled() {
		return DirSyncEnabled;
	}

	/**
	 * @param dirSyncEnabled The dirSyncEnabled to set to this User.
	 */
	public void setDirSyncEnabled(String dirSyncEnabled) {
		DirSyncEnabled = dirSyncEnabled;
	}

	/**
	 * @return The department of this User.
	 */
	public String getDepartment() {
		return Department;
	}

	/**
	 * @param department The department to set to this User.
	 */
	public void setDepartment(String department) {
		Department = department;
	}

	/**
	 * @return The lastDirSyncTime of this User.
	 */
	public String getLastDirSyncTime() {
		return LastDirSyncTime;
	}

	/**
	 * @param lastDirSyncTime The lastDirSyncTime to set to this User.
	 */
	public void setLastDirSyncTime(String lastDirSyncTime) {
		LastDirSyncTime = lastDirSyncTime;
	}

	/**
	 * @return The country of this User.
	 */
	public String getCountry() {
		return Country;
	}

	/**
	 * @param country The country to set to this User.
	 */
	public void setCountry(String country) {
		Country = country;
	}

	/**
	 * @return The city of this User.
	 */
	public String getCity() {
		return City;
	}

	/**
	 * @param city The city to set to this User.
	 */
	public void setCity(String city) {
		City = city;
	}

	/**
	 * @return The accountEnabled attribute of this User.
	 */
	public String getAccountEnabled() {
		return AccountEnabled;
	}

	/**
	 * @param accountEnabled The accountEnabled to set to this User.
	 */
	public void setAccountEnabled(String accountEnabled) {
		AccountEnabled = accountEnabled;
	}

	/**
	 * @return The DisplayName of the Manager
	 */
	public String getManagerDisplayName() {
		if(manager != null){
			return this.manager.getDisplayName();
		}
		else
			return null;
	}


	/**
	 * @return The objectId of the Manager
	 */
	public String getManagerObjectId() {
		if(manager != null){
			return this.manager.getObjectId();
		}
		else
			return null;
	}

	
	/**
	 * 
	 * @param dName DisplayName of the Manager.
	 * @param oId Object Id of the Manager.
	 */
	 
	
	public void setManager(String dName, String oId){
		this.manager = new UserInfo(dName, oId);
	}
	
	/**
	 * @param dName DisplayName of the DirectReport to be added.
	 * @param oId   ObjectId of the DirectReport to be added.
	 */
	public void addNewDirectReport(String dName, String oId){
		this.directReports.add(new DirectReport(dName, oId));
	}
	

	/**
	 * @param index The index of the DirectReport Entry.
	 * @return The ObjectId of the DirectReport entry at index.
	 */
	
	public String getDirectReportObjectId(int index){
		return this.directReports.get(index).getObjectId();
	}


	/**
	 * @param index The index of the DirectReport Entry.
	 * @return The DisplayName of the DirectReport entry at index.
	 */
	
	public String getDirectReportDisplayName(int index){
		return this.directReports.get(index).getDisplayName();
	}
	

	/**
	 * @return the number of direct report entries.
	 */
	
	public int getDirectReportNumber(){
		return this.directReports.size();
	}
	
	/**
	 * @param dName DisplayName of the Group to be added.
	 * @param oId   ObjectId of the Group to be added.
	 */
	public void addNewGroup(String dName, String oId){
		this.groups.add( new GroupInfo( dName, oId ) );
	}
	

	/**
	 * @param index The index of the Group Entry.
	 * @return The ObjectId of the Group entry at index.
	 */
	
	public String getGroupObjectId(int index){
		return this.groups.get(index).getObjectId();
	}


	/**
	 * @param index The index of the Group Entry.
	 * @return The DisplayName of the Group entry at index.
	 */
	
	public String getGroupDisplayName(int index){
		return this.groups.get(index).getDisplayName();
	}
	

	/**
	 * @return the number of group entries.
	 */
	
	public int getGroupNumber(){
		return this.groups.size();
	}	
	

	/**
	 * @return the number of roles entries.
	 */
	
	public int getRolesNumber(){
		return this.roles.size();
	}	

	/**
	 * @param index The index of the Roles Entry.
	 * @return The ObjectId of the Role entry at index.
	 */
	
	public String getRoleObjectId(int index){
		return this.roles.get(index).getObjectId();
	}


	/**
	 * @param index The index of the Roles Entry.
	 * @return The DisplayName of the Roles entry at index.
	 */
	
	public String getRoleDisplayName(int index){
		return this.roles.get(index).getDisplayName();
	}
	

	/**
	 * @param dName DisplayName of the Role to be added.
	 * @param oId   ObjectId of the Role to be added.
	 */

	
	public void addNewRole(String dName, String oId){
		this.roles.add( new GroupInfo( dName, oId ) );
	}

	
}


/**
 * 
 * The Class DirectReports Holds the essential data for a single DirectReport entry. Namely,
 * it holds the displayName and the objectId of the direct entry. Furthermore, it provides the
 * access methods to set or get the displayName and the ObjectId of this entry.
 *
 */

class DirectReport{

	private String displayName;
	private String objectId;


	/** 
	 * Two arguments Constructor for the DirectReport Class.
	 * @param dName DisplayName of the DirectReport.
	 * @param oId ObjectId of the DirectReport.
	 */
	
	public DirectReport(String dName, String oId){
		this.displayName = dName;
		this.objectId = oId;
	}
	

	/**
	 * @return The diaplayName of this direct report entry.
	 */
	
	public String getDisplayName() {
		return displayName;
	}

	/**
	 * @return The objectId of this direct report entry. 
	 */
	public String getObjectId() {
		return objectId;
	}

}



