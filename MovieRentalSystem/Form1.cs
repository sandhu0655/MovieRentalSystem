using System;
using System.Windows.Forms;

namespace MovieRentalSystem
{
    public partial class Form1 : Form
    {
        Database myDatabase = new Database();
        // set properties for customer/movie/rental ID
        public int CID { get; set; }
        public int MID { get; set; }
        public int RID { get; set; }

        public Form1()
        {
            InitializeComponent();
            LoadDB();
        }
        /// <summary>
        /// Show all the database tables in the 3 DGVs
        /// </summary>
        public void LoadDB()
        {
            DisplayCustomersDGV();
            DisplayMoviesDGV();
            DisplayRentalsDGV();
        }
        /// <summary>
        /// Set the data source to display the customers table. Show error if doesn't work
        /// </summary>
        private void DisplayCustomersDGV()
        {
            // Clear out any old data
            dgvCustomers.DataSource = null;
            try
            {
                dgvCustomers.DataSource = myDatabase.FillCustomersDGV();
                dgvCustomers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Customers DGV Cell Click
        /// </summary>
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // if user clicks a cell with data in it
            if (e.RowIndex >= 0)
            {
                // give value to customer ID
                int CustomerID = 0;
                try
                {
                    // set customer ID
                    CustomerID = (int)dgvCustomers.Rows[e.RowIndex].Cells[0].Value;
                    // display selected customer details in textboxes
                    txtFirstName.Text = dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtLastName.Text = dgvCustomers.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtAddress.Text = dgvCustomers.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtPhone.Text = dgvCustomers.Rows[e.RowIndex].Cells[4].Value.ToString();
                    // display selected customer details as a label outside of tabs
                    lblCustDetails.Text = dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString() + " ";
                    lblCustDetails.Text += dgvCustomers.Rows[e.RowIndex].Cells[2].Value.ToString() + "    ";
                    lblCustDetails.Text += dgvCustomers.Rows[e.RowIndex].Cells[3].Value.ToString() + "    ";
                    lblCustDetails.Text += dgvCustomers.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
                // show error message if there is any errors doing above code
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // give the value of customerID to the CID property for later use
                CID = CustomerID;
                MakeIssueMovieButtonVisible();
            }
        }
        /// <summary>
        /// 'Add Customer' button clicked
        /// </summary>
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            // collect text from text boxes and assign to variables
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;

            // call database method to add new customer
            myDatabase.AddNewCustomerToDB(firstName, lastName, address, phone);
            // refresh dgv displaying the new customer
            DisplayCustomersDGV();
            // clear data from textboxes
            firstName = "";
            lastName = "";
            address = "";
            phone = "";
        }
        /// <summary>
        /// 'Edit Customer' button clicked
        /// </summary>
        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            // collect text from text boxes and assign to variables
            int customerID = CID;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;

            // call the database method to edit customers
            myDatabase.EditCustomerInDB(customerID, firstName, lastName, address, phone);
            // refresh dgv displaying the updated information
            DisplayCustomersDGV();
            // clear data from textboxes
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
        }
        /// <summary>
        /// 'Delete Customer' button clicked
        /// </summary>
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            int CustomerId = CID;
            // call the database method to delete customer
            myDatabase.DeleteCustomer(CustomerId);
            // refresh dgv
            DisplayCustomersDGV();
        }
        /// <summary>
        /// Set the data source to display the movies table. Show error if doesn't work
        /// </summary>
        private void DisplayMoviesDGV()
        {
            // Clear out any old data
            dgvMovies.DataSource = null;
            try
            {
                dgvMovies.DataSource = myDatabase.FillMoviesDGV();
                dgvMovies.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Movies DGV Cell Click
        /// </summary>
        private void dgvMovies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // if user clicks a cell with data in it
            if (e.RowIndex >= 0)
            {
                // give value to movie ID
                int MovieID = 0;
                try
                {
                    // set movie ID
                    MovieID = (int)dgvMovies.Rows[e.RowIndex].Cells[0].Value;
                    //int movie = MovieID;
                    // display selected movie details in textboxes
                    txtTitle.Text = dgvMovies.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtYear.Text = dgvMovies.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtRating.Text = dgvMovies.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtCost.Text = dgvMovies.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtCopies.Text = dgvMovies.Rows[e.RowIndex].Cells[5].Value.ToString();
                    // row indexes are different for top movies table and all movies table
                    if (radTopMovies.Checked == false)
                    {
                        txtGenre.Text = dgvMovies.Rows[e.RowIndex].Cells[7].Value.ToString();
                        txtPlot.Text = dgvMovies.Rows[e.RowIndex].Cells[6].Value.ToString();
                    }
                    else
                    {
                        txtGenre.Text = dgvMovies.Rows[e.RowIndex].Cells[6].Value.ToString();
                        txtPlot.Text = dgvMovies.Rows[e.RowIndex].Cells[8].Value.ToString();
                    }
                    // display movie title and rating as a label outside of tabs
                    lblMovieDetails.Text = dgvMovies.Rows[e.RowIndex].Cells[2].Value.ToString() + "   ";
                    lblMovieDetails.Text += dgvMovies.Rows[e.RowIndex].Cells[1].Value.ToString() + "   ";
                    int year = Convert.ToInt16(dgvMovies.Rows[e.RowIndex].Cells[3].Value);
                    // if the movie is less than 5 years old
                    if (year >= 2013)
                    {
                        // display cost is $5
                        lblMovieDetails.Text += "$5.00";
                    }
                    // if the movie is older than 5 years
                    else
                    {
                        // display cost is $2
                        lblMovieDetails.Text += "$2.00";
                    }
                }
                // display error text if there is an error while running the above code
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // give the value of movie id to MID for later use
                MID = MovieID;
                // set copies variable
                string copies = dgvMovies.Rows[e.RowIndex].Cells[5].Value.ToString();
                // if there is a set value for number of copies call the function
                if (copies != "")
                {
                    CheckNumberOfCopies(MID, copies);
                }
                else
                {
                    MakeIssueMovieButtonVisible();
                }
            }
        }
        /// <summary>
        /// Check the number of copies available against the copies currently rented out
        /// </summary>
        private void CheckNumberOfCopies(int MID, string copies)
        {
            // check the database to see how many copies are available
            // assign this amount to a variable
            int available = myDatabase.CheckCopiesOut(MID);
            // convert total number of copies of movie to an int
            int total = Convert.ToInt16(copies);
            // if the number of available copies is less than the total
            if (available < total)
            {
                MakeIssueMovieButtonVisible();
            }
            // display a message that the movie can not be rented at this time
            else
            {
                MessageBox.Show("Sorry that movie is not available at this time.");
                lblMovieDetails.Text = "";
                btnIssue.Visible = false;
            }
        }
        /// <summary>
        /// 'Add Movie' Button clicked
        /// </summary>
        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            // set variables from textbox fields
            string rating = txtRating.Text;
            string title = txtTitle.Text;
            string year = txtYear.Text;
            string cost = txtCost.Text;
            string copies = txtCopies.Text;
            string plot = txtPlot.Text;
            string genre = txtGenre.Text;

            // call database method to add new movie
            myDatabase.AddNewMovieToDB(rating, title, year, cost, copies, plot, genre);
            // refresh dgv to display new movie
            DisplayMoviesDGV();
            // clear data from textboxes
            rating = "";
            title = "";
            year = "";
            cost = "";
            copies = "";
            plot = "";
            genre = "";
        }
        /// <summary>
        /// 'Edit Movie' Button clicked
        /// </summary>
        private void btnEditMovie_Click(object sender, EventArgs e)
        {
            int movieID = MID;

            // set variables from textbox fields
            string rating = txtRating.Text;
            string title = txtTitle.Text;
            string year = txtYear.Text;
            string cost = txtCost.Text;
            string copies = txtCopies.Text;
            string plot = txtPlot.Text;
            string genre = txtGenre.Text;

            // call database method to add new movie
            myDatabase.EditMovieInDB(movieID, rating, title, year, cost, copies, plot, genre);
            // refresh dgv to show updated movie
            DisplayMoviesDGV();

            // clear data from textboxes
            txtTitle.Text = "";
            txtGenre.Text = "";
            txtYear.Text = "";
            txtRating.Text = "";
            txtCost.Text = "";
            txtCopies.Text = "";
            txtPlot.Text = "";
        }
        /// <summary>
        /// 'Delete Movie' Button clicked
        /// </summary>
        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this movie?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            // if user clicks ok
            if (result.Equals(DialogResult.OK))
            {
                int MovieId = MID;
                // call the database method to delete customer
                myDatabase.DeleteMovie(MovieId);
                // refresh dgv
                DisplayMoviesDGV();
            }
        }
        /// <summary>
        /// Set the data source to display the rentals table. Show error if doesn't work
        /// </summary>
        private void DisplayRentalsDGV()
        {
            // Clear out any old data
            dgvRentals.DataSource = null;
            // set dgv data source to display the rentals table
            try
            {
                dgvRentals.DataSource = myDatabase.FillRentalsDGV();
                dgvRentals.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // if rental is returned while showing only rentals currently out
            // so that dgv resets to inital datasource and inital radbtn values
            radShowAll.Checked = true;
            radShowOut.Checked = false;
        }
        /// <summary>
        /// Rentals DGV Cell Click
        /// </summary>
        private void dgvRentals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RentalID = 0;
            // make 'issue movie' button invisible
            btnIssue.Visible = false;
            try
            {
                // show 'issued' and 'returned' labels
                lblIssued.Visible = true;
                lblReturned.Visible = true;
                // show customer and movie name in labels and date that movie was issued
                RentalID = (int)dgvRentals.Rows[e.RowIndex].Cells[0].Value;
                lblCustDetails.Text = dgvRentals.Rows[e.RowIndex].Cells[1].Value.ToString() + " ";
                lblCustDetails.Text += dgvRentals.Rows[e.RowIndex].Cells[2].Value.ToString();
                lblMovieDetails.Text = dgvRentals.Rows[e.RowIndex].Cells[3].Value.ToString();
                lblIssue.Text = dgvRentals.Rows[e.RowIndex].Cells[4].Value.ToString();
                // display the 'return movie' button
                btnReturn.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // set value of the rental ID to RID for future use
            RID = RentalID;
        }
        /// <summary>
        /// "Return Movie" button clicked
        /// </summary>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            int rentalId = RID;

            // call database method to return movie
            myDatabase.ReturnMovie(rentalId);
            // refresh dgv
            DisplayRentalsDGV();
            // clear data
            lblCustDetails.Text = "";
            lblMovieDetails.Text = "";
            lblIssue.Text = "";
            lblIssued.Visible = false;
            btnReturn.Visible = false;
        }
        /// <summary>
        /// 'Issue Movie' button clicked
        /// </summary>
        private void btnIssue_Click(object sender, EventArgs e)
        {
            int customer = CID;
            int movie = MID;
            string date = DateTime.Now.ToString();
            DateTime currentDate = Convert.ToDateTime(date);

            // call the database method to add to rented movies
            myDatabase.RentOutMovie(customer, movie, currentDate);
            // refresh rented movies dgv
            DisplayRentalsDGV();
            // show rented movies dgv
            tabControl1.SelectedIndex = 2;

            // clear data
            lblCustDetails.Text = "";
            lblMovieDetails.Text = "";
            btnIssue.Visible = false;
        }
        /// <summary>
        /// Display 'Issue Movie' button when a customer and movie has been selected
        /// </summary>
        private void MakeIssueMovieButtonVisible()
        {
            // only make the issue movie button available if a customer and movie have both been selected
            if (lblCustDetails.Text != "" && lblMovieDetails.Text != "")
            {
                btnIssue.Visible = true;
            }
        }
        /// <summary>
        /// 'Search customers' button clicked
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayCustomerSearchInDGV();
            // display clear search btn
            btnClearCust.Visible = true;
        }
        /// <summary>
        /// Set the data source to display the customers search result. Show error if doesn't work
        /// </summary>
        public void DisplayCustomerSearchInDGV()
        {
            // get name of customer that is being searched for
            string search = txtCustSearch.Text;

            // Clear out any old data
            dgvCustomers.DataSource = null;
            // set the data source of the dgv to show the search results in the table
            try
            {
                dgvCustomers.DataSource = myDatabase.SearchCustomers(search);
                dgvCustomers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                if (dgvCustomers.Rows.Count == 0)
                {
                    MessageBox.Show("There are no customers with this name.");
                    DisplayCustomersDGV();
                    btnClearCust.Visible = false;
                    txtCustSearch.Text = "";
                }
            }
            // display a message if there is any errors with the above code
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 'Clear customers search' button clicked
        /// </summary>
        private void btnClearCust_Click(object sender, EventArgs e)
        {
            // load up full customers table
            DisplayCustomersDGV();
            // clear search textbox
            txtCustSearch.Text = "";
            // remove 'clear search' button
            btnClearCust.Visible = false;
        }
        /// <summary>
        /// 'Show currently out rentals' radio button checked
        /// </summary>
        private void radShowOut_CheckedChanged(object sender, EventArgs e)
        {
            // radio button to show only movies currently out gets clicked
            if (radShowOut.Checked == true)
            {
                // uncheck show all movies radio button
                radShowAll.Checked = false;
                // Clear out any old data
                dgvRentals.DataSource = null;
                // set data source of dgv to show the currently out movies view
                try
                {
                    dgvRentals.DataSource = myDatabase.ShowRentedOutMovies();
                    dgvRentals.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                }
                // show message if there are any errors in above code
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// 'Show all rentals' radio button checked
        /// </summary>
        private void radShowAll_CheckedChanged(object sender, EventArgs e)
        {
            // radio button to show all movies is clicked
            if (radShowAll.Checked == true)
            {
                // uncheck radio button to show only currently out rentals
                radShowOut.Checked = false;
                // call method to display the complete rentals table
                DisplayRentalsDGV();
            }
        }
        /// <summary>
        /// 'Show top 10 customers' radio button checked
        /// </summary>
        private void radTopCust_CheckedChanged(object sender, EventArgs e)
        {
            // radio button for show top 10 customers is checked
            if (radTopCust.Checked == true)
            {
                // uncheck show all customers radio button
                radAllCust.Checked = false;
                // Clear out any old data
                dgvCustomers.DataSource = null;
                // set dgv data source to view to display top 10 customers
                try
                {
                    dgvCustomers.DataSource = myDatabase.ShowTopCustomers();
                    dgvCustomers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                    // make address and phone column invisible
                    dgvCustomers.Columns[3].Visible = false;
                    dgvCustomers.Columns[4].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// 'Show all customers' radio button checked
        /// </summary>
        private void radAllCust_CheckedChanged(object sender, EventArgs e)
        {
            // show all customers radio button is checked
            if (radAllCust.Checked == true)
            {
                // uncheck show top customers radio button
                radTopCust.Checked = false;
                // call method to display full customers table
                DisplayCustomersDGV();
            }
        }
        /// <summary>
        /// 'Show top 10 movies' radio button checked
        /// </summary>
        private void radTopMovies_CheckedChanged(object sender, EventArgs e)
        {
            // radio button top movies is checked
            if (radTopMovies.Checked == true)
            {
                // uncheck show all movies radio button
                radAllMovies.Checked = false;
                // Clear out any old data
                dgvMovies.DataSource = null;
                try
                {
                    // set dgv data source to the view to show only top 10 movies
                    dgvMovies.DataSource = myDatabase.ShowTopMovies();
                    dgvMovies.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                    // make all columns invisible except movie name
                    dgvMovies.Columns[1].Visible = false;
                    dgvMovies.Columns[3].Visible = false;
                    dgvMovies.Columns[4].Visible = false;
                    dgvMovies.Columns[5].Visible = false;
                    dgvMovies.Columns[6].Visible = false;
                    dgvMovies.Columns[8].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// 'Show all movies' radio button checked
        /// </summary>
        private void radAllMovies_CheckedChanged(object sender, EventArgs e)
        {
            // show all movies radio button is checked
            if (radAllMovies.Checked == true)
            {
                // uncheck show top movies radio button
                radTopMovies.Checked = false;
                // show all movies dgv
                DisplayMoviesDGV();
            }
        }
        /// <summary>
        /// 'Search movies' button clicked
        /// </summary>
        private void btnSearchMov_Click(object sender, EventArgs e)
        {
            // call method
            DisplayMovieSearchInDGV();
            // display 'clear search' button
            btnClearMov.Visible = true;
        }
        /// <summary>
        /// Set the data source to display the movies search result. Show error if doesn't work
        /// </summary>
        private void DisplayMovieSearchInDGV()
        {
            // get search term from text box
            string search = txtSearchMov.Text;

            // Clear out any old data
            dgvMovies.DataSource = null;
            try
            {
                // set dgv data source to show only movies with titles that match the search result
                dgvMovies.DataSource = myDatabase.SearchMovies(search);
                dgvMovies.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                if (dgvMovies.Rows.Count == 0)
                {
                    MessageBox.Show("There are no movies with this title.");
                    DisplayMoviesDGV();
                    btnClearMov.Visible = false;
                    txtSearchMov.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 'Clear movies search' button clicked
        /// </summary>
        private void btnClearMov_Click(object sender, EventArgs e)
        {
            // show all movies 
            DisplayMoviesDGV();
            // clear search textbox
            txtSearchMov.Text = "";
            // make 'clear search' button invisible
            btnClearMov.Visible = false;
        }
    }
}
