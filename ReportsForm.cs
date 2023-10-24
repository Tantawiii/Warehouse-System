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
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            StoreReportForm storeReportForm = new StoreReportForm();
            storeReportForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            ProductReportForm productReportForm = new ProductReportForm();
            productReportForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            TransfersReportForm transfersReportForm = new TransfersReportForm();
            transfersReportForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            ExpiredReportForm expiredReportForm = new ExpiredReportForm();
            expiredReportForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            ExpirationReportForm expirationReportForm = new ExpirationReportForm();
            expirationReportForm.Show();
        }
    }
}
