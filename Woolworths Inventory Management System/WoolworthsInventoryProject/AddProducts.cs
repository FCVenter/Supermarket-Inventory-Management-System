using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoolworthsInventorySystem
{
    public partial class AddProducts : Form
    {
        private ViewProducts prevForm;
        private Product newProduct;
        public AddProducts(ViewProducts prevForm)
        {
            InitializeComponent();
            this.prevForm = prevForm;
            newProduct = new Product();
        }

        /// <summary>
        /// Inserts the product details provided in the form's textboxes into the database.
        /// </summary>
        private void InsertDetails()
        {
            // Input validation

            // Validate product name
            if (string.IsNullOrEmpty(txtAddProductsName.Text))
            {
                MessageBox.Show("Please enter a valid product name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate product description
            if (string.IsNullOrEmpty(txtAddProductsDescription.Text))
            {
                MessageBox.Show("Please enter a valid product description.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate product price
            if (string.IsNullOrEmpty(txtAddProductsPrice.Text) || !decimal.TryParse(txtAddProductsPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid product price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate product quantity
            if (string.IsNullOrEmpty(txtAddProductsQuantity.Text) || !int.TryParse(txtAddProductsQuantity.Text, out int quantity))
            {
                MessageBox.Show("Please enter a valid product quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate product type
            if (string.IsNullOrEmpty(txtAddProductsProductType.Text))
            {
                MessageBox.Show("Please enter a valid product type.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Construct the product description with the type prepended
            string fullDescription = $"{txtAddProductsProductType.Text}: {txtAddProductsDescription.Text}";

            // Set the product details
            newProduct.ProductName = txtAddProductsName.Text;
            newProduct.ProductDescription = fullDescription;
            newProduct.ProductPrice = price;
            newProduct.StockLeft = quantity;

            // Display a confirmation message to the user
            ErrorMessage frmError = new ErrorMessage();
            frmError.lblErrorMessage.Text = $"You are about to insert a product with the following details:\n{newProduct}";
            frmError.ShowDialog();

            // If user does not want to continue, abort
            if (!frmError.confirm)
                return;

            try
            {
                // Use the InsertProduct method from the Product class to add a new record
                int newProductID = Product.InsertProduct(newProduct);
                newProduct.ProductID = newProductID;
                MessageBox.Show("Product has successfully been added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Return to previous form
                prevForm.Show();
                prevForm.RefreshGridView();
                this.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the insert operation
                ErrorMessage frmErrorDisplay = new ErrorMessage();
                frmErrorDisplay.lblErrorMessage.Text = $"An error occurred while inserting a new product: {ex.Message}";
                frmErrorDisplay.ShowDialog();
            }
        }



        private void btnAddInventoryBack_Click(object sender, EventArgs e)
        {
            prevForm.Show();
            this.Close();
        }

        private void btnAddProductsAddProduct_Click(object sender, EventArgs e)
        {
            InsertDetails();
        }

        private void AddProducts_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

        }
    }
}
