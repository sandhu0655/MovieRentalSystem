using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRentalSystem
{
    public class Database
    {

        private SqlConnection myConnection = new SqlConnection();
        private SqlCommand myCommand = new SqlCommand();
        private SqlDataAdapter da = new SqlDataAdapter();
        public Database()
        {
            // connect to the Movies Database
            string connectionString =
                @"Data Source=LAPTOP-RAKIOMBV\SQLEXPRESS;Initial Catalog=MoviesDatabase;Integrated Security=True;";
            myConnection.ConnectionString = connectionString;
            myCommand.Connection = myConnection;
        }
        /// <summary>
        /// SELECT * FROM Customers
        /// </summary>
        public DataTable FillCustomersDGV()
        {
            // Create a data table
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("SELECT * FROM Customers", myConnection))
            {
                // open a connection to the database
                myConnection.Open();
                // fill the datatable with the data from the SQL
                da.Fill(dt);
                // close the database connection
                myConnection.Close();
            }
            // pass the datatable data to the DGV
            return dt;
        }
        /// <summary>
        /// Add New Customer to DB
        /// </summary>
        public void AddNewCustomerToDB(string firstName, string lastName, string address, string phone)
        {
            try
            {
                // set the query to the SQL variable
                string SQL = "INSERT INTO Customers (FirstName, LastName, Address, Phone) VALUES (@First, @Last, @Address, @Phone)";

                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    // set the parameters
                    myCommand.Parameters.AddWithValue("First", firstName);
                    myCommand.Parameters.AddWithValue("Last", lastName);
                    myCommand.Parameters.AddWithValue("Address", address);
                    myCommand.Parameters.AddWithValue("Phone", phone);
                    //open a connection to the DB
                    myConnection.Open();
                    // run the query
                    myCommand.ExecuteNonQuery();
                    // close the connection
                    myConnection.Close();
                }
                // alert user that the query was successful
                MessageBox.Show("The new customer has been added to the database.");
            }
            // alert the user if there was an error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Edit Customer in DB
        /// </summary>
        public void EditCustomerInDB(int customerID, string firstName, string lastName, string address, string phone)
        {
            // only run if there is something in the textboxes 
            if (firstName != "" && lastName != "" && address != "" && phone != "")
            {
                try
                {
                    // set the query to the SQL variable
                    string SQL = "UPDATE Customers SET FirstName = @First, LastName = @Last, Address = @Address, Phone = @Phone WHERE CustID = @Id";

                    using (da = new SqlDataAdapter(SQL, myConnection))
                    {
                        var myCommand = new SqlCommand(SQL, myConnection);
                        // set the parameters
                        myCommand.Parameters.AddWithValue("Id", customerID);
                        myCommand.Parameters.AddWithValue("First", firstName);
                        myCommand.Parameters.AddWithValue("Last", lastName);
                        myCommand.Parameters.AddWithValue("Address", address);
                        myCommand.Parameters.AddWithValue("Phone", phone);
                        //open a connection to the DB
                        myConnection.Open();
                        // run the query
                        myCommand.ExecuteNonQuery();
                        // close the connection
                        myConnection.Close();
                    }
                    // alert user that the query was successful
                    MessageBox.Show("The customer details have been edited in the database.");
                }
                // alert the user if there was an error
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                // prompt user to complete all text fields
                MessageBox.Show("Please complete all textboxes.");
            }
        }
        /// <summary>
        /// Delete the selected customer
        /// </summary>
        public void DeleteCustomer(int CustomerId)
        {
            try
            {
                // set the query to the SQL variable
                string SQL = "DELETE FROM Customers WHERE CustID = @Id";

                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    // set the parameters
                    myCommand.Parameters.AddWithValue("Id", CustomerId);
                    //open a connection to the DB
                    myConnection.Open();
                    // run the query
                    myCommand.ExecuteNonQuery();
                    // close the connection
                    myConnection.Close();
                }
                // alert user that the query was successful
                MessageBox.Show("This customer has been deleted from the database.");
            }
            // alert the user if there was an error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// SELECT * FROM Movies
        /// </summary>
        public DataTable FillMoviesDGV()
        {
            // Create a data table
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("SELECT * FROM Movies", myConnection))
            {
                // open a connection to the database
                myConnection.Open();
                // fill the datatable with the data from the SQL
                da.Fill(dt);
                // close the database connection
                myConnection.Close();
            }
            // pass the datatable data to the DGV
            return dt;
        }
        /// <summary>
        /// Add new movie to DB
        /// </summary>
        public void AddNewMovieToDB(string rating, string title, string year, string cost, string copies, string plot, string genre)
        {
            try
            {
                // set the query to the SQL variable
                string SQL = "INSERT INTO Movies (Rating, Title, Year, Rental_Cost, Copies, Plot, Genre) VALUES (@Rating, @Title, @Year, @Cost, @Copies, @Plot, @Genre)";

                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    // set the parameters
                    myCommand.Parameters.AddWithValue("Rating", rating);
                    myCommand.Parameters.AddWithValue("Title", title);
                    myCommand.Parameters.AddWithValue("Year", year);
                    myCommand.Parameters.AddWithValue("Cost", cost);
                    myCommand.Parameters.AddWithValue("Copies", copies);
                    myCommand.Parameters.AddWithValue("Plot", plot);
                    myCommand.Parameters.AddWithValue("Genre", genre);
                    //open a connection to the DB
                    myConnection.Open();
                    // run the query
                    myCommand.ExecuteNonQuery();
                    // close the connection
                    myConnection.Close();
                }
                // alert user that the query was successful
                MessageBox.Show("The new movie has been added to the database.");
            }
            // alert the user if there was an error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Edit movie in DB
        /// </summary>
        public void EditMovieInDB(int movieId, string rating, string title, string year, string cost, string copies, string plot, string genre)
        {
            try
            {
                // set the query to the SQL variable
                string SQL = "UPDATE Movies SET Rating = @Rating, Title = @Title, Year = @Year, Rental_Cost = @Cost, Copies = @Copies, Plot = @Plot, Genre = @Genre WHERE MovieID = @Id";

                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    // set the parameters
                    myCommand.Parameters.AddWithValue("Id", movieId);
                    myCommand.Parameters.AddWithValue("Rating", rating);
                    myCommand.Parameters.AddWithValue("Title", title);
                    myCommand.Parameters.AddWithValue("Year", year);
                    myCommand.Parameters.AddWithValue("Cost", cost);
                    myCommand.Parameters.AddWithValue("Copies", copies);
                    myCommand.Parameters.AddWithValue("Plot", plot);
                    myCommand.Parameters.AddWithValue("Genre", genre);
                    //open a connection to the DB
                    myConnection.Open();
                    // run the query
                    myCommand.ExecuteNonQuery();
                    // close the connection
                    myConnection.Close();
                }
                // alert user that the query was successful
                MessageBox.Show("The movie details have been updated in the database.");
            }
            // alert the user if there was an error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Delete selected movie from the DB
        /// </summary>
        public void DeleteMovie(int movieId)
        {
            try
            {
                // set the query to the SQL variable
                string SQL = "DELETE FROM Movies WHERE MovieID = @Id";

                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    // set the parameters
                    myCommand.Parameters.AddWithValue("Id", movieId);
                    //open a connection to the DB
                    myConnection.Open();
                    // run the query
                    myCommand.ExecuteNonQuery();
                    // close the connection
                    myConnection.Close();
                }
                // alert user that the query was successful
                MessageBox.Show("This movie has been deleted from the database.");
            }
            // alert the user if there was an error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// SELECT * FROM Rentals
        /// </summary>
        public DataTable FillRentalsDGV()
        {
            // Create a data table
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("SELECT * FROM Rentals", myConnection))
            {
                // open a connection to the database
                myConnection.Open();
                // fill the datatable with the data from the SQL
                da.Fill(dt);
                // close the database connection
                myConnection.Close();
            }
            // pass the datatable data to the DGV
            return dt;
        }
        /// <summary>
        /// SELECT * FROM RentalsOutNow
        /// </summary>
        public DataTable ShowRentedOutMovies()
        {
            // Create a data table
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("SELECT * FROM RentalsOutNow", myConnection))
            {
                // open a connection to the database
                myConnection.Open();
                // fill the datatable with the data from the SQL
                da.Fill(dt);
                // close the database connection
                myConnection.Close();
            }
            // pass the datatable data to the DGV
            return dt;
        }
        /// <summary>
        /// Update selected movie with DateReturned
        /// </summary>
        public void ReturnMovie(int rentalId)
        {
            string currentDate = DateTime.Now.ToString();
            DateTime date = Convert.ToDateTime(currentDate);
            try
            {
                // set the query to the SQL variable
                string SQL = "UPDATE RentedMovies SET DateReturned = @Date WHERE RMID = @Id";

                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    // set the parameters
                    myCommand.Parameters.AddWithValue("Id", rentalId);
                    myCommand.Parameters.AddWithValue("Date", date);
                    //open a connection to the DB
                    myConnection.Open();
                    // run the query
                    myCommand.ExecuteNonQuery();
                    // close the connection
                    myConnection.Close();
                }
                // alert user that the query was successful
                MessageBox.Show("This movie has been successfully returned.");
            }
            // alert the user if there was an error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Rent out a movie
        /// </summary>
        public void RentOutMovie(int customer, int movie, DateTime date)
        {
            try
            {
                // set the query to the SQL variable
                string SQL = "INSERT INTO RentedMovies (MovieIDFK, CustIDFK, DateRented) VALUES (@Movie, @Customer, @Date)";

                using (da = new SqlDataAdapter(SQL, myConnection))
                {
                    var myCommand = new SqlCommand(SQL, myConnection);
                    // set the parameters
                    myCommand.Parameters.AddWithValue("Customer", customer);
                    myCommand.Parameters.AddWithValue("Movie", movie);
                    myCommand.Parameters.AddWithValue("Date", date);

                    //open a connection to the DB
                    myConnection.Open();
                    // run the query
                    myCommand.ExecuteNonQuery();
                    // close the connection
                    myConnection.Close();
                }
                // alert user that the query was successful
                MessageBox.Show("The movie has been issued successfully.");
            }
            // alert the user if there was an error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Search for customers first name
        /// </summary>
        public DataTable SearchCustomers(string search)
        {
            DataTable dt = new DataTable();
            string SQL = "SELECT * FROM Customers WHERE FirstName LIKE @SearchName";
            using (da = new SqlDataAdapter(SQL, myConnection))
            {
                // set the parameters
                da.SelectCommand.Parameters.AddWithValue("@SearchName", "%" + search + "%");
                // open a connection to the DB
                myConnection.Open();
                // fill the datatable with results from the query
                da.Fill(dt);
                // close the connection
                myConnection.Close();
            }

            // pass the datatable data to the DGV
            return dt;
        }
        /// <summary>
        /// SELECT * FROM TopCustomers
        /// </summary>
        public DataTable ShowTopCustomers()
        {
            // Create a data table
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("SELECT * FROM TopCustomers", myConnection))
            {
                // open a connection to the database
                myConnection.Open();
                // fill the datatable with the data from the SQL
                da.Fill(dt);
                // close the database connection
                myConnection.Close();
            }
            // pass the datatable data to the DGV
            return dt;
        }
        /// <summary>
        /// SELECT * FROM TopMovies
        /// </summary>
        public DataTable ShowTopMovies()
        {
            // Create a data table
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("SELECT TopMovies.*, Movies.Plot FROM TopMovies, Movies WHERE TopMovies.MovieID = Movies.MovieID", myConnection))
            {
                // open a connection to the database
                myConnection.Open();
                // fill the datatable with the data from the SQL
                da.Fill(dt);
                // close the database connection
                myConnection.Close();
            }
            // pass the datatable data to the DGV
            return dt;
        }
        /// <summary>
        /// Search for movie title
        /// </summary>
        public DataTable SearchMovies(string search)
        {
            DataTable dt = new DataTable();
            // set the query to the SQL variable
            string SQL = "SELECT * FROM Movies WHERE Title LIKE @SearchName";
            da = new SqlDataAdapter(SQL, myConnection);
            // set the parameters
            da.SelectCommand.Parameters.AddWithValue("@SearchName", "%" + search + "%");
            da.Fill(dt);

            // pass the datatable data to the DGV
            return dt;
        }
        /// <summary>
        /// Count how many copies of the movie are rented out currently
        /// </summary>
        public int CheckCopiesOut(int MID)
        {
            // set the query to the SQL variable
            string SQL = "SELECT Count(*) FROM RentedMovies WHERE MovieIDFK = @MID AND DateReturned IS NULL";

            using (da = new SqlDataAdapter(SQL, myConnection))
            {
                var myCommand = new SqlCommand(SQL, myConnection);
                // set the parameters
                myCommand.Parameters.AddWithValue("MID", MID);

                //open a connection to the DB
                myConnection.Open();
                // run the query
                int result = Convert.ToInt16(myCommand.ExecuteScalar());
                // close the connection
                myConnection.Close();
                return result;
            }
        }
    }
}
