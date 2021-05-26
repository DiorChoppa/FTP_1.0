using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CouerseWork
{
    public partial class Hello : Form
    {
        public Hello()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Fill the fields");
            }

            string php = "login.php";
            string post = $"Login={textBox1.Text}&Password={textBox2.Text}";

            string request = Request.Post(post, php);
            if(request[0] != '0')
            {
                StreamWriter sw = new StreamWriter("id.txt");
                sw.Write(request);
                sw.Close();
                sw = new StreamWriter("user.txt");
                sw.Write(textBox1.Text);
                sw.Close();
                sw = new StreamWriter("pass.txt");
                sw.Write(textBox2.Text);
                sw.Close();
                MessageBox.Show("Authorization Successful!");
                Hello hello = new Hello();
                this.Hide();
                
                FTP ftp = new FTP();
                ftp.Show();
            }
            else
            {
                MessageBox.Show("Incorrect user data!");
            }
        }
    }
}
