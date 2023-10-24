using System;
using System.Linq;
using System.Windows.Forms;

namespace EntityLinQProject
{
    public partial class TransfersForm : Form
    {
        Model1 model1 = new Model1();

        public TransfersForm()
        {
            InitializeComponent();
            dateTimePicker1.Enabled = false;
        }

        private void TransfersForm_Load(object sender, EventArgs e)
        {
            foreach (Stores store in model1.Stores)
            {
                comboBox1.Items.Add(store.StoreName);
                comboBox2.Items.Add(store.StoreName);
            }

            foreach (Products product in model1.Products)
            {
                comboBox3.Items.Add(product.ProductName);
            }

            dateTimePicker1.Value = DateTime.Now.Date;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sourceStoreName = comboBox1.SelectedItem.ToString();
            string destinationStoreName = comboBox2.SelectedItem.ToString();
            string productName = comboBox3.SelectedItem.ToString();
            if (!int.TryParse(textBox1.Text, out int quantity))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }
            DateTime transferDate = dateTimePicker1.Value.Date;
            var sourceStore = model1.Stores.FirstOrDefault(s => s.StoreName == sourceStoreName);

            if (sourceStore == null)
            {
                MessageBox.Show("Source store not found.");
                return;
            }
            var destinationStore = model1.Stores.FirstOrDefault(s => s.StoreName == destinationStoreName);

            if (destinationStore == null)
            {
                MessageBox.Show("Destination store not found.");
                return;
            }
            var product = model1.Products.FirstOrDefault(p => p.ProductName == productName);
            if (product == null)
            {
                MessageBox.Show("Product not found.");
                return;
            }
            var transfer = new Transfers
            {
                TransferID = int.Parse(textBox2.Text),
                FromStoreID = sourceStore.StoreID,
                ToStoreID = destinationStore.StoreID,
                TransferDate = transferDate
            };
            model1.Transfers.Add(transfer);
            var transferDetail = new TransferDetails
            {
                TransferID = transfer.TransferID,
                ProductID = product.ProductID,
                Quantity = quantity,
                TransferDetailID = transfer.TransferID
            };
            transfer.TransferDetails.Add(transferDetail);
            model1.SaveChanges();

            MessageBox.Show("Item transfer recorded successfully.");
            textBox1.Clear();
            dateTimePicker1.Value = DateTime.Now.Date;
        }
    }
}
