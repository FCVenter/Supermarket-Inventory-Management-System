
namespace WoolworthsInventorySystem
{
    partial class SupplierDatabase
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
            this.label9 = new System.Windows.Forms.Label();
            this.btnSupplierDatabaseBack = new System.Windows.Forms.Button();
            this.btnSupplierDatabaseAddSupplier = new System.Windows.Forms.Button();
            this.dgvSupplierDatabase = new System.Windows.Forms.DataGridView();
            this.btnSupplierDatabaseUpdateSupplier = new System.Windows.Forms.Button();
            this.btnSupplierDatabaseDeleteSupplier = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierDatabase)).BeginInit();
            this.SuspendLayout();
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
            this.label9.TabIndex = 84;
            this.label9.Text = "WOOLWORTHS";
            // 
            // btnSupplierDatabaseBack
            // 
            this.btnSupplierDatabaseBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplierDatabaseBack.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplierDatabaseBack.Location = new System.Drawing.Point(1328, 7);
            this.btnSupplierDatabaseBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnSupplierDatabaseBack.Name = "btnSupplierDatabaseBack";
            this.btnSupplierDatabaseBack.Size = new System.Drawing.Size(105, 38);
            this.btnSupplierDatabaseBack.TabIndex = 101;
            this.btnSupplierDatabaseBack.Text = "BACK";
            this.btnSupplierDatabaseBack.UseVisualStyleBackColor = true;
            this.btnSupplierDatabaseBack.Click += new System.EventHandler(this.btnSupplierDatabaseBack_Click);
            // 
            // btnSupplierDatabaseAddSupplier
            // 
            this.btnSupplierDatabaseAddSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplierDatabaseAddSupplier.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplierDatabaseAddSupplier.Location = new System.Drawing.Point(412, 566);
            this.btnSupplierDatabaseAddSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.btnSupplierDatabaseAddSupplier.Name = "btnSupplierDatabaseAddSupplier";
            this.btnSupplierDatabaseAddSupplier.Size = new System.Drawing.Size(187, 36);
            this.btnSupplierDatabaseAddSupplier.TabIndex = 106;
            this.btnSupplierDatabaseAddSupplier.Text = "ADD NEW SUPPLIER";
            this.btnSupplierDatabaseAddSupplier.UseVisualStyleBackColor = true;
            this.btnSupplierDatabaseAddSupplier.Click += new System.EventHandler(this.btnSupplierDatabaseAddSupplier_Click);
            // 
            // dgvSupplierDatabase
            // 
            this.dgvSupplierDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplierDatabase.Location = new System.Drawing.Point(411, 142);
            this.dgvSupplierDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSupplierDatabase.Name = "dgvSupplierDatabase";
            this.dgvSupplierDatabase.RowHeadersWidth = 51;
            this.dgvSupplierDatabase.RowTemplate.Height = 24;
            this.dgvSupplierDatabase.Size = new System.Drawing.Size(724, 405);
            this.dgvSupplierDatabase.TabIndex = 103;
            // 
            // btnSupplierDatabaseUpdateSupplier
            // 
            this.btnSupplierDatabaseUpdateSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplierDatabaseUpdateSupplier.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplierDatabaseUpdateSupplier.Location = new System.Drawing.Point(680, 566);
            this.btnSupplierDatabaseUpdateSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.btnSupplierDatabaseUpdateSupplier.Name = "btnSupplierDatabaseUpdateSupplier";
            this.btnSupplierDatabaseUpdateSupplier.Size = new System.Drawing.Size(221, 36);
            this.btnSupplierDatabaseUpdateSupplier.TabIndex = 102;
            this.btnSupplierDatabaseUpdateSupplier.Text = "CHANGE SUPPLIER DETAILS";
            this.btnSupplierDatabaseUpdateSupplier.UseVisualStyleBackColor = true;
            this.btnSupplierDatabaseUpdateSupplier.Click += new System.EventHandler(this.btnSupplierDatabaseUpdate_Click);
            // 
            // btnSupplierDatabaseDeleteSupplier
            // 
            this.btnSupplierDatabaseDeleteSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplierDatabaseDeleteSupplier.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplierDatabaseDeleteSupplier.Location = new System.Drawing.Point(971, 566);
            this.btnSupplierDatabaseDeleteSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.btnSupplierDatabaseDeleteSupplier.Name = "btnSupplierDatabaseDeleteSupplier";
            this.btnSupplierDatabaseDeleteSupplier.Size = new System.Drawing.Size(164, 36);
            this.btnSupplierDatabaseDeleteSupplier.TabIndex = 107;
            this.btnSupplierDatabaseDeleteSupplier.Text = "DELETE SUPPLIER DETAILS";
            this.btnSupplierDatabaseDeleteSupplier.UseVisualStyleBackColor = true;
            this.btnSupplierDatabaseDeleteSupplier.Click += new System.EventHandler(this.btnSupplierDatabaseDeleteSupplier_Click);
            // 
            // SupplierDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1442, 860);
            this.Controls.Add(this.btnSupplierDatabaseDeleteSupplier);
            this.Controls.Add(this.btnSupplierDatabaseAddSupplier);
            this.Controls.Add(this.dgvSupplierDatabase);
            this.Controls.Add(this.btnSupplierDatabaseUpdateSupplier);
            this.Controls.Add(this.btnSupplierDatabaseBack);
            this.Controls.Add(this.label9);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SupplierDatabase";
            this.Text = "SupplierDatabase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SupplierDatabase_Load);
            this.Shown += new System.EventHandler(this.SupplierDatabase_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierDatabase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSupplierDatabaseBack;
        private System.Windows.Forms.Button btnSupplierDatabaseAddSupplier;
        private System.Windows.Forms.DataGridView dgvSupplierDatabase;
        private System.Windows.Forms.Button btnSupplierDatabaseUpdateSupplier;
        private System.Windows.Forms.Button btnSupplierDatabaseDeleteSupplier;
    }
}