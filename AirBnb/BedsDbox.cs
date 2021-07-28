using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirBnb
{
    public partial class BedsDbox : Form
    {
        int propId;
        public BedsDbox()
        {
            InitializeComponent();

        }
        public BedsDbox(int id)
        {
            propId = id;
            InitializeComponent();
            comboBox1.Items.Add("king");
            comboBox1.Items.Add("single");
            comboBox1.Items.Add("double");

        }


        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Insert into BedsProperty values(" + propId + "," + int.Parse(tx2.Text) + ",'" + comboBox1.SelectedItem.ToString() + "')";
            MainForm mainForm = new MainForm();
            int rowsAffected = mainForm.connect(str);
            if (rowsAffected > 0)
            {

                tx2.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddGuest addGuest = new AddGuest(propId);
            addGuest.Show();
            this.Hide();
        }
    }
}
