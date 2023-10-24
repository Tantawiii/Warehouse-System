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
    public partial class TransfersReportForm : Form
    {
        Model1 model1 = new Model1();
        public TransfersReportForm()
        {
            InitializeComponent();
        }

        private void TransfersReportForm_Load(object sender, EventArgs e)
        {
            foreach (Stores stores in model1.Stores)
            {
                comboBox1.Items.Add(stores.StoreID);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedStoreID = comboBox1.SelectedItem.ToString();
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            var reportData = model1.TransferDetails
                .Where(td => (td.Transfers.FromStoreID.ToString() == selectedStoreID || td.Transfers.ToStoreID.ToString() == selectedStoreID) &&
                              td.Transfers.TransferDate >= startDate && td.Transfers.TransferDate <= endDate)
                .Select(td => new
                {
                    ProductName = td.Products.ProductName,
                    MovementType = (td.Transfers.FromStoreID.ToString() == selectedStoreID) ? "Outgoing" : "Incoming",
                    Quantity = td.Quantity,
                    MovementDate = td.Transfers.TransferDate
                })
                .ToList();
            dataGridView1.DataSource = reportData;
        }
    }
}
