namespace SupermarketForms
{
    partial class MainForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.makeOrderButton = new System.Windows.Forms.Button();
            this.manageInventoryButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.makeOrderButton);
            this.flowLayoutPanel1.Controls.Add(this.manageInventoryButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Are you a customer or an employee?";
            // 
            // makeOrderButton
            // 
            this.makeOrderButton.AutoSize = true;
            this.makeOrderButton.Location = new System.Drawing.Point(188, 3);
            this.makeOrderButton.Name = "makeOrderButton";
            this.makeOrderButton.Size = new System.Drawing.Size(140, 23);
            this.makeOrderButton.TabIndex = 2;
            this.makeOrderButton.Text = "Make an order";
            this.makeOrderButton.UseVisualStyleBackColor = true;
            this.makeOrderButton.Click += new System.EventHandler(this.makeOrderButton_Click);
            // 
            // manageInventoryButton
            // 
            this.manageInventoryButton.AutoSize = true;
            this.manageInventoryButton.Location = new System.Drawing.Point(334, 3);
            this.manageInventoryButton.Name = "manageInventoryButton";
            this.manageInventoryButton.Size = new System.Drawing.Size(190, 23);
            this.manageInventoryButton.TabIndex = 3;
            this.manageInventoryButton.Text = "Manage inventory";
            this.manageInventoryButton.UseVisualStyleBackColor = true;
            this.manageInventoryButton.Click += new System.EventHandler(this.manageInventoryButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Supermarket System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button makeOrderButton;
        private System.Windows.Forms.Button manageInventoryButton;
    }
}

