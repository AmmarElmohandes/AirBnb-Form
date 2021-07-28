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
    public partial class AddProperty : Form
    {
        int id;
        public AddProperty()
        {
            InitializeComponent();
        }
        public AddProperty(int hostId)
        {
            id = hostId;
            InitializeComponent();
            comboBox1.Items.Add("Hotel Room");
            comboBox1.Items.Add("Appartment");
            comboBox1.Items.Add("villa");
            comboBox2.Items.Add("private");
            comboBox2.Items.Add("shared");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            string str = "Insert into property(Title,PropertyType,AreaType,City,Country,PropertyAddress,PropertyDescription,AvailableStartDate,AvailableEndDate,Price,HostId)" + "values('" + tx1.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + tx4.Text.ToLower() + "','" + tx5.Text.ToLower() + "','" + tx6.Text + "','" + tx7.Text + "','" + tx8.Text + "','" + tx9.Text + "'," + float.Parse(textBox10.Text) + "," + id + ")";
            int rowsAffected = mainform.connect(str);
            str = "select PropertyId from property";
            int Propid = mainform.getId(str);
            BedsDbox bdx = new BedsDbox(Propid);
            bdx.Show();
            this.Hide();
            //if (rowsAffected > 0)
            //{

            //    tx1.Text = tx2.Text = tx3.Text = tx4.Text = tx5.Text = tx6.Text = tx7.Text = tx8.Text = tx9.Text = tx10.Text = "";
            //}

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login(1);
            log.Show();
            this.Hide();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
