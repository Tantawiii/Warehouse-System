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
    public partial class ProductsForm : Form
    {
        Model1 model1 = new Model1();

        public ProductsForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productID = int.Parse(comboBox1.SelectedItem.ToString());
            Products products = model1.Products.FirstOrDefault(p => p.ProductID == productID);
            textBox1.Text = products.ProductID.ToString();
            textBox2.Text = products.ProductName;
            textBox3.Text = products.ProductCode;
            textBox4.Text = products.UnitOfMeasurement;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                Products products1 = model1.Products.Find(int.Parse(textBox1.Text));
                if (products1 == null)
                {
                    products.ProductID = int.Parse(textBox1.Text);
                    products.ProductName = textBox2.Text;
                    products.ProductCode = textBox3.Text;
                    products.UnitOfMeasurement = textBox4.Text;
                    model1.Products.Add(products1);
                    model1.SaveChanges();
                    comboBox1.Items.Add(textBox1.Text);
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("Product Already Exists!");
                }
            }
            else
            {
                MessageBox.Show("Some Data is missing!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Products pr = model1.Products.Find(int.Parse(textBox1.Text));
            if (pr != null)
            {
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    pr.ProductName = textBox2.Text;
                    pr.ProductCode = textBox3.Text;
                    pr.UnitOfMeasurement = textBox4.Text;
                    model1.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("No Data Available about such Store!");
                }
            }
            else
            {
                MessageBox.Show("Not Available Data!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            foreach (Products products in model1.Products)
            {
                comboBox1.Items.Add(products.ProductID);
            }
        }
    }
}
