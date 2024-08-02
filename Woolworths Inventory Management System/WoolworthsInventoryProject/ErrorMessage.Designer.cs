
namespace WoolworthsInventorySystem
{
    partial class ErrorMessage
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
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.btnErrorMessageNo = new System.Windows.Forms.Button();
            this.btnErrorMessageYes = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.BackColor = System.Drawing.Color.Black;
            this.lblErrorMessage.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.White;
            this.lblErrorMessage.Location = new System.Drawing.Point(553, 199);
            this.lblErrorMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(415, 17);
            this.lblErrorMessage.TabIndex = 65;
            this.lblErrorMessage.Text = "GENERAL VALIDATION MESSAGE FOR DIFFERENT FORMS";
            // 
            // btnErrorMessageNo
            // 
            this.btnErrorMessageNo.BackColor = System.Drawing.Color.Black;
            this.btnErrorMessageNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnErrorMessageNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErrorMessageNo.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErrorMessageNo.ForeColor = System.Drawing.Color.White;
            this.btnErrorMessageNo.Location = new System.Drawing.Point(814, 457);
            this.btnErrorMessageNo.Margin = new System.Windows.Forms.Padding(2);
            this.btnErrorMessageNo.Name = "btnErrorMessageNo";
            this.btnErrorMessageNo.Size = new System.Drawing.Size(187, 36);
            this.btnErrorMessageNo.TabIndex = 64;
            this.btnErrorMessageNo.Text = "NO";
            this.btnErrorMessageNo.UseVisualStyleBackColor = false;
            this.btnErrorMessageNo.Click += new System.EventHandler(this.btnErrorMessageNo_Click);
            // 
            // btnErrorMessageYes
            // 
            this.btnErrorMessageYes.BackColor = System.Drawing.Color.White;
            this.btnErrorMessageYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnErrorMessageYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErrorMessageYes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErrorMessageYes.Location = new System.Drawing.Point(556, 457);
            this.btnErrorMessageYes.Margin = new System.Windows.Forms.Padding(2);
            this.btnErrorMessageYes.Name = "btnErrorMessageYes";
            this.btnErrorMessageYes.Size = new System.Drawing.Size(187, 36);
            this.btnErrorMessageYes.TabIndex = 63;
            this.btnErrorMessageYes.Text = "YES";
            this.btnErrorMessageYes.UseVisualStyleBackColor = false;
            this.btnErrorMessageYes.Click += new System.EventHandler(this.btnErrorMessageYes_Click);
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
            this.label9.TabIndex = 62;
            this.label9.Text = "WOOLWORTHS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(553, 408);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 17);
            this.label1.TabIndex = 102;
            this.label1.Text = "WOULD YOU LIKE TO CONTINUE?";
            // 
            // ErrorMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1442, 860);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.btnErrorMessageNo);
            this.Controls.Add(this.btnErrorMessageYes);
            this.Controls.Add(this.label9);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ErrorMessage";
            this.Text = "ErrorMessage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ErrorMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnErrorMessageNo;
        private System.Windows.Forms.Button btnErrorMessageYes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblErrorMessage;
    }
}