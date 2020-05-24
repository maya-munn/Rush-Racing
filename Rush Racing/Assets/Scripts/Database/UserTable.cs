
using UnityEngine;

/// <summary>
/// Methods to query and insert into the user table of the
/// database
/// Open and close are called with each method
/// 
/// Author: Maya Ashizumi-Munn
/// </summary>
public class UserTable : MonoBehaviour
{
	//SqliteCommand cmnd;
	//new SqliteConnection dbcon;

	//string connection;

	//private void openConnection()
	//{
	//	connection = "URI=file:" + Application.dataPath + "/StreamingAssets/RushRacingDB.db";
	//	dbcon = new SqliteConnection(connection);
	//	dbcon.Open();
	//}

	public bool[] existingProfileIndices()
	{
		bool[] profilesExisting = new bool[3] { false, false, false } ; //Max 3 profiles

		//using (dbcon)
		//{
		//	openConnection();

		//	// Read all values from table
		//	string query = "SELECT * FROM user";
		//	cmnd = new SqliteCommand(query, dbcon);

		//	//Reader object
		//	SqliteDataReader reader = cmnd.ExecuteReader();
		//	while (reader.Read())
		//	{
		//		//Change bool array values if userID exists
		//		int ID = reader.GetInt32(0); //userID is first value
		//		switch (ID)
		//		{
		//			case 1:
		//				profilesExisting[0] = true;
		//				break;
		//			case 2:
		//				profilesExisting[1] = true;
		//				break;
		//			case 3:
		//				profilesExisting[2] = true; 
		//				break;
		//		}
		//	}

		//	dbcon.Close();
		//	return profilesExisting;
		//}

		profilesExisting[0] = PlayerPrefs.GetInt("UserOneID") != 0;
		profilesExisting[1] = PlayerPrefs.GetInt("UserTwoID") != 0;
		profilesExisting[2] = PlayerPrefs.GetInt("UserThreeID") != 0;

		return profilesExisting;
	}

	public bool CheckForExistingUsers()
	{
		//using (dbcon)
		//{
		//	openConnection();

		//	//Read user table 
		//	//Check if rows exist
		//	bool exists = isTablePopulated();

		//	dbcon.Close();
		//	return exists;
		//}

		bool[] existingIndices = this.existingProfileIndices();
		if (existingIndices[0] == false && existingIndices[1] == false && existingIndices[2] == false)
		{
			//If all of them are false, then no users exist
			return false;
		}
		else
		{
			return true;
		}
	}

	public void CreateNewUser(string username, int pinHash, int userID)
	{
		//using (dbcon)
		//{
		//	openConnection();

		//	//Create new user in user table
		//	string insert = "INSERT INTO user(username, userPin, userID) VALUES('" + username + "', '" + pinHash + "', '" + userID + "')";
		//	cmnd = new SqliteCommand(insert, dbcon);
		//	cmnd.ExecuteNonQuery();

		//	//Set new user currency to 0
		//	gameObject.AddComponent<CurrencyTable>().SetNewUserCurrency(userID);

		//	PlayerPrefs.SetInt("CurrentUserID", userID);

		//	dbcon.Close();
		//}

		switch (userID)
		{
			case 1:
				PlayerPrefs.SetString("UserOneName", username);
				PlayerPrefs.SetInt("UserOnePin", pinHash);
				PlayerPrefs.SetInt("UserOneID", 1);

				PlayerPrefs.SetString("CurrentUsername", username);
				PlayerPrefs.SetInt("CurrentUserID", userID);
				break;
			case 2:
				PlayerPrefs.SetString("UserTwoName", username);
				PlayerPrefs.SetInt("UserTwoPin", pinHash);
				PlayerPrefs.SetInt("UserTwoID", 2);

				PlayerPrefs.SetString("CurrentUsername", username);
				PlayerPrefs.SetInt("CurrentUserID", userID);
				break;
			case 3:
				PlayerPrefs.SetString("UserThreeName", username);
				PlayerPrefs.SetInt("UserThreePin", pinHash);
				PlayerPrefs.SetInt("UserThreeID", 3);

				PlayerPrefs.SetString("CurrentUsername", username);
				PlayerPrefs.SetInt("CurrentUserID", userID);
				break;
		}
	}

	public string GetCurrentUsername()
	{
		//using(dbcon)
		//{
		//	bool existingUser = CheckForExistingUsers();
		//	if (existingUser)
		//	{
		//		//Need to open the connection
		//		openConnection();

		//		//Get the user name
		//		string query = "SELECT username FROM user WHERE userID = " + PlayerPrefs.GetInt("CurrentUserID");
		//		cmnd = new SqliteCommand(query, dbcon);
		//		object result = cmnd.ExecuteScalar();
		//		//Turn result into a string
		//		string usernameResult;
		//		try
		//		{
		//			usernameResult = result.ToString();
		//			dbcon.Close();
		//			return usernameResult;
		//		}
		//		catch (Exception e)
		//		{
		//			Debug.Log(e);
		//			dbcon.Close();
		//			return null;
		//		}
		//	}
		//	else
		//	{
		//		//No existing user
		//		dbcon.Close();
		//		return null;
		//	}
		//}

		string currentUsername = PlayerPrefs.GetString("CurrentUsername");
		return currentUsername;
	}
}


