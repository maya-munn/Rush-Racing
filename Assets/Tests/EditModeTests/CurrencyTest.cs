using NUnit.Framework;
using UnityEngine;

/// <summary>
/// Unit testing for user currency
/// This unit test requires a user profile to exist
/// Author: Maya Ashizumi-Munn
/// </summary>

namespace Tests
{
    public class CurrencyTest
    {
        CurrencyTable currencyScript;
        UserTable userScript; //Used to test if there is an existing user

        [SetUp]
        public void SetUp()
        {
            currencyScript = new CurrencyTable();
            userScript = new UserTable();
        }

        [Test]
        public void AddCurrency_Test()
        {
            //Check for existing user profiles
            bool usersExist = userScript.CheckForExistingUsers();
            if (usersExist == true)
            {
                //If there are existing users, can run the test

                //Test cases
                int initialTestBalance = currencyScript.GetUserCurrency();
                int amountToAdd = 300;
                int testBalance = initialTestBalance + amountToAdd;

                //Use method
                currencyScript.AddToUserCurrency(300);
                int methodBalance = currencyScript.GetUserCurrency();

                //Assert
                Assert.AreEqual(testBalance, methodBalance);
            }
            else
            {
                //No existing users. Must fail the test
                Assert.Fail("Cannot test adding currency when there are no existing users!");
            }
        }

        [Test]
        public void RemoveCurrency_Test()
        {
            //Check for existing user profiles
            bool usersExist = userScript.CheckForExistingUsers();
            if (usersExist == true)
            {
                //If there are existing users, can run the test

                //Test cases
                int initialTestBalance = currencyScript.GetUserCurrency();
                int amountToRemove = 50;
                int testBalance = initialTestBalance - amountToRemove;

                //Use method
                currencyScript.RemoveFromUserCurrency(50);
                int methodBalance = currencyScript.GetUserCurrency();

                //Assert
                Assert.AreEqual(testBalance, methodBalance);
            }
            else
            {
                //No existing users. Must fail the test
                Assert.Fail("Cannot test removing currency when there are no existing users!");
            }
        }

        [Test]
        public void CheckIfCanAfford_Test()
        {
            //Check for existing user profiles
            bool usersExist = userScript.CheckForExistingUsers();
            if (usersExist == true)
            {
                //Test cases
                int initialTestBalance = currencyScript.GetUserCurrency();
                int itemCost = 20000;
                bool testCanAfford = (initialTestBalance - itemCost) >= 0; //If greater or equal to 0, player can afford

                //Use method
                bool methodCanAfford = currencyScript.CheckIfUserCanAfford(itemCost);

                //Assert
                Assert.AreEqual(testCanAfford, methodCanAfford);
            }
            else
            {
                //No existing users. Must fail the test
                Assert.Fail("Cannot test when there are no existing users!");
            }
        }
    }
}
