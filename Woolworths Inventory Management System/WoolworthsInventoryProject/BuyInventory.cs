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
    public partial class BuyInventory : Form
    {
        private StoreManagerDirectory frmStoreManagerDirectory;
        public BuyInventory(StoreManagerDirectory frmStoreManagerDirectory)
        {
            InitializeComponent();
            this.frmStoreManagerDirectory = frmStoreManagerDirectory;
        }

        private void btnMaintainProductsBack_Click(object sender, EventArgs e)
        {
            frmStoreManagerDirectory.Show();
            this.Close();
        }

        private void RefreshGridView()
        {
            try
            {
                DisplaySql("SELECT * FROM PRODUCT", dgvBuyInventory);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void BuyInventory_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            RefreshGridView();
        }

        private void btnBuyInventoryAddOrder_Click(object sender, EventArgs e)
        {
            if (dgvBuyInventory.SelectedRows.Count <= 0)
            {
                MessageBox.Show($"Select a product to be ordered.", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the first selected row
            DataGridViewRow selectedRow = dgvBuyInventory.SelectedRows[0];

            // Access the cell values of the selected row
            int productID = Convert.ToInt32(selectedRow.Cells["Product_ID"].Value);


            int amount = (int)nudBuyInventory.Value;

            if (amount < 10)
            {
                MessageBox.Show("Please select more than 10 of a product.");
                return;
            }

            if (amount > 500)
            {
                Product product = Product.GetProductById(productID);
                ErrorMessage frmError = new ErrorMessage($"You are about to order a large amount ({amount}) of\n{product}");
                frmError.ShowDialog();

                if (!frmError.confirm)
                    return;
            }
            
            try
            {
                Supplier.OrderMoreProducts(productID, amount);
                MessageBox.Show("Order placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception E)
            {
                ErrorMessage frmError = new ErrorMessage(E.ToString());
                MessageBox.Show(E.ToString());
                frmError.ShowDialog();
            }

        }
    }
}
