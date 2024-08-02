
namespace WoolworthsInventorySystem
{
    partial class ViewProducts
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
            this.dgvViewProducts = new System.Windows.Forms.DataGridView();
            this.btnViewProductsAdd = new System.Windows.Forms.Button();
            this.btnViewProductsUpdate = new System.Windows.Forms.Button();
            this.btnViewProductsDelete = new System.Windows.Forms.Button();
            this.btnViewProductsBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvViewProducts
            // 
            this.dgvViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewProducts.Location = new System.Drawing.Point(356, 269);
            this.dgvViewProducts.Margin = new System.Windows.Forms.Padding(2);
            this.dgvViewProducts.Name = "dgvViewProducts";
            this.dgvViewProducts.RowHeadersWidth = 51;
            this.dgvViewProducts.RowTemplate.Height = 24;
            this.dgvViewProducts.Size = new System.Drawing.Size(794, 328);
            this.dgvViewProducts.TabIndex = 1;
            // 
            // btnViewProductsAdd
            // 
            this.btnViewProductsAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewProductsAdd.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewProductsAdd.Location = new System.Drawing.Point(356, 614);
            this.btnViewProductsAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewProductsAdd.Name = "btnViewProductsAdd";
            this.btnViewProductsAdd.Size = new System.Drawing.Size(177, 51);
            this.btnViewProductsAdd.TabIndex = 2;
            this.btnViewProductsAdd.Text = "ADD ITEM";
            this.btnViewProductsAdd.UseVisualStyleBackColor = true;
            this.btnViewProductsAdd.Click += new System.EventHandler(this.btnViewProductsAdd_Click);
            // 
            // btnViewProductsUpdate
            // 
            this.btnViewProductsUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewProductsUpdate.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewProductsUpdate.Location = new System.Drawing.Point(679, 614);
            this.btnViewProductsUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewProductsUpdate.Name = "btnViewProductsUpdate";
            this.btnViewProductsUpdate.Size = new System.Drawing.Size(177, 51);
            this.btnViewProductsUpdate.TabIndex = 3;
            this.btnViewProductsUpdate.Text = "CHANGE ITEM";
            this.btnViewProductsUpdate.UseVisualStyleBackColor = true;
            this.btnViewProductsUpdate.Click += new System.EventHandler(this.btnViewProductsUpdate_Click);
            // 
            // btnViewProductsDelete
            // 
            this.btnViewProductsDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewProductsDelete.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewProductsDelete.Location = new System.Drawing.Point(972, 614);
            this.btnViewProductsDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewProductsDelete.Name = "btnViewProductsDelete";
            this.btnViewProductsDelete.Size = new System.Drawing.Size(177, 51);
            this.btnViewProductsDelete.TabIndex = 4;
            this.btnViewProductsDelete.Text = "DELETE ITEM";
            this.btnViewProductsDelete.UseVisualStyleBackColor = true;
            this.btnViewProductsDelete.Click += new System.EventHandler(this.btnViewProductsDelete_Click);
            // 
            // btnViewProductsBack
            // 
            this.btnViewProductsBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewProductsBack.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewProductsBack.Location = new System.Drawing.Point(1328, 8);
            this.btnViewProductsBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewProductsBack.Name = "btnViewProductsBack";
            this.btnViewProductsBack.Size = new System.Drawing.Size(105, 38);
            this.btnViewProductsBack.TabIndex = 18;
            this.btnViewProductsBack.Text = "BACK";
            this.btnViewProductsBack.UseVisualStyleBackColor = true;
            this.btnViewProductsBack.Click += new System.EventHandler(this.btnMaintainProductsBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 41);
            this.label1.TabIndex = 99;
            this.label1.Text = "WOOLWORTHS";
            // 
            // ViewProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1442, 860);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnViewProductsBack);
            this.Controls.Add(this.btnViewProductsDelete);
            this.Controls.Add(this.btnViewProductsUpdate);
            this.Controls.Add(this.btnViewProductsAdd);
            this.Controls.Add(this.dgvViewProducts);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewProducts";
            this.Text = "Maintain Products";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ViewProducts_Load);
            this.Shown += new System.EventHandler(this.ViewProducts_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvViewProducts;
        private System.Windows.Forms.Button btnViewProductsAdd;
        private System.Windows.Forms.Button btnViewProductsUpdate;
        private System.Windows.Forms.Button btnViewProductsDelete;
        private System.Windows.Forms.Button btnViewProductsBack;
        private System.Windows.Forms.Label label1;
    }
}

