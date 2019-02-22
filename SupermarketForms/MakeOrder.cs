using Supermarket;
using System;
using System.Windows.Forms;

namespace SupermarketForms
{
    public partial class MakeOrder : Form
    {
        private readonly Order order = new Order();
        public MakeOrder()
        {
            InitializeComponent();
            UpdateTotal();
        }
        
        public void UpdateTotal()
        {
            total.Text = $"Total Price: {order.Total:C}";
        }

        private void makeOrderButton_Click(object sender, EventArgs e)
        {
            var wasSuccess = order.DoOrder();

            if (!wasSuccess)
            {
                MessageBox.Show("Failed to make order!", "Order failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                MessageBox.Show("Order was a success!", "Order success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            var dialog = new OrderItemDialog(order);
            dialog.Ordered += Dialog_Ordered;
            dialog.ShowDialog();
        }

        private void Dialog_Ordered()
        {
            UpdateTotal();
        }
    }
}
