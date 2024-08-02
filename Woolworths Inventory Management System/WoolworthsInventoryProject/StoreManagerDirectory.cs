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
    public partial class StoreManagerDirectory : Form
    {
        public Login frmLogin;
        public StoreManagerDirectory(Login frmLogin)
        {
            InitializeComponent();
            this.frmLogin = frmLogin;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RequestReports frmRequestReports = new RequestReports(this);
            frmRequestReports.Show();
            this.Hide();
        }

        private void btnDirectoryProducts_Click(object sender, EventArgs e)
        {
            ViewProducts frmViewProducts = new ViewProducts(this);
            frmViewProducts.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin.Show();
            this.Close();
        }

        private void btnDirectoryCustomers_Click(object sender, EventArgs e)
        {
            ViewCustomerDatabase frmCustomerDatabase = new ViewCustomerDatabase(this);
            frmCustomerDatabase.Show();
            this.Hide();
        }

        private void btnDirectorySuppliers_Click(object sender, EventArgs e)
        {
            SupplierDatabase frmSupplierDatabase = new SupplierDatabase(this);
            frmSupplierDatabase.Show();
            this.Hide();
        }

        private void StoreManagerDirectory_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            btnDirectoryCustomers.Focus();
        }

        private void btnDirectoryInventory_Click(object sender, EventArgs e)
        {
            BuyInventory frmBuyInventory = new BuyInventory(this);
            frmBuyInventory.Show();
            this.Hide();
        }
    }
}
