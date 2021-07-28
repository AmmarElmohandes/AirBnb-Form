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
    public partial class Login : Form
    {
        int HostOrrUser;
        public Login()
        {
            InitializeComponent();
        }
        public Login(int HorU)
        {
            HostOrrUser = HorU;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {




            if (HostOrrUser == 1)
            {
                string str = "select HostId,HostUserName,Password from Host where HostUserName='" + tx1.Text + "'And Password='" + tx2.Text + "'";
                MainForm mainform = new MainForm();
                int x = mainform.connectLogin(str);
                if (x == 0)
                {
                    MessageBox.Show("invalid Login");
                }
                else
                {
                    AddProperty f2 = new AddProperty(x);
                    tx1.Text = tx2.Text = "";
                    f2.Show();
                    this.Hide();
                }
            }
            else if (HostOrrUser == 2)
            {
                string str = "select UserId,UserName,Password from Logged_User where UserName='" + tx1.Text + "'And Password='" + tx2.Text + "'";
                MainForm mainform = new MainForm();
                int x = mainform.connectLogin(str);
                if (x == 0)
                {
                    MessageBox.Show("invalid Login");
                }
                else
                {
                    SearchReserve searchReserve = new SearchReserve(x);
                    searchReserve.Show();
                    this.Hide();
                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register(HostOrrUser);
            register.Show();
            this.Hide();
        }
    }
}
