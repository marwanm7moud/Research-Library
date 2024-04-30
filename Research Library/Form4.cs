using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Research_Library
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(textBox3.Text, out DateTime dateTime))
            {
                var updatedPaper = new Paper
                {
                    Title = textBox1.Text,
                    Author = textBox2.Text,
                    PublicationDate = Convert.ToDateTime(textBox3.Text),
                    Description = textBox4.Text
                };

                Form2.library.UpdatePaper(Form2.selectedPaperIndex, updatedPaper);
                Form2 Check = new Form2();
                Check.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Date should be MM/DD/YYYY");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Check = new Form2();
            Check.Show();
            Hide();
        }
    }
}
