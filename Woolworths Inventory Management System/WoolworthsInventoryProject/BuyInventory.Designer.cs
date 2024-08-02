
namespace WoolworthsInventorySystem
{
    partial class BuyInventory
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
            this.btnBuyInventoryBack = new System.Windows.Forms.Button();
            this.dgvBuyInventory = new System.Windows.Forms.DataGridView();
            this.btnBuyInventoryAddOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudBuyInventory = new System.Windows.Forms.NumericUpDown();
            this.lblBuyInventoryChosenProductt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuyInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuyInventoryBack
            // 
            this.btnBuyInventoryBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuyInventoryBack.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuyInventoryBack.Location = new System.Drawing.Point(1328, 7);
            this.btnBuyInventoryBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuyInventoryBack.Name = "btnBuyInventoryBack";
            this.btnBuyInventoryBack.Size = new System.Drawing.Size(105, 38);
            this.btnBuyInventoryBack.TabIndex = 43;
            this.btnBuyInventoryBack.Text = "BACK";
            this.btnBuyInventoryBack.UseVisualStyleBackColor = true;
            this.btnBuyInventoryBack.Click += new System.EventHandler(this.btnMaintainProductsBack_Click);
            // 
            // dgvBuyInventory
            // 
            this.dgvBuyInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuyInventory.Location = new System.Drawing.Point(294, 213);
            this.dgvBuyInventory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvBuyInventory.Name = "dgvBuyInventory";
            this.dgvBuyInventory.RowHeadersWidth = 51;
            this.dgvBuyInventory.RowTemplate.Height = 24;
            this.dgvBuyInventory.Size = new System.Drawing.Size(794, 328);
            this.dgvBuyInventory.TabIndex = 40;
            // 
            // btnBuyInventoryAddOrder
            // 
            this.btnBuyInventoryAddOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuyInventoryAddOrder.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuyInventoryAddOrder.Location = new System.Drawing.Point(610, 571);
            this.btnBuyInventoryAddOrder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuyInventoryAddOrder.Name = "btnBuyInventoryAddOrder";
            this.btnBuyInventoryAddOrder.Size = new System.Drawing.Size(184, 50);
            this.btnBuyInventoryAddOrder.TabIndex = 46;
            this.btnBuyInventoryAddOrder.Text = "ORDER PRODUCTS";
            this.btnBuyInventoryAddOrder.UseVisualStyleBackColor = true;
            this.btnBuyInventoryAddOrder.Click += new System.EventHandler(this.btnBuyInventoryAddOrder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 41);
            this.label1.TabIndex = 99;
            this.label1.Text = "WOOLWORTHS";
            // 
            // nudBuyInventory
            // 
            this.nudBuyInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nudBuyInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBuyInventory.Location = new System.Drawing.Point(409, 171);
            this.nudBuyInventory.Margin = new System.Windows.Forms.Padding(2);
            this.nudBuyInventory.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBuyInventory.Name = "nudBuyInventory";
            this.nudBuyInventory.Size = new System.Drawing.Size(52, 26);
            this.nudBuyInventory.TabIndex = 45;
            this.nudBuyInventory.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblBuyInventoryChosenProductt
            // 
            this.lblBuyInventoryChosenProductt.AutoSize = true;
            this.lblBuyInventoryChosenProductt.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuyInventoryChosenProductt.ForeColor = System.Drawing.Color.White;
            this.lblBuyInventoryChosenProductt.Location = new System.Drawing.Point(289, 172);
            this.lblBuyInventoryChosenProductt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuyInventoryChosenProductt.Name = "lblBuyInventoryChosenProductt";
            this.lblBuyInventoryChosenProductt.Size = new System.Drawing.Size(99, 25);
            this.lblBuyInventoryChosenProductt.TabIndex = 44;
            this.lblBuyInventoryChosenProductt.Text = "Amount:";
            // 
            // BuyInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1442, 860);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuyInventoryAddOrder);
            this.Controls.Add(this.nudBuyInventory);
            this.Controls.Add(this.lblBuyInventoryChosenProductt);
            this.Controls.Add(this.btnBuyInventoryBack);
            this.Controls.Add(this.dgvBuyInventory);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BuyInventory";
            this.Text = "BuyInventory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BuyInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuyInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuyInventoryBack;
        private System.Windows.Forms.DataGridView dgvBuyInventory;
        private System.Windows.Forms.Button btnBuyInventoryAddOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudBuyInventory;
        private System.Windows.Forms.Label lblBuyInventoryChosenProductt;
    }
}