using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CouerseWork
{
    public partial class FTP : Form
    {
        public int UID;
        public string ftp_user, ftp_pass, path, file;

        public void Refresh(string fuser, string fpass)
        {
            string post = $"Login={fuser}&Password={fpass}";
            string php = "files.php";

            string request = Request.Post(post, php);

            string path = "dab.txt";
            string[] source = File.ReadAllLines(path);
            for (int i = 0; i < source.Length; i++)
            {
                string[] arr = source[i].Split(' ');
                string obj = $"Id: {arr[0]}\t\tName: {arr[1]}\t\tSize(bytes): {arr[2]}";
                dataGridView1.Rows.Add(source[i].Split(' '));
            }
        }

        public FTP()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FTP_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form hello = Application.OpenForms[0];
            hello.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string php = "delete.php";
            StreamWriter sw = new StreamWriter("name.txt");
            sw.Write(name);
            sw.Close();
            string post = $"Login={ftp_user}&Password={ftp_pass}";


            string request = Request.Post(post, php);

            dataGridView1.Rows.Clear();
            Refresh(ftp_user, ftp_pass);
            MessageBox.Show("Successful!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form hello = Application.OpenForms[0];
            hello.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
                string php = "download.php";
                string obj = path + '\\' + name;
                StreamWriter sw = new StreamWriter("way.txt");
                sw.Write(obj);
                sw.Close();
                sw = new StreamWriter("name.txt");
                sw.Write(name);
                sw.Close();
                string post = $"Login={ftp_user}&Password={ftp_pass}";


                string request = Request.Post(post, php);

                MessageBox.Show("Successful!");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"c:\\";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                file = ofd.SafeFileName;
                StreamWriter sw = new StreamWriter("way.txt");
                sw.Write(path);
                sw.Close();
                sw = new StreamWriter("name.txt");
                sw.Write(file);
                sw.Close();
                string php = "upload.php";

                string post = $"Login={ftp_user}&Password={ftp_pass}";
                

                string request = Request.Post(post, php);
                
                dataGridView1.Rows.Clear();
                Refresh(ftp_user, ftp_pass);
                MessageBox.Show("Successful!");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }

        }

        private void FTP_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("id.txt");
            UID = Int32.Parse(sr.ReadToEnd());
            sr.Close();
            sr = new StreamReader("user.txt");
            ftp_user = sr.ReadToEnd();
            sr.Close();
            sr = new StreamReader("pass.txt");
            ftp_pass = sr.ReadToEnd();
            sr.Close();
            Refresh(ftp_user, ftp_pass);
            this.Text = ftp_user;
        }
    }
}
