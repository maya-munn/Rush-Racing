using UnityEngine;

/// <summary>
/// 
/// Author: Maya Ashizumi-Munn
/// </summary>
public class CurrencyTable : MonoBehaviour
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

	public int GetUserCurrency()
	{
		//using (dbcon)
		//{
		//	//Check if connection is not already open
		//	if (!dbcon.ConnectionString.Equals(connection))
		//	{
		//		//Need to open connection if not connected
		//		openConnection();
		//	}

		//	int currentUserID = PlayerPrefs.GetInt("CurrentUserID");

		//	string query = "SELECT coins FROM currency WHERE userID = " + currentUserID;
		//	cmnd = new SqliteCommand(query, dbcon);
		//	int coins = Int32.Parse(cmnd.ExecuteScalar().ToString());

		//	dbcon.Close();
		//	return coins;
		//}

		int currentUserID = PlayerPrefs.GetInt("CurrentUserID");
		switch (currentUserID)
		{
			case 1:
				return PlayerPrefs.GetInt("UserOneCoins");
			case 2:
				return PlayerPrefs.GetInt("UserTwoCoins");
			case 3:
				return PlayerPrefs.GetInt("UserThreeCoins");
			default:
				return 0;
		}
	}

	public void AddToUserCurrency(int amountToAdd)
	{
		//using (dbcon)
		//{
		//	openConnection();

		//	int increasedAmount = this.GetUserCurrency() + amountToAdd;
		//	//Connection was closed by calling GetUserCurrency, open connection again
		//	openConnection();

		//	string query = "UPDATE currency SET coins = " + increasedAmount + " WHERE userID = " + PlayerPrefs.GetInt("CurrentUserID");

		//	dbcon.Close();
		//}

		int currentUserID = PlayerPrefs.GetInt("CurrentUserID");
		switch (currentUserID)
		{
			case 1:
				PlayerPrefs.SetInt("UserOneCoins", PlayerPrefs.GetInt("UserOneCoins") + amountToAdd);
				break;
			case 2:
				PlayerPrefs.SetInt("UserTwoCoins", PlayerPrefs.GetInt("UserTwoCoins") + amountToAdd);
				break;
			case 3:
				PlayerPrefs.SetInt("UserThreeCoins", PlayerPrefs.GetInt("UserThreeCoins") + amountToAdd);
				break;
		}
	}


	public void RemoveFromUserCurrency(int amountToRemove)
	{
		int currentUserID = PlayerPrefs.GetInt("CurrentUserID");
		switch (currentUserID)
		{
			case 1:
				PlayerPrefs.SetInt("UserOneCoins", PlayerPrefs.GetInt("UserOneCoins") - amountToRemove);
				break;
			case 2:
				PlayerPrefs.SetInt("UserTwoCoins", PlayerPrefs.GetInt("UserTwoCoins") - amountToRemove);
				break;
			case 3:
				PlayerPrefs.SetInt("UserThreeCoins", PlayerPrefs.GetInt("UserThreeCoins") - amountToRemove);
				break;
		}
	}

	public bool CheckIfUserCanAfford(int itemCost)
	{
		int currentUserID = PlayerPrefs.GetInt("CurrentUserID");
		switch (currentUserID)
		{
			case 1:
				if ((PlayerPrefs.GetInt("UserOneCoins") - itemCost) < 0)
				{
					//Cannot afford
					return false;
				}
				else
				{
					return true;
				}
			case 2:
				if ((PlayerPrefs.GetInt("UserTwoCoins") - itemCost) < 0)
				{
					//Cannot afford
					return false;
				}
				else
				{
					return true;
				}
			case 3:
				if ((PlayerPrefs.GetInt("UserThreeCoins") - itemCost) < 0)
				{
					//Cannot afford
					return false;
				}
				else
				{
					return true;
				}
			default:
				return false;
		}
	}
}
