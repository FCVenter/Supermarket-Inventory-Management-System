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
    public partial class AddSupplier : Form
    {
        private SupplierDatabase prevForm;
        private Supplier newSupplier;
        public AddSupplier(SupplierDatabase prevForm)
        {
            InitializeComponent();
            this.prevForm = prevForm;
            newSupplier = new Supplier();
        }

        private void AddSupplier_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            txtAddSupplierName.Focus();
        }

        private void InsertDetails()
        {
            // Input validation
            if (string.IsNullOrEmpty(txtAddSupplierName.Text))
            {
                MessageBox.Show("Please enter a valid name.");
                return;
            }

            if (string.IsNullOrEmpty(txtAddSupplierAddress.Text))
            {
                MessageBox.Show("Please enter a valid address.");
                return;
            }

            if (string.IsNullOrEmpty(txtAddSupplierPhoneNumber.Text.Trim()) || !Regex.IsMatch(txtAddSupplierPhoneNumber.Text.Trim(), @"^0\d{9}$"))
            {
                MessageBox.Show("Please enter a valid South African phone number. (+27)");
                return;
            }


            newSupplier.SupplierName = txtAddSupplierName.Text;
            newSupplier.SupplierAddress = txtAddSupplierAddress.Text;
            newSupplier.SupplierPhoneNumber = "+27" + txtAddSupplierPhoneNumber.Text.Substring(1);

            ErrorMessage frmError = new ErrorMessage();
            frmError.lblErrorMessage.Text = $"You are about to insert a supplier with the following details:\n{newSupplier}";
            frmError.ShowDialog();

            // If user does not want to continue, abort
            if (!frmError.confirm)
                return;

            try
            {
                // Use the InsertSupplier method from the Supplier class to add a new record
                int newSupplierID = Supplier.InsertSupplier(newSupplier);
                newSupplier.SupplierID = newSupplierID;
                MessageBox.Show("You have successfully been registered!");

                // Return to previous form
                prevForm.Show();
                prevForm.RefreshGridView();
                this.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the insert operation
                MessageBox.Show($"An error occurred while inserting a new supplier: {ex.Message}");
            }
        }


        private void btnAddSupplierAddSupplier_Click(object sender, EventArgs e)
        {
            InsertDetails();
        }

        private void btnAddSupplierCancel_Click(object sender, EventArgs e)
        {
            prevForm.Show();
            this.Close();
        }
    }
}
