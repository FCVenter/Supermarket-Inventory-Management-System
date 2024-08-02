using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoolworthsInventorySystem
{
    public partial class AddCustomer : Form
    {
        public Customer newCustomer;
        private BuyProducts frmBuyProducts;
        private ViewCustomerDatabase frmViewCustomerDatabase;
        public AddCustomer(BuyProducts frmBuyProducts)
        {
            InitializeComponent();
            this.frmBuyProducts = frmBuyProducts;
            this.frmViewCustomerDatabase = null;
            newCustomer = new Customer();
        }

        public AddCustomer(ViewCustomerDatabase frmViewCustomerDatabase)
        {
            InitializeComponent();
            this.frmBuyProducts = null;
            this.frmViewCustomerDatabase = frmViewCustomerDatabase;
            newCustomer = new Customer();
        }

        private void btnAddCustomersCreateAcc_Click(object sender, EventArgs e)
        {
            InsertDetails();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

        }

        private void InsertDetails()
        {
            // Input validation
            if (string.IsNullOrEmpty(txtAddCustomerName.Text))
            {
                MessageBox.Show("Please enter a valid name.");
                return;
            }

            if (string.IsNullOrEmpty(txtAddCustomerAddress.Text))
            {
                MessageBox.Show("Please enter a valid address.");
                return;
            }

            if (string.IsNullOrEmpty(txtAddCustomerPhoneNumber.Text.Trim()) || !Regex.IsMatch(txtAddCustomerPhoneNumber.Text.Trim(), @"^0\d{9}$"))
            {
                MessageBox.Show("Please enter a valid 10-digit phone number.");
                return;
            }

            if (string.IsNullOrEmpty(txtAddCustomerEmail.Text) || !Regex.IsMatch(txtAddCustomerEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) // Simple email validation
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            newCustomer.CustomerName = txtAddCustomerName.Text;
            newCustomer.CustomerAddress = txtAddCustomerAddress.Text;
            newCustomer.CustomerPhoneNumber = "+27" + txtAddCustomerPhoneNumber.Text.Substring(1);
            newCustomer.CustomerEmail = txtAddCustomerEmail.Text;

            
            try
            {
                // Use the UpdateCustomer method from the Customer class to update the customer details
                int newCustomerID = Customer.InsertCustomer(newCustomer);
                newCustomer.CustomerID = newCustomerID;

                MessageBox.Show("You have successfully been registered!");

                if (frmBuyProducts != null)
                {
                    frmBuyProducts.Show();
                }
                else
                {
                    frmViewCustomerDatabase.Show();
                    frmViewCustomerDatabase.RefreshGridView();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the insert operation
                MessageBox.Show($"An error occurred while inserting a new customer: {ex.Message}");
            }
        }

        private void btnAddCustomersBack_Click(object sender, EventArgs e)
        {
            if (frmBuyProducts != null)
                frmBuyProducts.Show();
            else
                frmViewCustomerDatabase.Show();

            this.Close();

        }
    }
}
