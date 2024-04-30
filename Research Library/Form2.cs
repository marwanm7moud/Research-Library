using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Research_Library
{
    public partial class Form2 : Form
    {
        public static Library library = new Library();
        private List<Paper> papers ;
        public static Paper selectedPaper ;
        public static int selectedPaperIndex ;
        public Form2()
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
            papers = library.GetAllPapers();
            foreach (var paper in papers)
            {
                dataGridView1.Rows.Add(paper.Title, paper.Author, paper.PublicationDate.ToShortDateString(), paper.Description);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 Check = new Form1();
            Check.Show();
            Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                int rowIndex = e.RowIndex;
                string title = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                string author = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                DateTime publicationDate = DateTime.Parse(dataGridView1.Rows[rowIndex].Cells[2].Value.ToString());
                string description = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();

                int index = papers.FindIndex(p => p.Title == title && p.Author == author && p.PublicationDate == publicationDate && p.Description == description);

                if (index != -1)
                {
                    selectedPaper = library.GetAllPapers()[index];
                    selectedPaperIndex = index;
                    button1.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 Check = new Form3();
            Check.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 Check = new Form4();
            Check.Show();
            Hide();
        }
    }
}
