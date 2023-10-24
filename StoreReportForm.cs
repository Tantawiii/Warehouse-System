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
    public partial class StoreReportForm : Form
    {
        Model1 model1 = new Model1();
        public StoreReportForm()
        {
            InitializeComponent();
        }
        private void StoreReportForm_Load(object sender, EventArgs e)
        {
            foreach (Stores stores in model1.Stores)
            {
                comboBox1.Items.Add(stores.StoreName);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedStoreName = comboBox1.SelectedItem.ToString();
            DateTime selectedStartDate = dateTimePicker1.Value;
            DateTime selectedEndDate = dateTimePicker2.Value;
            var reportData = model1.PurchaseOrders
                .Where(po => po.Stores.StoreName == selectedStoreName && po.OrderDate >= selectedStartDate && po.OrderDate <= selectedEndDate)
                .Select(po => new
                {
                    OrderNumber = po.PurchaseOrderID,
                    OrderDate = po.OrderDate,
                    ExpireDate = po.ExpectedDeliveryDate,
                    ProductName = po.PurchaseOrderDetails.FirstOrDefault().Products.ProductName,
                    SupplierName = po.Suppliers.SupplierName
                })
                .ToList();
            dataGridView1.DataSource = reportData;
        }
    }
}
