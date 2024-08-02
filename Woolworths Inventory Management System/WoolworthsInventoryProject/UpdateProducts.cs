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
    public partial class UpdateProducts : Form
    {
        private Product updatedProduct;
        public UpdateProducts(Product updatedProduct)
        {
            InitializeComponent();
            this.updatedProduct = updatedProduct;
        }

        /// <summary>
        /// Fills the text boxes with the details of the given product.
        /// </summary>
        /// <param name="product">The product whose details are to be displayed.</param>
        private void FillProductDetails(Product product)
        {
            if (product == null)
            {
                // Log the error for debugging and future reference.
                // Consider using a logging library or framework you have in place.
                // For now, I'll use a simple comment.
                // LogError("Attempted to fill product details with a null product object.");

                // Inform the user in a non-disruptive manner.
                MessageBox.Show("Unable to display product details. Please try again or contact support if the issue persists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Safely set the text box values.
            txtUpdateProductsProductID.Text = product.ProductID.ToString();
            txtUpdateProductsName.Text = product.ProductName ?? string.Empty;
            txtUpdateProductsDescription.Text = product.ProductDescription ?? string.Empty;
            txtUpdateProductsPrice.Text = product.ProductPrice.ToString("F2"); // Assuming ProductPrice is a decimal or double. "F2" formats it to two decimal places.
            txtUpdateProductsQuantity.Text = product.StockLeft.ToString(); // Assuming StockLeft is an integer or similar type.
        }



        private void btnMaintainProductsBack_Click(object sender, EventArgs e)
        {
            //ViewProducts frmViewProducts = new ViewProducts();
            //frmViewProducts.ShowDialog();
            //this.Close();
        }

        private void UpdateProducts_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            FillProductDetails(updatedProduct);
        }

        /// <summary>
        /// Updates product details based on the information provided in textboxes.
        /// </summary>
        private void UpdateProductDetails()
        {
            // Input validation
            if (string.IsNullOrEmpty(txtUpdateProductsName.Text))
            {
                MessageBox.Show("Please enter a valid product name.");
                return;
            }

            if (string.IsNullOrEmpty(txtUpdateProductsDescription.Text))
            {
                MessageBox.Show("Please enter a valid product description.");
                return;
            }

            if (string.IsNullOrEmpty(txtUpdateProductsPrice.Text) || !decimal.TryParse(txtUpdateProductsPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid product price.");
                return;
            }

            if (string.IsNullOrEmpty(txtUpdateProductsQuantity.Text) || !int.TryParse(txtUpdateProductsQuantity.Text, out int quantity))
            {
                MessageBox.Show("Please enter a valid product quantity.");
                return;
            }

            updatedProduct.ProductDescription = txtUpdateProductsDescription.Text;
            updatedProduct.ProductName = txtUpdateProductsName.Text;
            updatedProduct.ProductPrice = price;
            updatedProduct.StockLeft = quantity;

            ErrorMessage frmError = new ErrorMessage();
            frmError.lblErrorMessage.Text = $"You are about to update a product with the following details:\n{updatedProduct}";
            frmError.ShowDialog();

            // If user does not want to continue, abort
            if (!frmError.confirm)
                return;

            try
            {
                // Use the UpdateProduct method from the Product class to update the product details
                Product.UpdateProduct(updatedProduct);

                MessageBox.Show("Product details updated successfully!");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the update operation
                MessageBox.Show($"An error occurred while updating product details: {ex.Message}");
            }
        }


        private void btnUpdateProductsAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateProductDetails(); // Assuming you have a method to update product details.
                this.Close();
            }
            catch (Exception ex)
            {
                // Use the error form to display the error message.
                ErrorMessage frmError = new ErrorMessage();
                frmError.lblErrorMessage.Text = $"An error occurred while updating product details: {ex.Message}";
                frmError.ShowDialog();
            }
        }
    }
}
