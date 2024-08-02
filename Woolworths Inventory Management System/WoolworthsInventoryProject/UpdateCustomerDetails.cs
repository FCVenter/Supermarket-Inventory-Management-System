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
    public partial class UpdateCustomerDetails : Form
    {
        private Customer updatedCustomer;
        public UpdateCustomerDetails(Customer updatedCustomer)
        {
            InitializeComponent();
            this.updatedCustomer = updatedCustomer;
        }

        private void UpdateCustomerDetails_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            FillCustomerDetailsToTextBoxes(updatedCustomer);
            txtUpdateCustomerDetailsName.Focus();
        }

        private void btnContinueShopping_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateCustomerDetailsUpdateDetails_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateDetails();
                this.Close();
            }
            catch (Exception E) 
            {
                MessageBox.Show("An error occurred while updating details.");
            }
        }

        /// <summary>
        /// Fills the textboxes with the details of the provided customer.
        /// </summary>
        /// <param name="customer">The customer whose details need to be displayed.</param>
        private void FillCustomerDetailsToTextBoxes(Customer customer)
        {
            if (customer == null)
            {
                MessageBox.Show("Invalid customer provided.");
                return;
            }

            // Fill each textbox with the corresponding property of the customer
            txtUpdateCustomerDetailsName.Text = customer.CustomerName;
            txtUpdateCustomerDetailsAddress.Text = customer.CustomerAddress;
            txtUpdateCustomerDetailsPhoneNumber.Text = customer.CustomerPhoneNumber;
            txtUpdateCustomerDetailsEmail.Text = customer.CustomerEmail;
        }


        /// <summary>
        /// Updates customer details based on the information provided in textboxes.
        /// </summary>
        private void UpdateDetails()
        {
            // Input validation
            if (string.IsNullOrEmpty(txtUpdateCustomerDetailsName.Text))
            {
                MessageBox.Show("Please enter a valid name.");
                return;
            }

            if (string.IsNullOrEmpty(txtUpdateCustomerDetailsAddress.Text))
            {
                MessageBox.Show("Please enter a valid address.");
                return;
            }

            if (string.IsNullOrEmpty(txtUpdateCustomerDetailsPhoneNumber.Text) || !Regex.IsMatch(txtUpdateCustomerDetailsPhoneNumber.Text, @"^\+\d{11}$")) // Assuming a phone number format like +27887654321
            {
                MessageBox.Show("Please enter a valid 10-digit phone number.");
                return;
            }

            if (string.IsNullOrEmpty(txtUpdateCustomerDetailsEmail.Text) || !Regex.IsMatch(txtUpdateCustomerDetailsEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) // Simple email validation
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            updatedCustomer.CustomerName = txtUpdateCustomerDetailsName.Text;
            updatedCustomer.CustomerAddress = txtUpdateCustomerDetailsAddress.Text;
            updatedCustomer.CustomerPhoneNumber = txtUpdateCustomerDetailsPhoneNumber.Text;
            updatedCustomer.CustomerEmail = txtUpdateCustomerDetailsEmail.Text;

            ErrorMessage frmError = new ErrorMessage();
            frmError.lblErrorMessage.Text = $"You are about to insert a customer with the following details:\n{updatedCustomer}";
            frmError.ShowDialog();

            // If user does not want to continue, abort
            if (!frmError.confirm)
                return;

            try
            {
                // Use the UpdateCustomer method from the Customer class to update the customer details
                Customer.UpdateCustomer(updatedCustomer);

                MessageBox.Show("Customer details updated successfully!");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the update operation
                MessageBox.Show($"An error occurred while updating customer details: {ex.Message}");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
