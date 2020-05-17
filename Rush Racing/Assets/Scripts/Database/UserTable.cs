using Mono.Data.Sqlite;
using System;
using System.Data;
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
	public bool ReadUserTable()
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

	public bool CheckForExistingUsers()
	{
		using (dbcon)
		{
			openConnection();

			//Read user table 
			//Check if rows exist
			bool exists = ReadUserTable();

			dbcon.Close();
			return exists;
		}
	}

	public void CreateNewUser(string username, long pinHash)
	{
		using (dbcon)
		{
			openConnection();

			string insert = "INSERT INTO user(username, userPin) VALUES('" + username + "', '" + pinHash + "')";
			cmnd = new SqliteCommand(insert, dbcon);
			cmnd.ExecuteNonQuery();

			dbcon.Close();
		}
	}

	/// <summary>
	/// creates new user at specific ID
	/// </summary>
	/// <param name="username"></param>
	/// <param name="pinHash"></param>
	/// <param name="userID"></param>
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

	public string GetFirstUsername()
	{
		using(dbcon)
		{
			bool existingUser = CheckForExistingUsers();
			if (existingUser)
			{
				//Need to open the connection
				openConnection();

				//Get the user name
				string query = "SELECT username FROM user WHERE userID = 1";
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


