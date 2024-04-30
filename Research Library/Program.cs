using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Research_Library
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}

public class Paper
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Description { get; set; }
}

public class Library
{
    private List<Paper> papers = new List<Paper>();
    private string filePath = "C:\\Users\\hp\\source\\repos\\Research Library\\Research Library\\papers.txt";

    public Library()
    {
        LoadPapers();
    }

    private void LoadPapers()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 4)
                {
                    Paper paper = new Paper
                    {
                        Title = parts[0],
                        Author = parts[1],
                        PublicationDate = DateTime.Parse(parts[2]),
                        Description = parts[3]
                    };
                    papers.Add(paper);
                }
            }
        }
    }

    private void SavePapers()
    {
        List<string> lines = new List<string>();
        foreach (Paper paper in papers)
        {
            string line = $"{paper.Title};{paper.Author};{paper.PublicationDate};{paper.Description}";
            lines.Add(line);
        }

        File.WriteAllLines(filePath, lines);
    }

    public void AddPaper(Paper paper)
    {
        papers.Add(paper);
        SavePapers();
    }

    public void UpdatePaper(int index, Paper updatedPaper)
    {
        if (index >= 0 && index < papers.Count)
        {
            papers[index] = updatedPaper;
            SavePapers();
        }
    }

    public void DeletePaper(Paper paperToDelete)
    {
        papers.RemoveAll(p => p.Title == paperToDelete.Title && p.Author == paperToDelete.Author && p.PublicationDate == paperToDelete.PublicationDate && p.Description == paperToDelete.Description);
        SavePapers();
    }
    public List<Paper> GetAllPapers()
    {
        return papers;
    }

}
