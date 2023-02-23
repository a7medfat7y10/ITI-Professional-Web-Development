using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using DAL;

namespace Task_1_NorthWind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TitleList TLst;
        PublisherList PLst;
        int index_of_pubID;

        private void Form1_Load(object sender, EventArgs e)
        {
            TLst = TitleManager.SelectAllTitles();
            titleBindingSource.DataSource = TLst;

            grdTitles.DataSource = titleBindingSource;


            grdTitles.UserDeletingRow += (sender, e) => TitleManager.DeleteTitle(e?.Row?.Cells["title_id"]?.Value?.ToString() ?? "");
            titleBindingSource.AddingNew += (sender, e) => e.NewObject = new Title() { State = EntityState.Added };

        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var t in TLst)
            {
                if (t.State == EntityState.Changed)
                    TitleManager.UpdateTitle(t.Title_Id, t.TitleName, t.Type, t.Pub_id, t.Price, t.Advance, t.Royalty, t.Ytd_sales, t.Notes, t.Pubdate);
                else if (t.State == EntityState.Added)
                    TitleManager.InsertTitle(t.Title_Id, t.TitleName, t.Type, t.Pub_id, t.Price, t.Advance, t.Royalty, t.Ytd_sales, t.Notes, t.Pubdate);
            }
             
            //reset all 
            foreach (var t in TLst)
                t.State = EntityState.Unchanged;
        }
    }
}