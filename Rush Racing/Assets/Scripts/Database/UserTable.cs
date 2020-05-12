using Mono.Data.Sqlite;
using System;
using System.Data;
using UnityEngine;

/// <summary>
/// Methods to query and insert into the user table of the
/// database
/// Author: Maya Ashizumi-Munn
/// </summary>
public class UserTable : DBSuperClass
{
	SqliteCommand cmnd;
	SqliteDataReader reader;
	new SqliteConnection dbcon;

	string connection;

	private void Start()
	{
		//Calls super class method to initialise DB connection
		// Get database path
		connection = "URI=file:" + Application.dataPath + "/RushRacingDB.db";

		// Open connection
		dbcon = new SqliteConnection(connection);
		dbcon.Open();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns>bool to see if there is any thing in table</returns>
	public bool ReadUserTable()
    {
		//Bad fix to solve a connection error - start needs to be called but cant figure it out yet
		this.Start();

		using (dbcon)
		{
			// Read all values from table
			string query = "SELECT * FROM user";
			cmnd = new SqliteCommand(query, dbcon);
			//Not good programming - only for testing //TODO
			object result = cmnd.ExecuteScalar();
			bool tablePopulated = result != null;
			return tablePopulated;
		}
	}

	public bool CheckForExistingUsers()
	{
		using (dbcon)
		{
			//Read user table 
			bool exists = ReadUserTable();
			//Check if rows exist
			return exists;
		}
	}

	public void CreateNewUser(string username, long pinHash)
	{
		using (dbcon)
		{
			string insert = "INSERT INTO user(username, userPin) VALUES('" + username + "', '" + pinHash + "')";
			cmnd = new SqliteCommand(insert, dbcon);
			cmnd.ExecuteNonQuery();
		}
	}

	//TODO - Fix
	public int GetIDFromUsername(string username)
	{
		//Need to open connection again
		using (dbcon = new SqliteConnection(connection))
		{
			dbcon.Open();
			string query = "SELECT userID FROM user WHERE username = '" + username + "'";
			cmnd = new SqliteCommand(query, dbcon);

			int ID = Convert.ToInt32(cmnd.ExecuteScalar());
			return ID;
		}
	}
}


