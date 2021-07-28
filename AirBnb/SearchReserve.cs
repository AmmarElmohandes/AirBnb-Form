using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirBnb
{
    public partial class SearchReserve : Form
    {
        int userId;
        public SearchReserve()
        {
            InitializeComponent();
        }
        public SearchReserve(int id)
        {
            userId = id;
            InitializeComponent();
            comboBox1.Items.Add("Hotel Room");
            comboBox1.Items.Add("Appartment");
            comboBox1.Items.Add("villa");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> titles = new List<string>();
            string str = "select Title from property p inner join GuestsProperty g on p.PropertyId=g.PropertyId and '" + sdate.Text + "' between AvailableStartDate and AvailableEndDate and '" + edate.Text + "'between AvailableStartDate and AvailableEndDate and Country='" + Country.Text.ToLower() + "' and City='" + City.Text.ToLower() + "' and PropertyType='" + comboBox1.SelectedItem.ToString() + "' and NoOfAdultGuests>=" + int.Parse(Adults.Text) + " and NoOfChildGuests>=" + int.Parse(childs.Text);
            MainForm mf = new MainForm();
            titles = mf.search(str);
            foreach (var item in titles)
            {
                comboBox2.Items.Add(item);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> titles = new List<string>();

            string str = "select Price,PropertyDescription,AreaType,PropertyAddress from property where Title='" + comboBox2.SelectedItem.ToString() + "'";
            MainForm mf = new MainForm();

            titles = mf.viewValues(str);
            price.Text = titles[0];
            desc.Text = titles[1];
            atype.Text = titles[2];
            address.Text = titles[3];

            str = "select PropertyId from property where Title = '" + comboBox2.SelectedItem.ToString() + "'";
            int x = mf.connectLogin(str);
            str = "select images from Photos where PropertyId=" + x;
            string image = mf.getImage(str);
            MessageBox.Show(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/AirBnb/images/" + image);
            pictureBox1.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/AirBnb/images/" + image);
            pictureBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "Insert into Reservation(CheckInDate,CheckOutDate,UserId)values('" + sdate.Text + "'" + ",'" + edate.Text + "'," + userId + ")";
            MainForm mf = new MainForm();
            mf.connect(str);
            str = "select ReservationId from Reservation";
            int x = mf.getId(str);
            str = "update property set ReservationId=" + x + "where Title='" + comboBox2.SelectedItem.ToString() + "'";
            mf.connect(str);
            MessageBox.Show("Reservation succeeded");

        }
    }
}
