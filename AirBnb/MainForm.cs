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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public string getImage(string str)
        {
            SqlDataReader dReader;
            sqlConnection1.Open();
            string image = "";
            sqlCommand1.CommandText = str;
            dReader = sqlCommand1.ExecuteReader();
            bool exist = dReader.HasRows;
            if (exist)
            {
                while (dReader.Read())
                {
                    image = dReader[0].ToString();
                }
            }

            dReader.Close();
            sqlConnection1.Close();
            return image;


        }
        public List<string> search(string str)
        {

            List<string> titles = new List<string>();
            SqlDataReader dReader;
            sqlConnection1.Open();
            int i = 0;
            sqlCommand1.CommandText = str;
            dReader = sqlCommand1.ExecuteReader();
            bool exist = dReader.HasRows;
            if (exist)
            {
                while (dReader.Read())
                {
                    titles.Add(dReader[0].ToString());
                }
            }
            dReader.Close();
            sqlConnection1.Close();
            return titles;
        }
        public List<string> viewValues(string str)
        {

            List<string> titles = new List<string>();
            SqlDataReader dReader;
            sqlConnection1.Open();
            //int i = 0;
            sqlCommand1.CommandText = str;
            dReader = sqlCommand1.ExecuteReader();
            bool exist = dReader.HasRows;
            if (exist)
            {
                while (dReader.Read())
                {
                    for (int i = 0; i < 4; i++)
                    {
                        titles.Add(dReader[i].ToString());
                    }
                }
            }
            dReader.Close();
            sqlConnection1.Close();
            return titles;
        }

        public int connect(string str)
        {
            sqlCommand1.CommandText = str;
            sqlConnection1.Open();
            int x = sqlCommand1.ExecuteNonQuery();
            sqlConnection1.Close();
            return x;
        }
        public int connectLogin(string str)
        {

            SqlDataReader dReader;
            sqlConnection1.Open();
            int i = 0;
            sqlCommand1.CommandText = str;
            dReader = sqlCommand1.ExecuteReader();
            bool exist = dReader.HasRows;
            if (exist)
            {
                while (dReader.Read())
                {
                    i = int.Parse(dReader[0].ToString());
                }
            }
            else
            { i = 0; }
            dReader.Close();
            sqlConnection1.Close();
            return i;
        }
        public int getId(string str)
        {
            SqlDataReader dReader;
            sqlConnection1.Open();
            int max = 0;
            sqlCommand1.CommandText = str;
            dReader = sqlCommand1.ExecuteReader();
            bool exist = dReader.HasRows;
            if (exist)
            {
                while (dReader.Read())
                {

                    if (int.Parse(dReader[0].ToString()) > max)
                    {
                        max = int.Parse(dReader[0].ToString());
                    }
                }

            }
            else
            { max = 0; }
            //int x = int.Parse(dReader[i].ToString());
            dReader.Close();
            sqlConnection1.Close();
            return max;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login log = new Login(1);
            log.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login(2);
            log.Show();
            this.Hide();
        }
    }
}
