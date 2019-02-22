using System;
using System.Windows.Forms;

namespace SupermarketForms
{
    partial class ManageInventoryForm
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
            this.itemGrid = new System.Windows.Forms.DataGridView();
            this.RefNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.QuantityInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PricePerEach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KgsInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PricePerKg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.itemGrid, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // itemGrid
            // 
            this.itemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.itemGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.itemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefNo,
            this.ItemName,
            this.Description,
            this.ItemType,
            this.QuantityInStock,
            this.PricePerEach,
            this.KgsInStock,
            this.PricePerKg});
            this.itemGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemGrid.Location = new System.Drawing.Point(3, 3);
            this.itemGrid.Name = "itemGrid";
            this.itemGrid.Size = new System.Drawing.Size(794, 444);
            this.itemGrid.TabIndex = 1;
            this.itemGrid.CellValueChanged += this.CellValueChanged;
            // 
            // RefNo
            // 
            this.RefNo.HeaderText = "Reference Number";
            this.RefNo.Name = "RefNo";
            this.RefNo.ReadOnly = true;
            this.RefNo.Width = 112;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 60;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 85;
            // 
            // ItemType
            // 
            this.ItemType.HeaderText = "Item Type";
            this.ItemType.Items.AddRange(Supermarket.Item.TypeNames);
            this.ItemType.Name = "ItemType";
            this.ItemType.Width = 54;
            // 
            // QuantityInStock
            // 
            this.QuantityInStock.HeaderText = "Quantity in Stock";
            this.QuantityInStock.Name = "QuantityInStock";
            this.QuantityInStock.Width = 78;
            // 
            // PricePerEach
            // 
            this.PricePerEach.HeaderText = "Price per Item";
            this.PricePerEach.Name = "PricePerEach";
            this.PricePerEach.Width = 71;
            this.PricePerEach.DefaultCellStyle.Format = "C";
            // 
            // KgsInStock
            // 
            this.KgsInStock.HeaderText = "Kgs in Stock";
            this.KgsInStock.Name = "KgsInStock";
            this.KgsInStock.Width = 85;
            this.KgsInStock.DefaultCellStyle.Format = "0.00 kg";
            // 
            // PricePerKg
            // 
            this.PricePerKg.HeaderText = "Price per Kg";
            this.PricePerKg.Name = "PricePerKg";
            this.PricePerKg.Width = 71;
            this.PricePerEach.DefaultCellStyle.Format = "C";
            // 
            // ManageInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ManageInventoryForm";
            this.Text = "Manage inventory";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView itemGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewComboBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn PricePerEach;
        private System.Windows.Forms.DataGridViewTextBoxColumn KgsInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn PricePerKg;
    }
}