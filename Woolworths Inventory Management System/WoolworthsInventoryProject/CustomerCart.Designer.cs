
namespace WoolworthsInventorySystem
{
    partial class CustomerCart
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnCustomerCartPlaceOrder = new System.Windows.Forms.Button();
            this.btnCustomerCartChangeOrder = new System.Windows.Forms.Button();
            this.rtbCustomerCart = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.lblPaymentType = new System.Windows.Forms.Label();
            this.cbxPaymentType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(342, 211);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 32);
            this.label3.TabIndex = 65;
            this.label3.Text = "Your Cart:";
            // 
            // btnCustomerCartPlaceOrder
            // 
            this.btnCustomerCartPlaceOrder.BackColor = System.Drawing.Color.White;
            this.btnCustomerCartPlaceOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomerCartPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerCartPlaceOrder.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerCartPlaceOrder.Location = new System.Drawing.Point(880, 635);
            this.btnCustomerCartPlaceOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnCustomerCartPlaceOrder.Name = "btnCustomerCartPlaceOrder";
            this.btnCustomerCartPlaceOrder.Size = new System.Drawing.Size(230, 36);
            this.btnCustomerCartPlaceOrder.TabIndex = 64;
            this.btnCustomerCartPlaceOrder.Text = "PLACE ORDER";
            this.btnCustomerCartPlaceOrder.UseVisualStyleBackColor = false;
            this.btnCustomerCartPlaceOrder.Click += new System.EventHandler(this.btnCustomerCartPlaceOrder_Click);
            // 
            // btnCustomerCartChangeOrder
            // 
            this.btnCustomerCartChangeOrder.BackColor = System.Drawing.Color.White;
            this.btnCustomerCartChangeOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomerCartChangeOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerCartChangeOrder.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerCartChangeOrder.Location = new System.Drawing.Point(347, 635);
            this.btnCustomerCartChangeOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnCustomerCartChangeOrder.Name = "btnCustomerCartChangeOrder";
            this.btnCustomerCartChangeOrder.Size = new System.Drawing.Size(218, 36);
            this.btnCustomerCartChangeOrder.TabIndex = 63;
            this.btnCustomerCartChangeOrder.Text = "CHANGE ORDER";
            this.btnCustomerCartChangeOrder.UseVisualStyleBackColor = false;
            this.btnCustomerCartChangeOrder.Click += new System.EventHandler(this.btnCustomerCartChangeOrder_Click);
            // 
            // rtbCustomerCart
            // 
            this.rtbCustomerCart.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCustomerCart.Location = new System.Drawing.Point(347, 258);
            this.rtbCustomerCart.Margin = new System.Windows.Forms.Padding(2);
            this.rtbCustomerCart.Name = "rtbCustomerCart";
            this.rtbCustomerCart.Size = new System.Drawing.Size(764, 357);
            this.rtbCustomerCart.TabIndex = 62;
            this.rtbCustomerCart.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(9, 7);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(259, 41);
            this.label9.TabIndex = 85;
            this.label9.Text = "WOOLWORTHS";
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewOrder.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewOrder.Location = new System.Drawing.Point(1326, 15);
            this.btnNewOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(105, 38);
            this.btnNewOrder.TabIndex = 102;
            this.btnNewOrder.Text = "NEW ORDER";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.AutoSize = true;
            this.lblPaymentType.BackColor = System.Drawing.Color.Black;
            this.lblPaymentType.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentType.ForeColor = System.Drawing.Color.White;
            this.lblPaymentType.Location = new System.Drawing.Point(785, 15);
            this.lblPaymentType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(186, 30);
            this.lblPaymentType.TabIndex = 103;
            this.lblPaymentType.Text = "Payment type:";
            // 
            // cbxPaymentType
            // 
            this.cbxPaymentType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxPaymentType.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPaymentType.FormattingEnabled = true;
            this.cbxPaymentType.Items.AddRange(new object[] {
            "Cash",
            "Card",
            "Paypal"});
            this.cbxPaymentType.Location = new System.Drawing.Point(999, 22);
            this.cbxPaymentType.Margin = new System.Windows.Forms.Padding(2);
            this.cbxPaymentType.Name = "cbxPaymentType";
            this.cbxPaymentType.Size = new System.Drawing.Size(125, 26);
            this.cbxPaymentType.TabIndex = 104;
            // 
            // CustomerCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1442, 860);
            this.Controls.Add(this.cbxPaymentType);
            this.Controls.Add(this.lblPaymentType);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCustomerCartPlaceOrder);
            this.Controls.Add(this.btnCustomerCartChangeOrder);
            this.Controls.Add(this.rtbCustomerCart);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CustomerCart";
            this.Text = "CustomerCart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CustomerCart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCustomerCartPlaceOrder;
        private System.Windows.Forms.Button btnCustomerCartChangeOrder;
        private System.Windows.Forms.RichTextBox rtbCustomerCart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Label lblPaymentType;
        private System.Windows.Forms.ComboBox cbxPaymentType;
    }
}