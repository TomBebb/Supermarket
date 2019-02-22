using System;

namespace SupermarketForms
{
    partial class OrderItemDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kgsToBuy = new System.Windows.Forms.TextBox();
            this.itemLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.items = new System.Windows.Forms.ComboBox();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.kgsToBuyLabel = new System.Windows.Forms.Label();
            this.itemPrice = new System.Windows.Forms.Label();
            this.addItem = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33333F));
            this.tableLayoutPanel1.Controls.Add(this.kgsToBuy, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.itemLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.quantityLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.items, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.quantity, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.kgsToBuyLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.itemPrice, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.addItem, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // kgsToBuy
            // 
            this.kgsToBuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kgsToBuy.Location = new System.Drawing.Point(136, 43);
            this.kgsToBuy.Name = "kgsToBuy";
            this.kgsToBuy.Size = new System.Drawing.Size(661, 20);
            this.kgsToBuy.TabIndex = 8;
            this.kgsToBuy.Text = "0";
            this.kgsToBuy.TextChanged += new System.EventHandler(this.kgsToBuy_TextChanged);
            // 
            // itemLabel
            // 
            this.itemLabel.AutoSize = true;
            this.itemLabel.Location = new System.Drawing.Point(3, 0);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(33, 13);
            this.itemLabel.TabIndex = 0;
            this.itemLabel.Text = "Item: ";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(3, 20);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(52, 13);
            this.quantityLabel.TabIndex = 1;
            this.quantityLabel.Text = "Quantity: ";
            // 
            // items
            // 
            this.items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.items.FormattingEnabled = true;
            this.items.Location = new System.Drawing.Point(136, 3);
            this.items.Name = "items";
            this.items.Size = new System.Drawing.Size(661, 21);
            this.items.TabIndex = 2;
            this.items.Text = "item";
            this.items.SelectedIndexChanged += new System.EventHandler(this.items_SelectedIndexChanged);
            // 
            // quantity
            // 
            this.quantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quantity.Location = new System.Drawing.Point(136, 23);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(661, 20);
            this.quantity.TabIndex = 3;
            this.quantity.ValueChanged += new System.EventHandler(this.quantity_ValueChanged);
            // 
            // kgsToBuyLabel
            // 
            this.kgsToBuyLabel.AutoSize = true;
            this.kgsToBuyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kgsToBuyLabel.Location = new System.Drawing.Point(3, 40);
            this.kgsToBuyLabel.Name = "kgsToBuyLabel";
            this.kgsToBuyLabel.Size = new System.Drawing.Size(127, 20);
            this.kgsToBuyLabel.TabIndex = 6;
            this.kgsToBuyLabel.Text = "Kilograms to buy:";
            // 
            // itemPrice
            // 
            this.itemPrice.AutoSize = true;
            this.itemPrice.Location = new System.Drawing.Point(3, 60);
            this.itemPrice.Name = "itemPrice";
            this.itemPrice.Size = new System.Drawing.Size(99, 13);
            this.itemPrice.TabIndex = 5;
            this.itemPrice.Text = "Total Item Price: £0";
            // 
            // addItem
            // 
            this.addItem.Location = new System.Drawing.Point(136, 63);
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(75, 23);
            this.addItem.TabIndex = 9;
            this.addItem.Text = "Add item to order";
            this.addItem.UseVisualStyleBackColor = true;
            this.addItem.Click += new System.EventHandler(this.addItem_Click);
            // 
            // OrderItemDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OrderItemDialog";
            this.Text = "Order an item";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.ComboBox items;
        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.Label kgsToBuyLabel;
        private System.Windows.Forms.Label itemPrice;
        private System.Windows.Forms.TextBox kgsToBuy;
        private System.Windows.Forms.Button addItem;
    }
}