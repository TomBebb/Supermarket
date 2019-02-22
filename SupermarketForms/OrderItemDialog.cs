using Supermarket;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SupermarketForms
{
    public partial class OrderItemDialog : Form
    {
        private Order order;
        public event Action Ordered;
        public Item SelectedItem {
            get
            {
                var allItems = MainForm.Supermarket.Items.Values;
                var selectedIndex = items.SelectedIndex;
                return allItems.ElementAt(selectedIndex);
            }
        }
        public OrderItemDialog(Order order)
        {
            this.order = order;
            InitializeComponent();
            
            kgsToBuy.KeyPress += new KeyPressEventHandler(kgsToBuy_keyPress);
            quantity.KeyPress += new KeyPressEventHandler(quantity_keyPress);
            foreach (var item in MainForm.Supermarket.Items.Values)
            {
                var itemTxt = "";
                if (item is QuantifiableItem qItem)
                {
                    var leftInStock = qItem.StockAfterOrder(order);
                    itemTxt = $"{item.Name}: {item.Description} ({qItem.PricePerEach:C} per item and {leftInStock} in stock)";
                }
                else if (item is WeighableItem wItem)
                {
                    var leftInStock = wItem.KgsAfterOrder(order);
                    itemTxt = $"{item.Name}: {item.Description} ({wItem.PricePerKg:C} per kg and {leftInStock} kg in stock)";
                }
                items.Items.Add(itemTxt);
            }

            items.SelectedIndex = 0;
            items.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void quantity_keyPress(object sender, KeyPressEventArgs e)
        {
            UpdateTotal();
        }

        private void kgsToBuy_keyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void UpdateTotal()
        {
            var selectedItem = SelectedItem;

            var total = 0m;
            if (selectedItem is QuantifiableItem qItem)
                total = qItem.CalculatePrice((int)quantity.Value);

            else if (kgsToBuy.Text.Length > 0 && selectedItem is WeighableItem wItem)
            {
                total = wItem.CalculatePrice(Convert.ToDouble(kgsToBuy.Text));
            }

            itemPrice.Text = $"Total Item Price: {total:C}";
        }

        private void quantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void items_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selectedItem = SelectedItem;

            if (selectedItem is QuantifiableItem qItem)
            {
                quantity.Visible = quantityLabel.Visible = true;
                kgsToBuyLabel.Visible = kgsToBuy.Visible = false;

                quantity.Minimum = 0;
                quantity.Maximum = qItem.StockAfterOrder(order);
                quantity.Value = 0;
            }
            else
            {
                quantity.Visible = quantityLabel.Visible = false;
                kgsToBuyLabel.Visible = kgsToBuy.Visible = true;

            }
            UpdateTotal();

        }

        private void kgsToBuy_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            IOrderItem orderItem = null;

            var selectedItem = SelectedItem;
            if (selectedItem is QuantifiableItem qItem)
            {
                orderItem = new QuanitifiableOrderItem((int)quantity.Value, qItem);
            } else if (selectedItem is WeighableItem wItem)
            {
                orderItem = new WeighableOrderItem(Double.Parse(kgsToBuy.Text), wItem);
            }

            order.AddOrderItem(orderItem);
            Ordered();
            Close();
        }
    }
}
