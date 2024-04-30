using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Research_Library
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedPaper = Form2.selectedPaper;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Check = new Form2();
            Check.Show();
            Hide();
        }
    }
}
