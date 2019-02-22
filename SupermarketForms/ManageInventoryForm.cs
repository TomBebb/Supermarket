using Supermarket;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SupermarketForms
{
    public partial class ManageInventoryForm : Form
    {
        static bool isUpdating = false;
        public ManageInventoryForm()
        {
            InitializeComponent();
            
            itemGrid.RowsAdded += itemGrid_rowsAdded;
            var supermarket = MainForm.Supermarket;
            PricePerKg.DefaultCellStyle.Format = "C";
            UpdateTableToMatchData();
        }

        private void itemGrid_rowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            AddItemFromRow(e.RowIndex);
        }

        private long NextRefNo()
        {
            long max = 0;
            for(int rowIndex = 0; rowIndex < itemGrid.Rows.Count; rowIndex++)
            {
                var row = itemGrid.Rows[rowIndex];
                if (row.Cells["RefNo"].Value == null)
                    continue;
                var refNo = (long)row.Cells["RefNo"].Value;
                if (refNo > max)
                    max = refNo;
            }
            return 1 + max;
        }

        private void AddItemFromRow(int rowIndex)
        {

            var row = itemGrid.Rows[rowIndex];
            var refNoCell = row.Cells["RefNo"];
            refNoCell.ReadOnly = true;
            var newRefNo = NextRefNo();
            var refNo = (long)GetCellOrSetIfEmpty(refNoCell, newRefNo);
            var itemType = (string)row.Cells["ItemType"].Value;
            if (string.IsNullOrWhiteSpace(itemType))
                return;
            var name = (string)row.Cells["ItemName"].Value;
            if (string.IsNullOrWhiteSpace(name))
                return;

            isUpdating = true;
            var desc = (string) GetCellOrSetIfEmpty(row.Cells["Description"], name);
            Item item = null;
            switch (row.Cells["ItemType"].Value)
            {
                case QuantifiableItem.ItemTypeName:
                    var quantity = (int) GetCellOrSetIfEmpty(row.Cells["QuantityInStock"], 0);
                    var pricePerEach = (decimal)GetCellOrSetIfEmpty(row.Cells["PricePerEach"], 0m);
                    item = new QuantifiableItem(refNo, name, desc, pricePerEach, quantity);
                    break;
                case WeighableItem.ItemTypeName:
                    var kgsInStock = (double)GetCellOrSetIfEmpty(row.Cells["KgsInStock"], 0.0);
                    var pricePerKg = (decimal)GetCellOrSetIfEmpty(row.Cells["PricePerKg"], 0m);
                    item = new WeighableItem(refNo, name, desc, pricePerKg, kgsInStock);
                    break;
            }
            if (item != null)
            {
                PopulateRowFromItem(rowIndex, item);
                refNoCell.ReadOnly = true;
            }
            isUpdating = false;
        }

        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= itemGrid.Rows.Count || e.RowIndex == -1 || isUpdating)
                return;
            var row = itemGrid.Rows[e.RowIndex];
            var refNo = (long) row.Cells["RefNo"].Value;

            var supermarket = MainForm.Supermarket;
            if(!supermarket.Items.ContainsKey(refNo))
            {
                AddItemFromRow(e.RowIndex);
                return;
            }
            var item = supermarket.Items[refNo];

            var column = itemGrid.Columns[e.ColumnIndex];
            var value = row.Cells[e.ColumnIndex].Value;
            Console.WriteLine(column.DefaultCellStyle.Format);
            if (value is string txt && txt == "N/A")
                value = null;
            else if (value is string && column.DefaultCellStyle.Format == "C")
                value = decimal.Parse((string)value, System.Globalization.NumberStyles.AllowCurrencySymbol | System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint);

            switch (column.Name)
            {
                case "ItemName":
                    item.Name = (string) value;
                    break;
                case "Description":
                    item.Description = (string)value;
                    break;

                case "ItemType":
                    isUpdating = true;
                    if ((string)value == QuantifiableItem.ItemTypeName && item is WeighableItem)
                    {
                        var newItem = new QuantifiableItem(item.RefNo, item.Name, item.Description, 0m, 0);
                        supermarket.RemoveItem(item);
                        supermarket.AddItem(newItem);

                        row.Cells["QuantityInStock"].Value = 0;
                        row.Cells["PricePerEach"].Value = 0m;
                        row.Cells["KgsInStock"].Value = "N/A";
                        row.Cells["PricePerKg"].Value = "N/A";

                        Debug.Assert(supermarket.Items[item.RefNo] is QuantifiableItem);
                    } else if ((string)value == WeighableItem.ItemTypeName && item is QuantifiableItem)
                    {
                        var newItem = new WeighableItem(item.RefNo, item.Name, item.Description, 0m, 0);
                        supermarket.RemoveItem(item);
                        supermarket.AddItem(newItem);

                        row.Cells["QuantityInStock"].Value = "N/A";
                        row.Cells["PricePerEach"].Value = "N/A";
                        row.Cells["KgsInStock"].Value = 0.0;
                        row.Cells["PricePerKg"].Value = 0m;
                        Debug.Assert(supermarket.Items[item.RefNo] is WeighableItem);
                    }
                    isUpdating = false;
                    break;
                case "QuantityInStock" when item is QuantifiableItem qItem:
                    qItem.NumberInStock = Convert.ToInt32(value);
                    break;
                case "PricePerEach" when item is QuantifiableItem qItem:
                    qItem.PricePerEach = (decimal)value;
                    break;

                case "KgsInStock" when item is WeighableItem wItem:
                    if (value is string vTxt && vTxt.EndsWith("kg"))
                        value = Convert.ToDouble(vTxt.Substring(0, vTxt.Length - 2).Trim());
                    wItem.KgsInStock = Convert.ToDouble(value);
                    break;

                case "PricePerKg" when item is WeighableItem wItem:
                    wItem.PricePerKg = (decimal)value;
                    break;
                default:
                    throw new Exception($"{column.Name} cannot be changed for item kind {(item is WeighableItem ? "weighable" : "quantifiable")}");
                    break;
            }

        }
        private void PopulateRowFromItem(int rowId, Item item)
        {
            var row = itemGrid.Rows[rowId];

            row.Cells["RefNo"].Value = item.RefNo;
            row.Cells["Description"].Value = item.Description;
            row.Cells["ItemName"].Value = item.Name;

            var itemTypeCell = (DataGridViewComboBoxCell) row.Cells["ItemType"];

            string itemType = null;

            var pricePerEach = row.Cells["PricePerEach"];
            var quantityInStock = row.Cells["QuantityInStock"];
            var kgsInStock = row.Cells["KgsInStock"];
            var pricePerKg = row.Cells["PricePerKg"];

            if (item is QuantifiableItem qItem)
            {
                itemType = "Quantifiable";
                SetCell(pricePerEach, qItem.PricePerEach);
                SetCell(quantityInStock, qItem.NumberInStock);
                SetNull(pricePerKg);
                SetNull(kgsInStock);
            }
            else if (item is WeighableItem wItem)
            {
                itemType = "Weighable";
                SetCell(pricePerKg, wItem.PricePerKg);
                SetCell(kgsInStock, wItem.KgsInStock);
                SetNull(pricePerEach);
                SetNull(quantityInStock);
            }

            itemGrid.Update();

            itemTypeCell.Value = itemType;
        }
        private void SetNull(DataGridViewCell cell)
        {
            cell.Value = "N/A";
            cell.ReadOnly = true;
        }
        private void SetCell(DataGridViewCell cell, object value)
        {
            cell.Value = value;
            cell.ReadOnly = false;
        }
        private object GetCellOrSetIfEmpty(DataGridViewCell cell, object value)
        {
            if(cell.Value == null || (cell.Value is string txt && txt.Length == 0))
                cell.Value = value;

            return cell.Value;

        }
        public void UpdateTableToMatchData()
        {
            isUpdating = true;
            var supermarket = MainForm.Supermarket;

            itemGrid.Rows.Clear();
            
            foreach (var item in supermarket.Items.Values)
            {
                var row = itemGrid.Rows.Add();
                PopulateRowFromItem(row, item);
            }

            isUpdating = false;
        }
    }
}
