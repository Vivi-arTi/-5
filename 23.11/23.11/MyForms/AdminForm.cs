using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23._11
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

            //checkBox1.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (MyClassConnection.ConnectBD() == false)
            {
                MessageBox.Show("Ошибка подключения!", "Ошибка");
                this.Close();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyClassConnection.CloseBD() == false)
            {
                MessageBox.Show("Ошибка отключения от БД");
                this.Close();           
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            MyClassConnection.Authorization(textBox1.Text, textBox2.Text);

            switch(MyClassConnection.role)
            {
                case null:
                    MessageBox.Show("Нерезарегистрированн пользователь", "Ошибка");
                        break;
                case "admin":
                    this.Hide();
                    Klient fr = new Klient();
                    fr.Show();
                    break;

            }    
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
