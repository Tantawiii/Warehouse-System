using System;
using System.Windows.Forms;
using System.Linq;

namespace EntityLinQProject
{
    public partial class ExpirationReportForm : Form
    {
        Model1 model1 = new Model1();

        public ExpirationReportForm()
        {
            InitializeComponent();
        }

        private void ExpirationReportForm_Load(object sender, EventArgs e)
        {
            foreach (Products product in model1.Products)
            {
                comboBox1.Items.Add(product.ProductName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedProductName = comboBox1.SelectedItem.ToString();
            DateTime currentDate = dateTimePicker1.Value;

            int expirationDays = GetExpirationDaysForProduct(selectedProductName);
            DateTime arrivalDate = GetArrivalDateForProduct(selectedProductName);

            if (arrivalDate == DateTime.MinValue)
            {
                MessageBox.Show("Arrival date not found for the selected product.");
                return;
            }

            DateTime expirationDate = arrivalDate.AddDays(expirationDays);

            var reportData = model1.PurchaseOrderDetails
                .Where(pod => pod.Products.ProductName == selectedProductName &&
                               pod.PurchaseOrders.ExpectedDeliveryDate >= arrivalDate &&
                               pod.PurchaseOrders.ExpectedDeliveryDate <= currentDate)
                .Select(pod => new
                {
                    StoreName = pod.PurchaseOrders.Stores.StoreName,
                    ItemName = pod.Products.ProductName,
                    ProductArrivalDate = arrivalDate,
                    ExpirationDate = expirationDate,
                })
                .ToList();

            dataGridView1.DataSource = reportData;
        }

        public int GetExpirationDaysForProduct(string productName)
        {
            switch (productName)
            {
                case "تين شوكى":
                    return 10;
                case "فسيخ":
                    return 7;
                case "توت مصري":
                    return 5;
                default:
                    return 0;
            }
        }

        public DateTime GetArrivalDateForProduct(string productName)
        {
            var purchaseOrderDetail = model1.PurchaseOrderDetails
                .FirstOrDefault(pod => pod.Products.ProductName == productName);

            return purchaseOrderDetail?.PurchaseOrders.OrderDate ?? DateTime.MinValue;
        }
    }
}
