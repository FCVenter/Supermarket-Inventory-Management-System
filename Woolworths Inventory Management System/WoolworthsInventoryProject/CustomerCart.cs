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
    public partial class CustomerCart : Form
    {
        private Customer customer;
        private BuyProducts frmBuyProducts;
        private ProductPurchased order;
        public CustomerCart(Customer customer, BuyProducts frmBuyProducts, ProductPurchased order)
        {
            InitializeComponent();
            this.customer = customer;
            this.frmBuyProducts = frmBuyProducts;
            this.order = order;
        }

        private void btnCustomerCartPlaceOrder_Click(object sender, EventArgs e)
        {
            switch (cbxPaymentType.SelectedIndex)
            {
                case 0:
                    order.PaymentMethod = PaymentMethod.Cash;
                    break;

                case 1:
                    order.PaymentMethod = PaymentMethod.Card;
                    break;

                case 2:
                    order.PaymentMethod = PaymentMethod.Paypal;
                    break;

                default:
                    MessageBox.Show("Please select a payment type.");
                    return;
            }

            try
            {
                ProductPurchased.PlaceOrder(order);
                MessageBox.Show("Order placed successfully!");
                btnNewOrder.Show();
                btnCustomerCartPlaceOrder.Enabled = false;
                btnCustomerCartChangeOrder.Enabled = false;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }

        /// <summary>
        /// Writes each item of an order, along with its quantity, subtotal per product, and total for the order, to a RichTextBox.
        /// </summary>
        /// <param name="orderProducts">The list of OrderProduct objects representing the order.</param>
        /// <param name="rtb">The RichTextBox to which the order details will be written.</param>
        private void WriteOrderToRichTextBox(List<OrderProduct> orderProducts, RichTextBox rtb)
        {
            // Clear the RichTextBox content.
            rtb.Clear();

            // Define the header for the order details.
            string header = "Product Name".PadRight(30) + "Quantity".PadRight(10) + "Subtotal".PadRight(15) + Environment.NewLine;
            rtb.AppendText(header);
            rtb.AppendText(new string('-', header.Length) + Environment.NewLine); // Add a separator line.

            decimal totalOrderAmount = 0; // To keep track of the total order amount.

            // Iterate through each OrderProduct in the order.
            foreach (var orderProduct in orderProducts)
            {
                // Retrieve the product details using its ID.
                var product = Product.GetProductById(orderProduct.ProductID);

                // Calculate the subtotal for the product.
                decimal subtotal = product.ProductPrice * orderProduct.Quantity;

                // Add the subtotal to the total order amount.
                totalOrderAmount += subtotal;

                // Write the product details to the RichTextBox.
                string productLine = product.ProductName.PadRight(30) +
                                     orderProduct.Quantity.ToString().PadRight(10) +
                                     subtotal.ToString("C").PadRight(15) +
                                     Environment.NewLine;
                rtb.AppendText(productLine);
            }

            // Add a separator line.
            rtb.AppendText(new string('-', header.Length) + Environment.NewLine);

            // Write the total order amount to the RichTextBox.
            rtb.AppendText("Total:".PadRight(40) + totalOrderAmount.ToString("C"));
        }


        private void CustomerCart_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            try
            {
                WriteOrderToRichTextBox(order.GetOrderProducts(), rtbCustomerCart);
            }
            catch (Exception E)
            {
                MessageBox.Show("Error loading order.");
                frmBuyProducts.Show();
                this.Close();
            }
            btnNewOrder.Hide();
        }

        private void btnCustomerCartChangeOrder_Click(object sender, EventArgs e)
        {
            frmBuyProducts.Show();
            this.Close();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            frmBuyProducts.clearControls();
            frmBuyProducts.Show();
            this.Close();
        }
    }
}
