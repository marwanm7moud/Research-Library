using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Research_Library
{
    public partial class Form1 : Form
    {

        private Library library = new Library();
        private List<Paper> displayedPapers;


        public Form1()
        {
            InitializeComponent();
            //AddSampleMaterials();
            DisplayAllPapers();
        }

        //private void AddSampleMaterials()
        //{
        //    AddPaper(1, "The Impact of Virtual Reality on Cognitive Abilities", "Dr. Jane Doe", new DateTime(2024, 4, 1), "This paper investigates the effects of virtual reality (VR) technology on cognitive abilities...");
        //    AddPaper(2, "The Role of Artificial Intelligence in Healthcare", "Dr. John Smith", new DateTime(2023, 5, 15), "This paper explores the various applications of artificial intelligence (AI) in healthcare...");
        //    AddPaper(3, "Climate Change and Its Impact on Biodiversity", "Prof. Emily Johnson", new DateTime(2022, 6, 10), "This paper reviews the scientific evidence for climate change and its consequences for biodiversity loss...");
        //    AddPaper(4, "The Future of Renewable Energy: Trends and Challenges", "Dr. Michael Brown", new DateTime(2024, 8, 5), "This paper analyzes current trends and future prospects for renewable energy sources...");
        //    AddPaper(5, "Understanding Quantum Computing: Principles and Applications", "Prof. Sarah Lee", new DateTime(2023, 1, 20), "This paper provides an overview of quantum computing principles and their potential applications...");
        //    AddPaper(6, "The Psychology of Decision Making: Insights from Behavioral Economics", "Dr. David Miller", new DateTime(2023, 11, 3), "This paper explores the psychological mechanisms underlying decision making processes...");
        //    AddPaper(8, "Advancements in Cancer Immunotherapy", "Dr. Samantha Johnson", new DateTime(2022, 9, 20), "This paper discusses recent advancements in cancer immunotherapy treatments...");
        //    AddPaper(9, "Urbanization and Its Environmental Impact", "Prof. Robert Wilson", new DateTime(2024, 2, 15), "This paper examines the environmental consequences of rapid urbanization...");
        //    AddPaper(10, "The Ethics of Artificial Intelligence", "Dr. Emily Chen", new DateTime(2023, 7, 8), "This paper explores ethical considerations surrounding the development and deployment of artificial intelligence...");
        //    AddPaper(11, "Nanotechnology in Medicine: Current Status and Future Prospects", "Prof. William Johnson", new DateTime(2022, 4, 30), "This paper reviews the applications of nanotechnology in medicine, including drug delivery systems and diagnostic techniques...");
        //    AddPaper(12, "The Impact of Social Media on Mental Health", "Dr. Amanda Roberts", new DateTime(2023, 3, 12), "This paper examines the relationship between social media usage and mental health outcomes...");
        //    AddPaper(13, "Blockchain Technology: Principles and Applications", "Prof. Christopher Brown", new DateTime(2024, 6, 5), "This paper provides an overview of blockchain technology and its potential applications in various industries...");
        //    AddPaper(14, "Gene Editing Technologies: CRISPR-Cas9 and Beyond", "Dr. Michael Garcia", new DateTime(2022, 10, 10), "This paper discusses the principles and applications of gene editing technologies, focusing on CRISPR-Cas9...");
        //    AddPaper(15, "Artificial Neural Networks: Fundamentals and Applications", "Prof. Jessica Thompson", new DateTime(2023, 12, 18), "This paper provides an introduction to artificial neural networks and their applications in machine learning...");
        //    AddPaper(16, "The Future of Space Exploration: Challenges and Opportunities", "Dr. Thomas Anderson", new DateTime(2024, 1, 25), "This paper explores the future prospects for space exploration missions and technologies...");
        //}

        private void AddPaper(int id , string title, string author, DateTime publicationDate, string abstractText)
        {
            // Create a new Paper object with the given data
            Paper paper = new Paper
            {
                Title = title,
                Author = author,
                PublicationDate = publicationDate,
                Description = abstractText
            };

            // Add the paper to the library
            library.AddPaper(paper);
        }


        private void DisplayAllPapers()
        {
            displayedPapers = library.GetAllPapers();
            DisplayPapers(displayedPapers);
        }

        private void DisplayPapers(List<Paper> papers)
        {
            dataGridView1.Rows.Clear();
            foreach (var paper in papers)
            {
                dataGridView1.Rows.Add(paper.Title, paper.Author, paper.PublicationDate.ToShortDateString(), paper.Description);
            }

        }

        private void SearchPapers(string searchTerm)
        {
            List<Paper> filteredPapers = displayedPapers.Where(p => p.Title.Contains(searchTerm) ||
                                                                    p.Author.Contains(searchTerm) ||
                                                                    p.Description.Contains(searchTerm)).ToList();

            DisplayPapers(filteredPapers);
        }


        private void SearchTextBox_TextChanged(object sender, EventArgs e){}

        

        private void label1_Click(object sender, EventArgs e){}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){}

        private void button1_Click(object sender, EventArgs e)
        {
            string searchTerm = SearchTextBox.Text;
            var sortBy = comboBox1.SelectedItem.ToString();

            List<Paper> filteredPapers;

            if(sortBy != null)
            {
                    switch (sortBy)
                 {
                case "topic":
                    filteredPapers = library.GetAllPapers().Where(p => p.Title.ToLower().Contains(searchTerm.ToLower())).ToList();
                    displayedPapers = filteredPapers.OrderBy(p => p.Title.ToLower()).ToList();
                    break;
                case "author":
                    filteredPapers = library.GetAllPapers().Where(p => p.Author.ToLower().Contains(searchTerm.ToLower())).ToList();
                    displayedPapers = filteredPapers.OrderBy(p => p.Author.ToLower()).ToList();
                    break;
                case "description":
                    filteredPapers = library.GetAllPapers().Where(p => p.Description.ToLower().Contains(searchTerm.ToLower())).ToList();
                    displayedPapers = filteredPapers.OrderBy(p => p.Description.ToLower()).ToList();
                    break;
                default:
                    filteredPapers = library.GetAllPapers();
                    displayedPapers = filteredPapers;
                    break;
            }
            }
            

            // Display the filtered papers in the DataGridView
            DisplayPapers(displayedPapers);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 Check = new Form2();
            Check.Show();
            Hide();
        }
    }
}
