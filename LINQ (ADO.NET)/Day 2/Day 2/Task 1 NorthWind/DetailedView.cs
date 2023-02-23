using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1_NorthWind
{
    public partial class DetailedView : Form
    {
        TitleList TLst;
        PublisherList PLst;
        BindingNavigator bindingNavigator;


        public DetailedView()
        {
            InitializeComponent();
        }

        private void DetailedView_Load(object sender, EventArgs e)
        {
            TLst = TitleManager.SelectAllTitles();
            PLst = PublisherManager.SelectAllPublishers();

            //titleBindingSource is  the name of the binding source added from the toolbox
            titleBindingSource.DataSource = TLst;
            
            
            txtId.DataBindings.Add("text", titleBindingSource, "Title_Id");
            txtTitle.DataBindings.Add("text", titleBindingSource, "TitleName");
            txtType.DataBindings.Add("text", titleBindingSource, "Type");
            txtNotes.DataBindings.Add("text", titleBindingSource, "Notes");
            txtPubDate.DataBindings.Add("text", titleBindingSource, "Pubdate");
            txtPrice.DataBindings.Add("text", titleBindingSource, "Price", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            txtAdvance.DataBindings.Add("text", titleBindingSource, "Advance", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            txtRoyalty.DataBindings.Add("text", titleBindingSource, "Royalty", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            txtYtd.DataBindings.Add("text", titleBindingSource, "Ytd_sales", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);


            bindingNavigator = new BindingNavigator(titleBindingSource);
            this.Controls.Add(bindingNavigator);

            comboBoxPublisher.DataSource = PLst;
            comboBoxPublisher.DisplayMember = "Pub_Name";
            comboBoxPublisher.ValueMember = "Pub_id";
            comboBoxPublisher.DataBindings.Add("SelectedValue", titleBindingSource, "Pub_id");


            //events used to add and delete in binding navigator
            bindingNavigator.DeleteItem.MouseDown += (sender, e) => TitleManager.DeleteTitle(txtId.Text);
            titleBindingSource.AddingNew += (sender, e) => e.NewObject = new Title() { Title_Id = "", Pubdate = DateTime.Now, State = EntityState.Added };

        }

        private void btnSave_Click(object sender, EventArgs e)
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
