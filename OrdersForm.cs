using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityLinQProject
{
    public partial class OrdersForm : Form
    {
        Model1 model1 = new Model1();
        public OrdersForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            SalesOrderForm salesOrderForm = new SalesOrderForm();
            salesOrderForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            SupplyOrderForm supplyOrderForm = new SupplyOrderForm();
            supplyOrderForm.Show();
        }
    }
}
