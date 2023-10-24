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
    public partial class SuppliersForm : Form
    {
        Model1 model1 = new Model1();

        public SuppliersForm()
        {
            InitializeComponent();
        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            foreach (Suppliers suppliers in model1.Suppliers)
            {
                comboBox1.Items.Add(suppliers.SupplierID);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int supplierID = int.Parse(comboBox1.SelectedItem.ToString());
            Suppliers suppliers = model1.Suppliers.FirstOrDefault(c => c.SupplierID == supplierID);
            textBox1.Text = suppliers.SupplierID.ToString();
            textBox2.Text = suppliers.SupplierName;
            textBox3.Text = suppliers.Phone;
            textBox4.Text = suppliers.Fax;
            textBox5.Text = suppliers.Mobile;
            textBox6.Text = suppliers.Email;
            textBox7.Text = suppliers.Website;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                Suppliers su = model1.Suppliers.Find(int.Parse(textBox1.Text));
                if (su == null)
                {
                    suppliers.SupplierID = int.Parse(textBox1.Text);
                    suppliers.SupplierName = textBox2.Text;
                    suppliers.Phone = textBox3.Text;
                    suppliers.Fax = textBox4.Text;
                    suppliers.Mobile = textBox5.Text;
                    suppliers.Email = textBox6.Text;
                    suppliers.Website = textBox7.Text;
                    model1.Suppliers.Add(suppliers);
                    model1.SaveChanges();
                    comboBox1.Items.Add(textBox1.Text);
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                }
                else
                {
                    MessageBox.Show("Supplier Already Exists!");
                }
            }
            else
            {
                MessageBox.Show("Some Data is missing!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Suppliers su = model1.Suppliers.Find(int.Parse(textBox1.Text));
            if (su != null)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                {
                    su.SupplierName = textBox2.Text;
                    su.Phone = textBox3.Text;
                    su.Fax = textBox4.Text;
                    su.Mobile = textBox5.Text;
                    su.Email = textBox6.Text;
                    su.Website = textBox7.Text;
                    model1.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                }
                else
                {
                    MessageBox.Show("No Data Available about such Supplier!");
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
    }
}
