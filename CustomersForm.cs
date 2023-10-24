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
    public partial class CustomersForm : Form
    {
        Model1 model1 = new Model1();

        public CustomersForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                Customers cs = model1.Customers.Find(int.Parse(textBox1.Text));
                if (cs == null)
                {
                    customers.CustomerID = int.Parse(textBox1.Text);
                    customers.CustomerName = textBox2.Text;
                    customers.Phone = textBox3.Text;
                    customers.Fax = textBox4.Text;
                    customers.Mobile = textBox5.Text;
                    customers.Email = textBox6.Text;
                    customers.Website = textBox7.Text;
                    model1.Customers.Add(customers);
                    model1.SaveChanges();
                    comboBox1.Items.Add(textBox1.Text);
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                }
                else
                {
                    MessageBox.Show("Customer Already Exists!");
                }
            }
            else
            {
                MessageBox.Show("Some Data is missing!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customers cs = model1.Customers.Find(int.Parse(textBox1.Text));
            if (cs != null)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                {
                    cs.CustomerName = textBox2.Text;
                    cs.Phone = textBox3.Text;
                    cs.Fax = textBox4.Text;
                    cs.Mobile = textBox5.Text;
                    cs.Email = textBox6.Text;
                    cs.Website = textBox7.Text;
                    model1.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int customerID = int.Parse(comboBox1.SelectedItem.ToString());
            Customers customers = model1.Customers.FirstOrDefault(c => c.CustomerID == customerID);
            textBox1.Text = customers.CustomerID.ToString();
            textBox2.Text = customers.CustomerName;
            textBox3.Text = customers.Phone;
            textBox4.Text = customers.Fax;
            textBox5.Text = customers.Mobile;
            textBox6.Text = customers.Email;
            textBox7.Text = customers.Website;
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            foreach (Customers customers in model1.Customers)
            {
                comboBox1.Items.Add(customers.CustomerID);
            }
        }
    }
}
