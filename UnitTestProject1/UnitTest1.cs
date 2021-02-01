using System;
using System.Data;
using MovieRentalSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Database d = new Database();
        /// <summary>
        /// Test Customer Search when customer(s) do exist
        /// </summary>
        [TestMethod]
        public void TestCustomerSearchValue()
        {
            string searchValue = "jess";
            DataTable result = d.SearchCustomers(searchValue);
            int x = 3;
            Assert.AreEqual(x, result.Rows.Count);
        }
        /// <summary>
        /// Test customer search when customer does not exist
        /// </summary>
        [TestMethod]
        public void TestCustomerSearchNoValue()
        {
            string searchValue = "katie";
            DataTable result = d.SearchCustomers(searchValue);
            int x = 0;
            Assert.AreEqual(x, result.Rows.Count);
        }
        /// <summary>
        /// Test when the movie is currently rented out
        /// </summary>
        [TestMethod]
        public void TestCheckCopiesRentalsOut()
        {
            int MID = 9;
            int x = 1;

            Assert.AreEqual(x, d.CheckCopiesOut(MID));
        }
        /// <summary>
        /// Test when the movie is not out currently
        /// </summary>
        [TestMethod]
        public void TestCheckCopiesNoRentals()
        {
            int MID = 3;
            int x = 0;

            Assert.AreEqual(x, d.CheckCopiesOut(MID));
        }
    }
}
