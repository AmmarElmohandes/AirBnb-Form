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
    public partial class AddGuest : Form
    {
        int propId;
        public AddGuest()
        {
            InitializeComponent();
        }
        public AddGuest(int id)
        {
            propId = id;
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Insert into GuestsProperty values(" + propId + "," + int.Parse(tx1.Text) + "," + int.Parse(tx2.Text) + ")";
            MainForm mainForm = new MainForm();
            int rowsAffected = mainForm.connect(str);
            if (rowsAffected > 0)
            {
                tx2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImageForm imageForm = new ImageForm(propId);
            imageForm.Show();
            this.Hide();
        }
    }
}
