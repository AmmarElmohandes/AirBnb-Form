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
    public partial class ImageForm : Form
    {
        int propId;
        string imageName;
        public ImageForm()
        {
            InitializeComponent();
        }
        public ImageForm(int id)
        {
            propId = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string imageName;
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;*.png;*)|*.jpg;*.jpeg;.*.gif;*.png;*";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                pictureBox1.Image = new Bitmap(opnfd.FileName);

            }

            File.Copy(opnfd.FileName, Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/AirBnb/images/" + Path.GetFileName(opnfd.FileName), true);
            imageName = Path.GetFileName(opnfd.FileName);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            string str = "select HostId from property where PropertyId=" + propId;
            int hostId = mainForm.connectLogin(str);
            MessageBox.Show(hostId.ToString());
            AddProperty addProperty = new AddProperty(hostId);
            addProperty.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            string str = "Insert into Photos(PropertyId,images) values(" + propId + ",'" + imageName + "')";
            int rowsaffected = mainForm.connect(str);

            if (rowsaffected > 0)
            {
                pictureBox1.Image = null;
            }


        }
    }
}
