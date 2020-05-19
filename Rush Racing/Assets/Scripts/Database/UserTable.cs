using Mono.Data.Sqlite;
using System;
using UnityEngine;

/// <summary>
/// Methods to query and insert into the user table of the
/// database
/// Open and close are called with each method
/// 
/// Author: Maya Ashizumi-Munn
/// </summary>
public class UserTable : DBSuperClass
{
	SqliteCommand cmnd;
	new SqliteConnection dbcon;

	string connection;

	private void openConnection()
	{
		connection = "URI=file:" + Application.dataPath + "/RushRacingDB.db";
		dbcon = new SqliteConnection(connection);
		dbcon.Open();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns>bool to see if there is any thing in table</returns>
	public bool isTablePopulated()
    {
		using (dbcon)
		{
			openConnection();

			// Read all values from table
			string query = "SELECT * FROM user";
			cmnd = new SqliteCommand(query, dbcon);
			//Not good programming - only for testing //TODO
			object result = cmnd.ExecuteScalar();
			bool tablePopulated = result != null;

			dbcon.Close();
			return tablePopulated;
		}
	}

	public bool[] existingProfileIndices()
	{
		bool[] profilesExisting = new bool[3] { false, false, false } ; //Max 3 profiles

		using (dbcon)
		{
			openConnection();

			// Read all values from table
			string query = "SELECT * FROM user";
			cmnd = new SqliteCommand(query, dbcon);

			//Reader object
			SqliteDataReader reader = cmnd.ExecuteReader();
			while (reader.Read())
			{
				//Change bool array values if userID exists
				int ID = reader.GetInt32(0); //userID is first value
				switch (ID)
				{
					case 1:
						profilesExisting[0] = true;
						break;
					case 2:
						profilesExisting[1] = true;
						break;
					case 3:
						profilesExisting[2] = true; 
						break;
				}
			}

			dbcon.Close();
			return profilesExisting;
		}
	}

	public bool CheckForExistingUsers()
	{
		using (dbcon)
		{
			openConnection();

			//Read user table 
			//Check if rows exist
			bool exists = isTablePopulated();

			dbcon.Close();
			return exists;
		}
	}

	public void CreateNewUser(string username, long pinHash, int userID)
	{
		using (dbcon)
		{
			openConnection();

			//Create new user in user table
			string insert = "INSERT INTO user(username, userPin, userID) VALUES('" + username + "', '" + pinHash + "', '" + userID + "')";
			cmnd = new SqliteCommand(insert, dbcon);
			cmnd.ExecuteNonQuery();

			//Set new user currency to 0
			gameObject.AddComponent<CurrencyTable>().SetNewUserCurrency(userID);

			PlayerPrefs.SetInt("CurrentUserID", userID);

			dbcon.Close();
		}
	}

	/// <summary>
	/// creates new user at specific ID
	/// </summary>
	public void CreateOverrideUser(string username, long pinHash, int userID)
	{
		using (dbcon)
		{
			openConnection();

			//remove existing entry at specified user ID
			string remove = "DELETE FROM user WHERE userID = " + userID;
			cmnd = new SqliteCommand(remove, dbcon);
			cmnd.ExecuteNonQuery();

			//Make new table entry
			string insert = "INSERT INTO user(username, userPin, userID) VALUES('" + username + "', " + pinHash + ", " + userID + ")";
			cmnd = new SqliteCommand(insert, dbcon);
			cmnd.ExecuteNonQuery();

			//Set new user currency to 0
			gameObject.AddComponent<CurrencyTable>().SetNewUserCurrency(userID);

			PlayerPrefs.SetInt("CurrentUserID", userID);

			dbcon.Close();
		}
	}

	public int GetIDFromUsername(string username)
	{
		//Need to open connection again
		using (dbcon)
		{
			openConnection();
			string query = "SELECT userID FROM user WHERE username = '" + username + "'";
			cmnd = new SqliteCommand(query, dbcon);
			int ID = Convert.ToInt32(cmnd.ExecuteScalar());

			//close connection
			dbcon.Close();

			return ID;
		}
	}

	public string GetCurrentUsername()
	{
		using(dbcon)
		{
			bool existingUser = CheckForExistingUsers();
			if (existingUser)
			{
				//Need to open the connection
				openConnection();

				//Get the user name
				string query = "SELECT username FROM user WHERE userID = " + PlayerPrefs.GetInt("CurrentUserID");
				cmnd = new SqliteCommand(query, dbcon);
				object result = cmnd.ExecuteScalar();
				//Turn result into a string
				string usernameResult;
				try
				{
					usernameResult = result.ToString();
					dbcon.Close();
					return usernameResult;
				}
				catch (Exception e)
				{
					Debug.Log(e);
					dbcon.Close();
					return null;
				}
			}
			else
			{
				//No existing user
				dbcon.Close();
				return null;
			}
		}
	}
}


