using Mono.Data.Sqlite;
using System;
using UnityEngine;

/// <summary>
/// 
/// Author: Maya Ashizumi-Munn
/// </summary>
public class CurrencyTable : DBSuperClass
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
	/// Called when a new user is created in UserTable methods
	/// </summary>
	/// <param name="userID"></param>
	public void SetNewUserCurrency(int userID)
	{
		using (dbcon)
		{
			openConnection();

			string insert = "INSERT INTO currency(userID, coins) VALUES (" + userID + ", 0)";
			cmnd = new SqliteCommand(insert, dbcon);
			cmnd.ExecuteNonQuery();

			dbcon.Close();
		}
	}

	public int GetUserCurrency()
	{
		using (dbcon)
		{
			//Check if connection is not already open
			if (!dbcon.ConnectionString.Equals(connection))
			{
				//Need to open connection if not connected
				openConnection();
			}

			int currentUserID = PlayerPrefs.GetInt("CurrentUserID");

			string query = "SELECT coins FROM currency WHERE userID = " + currentUserID;
			cmnd = new SqliteCommand(query, dbcon);
			int coins = Int32.Parse(cmnd.ExecuteScalar().ToString());

			dbcon.Close();
			return coins;
		}
	}

	public void AddToUserCurrency(int amountToAdd)
	{
		using (dbcon)
		{
			openConnection();

			int increasedAmount = this.GetUserCurrency() + amountToAdd;
			//Connection was closed by calling GetUserCurrency, open connection again
			openConnection();

			string query = "UPDATE currency SET coins = " + increasedAmount + " WHERE userID = " + PlayerPrefs.GetInt("CurrentUserID");

			dbcon.Close();
		}
	}
}
