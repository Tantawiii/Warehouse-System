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
    public partial class ProductReportForm : Form
    {
        Model1 model1 = new Model1();

        public ProductReportForm()
        {
            InitializeComponent();
        }
        private void ProductReportForm_Load(object sender, EventArgs e)
        {
            foreach (Products products in model1.Products)
            {
                comboBox1.Items.Add(products.ProductName);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedProductName = comboBox1.SelectedItem.ToString();
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            var reportData = model1.PurchaseOrderDetails
                .Where(pod => pod.Products.ProductName == selectedProductName &&
                               pod.PurchaseOrders.OrderDate >= startDate &&
                               pod.PurchaseOrders.ExpectedDeliveryDate <= endDate)
                .Select(pod => new
                {
                    ItemName = pod.Products.ProductName,
                    Quantity = pod.Quantity,
                    UnitPrice = pod.UnitPrice,
                    StoreName = pod.PurchaseOrders.Stores.StoreName,
                    OrderDate = pod.PurchaseOrders.OrderDate,
                    ExpireDate = pod.PurchaseOrders.ExpectedDeliveryDate
                })
                .ToList();
            dataGridView1.DataSource = reportData;
        }
    }
}
