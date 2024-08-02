
namespace WoolworthsInventorySystem
{
    partial class RequestReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpPopularProducts = new System.Windows.Forms.TabPage();
            this.btnPopularProductsSortHighToLow = new System.Windows.Forms.Button();
            this.btnPopularProductsSortLowToHigh = new System.Windows.Forms.Button();
            this.rtxtPopular = new System.Windows.Forms.RichTextBox();
            this.tbpFinance = new System.Windows.Forms.TabPage();
            this.hsbSalesRevenueDates = new System.Windows.Forms.HScrollBar();
            this.label10 = new System.Windows.Forms.Label();
            this.lblScrollBarSalesRange = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxSalesRevenuePRoductCategory = new System.Windows.Forms.ComboBox();
            this.txtSalesRevenueProductName = new System.Windows.Forms.TextBox();
            this.rtxtSales = new System.Windows.Forms.RichTextBox();
            this.tbpReports = new System.Windows.Forms.TabControl();
            this.tbpPopularProducts.SuspendLayout();
            this.tbpFinance.SuspendLayout();
            this.tbpReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1770, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 47);
            this.btnBack.TabIndex = 44;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnRequestReportsLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 41);
            this.label1.TabIndex = 99;
            this.label1.Text = "WOOLWORTHS";
            // 
            // tbpPopularProducts
            // 
            this.tbpPopularProducts.BackColor = System.Drawing.Color.Black;
            this.tbpPopularProducts.Controls.Add(this.rtxtPopular);
            this.tbpPopularProducts.Controls.Add(this.btnPopularProductsSortLowToHigh);
            this.tbpPopularProducts.Controls.Add(this.btnPopularProductsSortHighToLow);
            this.tbpPopularProducts.Location = new System.Drawing.Point(4, 28);
            this.tbpPopularProducts.Name = "tbpPopularProducts";
            this.tbpPopularProducts.Size = new System.Drawing.Size(1664, 705);
            this.tbpPopularProducts.TabIndex = 3;
            this.tbpPopularProducts.Text = "POPULAR PRODUCTS";
            // 
            // btnPopularProductsSortHighToLow
            // 
            this.btnPopularProductsSortHighToLow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPopularProductsSortHighToLow.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPopularProductsSortHighToLow.Location = new System.Drawing.Point(1327, 50);
            this.btnPopularProductsSortHighToLow.Name = "btnPopularProductsSortHighToLow";
            this.btnPopularProductsSortHighToLow.Size = new System.Drawing.Size(322, 49);
            this.btnPopularProductsSortHighToLow.TabIndex = 3;
            this.btnPopularProductsSortHighToLow.Text = "SEARCH BY MOST POPULAR";
            this.btnPopularProductsSortHighToLow.UseVisualStyleBackColor = true;
            this.btnPopularProductsSortHighToLow.Click += new System.EventHandler(this.btnPopularProductsSortHighToLow_Click);
            // 
            // btnPopularProductsSortLowToHigh
            // 
            this.btnPopularProductsSortLowToHigh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPopularProductsSortLowToHigh.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPopularProductsSortLowToHigh.Location = new System.Drawing.Point(1327, 346);
            this.btnPopularProductsSortLowToHigh.Name = "btnPopularProductsSortLowToHigh";
            this.btnPopularProductsSortLowToHigh.Size = new System.Drawing.Size(322, 49);
            this.btnPopularProductsSortLowToHigh.TabIndex = 4;
            this.btnPopularProductsSortLowToHigh.Text = "SEARCH BY LEAST POPULAR";
            this.btnPopularProductsSortLowToHigh.UseVisualStyleBackColor = true;
            this.btnPopularProductsSortLowToHigh.Click += new System.EventHandler(this.btnPopularProductsSortLowToHigh_Click);
            // 
            // rtxtPopular
            // 
            this.rtxtPopular.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtPopular.Location = new System.Drawing.Point(17, 19);
            this.rtxtPopular.Name = "rtxtPopular";
            this.rtxtPopular.Size = new System.Drawing.Size(1286, 661);
            this.rtxtPopular.TabIndex = 43;
            this.rtxtPopular.Text = "";
            // 
            // tbpFinance
            // 
            this.tbpFinance.BackColor = System.Drawing.Color.Black;
            this.tbpFinance.Controls.Add(this.rtxtSales);
            this.tbpFinance.Controls.Add(this.txtSalesRevenueProductName);
            this.tbpFinance.Controls.Add(this.cbxSalesRevenuePRoductCategory);
            this.tbpFinance.Controls.Add(this.label3);
            this.tbpFinance.Controls.Add(this.label2);
            this.tbpFinance.Controls.Add(this.lblScrollBarSalesRange);
            this.tbpFinance.Controls.Add(this.label10);
            this.tbpFinance.Controls.Add(this.hsbSalesRevenueDates);
            this.tbpFinance.Location = new System.Drawing.Point(4, 28);
            this.tbpFinance.Name = "tbpFinance";
            this.tbpFinance.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFinance.Size = new System.Drawing.Size(1664, 705);
            this.tbpFinance.TabIndex = 0;
            this.tbpFinance.Text = "SALES REVENUE AND PROFIT";
            // 
            // hsbSalesRevenueDates
            // 
            this.hsbSalesRevenueDates.Location = new System.Drawing.Point(1433, 116);
            this.hsbSalesRevenueDates.Name = "hsbSalesRevenueDates";
            this.hsbSalesRevenueDates.Size = new System.Drawing.Size(181, 21);
            this.hsbSalesRevenueDates.TabIndex = 1;
            this.hsbSalesRevenueDates.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbSalesRevenueDates_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(1173, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 22);
            this.label10.TabIndex = 36;
            this.label10.Text = "SALES DATE RANGE:";
            // 
            // lblScrollBarSalesRange
            // 
            this.lblScrollBarSalesRange.AutoSize = true;
            this.lblScrollBarSalesRange.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScrollBarSalesRange.ForeColor = System.Drawing.Color.White;
            this.lblScrollBarSalesRange.Location = new System.Drawing.Point(1495, 151);
            this.lblScrollBarSalesRange.Name = "lblScrollBarSalesRange";
            this.lblScrollBarSalesRange.Size = new System.Drawing.Size(48, 16);
            this.lblScrollBarSalesRange.TabIndex = 37;
            this.lblScrollBarSalesRange.Text = "[LABEL]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1173, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 22);
            this.label2.TabIndex = 38;
            this.label2.Text = "PRODUCT NAME:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1173, 526);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 22);
            this.label3.TabIndex = 40;
            this.label3.Text = "PRODUCT CATEGORY:";
            // 
            // cbxSalesRevenuePRoductCategory
            // 
            this.cbxSalesRevenuePRoductCategory.FormattingEnabled = true;
            this.cbxSalesRevenuePRoductCategory.Items.AddRange(new object[] {
            "Fruit & Veg",
            "Meat",
            "Dairy",
            "Beverages",
            "Bakery",
            "Pantry"});
            this.cbxSalesRevenuePRoductCategory.Location = new System.Drawing.Point(1433, 526);
            this.cbxSalesRevenuePRoductCategory.Name = "cbxSalesRevenuePRoductCategory";
            this.cbxSalesRevenuePRoductCategory.Size = new System.Drawing.Size(181, 27);
            this.cbxSalesRevenuePRoductCategory.TabIndex = 41;
            this.cbxSalesRevenuePRoductCategory.SelectedIndexChanged += new System.EventHandler(this.cbxSalesRevenuePRoductCategory_SelectedIndexChanged);
            // 
            // txtSalesRevenueProductName
            // 
            this.txtSalesRevenueProductName.Location = new System.Drawing.Point(1433, 338);
            this.txtSalesRevenueProductName.Name = "txtSalesRevenueProductName";
            this.txtSalesRevenueProductName.Size = new System.Drawing.Size(181, 29);
            this.txtSalesRevenueProductName.TabIndex = 39;
            this.txtSalesRevenueProductName.TextChanged += new System.EventHandler(this.txtSalesRevenueProductName_TextChanged);
            // 
            // rtxtSales
            // 
            this.rtxtSales.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtSales.Location = new System.Drawing.Point(26, 21);
            this.rtxtSales.Name = "rtxtSales";
            this.rtxtSales.Size = new System.Drawing.Size(1126, 661);
            this.rtxtSales.TabIndex = 42;
            this.rtxtSales.Text = "";
            // 
            // tbpReports
            // 
            this.tbpReports.Controls.Add(this.tbpFinance);
            this.tbpReports.Controls.Add(this.tbpPopularProducts);
            this.tbpReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbpReports.Location = new System.Drawing.Point(111, 175);
            this.tbpReports.Name = "tbpReports";
            this.tbpReports.SelectedIndex = 0;
            this.tbpReports.Size = new System.Drawing.Size(1672, 737);
            this.tbpReports.TabIndex = 21;
            // 
            // RequestReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1922, 1058);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tbpReports);
            this.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "RequestReports";
            this.Text = "RequestReports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RequestReports_Load);
            this.tbpPopularProducts.ResumeLayout(false);
            this.tbpFinance.ResumeLayout(false);
            this.tbpFinance.PerformLayout();
            this.tbpReports.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbpPopularProducts;
        private System.Windows.Forms.RichTextBox rtxtPopular;
        private System.Windows.Forms.Button btnPopularProductsSortLowToHigh;
        private System.Windows.Forms.Button btnPopularProductsSortHighToLow;
        private System.Windows.Forms.TabPage tbpFinance;
        private System.Windows.Forms.RichTextBox rtxtSales;
        private System.Windows.Forms.TextBox txtSalesRevenueProductName;
        private System.Windows.Forms.ComboBox cbxSalesRevenuePRoductCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblScrollBarSalesRange;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.HScrollBar hsbSalesRevenueDates;
        private System.Windows.Forms.TabControl tbpReports;
    }
}