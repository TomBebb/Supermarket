using System;
using System.Windows.Forms;

namespace SupermarketForms
{
    public partial class MainForm : Form
    {
        
        public static Supermarket.Supermarket Supermarket { get; private set; }
        public MainForm()
        {
            Supermarket = new Supermarket.Supermarket();
            Supermarket.SetupDefaults();
            InitializeComponent();
        }

        private void manageInventoryButton_Click(object sender, EventArgs e)
        {
            new ManageInventoryForm().ShowDialog();
        }

        private void makeOrderButton_Click(object sender, EventArgs e)
        {
            new MakeOrder().ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
