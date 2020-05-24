
using System.Data;
using UnityEngine;
using System.IO;

public class DBImport : MonoBehaviour
{
	//// Use this for initialization
	//void Start()
	//{

	//	// Create database
	//	string connection = "URI=file:" + Application.dataPath + "/Database.db";

	//	// Open connection
	//	IDbConnection dbcon = new SqliteConnection(connection);
	//	dbcon.Open();

	//	// Read and print all values in table
	//	IDbCommand cmnd_read = dbcon.CreateCommand();
	//	IDataReader reader;
	//	string query = "SELECT * FROM user";
	//	cmnd_read.CommandText = query;
	//	reader = cmnd_read.ExecuteReader();

	//	while (reader.Read())
	//	{
	//		string user = reader.GetString(0);
	//		Debug.Log("username: " + user);
	//	}

	//	// Close connection
	//	dbcon.Close();

	//}

	//// Update is called once per frame
	//void Update()
	//{

	//}
}