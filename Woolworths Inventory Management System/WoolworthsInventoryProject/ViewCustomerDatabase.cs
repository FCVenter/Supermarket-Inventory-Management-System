using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WoolworthsInventorySystem.DbOperations;

namespace WoolworthsInventorySystem
{
    public partial class ViewCustomerDatabase : Form
    {
        private StoreManagerDirectory frmStoreManagerDirectory;
        public ViewCustomerDatabase(StoreManagerDirectory frmStoreManagerDirectory)
        {
            InitializeComponent();
            this.frmStoreManagerDirectory = frmStoreManagerDirectory;
        }

        private void btnViewCustomerDetailsChangeDetails_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count <= 0)
            {
                MessageBox.Show($"Select a customer who's details should be changed.", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the first selected row
            DataGridViewRow selectedRow = dgvCustomer.SelectedRows[0];

            // Access the cell values of the selected row
            int customerID = Convert.ToInt32(selectedRow.Cells["Customer_ID"].Value);

            Customer customer = Customer.GetCustomerById(customerID);


            UpdateCustomerDetails frmUpdateCustomer = new UpdateCustomerDetails(customer);
            frmUpdateCustomer.ShowDialog();
            RefreshGridView();
        }

        public void RefreshGridView()
        {
            try
            {
                DisplaySql("SELECT * FROM CUSTOMER", dgvCustomer);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void ViewCustomerDatabase_Load(object sender, EventArgs e)
        {
            RefreshGridView();
            this.ControlBox = false;

        }

        private void btnViewCustomerDetailsAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer frmAddCustomer = new AddCustomer(this);
            frmAddCustomer.Show();
            this.Hide();
        }

        private void btnViewCustomerDetailsDeleteAcc_Click(object sender, EventArgs e)
        {

            if (dgvCustomer.SelectedRows.Count <= 0)
            {
                MessageBox.Show($"Select a customer to be deleted.", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the first selected row
            DataGridViewRow selectedRow = dgvCustomer.SelectedRows[0];

            // Access the cell values of the selected row
            int customerID = Convert.ToInt32(selectedRow.Cells["Customer_ID"].Value);

            Customer customer = Customer.GetCustomerById(customerID);

            ErrorMessage frmErrorMessage = new ErrorMessage();
            frmErrorMessage.lblErrorMessage.Text = $"You are about to delete customer with details:\n{customer}";
            frmErrorMessage.ShowDialog();

            if (!frmErrorMessage.confirm)
                return;

            try
            {
                Customer.DeleteCustomer(customerID);
                MessageBox.Show("Customer Successfully Deleted.");
                RefreshGridView();
            }
            catch (Exception E)
            {
                frmErrorMessage.lblErrorMessage.Text = E.ToString();
                frmErrorMessage.Show();
            }

            

        }

        private void btnViewCustomerDatabaseBack_Click(object sender, EventArgs e)
        {
            frmStoreManagerDirectory.Show();
            this.Close();
        }

        private void ViewCustomerDatabase_Shown(object sender, EventArgs e)
        {
            RefreshGridView();
        }
    }
}
