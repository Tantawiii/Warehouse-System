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
    public partial class SupplyOrderForm : Form
    {
        Model1 model1 = new Model1();
        public SupplyOrderForm()
        {
            InitializeComponent();
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            //textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            dateTimePicker3.Enabled = false;
            dateTimePicker4.Enabled = false;
        }

        private void SupplyOrderForm_Load(object sender, EventArgs e)
        {
            foreach (PurchaseOrderDetails sdo in model1.PurchaseOrderDetails)
            {
                comboBox1.Items.Add(sdo.PurchaseOrderDetailID);
            }
            foreach (Stores stores in model1.Stores)
            {
                comboBox4.Items.Add(stores.StoreName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sdID = int.Parse(comboBox1.SelectedItem.ToString());
            PurchaseOrderDetails selectedSalesOrderDetail = model1.PurchaseOrderDetails.FirstOrDefault(sd => sd.PurchaseOrderDetailID == sdID);
            comboBox2.Items.Clear();
            if (selectedSalesOrderDetail != null)
            {
                comboBox2.Enabled = true;
                int selectedSalesOrderID = (int)selectedSalesOrderDetail.PurchaseOrderID;
                var salesOrderIDs = model1.PurchaseOrderDetails.Where(sd => sd.PurchaseOrderID == selectedSalesOrderID).Select(sd => sd.PurchaseOrderID).Distinct().ToList();
                foreach (int orderID in salesOrderIDs)
                {
                    comboBox2.Items.Add(orderID);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sdID = int.Parse(comboBox1.SelectedItem.ToString());
            PurchaseOrderDetails selectedSalesOrderDetail = model1.PurchaseOrderDetails.FirstOrDefault(sd => sd.PurchaseOrderDetailID == sdID);
            comboBox3.Items.Clear();
            if (comboBox2.SelectedItem != null)
            {
                int selectedSalesOrderID = (int)selectedSalesOrderDetail.PurchaseOrderID;
                var salesOrderIDs = model1.PurchaseOrderDetails.Where(sd => sd.PurchaseOrderID == selectedSalesOrderID).Select(sd => sd.PurchaseOrderID).Distinct().ToList();
                comboBox3.Enabled = true;
                var productNames = model1.PurchaseOrderDetails.Where(sd => sd.PurchaseOrderID == selectedSalesOrderID).Select(sd => sd.Products.ProductName).Distinct().ToList();
                foreach (string productName in productNames)
                {
                    comboBox3.Items.Add(productName);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProductName = comboBox3.SelectedItem.ToString();
            int selectedSalesOrderID = int.Parse(comboBox2.SelectedItem.ToString());
            PurchaseOrderDetails selectedSalesOrderDetail = model1.PurchaseOrderDetails.FirstOrDefault(sd => sd.PurchaseOrderID == selectedSalesOrderID && sd.Products.ProductName == selectedProductName);
            PurchaseOrders selectedSalesOrder = model1.PurchaseOrders.FirstOrDefault(so => so.PurchaseOrderID == selectedSalesOrderID);
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker3.Enabled = true;
            if (selectedSalesOrderDetail != null && selectedSalesOrder != null)
            {
                textBox1.Text = selectedSalesOrderDetail.Quantity.ToString();
                textBox2.Text = selectedSalesOrderDetail.UnitPrice.ToString();
                textBox3.Text = selectedSalesOrder.Stores.StoreName;
                textBox4.Text = selectedSalesOrder.Suppliers.SupplierName;
                dateTimePicker1.Text = selectedSalesOrder.OrderDate.ToString();
                dateTimePicker3.Text = selectedSalesOrder.ExpectedDeliveryDate.ToString();
            }
            else
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                dateTimePicker1.Text = string.Empty;
                dateTimePicker3.Text = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedProductName = comboBox3.SelectedItem.ToString();
            int selectedSalesOrderID = int.Parse(comboBox2.SelectedItem.ToString());
            PurchaseOrderDetails selectedSalesOrderDetail = model1.PurchaseOrderDetails.FirstOrDefault(sd => sd.PurchaseOrderID == selectedSalesOrderID && sd.Products.ProductName == selectedProductName);
            PurchaseOrders selectedSalesOrder = model1.PurchaseOrders.FirstOrDefault(so => so.PurchaseOrderID == selectedSalesOrderID);
            if (selectedSalesOrderDetail != null && selectedSalesOrder != null)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && dateTimePicker1.Text != "")
                {
                    selectedSalesOrderDetail.Quantity = int.Parse(textBox1.Text);
                    selectedSalesOrderDetail.UnitPrice = decimal.Parse(textBox2.Text);
                    selectedSalesOrder.Stores.StoreName = textBox3.Text;
                    selectedSalesOrder.Suppliers.SupplierName = textBox4.Text;
                    selectedSalesOrder.OrderDate = DateTime.Parse(dateTimePicker1.Text);
                    selectedSalesOrder.ExpectedDeliveryDate = DateTime.Parse(dateTimePicker3.Text);
                    model1.SaveChanges();
                    MessageBox.Show("Data updated successfully!");
                }
                else
                {
                    MessageBox.Show("No Data Available about such Customer!");
                }
            }
            else
            {
                MessageBox.Show("Not Available Data!");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            if (comboBox4.SelectedItem != null)
            {
                comboBox5.Enabled = true;
                foreach (Products products in model1.Products)
                {
                    comboBox5.Items.Add(products.ProductName);
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            if (comboBox5.SelectedItem != null)
            {
                comboBox6.Enabled = true;
                foreach (Suppliers suppliers in model1.Suppliers)
                {
                    comboBox6.Items.Add(suppliers.SupplierName);
                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedItem != null)
            {
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                comboBox6.Enabled = true;
                dateTimePicker2.Enabled = true;
                dateTimePicker4.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PurchaseOrderDetails salesOrderDetails = new PurchaseOrderDetails();
            PurchaseOrders salesOrders = new PurchaseOrders();
            PurchaseOrderDetails salesOrderDetail = model1.PurchaseOrderDetails.Find(int.Parse(textBox9.Text));
            PurchaseOrders salesOrders1 = model1.PurchaseOrders.Find(int.Parse(textBox6.Text));
            Stores stores = model1.Stores.FirstOrDefault(s => s.StoreName == comboBox4.SelectedItem.ToString());
            Products products = model1.Products.FirstOrDefault(s => s.ProductName == comboBox5.SelectedItem.ToString());
            Suppliers suppliers = model1.Suppliers.FirstOrDefault(c => c.SupplierName == comboBox6.SelectedItem.ToString());
            if (comboBox4.SelectedItem != null && comboBox5.SelectedItem != null && comboBox6.SelectedItem != null && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && dateTimePicker2.Text != "" && dateTimePicker4.Text != "")
            {
                if (salesOrderDetail == null && salesOrders1 == null)
                {
                    salesOrders.StoreID = stores.StoreID;
                    salesOrderDetails.ProductID = products.ProductID;
                    salesOrders.SupplierID = suppliers.SupplierID;
                    salesOrders.PurchaseOrderID = int.Parse(textBox6.Text);
                    salesOrderDetails.PurchaseOrderID = int.Parse(textBox6.Text);
                    salesOrderDetails.Quantity = int.Parse(textBox7.Text);
                    salesOrderDetails.UnitPrice = decimal.Parse(textBox8.Text);
                    salesOrderDetails.PurchaseOrderDetailID = int.Parse(textBox9.Text);
                    salesOrders.OrderDate = DateTime.Parse(dateTimePicker2.Text);
                    salesOrders.ExpectedDeliveryDate = DateTime.Parse(dateTimePicker4.Text);
                    model1.PurchaseOrders.Add(salesOrders);
                    model1.PurchaseOrderDetails.Add(salesOrderDetails);
                    model1.SaveChanges();
                    comboBox1.Items.Add(textBox9.Text);
                    comboBox2.Items.Add(textBox6.Text);
                    textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = "";
                    MessageBox.Show("Data added successfully!");
                }
                else
                {
                    MessageBox.Show("Such Purchase Already Exists!");
                }
            }
            else
            {
                MessageBox.Show("Some Data is missing!");
            }
        }
    }
}
