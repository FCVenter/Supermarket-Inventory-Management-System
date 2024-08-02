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
    public partial class SupplierDatabase : Form
    {
        private StoreManagerDirectory frmStoreManagerDirectory;

        public SupplierDatabase(StoreManagerDirectory frmStoreManagerDirectory)
        {
            InitializeComponent();
            this.frmStoreManagerDirectory = frmStoreManagerDirectory;
        }

        private void btnSupplierDatabaseUpdate_Click(object sender, EventArgs e)
        {
            if(dgvSupplierDatabase.SelectedRows.Count <= 0)
            {
                MessageBox.Show($"Select a supplier who's details should be changed.", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the first selected row
            DataGridViewRow selectedRow = dgvSupplierDatabase.SelectedRows[0];

            // Access the cell values of the selected row
            int supplierID = Convert.ToInt32(selectedRow.Cells["Supplier_ID"].Value);

            Supplier supplier = Supplier.GetSupplierById(supplierID);

            UpdateSupplier frmUpdateSupplier = new UpdateSupplier(supplier);
            frmUpdateSupplier.ShowDialog();
            RefreshGridView();

        }

        private void btnSupplierDatabaseAddSupplier_Click(object sender, EventArgs e)
        {
            AddSupplier frmAddSupplier = new AddSupplier(this);
            frmAddSupplier.Show();
            this.Hide();
        }

        public void RefreshGridView()
        {
            try
            {
                DisplaySql("SELECT * FROM SUPPLIER", dgvSupplierDatabase);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void SupplierDatabase_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            RefreshGridView();
        }

        private void btnSupplierDatabaseDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (dgvSupplierDatabase.SelectedRows.Count <= 0)
            {
                MessageBox.Show($"Select a supplier to be deleted.", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the first selected row
            DataGridViewRow selectedRow = dgvSupplierDatabase.SelectedRows[0];

            // Access the cell values of the selected row
            int supplierID = Convert.ToInt32(selectedRow.Cells["Supplier_ID"].Value);

            Supplier supplier = new Supplier();

            try
            {
                supplier = Supplier.GetSupplierById(supplierID);
            }
            catch (Exception E)
            {
                ErrorMessage frmError = new ErrorMessage("An error occurred while getting the supplier to delete");
                frmError.ShowDialog();
                return;
            }

            ErrorMessage frmErrorMessage = new ErrorMessage();
            frmErrorMessage.lblErrorMessage.Text = $"You are about to delete supplier with details:\n{supplier}";
            frmErrorMessage.ShowDialog();

            if (!frmErrorMessage.confirm)
                return;

            try
            {
                Supplier.DeleteSupplier(supplierID);
                MessageBox.Show("Supplier Successfully Deleted.");
                RefreshGridView();
            }
            catch (Exception E)
            {
                frmErrorMessage.lblErrorMessage.Text = E.Message;
                frmErrorMessage.Show();
            }

        }

        private void btnSupplierDatabaseBack_Click(object sender, EventArgs e)
        {
            frmStoreManagerDirectory.Show();
            this.Close();
        }

        private void SupplierDatabase_Shown(object sender, EventArgs e)
        {
            RefreshGridView();
        }
    }
}
