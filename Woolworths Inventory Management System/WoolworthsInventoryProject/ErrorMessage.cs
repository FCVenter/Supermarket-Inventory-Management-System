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
    public partial class ErrorMessage : Form
    {
        public bool confirm;
        public ErrorMessage()
        {
            InitializeComponent();
        }

        public ErrorMessage(string message)
        {
            InitializeComponent();
            lblErrorMessage.Text = message;
        }

        private void ErrorMessage_Load(object sender, EventArgs e)
        {
            btnErrorMessageYes.Focus();
        }

        private void btnErrorMessageYes_Click(object sender, EventArgs e)
        {
            confirm = true;
            this.Close();
        }

        private void btnErrorMessageNo_Click(object sender, EventArgs e)
        {
            confirm = false;
            this.Close();
        }
    }
}
