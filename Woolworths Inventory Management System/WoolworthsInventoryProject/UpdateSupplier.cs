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
    public partial class UpdateSupplier : Form
    {
        private Supplier updatedSupplier;

        public UpdateSupplier(Supplier updatedSupplier)
        {
            InitializeComponent();
            this.updatedSupplier = updatedSupplier;
        }

        private void UpdateSupplier_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            FillSupplierDetails(updatedSupplier);
            txtUpdateSupplierName.Focus();
        }


        /// <summary>
        /// Fills the text boxes with the details of the given supplier.
        /// </summary>
        /// <param name="supplier">The supplier whose details are to be displayed.</param>
        private void FillSupplierDetails(Supplier supplier)
        {
            if (supplier == null)
            {
                // Log the error for debugging and future reference.
                // Consider using a logging library or framework you have in place.
                // For now, I'll use a simple comment.
                // LogError("Attempted to fill supplier details with a null supplier object.");

                // Inform the user in a non-disruptive manner.
                MessageBox.Show("Unable to display supplier details. Please try again or contact support if the issue persists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Safely set the text box values.
            // Using the null conditional operator to ensure no null reference exceptions.
            txtUpdateSupplierName.Text = supplier.SupplierName ?? string.Empty;
            txtUpdateSupplierAddress.Text = supplier.SupplierAddress ?? string.Empty;
            txtUpdateSupplierPhoneNumber.Text = supplier.SupplierPhoneNumber ?? string.Empty;
        }

        private void btnUpdateSupplierSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateDetails();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating supplier details: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates supplier details based on the information provided in textboxes.
        /// </summary>
        private void UpdateDetails()
        {
            // Input validation
            if (string.IsNullOrEmpty(txtUpdateSupplierName.Text))
            {
                MessageBox.Show("Please enter a valid name.");
                return;
            }

            if (string.IsNullOrEmpty(txtUpdateSupplierAddress.Text))
            {
                MessageBox.Show("Please enter a valid address.");
                return;
            }

            if (string.IsNullOrEmpty(txtUpdateSupplierPhoneNumber.Text) || !Regex.IsMatch(txtUpdateSupplierPhoneNumber.Text, @"^\+\d{11}$")) // Assuming a phone number format like +27887654321
            {
                MessageBox.Show("Please enter a valid South African phone number. (+27)");
                return;
            }

            updatedSupplier.SupplierName = txtUpdateSupplierName.Text;
            updatedSupplier.SupplierAddress = txtUpdateSupplierAddress.Text;
            updatedSupplier.SupplierPhoneNumber = txtUpdateSupplierPhoneNumber.Text;

            ErrorMessage frmError = new ErrorMessage();
            frmError.lblErrorMessage.Text = $"You are about to update a supplier to the with the following details:\n{updatedSupplier}";
            frmError.ShowDialog();

            // If user does not want to continue, abort
            if (!frmError.confirm)
                return;

            try
            {
                // Use the UpdateSupplier method from the Supplier class to update the supplier details
                Supplier.UpdateSupplier(updatedSupplier);

                MessageBox.Show("Supplier details updated successfully!");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the update operation
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateSupplierBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
