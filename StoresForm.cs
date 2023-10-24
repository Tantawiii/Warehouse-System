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
    public partial class StoresForm : Form
    {
        Model1 model1 = new Model1();
        public StoresForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stores Store = new Stores();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                Stores st = model1.Stores.Find(int.Parse(textBox1.Text));
                if (st == null)
                {
                    Store.StoreID = int.Parse(textBox1.Text);
                    Store.StoreName = textBox2.Text;
                    Store.Address = textBox3.Text;
                    Store.ResponsiblePerson = textBox4.Text;
                    model1.Stores.Add(Store);
                    model1.SaveChanges();
                    comboBox1.Items.Add(textBox1.Text);
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("Store Already Exists!");
                }
            }
            else
            {
                MessageBox.Show("Some Data is missing!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stores st = model1.Stores.Find(int.Parse(textBox1.Text));
            if (st != null)
            {
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    st.StoreName = textBox2.Text;
                    st.Address = textBox3.Text;
                    st.ResponsiblePerson = textBox4.Text;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int storeID = int.Parse(comboBox1.SelectedItem.ToString());
            Stores Store = model1.Stores.FirstOrDefault(s => s.StoreID == storeID);
            textBox1.Text = Store.StoreID.ToString();
            textBox2.Text = Store.StoreName;
            textBox3.Text = Store.Address;
            textBox4.Text = Store.ResponsiblePerson;
        }

        private void StoresForm_Load(object sender, EventArgs e)
        {
                foreach (Stores stores in model1.Stores)
                {
                    comboBox1.Items.Add(stores.StoreID);
                }
        }
    }
}
