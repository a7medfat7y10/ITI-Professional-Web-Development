using Microsoft.EntityFrameworkCore;
using Task_1_GridView.Context;

namespace Task_1_GridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) => Context?.Dispose();
        }
        pubsContext Context = new();
        private void Form1_Load(object sender, EventArgs e)
        {
            var TLst1 = Context.Titles.ToList();

            Context.Titles.Load();

            this.grdTitles.DataSource = Context.Titles.Local.ToBindingList();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Context.SaveChanges();
        }
    }
}