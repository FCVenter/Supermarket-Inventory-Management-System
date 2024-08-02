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
    public partial class ViewProducts : Form
    {
        private StoreManagerDirectory frmStoreManagerDirectory;

        public ViewProducts(StoreManagerDirectory frmStoreManagerDirectory)
        {
            InitializeComponent();
            this.frmStoreManagerDirectory = frmStoreManagerDirectory;
        }

        private void btnMaintainProductsBack_Click(object sender, EventArgs e)
        {
            frmStoreManagerDirectory.Show();
            this.Close();
        }

        private void btnViewProductsAdd_Click(object sender, EventArgs e)
        {
            AddProducts frmAddProducts = new AddProducts(this);
            frmAddProducts.Show();
            this.Hide();
        }

        public void RefreshGridView()
        {
            try
            {
                DisplaySql("SELECT * FROM PRODUCT", dgvViewProducts);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void btnViewProductsUpdate_Click(object sender, EventArgs e)
        {
            if (dgvViewProducts.SelectedRows.Count <= 0)
            {
                MessageBox.Show($"Select a product which details should be changed.", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the first selected row
            DataGridViewRow selectedRow = dgvViewProducts.SelectedRows[0];

            // Access the cell values of the selected row
            int ProductID = Convert.ToInt32(selectedRow.Cells["Product_ID"].Value);

            Product product = Product.GetProductById(ProductID);

            UpdateProducts frmUpdateProduct = new UpdateProducts(product);
            frmUpdateProduct.Show();
            RefreshGridView();

        }

        private void btnViewProductsDelete_Click(object sender, EventArgs e)
        {
            if (dgvViewProducts.SelectedRows.Count <= 0)
            {
                MessageBox.Show($"Select a product to be deleted.", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the first selected row
            DataGridViewRow selectedRow = dgvViewProducts.SelectedRows[0];

            // Access the cell values of the selected row
            int productID = Convert.ToInt32(selectedRow.Cells["Product_ID"].Value);

            Product product = Product.GetProductById(productID);

            ErrorMessage frmErrorMessage = new ErrorMessage();
            frmErrorMessage.lblErrorMessage.Text = $"You are about to delete product with details:\n{product}";
            frmErrorMessage.ShowDialog();

            if (!frmErrorMessage.confirm)
                return;

            try
            {
                Product.DeleteProduct(productID);
                MessageBox.Show("Product Successfully Deleted.");
                RefreshGridView();
            }
            catch (Exception E)
            {
                frmErrorMessage.lblErrorMessage.Text = E.Message;
                frmErrorMessage.Show();
            }
        }

        private void ViewProducts_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            RefreshGridView();
        }

        private void ViewProducts_Shown(object sender, EventArgs e)
        {
            RefreshGridView();
        }
    }
}
