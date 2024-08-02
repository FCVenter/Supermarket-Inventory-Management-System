
namespace WoolworthsInventorySystem
{
    partial class ViewCustomerDatabase
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
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.btnViewCustomerDetailsChangeDetails = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewCustomerDatabaseBack = new System.Windows.Forms.Button();
            this.btnViewCustomerDetailsDeleteAcc = new System.Windows.Forms.Button();
            this.btnViewCustomerDetailsAddCustomer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Location = new System.Drawing.Point(424, 212);
            this.dgvCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.RowHeadersWidth = 51;
            this.dgvCustomer.RowTemplate.Height = 24;
            this.dgvCustomer.Size = new System.Drawing.Size(724, 436);
            this.dgvCustomer.TabIndex = 23;
            // 
            // btnViewCustomerDetailsChangeDetails
            // 
            this.btnViewCustomerDetailsChangeDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewCustomerDetailsChangeDetails.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCustomerDetailsChangeDetails.Location = new System.Drawing.Point(694, 677);
            this.btnViewCustomerDetailsChangeDetails.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewCustomerDetailsChangeDetails.Name = "btnViewCustomerDetailsChangeDetails";
            this.btnViewCustomerDetailsChangeDetails.Size = new System.Drawing.Size(202, 54);
            this.btnViewCustomerDetailsChangeDetails.TabIndex = 22;
            this.btnViewCustomerDetailsChangeDetails.Text = "CHANGE CUSTOMER DETAILS";
            this.btnViewCustomerDetailsChangeDetails.UseVisualStyleBackColor = true;
            this.btnViewCustomerDetailsChangeDetails.Click += new System.EventHandler(this.btnViewCustomerDetailsChangeDetails_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 41);
            this.label2.TabIndex = 99;
            this.label2.Text = "WOOLWORTHS";
            // 
            // btnViewCustomerDatabaseBack
            // 
            this.btnViewCustomerDatabaseBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewCustomerDatabaseBack.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCustomerDatabaseBack.Location = new System.Drawing.Point(1328, 7);
            this.btnViewCustomerDatabaseBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewCustomerDatabaseBack.Name = "btnViewCustomerDatabaseBack";
            this.btnViewCustomerDatabaseBack.Size = new System.Drawing.Size(105, 38);
            this.btnViewCustomerDatabaseBack.TabIndex = 100;
            this.btnViewCustomerDatabaseBack.Text = "BACK";
            this.btnViewCustomerDatabaseBack.UseVisualStyleBackColor = true;
            this.btnViewCustomerDatabaseBack.Click += new System.EventHandler(this.btnViewCustomerDatabaseBack_Click);
            // 
            // btnViewCustomerDetailsDeleteAcc
            // 
            this.btnViewCustomerDetailsDeleteAcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewCustomerDetailsDeleteAcc.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCustomerDetailsDeleteAcc.Location = new System.Drawing.Point(956, 674);
            this.btnViewCustomerDetailsDeleteAcc.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewCustomerDetailsDeleteAcc.Name = "btnViewCustomerDetailsDeleteAcc";
            this.btnViewCustomerDetailsDeleteAcc.Size = new System.Drawing.Size(192, 54);
            this.btnViewCustomerDetailsDeleteAcc.TabIndex = 105;
            this.btnViewCustomerDetailsDeleteAcc.Text = "DELETE CUSTOMER ACCOUNT";
            this.btnViewCustomerDetailsDeleteAcc.UseVisualStyleBackColor = true;
            this.btnViewCustomerDetailsDeleteAcc.Click += new System.EventHandler(this.btnViewCustomerDetailsDeleteAcc_Click);
            // 
            // btnViewCustomerDetailsAddCustomer
            // 
            this.btnViewCustomerDetailsAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewCustomerDetailsAddCustomer.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCustomerDetailsAddCustomer.Location = new System.Drawing.Point(424, 677);
            this.btnViewCustomerDetailsAddCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewCustomerDetailsAddCustomer.Name = "btnViewCustomerDetailsAddCustomer";
            this.btnViewCustomerDetailsAddCustomer.Size = new System.Drawing.Size(189, 54);
            this.btnViewCustomerDetailsAddCustomer.TabIndex = 106;
            this.btnViewCustomerDetailsAddCustomer.Text = "ADD NEW CUSTOMER";
            this.btnViewCustomerDetailsAddCustomer.UseVisualStyleBackColor = true;
            this.btnViewCustomerDetailsAddCustomer.Click += new System.EventHandler(this.btnViewCustomerDetailsAddCustomer_Click);
            // 
            // ViewCustomerDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1442, 860);
            this.Controls.Add(this.btnViewCustomerDetailsAddCustomer);
            this.Controls.Add(this.btnViewCustomerDetailsDeleteAcc);
            this.Controls.Add(this.btnViewCustomerDatabaseBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvCustomer);
            this.Controls.Add(this.btnViewCustomerDetailsChangeDetails);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewCustomerDatabase";
            this.Text = "ViewCustomerDatabase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ViewCustomerDatabase_Load);
            this.Shown += new System.EventHandler(this.ViewCustomerDatabase_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.Button btnViewCustomerDetailsChangeDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewCustomerDatabaseBack;
        private System.Windows.Forms.Button btnViewCustomerDetailsDeleteAcc;
        private System.Windows.Forms.Button btnViewCustomerDetailsAddCustomer;
    }
}