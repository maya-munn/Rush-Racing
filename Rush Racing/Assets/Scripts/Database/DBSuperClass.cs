using Mono.Data.Sqlite;
using UnityEngine;

/// <summary>
/// This script is to be used for the super class of all database scripts
/// Initialises a connection to a db when the instance of a class is initialised
/// 
/// Authors: Bernadette Cruz, Maya Ashizumi-Munn
/// </summary>
public class DBSuperClass : MonoBehaviour
{
	//Connection to DB
	protected SqliteConnection dbcon;

	//******************************************//

	protected SqliteConnection StartDB()
	{
		// Get database path
		string connection = "URI=file:" + Application.dataPath + "/RushRacingDB.db";

		// Open connection
		dbcon = new SqliteConnection(connection);
		dbcon.Open();
		return dbcon;
	}

	public void closeConn()
	{
		// Close connection
		dbcon.Close();
	}
}