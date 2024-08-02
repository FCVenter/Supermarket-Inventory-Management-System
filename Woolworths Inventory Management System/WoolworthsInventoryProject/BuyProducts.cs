using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using static WoolworthsInventorySystem.DbOperations;
using static WoolworthsInventorySystem.Product;

namespace WoolworthsInventorySystem
{
    public partial class BuyProducts : Form
    {
        private List<OrderProduct> orderProducts;
        private string customerEmail = "";
        Customer currentCustomer;
        private Login frmLogin;

        public BuyProducts(Login frmLogin)
        {
            InitializeComponent();
            orderProducts = new List<OrderProduct>();
            this.frmLogin = frmLogin;
        }

        public void PopulateProductComboBoxes()
        {
            // SQL queries to filter products by their type
            string sqlFruitAndVeg = "SELECT Product_Name FROM Product WHERE Product_Description LIKE 'Fruit & Veg%'";
            string sqlMeat = "SELECT Product_Name FROM Product WHERE Product_Description LIKE 'Meat%'";
            string sqlDairy = "SELECT Product_Name FROM Product WHERE Product_Description LIKE 'Dairy%'";
            string sqlBakery = "SELECT Product_Name FROM Product WHERE Product_Description LIKE 'Bakery%'";
            string sqlBeverages = "SELECT Product_Name FROM Product WHERE Product_Description LIKE 'Beverages%'";
            string sqlPantry = "SELECT Product_Name FROM Product WHERE Product_Description LIKE 'Pantry%'";


            populateCombobox(cbxFruitVeg, sqlFruitAndVeg);
            populateCombobox(cbxMeat, sqlMeat);
            populateCombobox(cbxDairy, sqlDairy);
            populateCombobox(cbxBakery, sqlBakery);
            populateCombobox(cbxBeverages, sqlBeverages);
            populateCombobox(cbxPantry, sqlPantry);
        }

        public void clearControls()
        {
            cbxBakery.SelectedIndex = -1;
            cbxBeverages.SelectedIndex = -1;
            cbxDairy.SelectedIndex = -1;
            cbxFruitVeg.SelectedIndex = -1;
            cbxMeat.SelectedIndex = -1;
            cbxPantry.SelectedIndex = -1;

            nudBakery.Value = 0;
            nudBeverages.Value = 0;
            nudDairy.Value = 0;
            nudFruitVeg.Value = 0;
            nudMeat.Value = 0;
            nudPantry.Value = 0;
            
            txtCustomerEmail.Clear();

            currentCustomer = null;
            customerEmail = null;

        }

        private void BuyProducts_Load(object sender, EventArgs e)
        {
            InitialiseControls();
            this.ControlBox = false;

        }

        private void InitialiseControls()
        {
            cbxFruitVeg.Focus();
            PopulateProductComboBoxes();

            linklblRegister.Visible = false;
            lblEmailNotFound.Visible = false;
            lblMessage.Visible = false;
        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            currentCustomer = Customer.GetCustomerByEmail(customerEmail);

            if (currentCustomer == null)
            {
                lblEmailNotFound.Hide();
                linklblRegister.Hide();
                DelayAction(300, () => lblEmailNotFound.Show());
                DelayAction(300, () => linklblRegister.Show());
                return;
            }
            else
            {
                lblEmailNotFound.Hide();
                linklblRegister.Hide();
            }

            new UpdateCustomerDetails(currentCustomer).ShowDialog();

        }

        private void btnCustomerCart_Click(object sender, EventArgs e)
        {
            if (orderProducts.Count < 1)
            {
                MessageBox.Show("You can't checkout with nothing!");
                return;
            }

            try
            {
                currentCustomer = Customer.GetCustomerByEmail(customerEmail);
            }
            catch (ApplicationException ae)
            {
                MessageBox.Show("An error occurred getting a customer by email.");
                return;
            }

            if (currentCustomer == null)
            {
                lblEmailNotFound.Hide();
                linklblRegister.Hide();
                DelayAction(300, () => lblEmailNotFound.Show());
                DelayAction(300, () => linklblRegister.Show());
                return;
            }
            else
            {
                lblEmailNotFound.Hide();
                linklblRegister.Hide();
            }

            ProductPurchased order = new ProductPurchased
            {
                OrderDate = DateTime.Now,
                CustomerID = currentCustomer.CustomerID
            };

            // Now that all products have been selected, add them to the order
            foreach (OrderProduct product in orderProducts)
            {
                order.AddOrderProduct(product);
            }

            CustomerCart frmCard = new CustomerCart(currentCustomer, this, order);
            this.Hide();
            frmCard.ShowDialog();
        }

