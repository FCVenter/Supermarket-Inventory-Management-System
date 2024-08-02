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
    public partial class RequestReports : Form
    {
        private StoreManagerDirectory frmStoreManagerDirectory;
        private DateTime startDate;  // The start date of your date range
        private DateTime endDate;    // The end date of your date range
        private bool isManager;
        public RequestReports(StoreManagerDirectory frmStoreManagerDirectory, bool isManager = true)
        {
            InitializeComponent();
            this.frmStoreManagerDirectory = frmStoreManagerDirectory;
            InitializeDateRange();
            this.isManager = isManager;
        }

        

        private void btnMaintainProductsBack_Click(object sender, EventArgs e)
        {
            //StoreManagerDirectory frmStoreManagerDirectory = new StoreManagerDirectory();
            //frmStoreManagerDirectory.ShowDialog();
            //this.Close();
        }

        private void cbxSalesRevenuePRoductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSalesRevenuePRoductCategory.SelectedIndex != -1)
            {
                string sql = $"SELECT * FROM Product WHERE Product_Description LIKE '{cbxSalesRevenuePRoductCategory.Text}:%'";
                GenerateReport(rtxtSales, sql);
            }
        }

        private void RequestReports_Load(object sender, EventArgs e)
        {
            GenerateReport(rtxtPopular, "SELECT * FROM PRODUCT");
            this.ControlBox = false;

        }

        private void btnRequestReportsLogout_Click(object sender, EventArgs e)
        {
            if (isManager)
                frmStoreManagerDirectory.Show();
            else
                frmStoreManagerDirectory.frmLogin.Show();

            this.Close();
        }

        /// <summary>
        /// Initializes the date range based on the minimum and maximum order dates from the database.
        /// </summary>
        private void InitializeDateRange()
        {
            try
            {
                // Fetch the minimum and maximum order dates from your database
                // For this example, I'm using hardcoded dates. Replace with actual database query.
                startDate = new DateTime(2023, 1, 1);
                endDate = DateTime.Today;

                // Set the scrollbar properties
                hsbSalesRevenueDates.Minimum = 0;
                hsbSalesRevenueDates.Maximum = (endDate - startDate).Days;
                hsbSalesRevenueDates.Value = 0;  // Default to start date

                // Update data for the default date
                UpdateDataBasedOnSelectedDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during initialization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler for the scrollbar's scroll event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void hsbSalesRevenueDates_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                UpdateDataBasedOnSelectedDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while scrolling: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Updates the displayed data based on the selected date from the scrollbar.
        /// </summary>
        private void UpdateDataBasedOnSelectedDate()
        {
            try
            {
                // Calculate the date corresponding to the scrollbar value
                DateTime selectedDate = startDate.AddDays(hsbSalesRevenueDates.Value);

                // Display the selected date in a label
                lblScrollBarSalesRange.Text = selectedDate.ToString("yyyy-MM-dd");

                // Generate the SQL query for the selected date
                string sql = $@"
            SELECT 
                pp.Order_Date,
                p.Product_Name,
                p.Product_Description,
                p.Product_Price,
                op.Quantity,
                (p.Product_Price * op.Quantity) AS TotalSale
            FROM 
                Product_Purchased pp
            JOIN 
                Order_Product op ON pp.Order_ID = op.Order_ID
            JOIN 
                Product p ON op.Product_ID = p.Product_ID
            WHERE 
                pp.Order_Date < '{selectedDate:yyyy-MM-dd}'
            ORDER BY 
                pp.Order_Date, p.Product_Name;
        ";

                // Use the GenerateReport method to fetch and display the data in the provided RichTextBox
                GenerateReport(rtxtSales, sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSalesRevenueProductName_TextChanged(object sender, EventArgs e)
        {
            string sql = $"SELECT * FROM Product WHERE Product_Name LIKE '%{txtSalesRevenueProductName.Text}%'";
            GenerateReport(rtxtSales, sql);
        }

        private void btnPopularProductsSortHighToLow_Click(object sender, EventArgs e)
        {
            string sql = "SELECT p.Product_ID, p.Product_Name, SUM(op.Quantity) as TotalQuantitySold FROM Product p JOIN Order_Product op ON p.Product_ID = op.Product_ID GROUP BY p.Product_ID, p.Product_Name ORDER BY TotalQuantitySold DESC";

            GenerateReport(rtxtPopular, sql);
        }

        private void btnPopularProductsSortLowToHigh_Click(object sender, EventArgs e)
        {
            string sql = "SELECT p.Product_ID, p.Product_Name, SUM(op.Quantity) as TotalQuantitySold FROM Product p JOIN Order_Product op ON p.Product_ID = op.Product_ID GROUP BY p.Product_ID, p.Product_Name ORDER BY TotalQuantitySold ASC";

            GenerateReport(rtxtPopular, sql);
        }
    }
}
