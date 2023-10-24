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
    public partial class ExpiredReportForm : Form
    {
        Model1 model1 = new Model1();
        public ExpiredReportForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string selectedStoreName = comboBox1.SelectedItem.ToString();
            DateTime orderDate = dateTimePicker1.Value;
            DateTime pastDate = DateTime.Now.AddDays(-15);
            var reportData = model1.PurchaseOrderDetails
                .Where(pod => pod.PurchaseOrders.Stores.StoreName == selectedStoreName &&
                               pod.PurchaseOrders.OrderDate <= pastDate)
                .Select(pod => new
                {
                    StoreName = pod.PurchaseOrders.Stores.StoreName,
                    ProductName = pod.Products.ProductName,
                    Quantity = pod.Quantity,
                    OrderDate = pod.PurchaseOrders.OrderDate
                })
                .ToList();
            dataGridView1.DataSource = reportData;
        }

        private void ExpiredReportForm_Load_1(object sender, EventArgs e)
        {
            foreach (Stores stores in model1.Stores)
            {
                comboBox1.Items.Add(stores.StoreName);
            }
        }
    }
}
