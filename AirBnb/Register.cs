using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirBnb
{
    public partial class Register : Form
    {
        int HorU;
        public Register()
        {
            InitializeComponent();
        }
        public Register(int HostorUser)
        {
            HorU = HostorUser;

            InitializeComponent();
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string str = "";
            MainForm mainform = new MainForm();
            if (HorU == 1)
            {
                str = "INSERT Into Host (HostUserName,FirstName,LastName,Email,Password,PhoneNo,BD,gender) values('" + tx8.Text + "','" + tx1.Text + "','" + tx2.Text + "','" + tx3.Text + "','" + tx4.Text + "'," + int.Parse(tx5.Text) + ",'" + tx6.Text + "','" + comboBox1.SelectedItem.ToString() + "')";
            }
            else if (HorU == 2)
            {
                str = "INSERT Into Logged_User(UserName, FirstName, LastName, Email, Password, PhoneNo, BD, gender) values('" + tx8.Text + "', '" + tx1.Text + "', '" + tx2.Text + "', '" + tx3.Text + "', '" + tx4.Text + "', " + int.Parse(tx5.Text) + ", '" + tx6.Text + "', '" + comboBox1.SelectedItem.ToString() + "')";
            }
            mainform.connect(str);
            Login login = new Login(HorU);
            login.Show();
            this.Hide();
            tx1.Text = tx2.Text = tx3.Text = tx4.Text = tx5.Text = tx6.Text = tx8.Text = "";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedItem == "Male")
            //{
            //    comboBox1. = "M";

            //}
            //else if (comboBox1.SelectedItem == "Female")
            //{
            //    comboBox1.SelectedItem = "F";
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login(HorU);
            log.Show();
            this.Hide();
        }
    }
}