        private void txtLoginUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddFruitVeg_Click(object sender, EventArgs e)
        {
            addProduct(cbxFruitVeg, nudFruitVeg);
        }


        /// <summary>
        /// Executes a specified action after a given delay.
        /// </summary>
        /// <param name="millisecond">The delay in milliseconds before executing the action.</param>
        /// <param name="action">The action to be executed after the delay.</param>
        private static void DelayAction(int millisecond, Action action)
        {
            // Create a new DispatcherTimer instance.
            var timer = new DispatcherTimer();

            // Attach an event handler to the Tick event of the timer.
            timer.Tick += delegate
            {
                // Invoke the specified action.
                action.Invoke();

                // Stop the timer after the action has been executed to ensure it doesn't keep ticking.
                timer.Stop();
            };

            // Set the interval for the timer using the specified delay in milliseconds.
            timer.Interval = TimeSpan.FromMilliseconds(millisecond);

            // Start the timer. The attached action will be executed once the interval has elapsed.
            timer.Start();
        }


        /// <summary>
        /// Adds a product to the order based on the selected product in the ComboBox and the specified quantity in the NumericUpDown control.
        /// </summary>
        /// <param name="cbx">The ComboBox containing the list of products.</param>
        /// <param name="nud">The NumericUpDown control for specifying the quantity of the selected product.</param>
        private void addProduct(ComboBox cbx, NumericUpDown nud)
        {
            // Check if the specified quantity in the NumericUpDown control is less than 1.
            if (nud.Value < 1)
            {
                // Display an error message to the user.
                MessageBox.Show("Please add 1 or more of a product.");
                return; // Exit the method.
            }

            // Check if no product is selected in the ComboBox.
            if (string.IsNullOrEmpty(cbx.Text))
            {
                // Display an error message to the user.
                MessageBox.Show("Please select a product to add.");
                return; // Exit the method.
            }

            // Retrieve the ProductID of the selected product in the ComboBox using the GetProductByName method.
            int prodID = GetProductByName(cbx.Text).ProductID;

            // Prevent duplicate primary keys in orderproduct by increasing quantity if duplicate is found
            bool isDuplicate = false;
            foreach(OrderProduct op in orderProducts)
            {
                if (op.ProductID == prodID)
                {
                    op.Quantity += (int)nud.Value;
                    isDuplicate = true;
                }
            }

            // Create a new OrderProduct object with the retrieved ProductID and specified quantity.
            // Add this object to the orderProducts list, if it does not already exist in the list
            if (!isDuplicate)
            {
                orderProducts.Add(new OrderProduct
                {
                    ProductID = prodID,
                    Quantity = (int)nud.Value
                });
            }

            // Make the lblMessage label visible to inform the user that the product has been added.
            // First make false to accommodate frequent use of method. (button being clicked before the label has been hidden)
            lblMessage.Visible = false;
            DelayAction(200, () => lblMessage.Show());


            // Hide the lblMessage label after a delay of 3 seconds.
            DelayAction(2000, () => lblMessage.Hide());
        }


        private void btnConfirmEmail_Click(object sender, EventArgs e)
        {
            customerEmail = txtCustomerEmail.Text;

            currentCustomer = Customer.GetCustomerByEmail(customerEmail);

            if (currentCustomer == null)
            {
                lblEmailNotFound.Hide();
                linklblRegister.Hide();
                DelayAction(300, () => lblEmailNotFound.Show());
                DelayAction(300, () => linklblRegister.Show());
            }
            else
            {
                lblEmailNotFound.Hide();
                linklblRegister.Hide();
            }
        }

        private void btnAddMeat_Click(object sender, EventArgs e)
        {
            addProduct(cbxMeat, nudMeat);
        }

        private void btnAddDairy_Click(object sender, EventArgs e)
        {
            addProduct(cbxDairy, nudDairy);
        }

        private void btnAddBakery_Click(object sender, EventArgs e)
        {
            addProduct(cbxBakery, nudBakery);
        }

        private void btnAddBeverages_Click(object sender, EventArgs e)
        {
            addProduct(cbxBeverages, nudBeverages);
        }

        private void btnAddPantry_Click(object sender, EventArgs e)
        {
            addProduct(cbxPantry, nudPantry);
        }

        private void linklblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddCustomer frmAddCustomer = new AddCustomer(this);
            frmAddCustomer.ShowDialog();
            currentCustomer = frmAddCustomer.newCustomer;
            customerEmail = currentCustomer.CustomerEmail;
        }

        private void btnBuyProductsLogout_Click(object sender, EventArgs e)
        {
            frmLogin.Show();
            this.Close();
        }
    }
}
