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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Stores
        {
            StoresForm storesForm = new StoresForm();
            storesForm.Show();
        }

        private void button2_Click(object sender, EventArgs e) //Products
        {
            ProductsForm productsForm = new ProductsForm();
            productsForm.Show();
        }

        private void button3_Click(object sender, EventArgs e) //Suppliers
        {
            SuppliersForm suppliersForm = new SuppliersForm();
            suppliersForm.Show();
        }

        private void button4_Click(object sender, EventArgs e) //Customers
        {
            CustomersForm customersForm = new CustomersForm();
            customersForm.Show();
        }

        private void button5_Click(object sender, EventArgs e) //Orders
        {
            OrdersForm ordersForm = new OrdersForm();
            ordersForm.Show();
        }

        private void button6_Click(object sender, EventArgs e) //Reports
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TransfersForm transfersForm = new TransfersForm();
            transfersForm.Show();
        }
    }
}
