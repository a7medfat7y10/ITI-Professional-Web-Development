using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_1_GridView.Context;
using Task_1_GridView.Models;

namespace Task_1_GridView
{
    public partial class DetailedView : Form
    {
        public DetailedView()
        {
            InitializeComponent();
            this.FormClosed += (sender, e) => Context?.Dispose();
        }
        pubsContext Context = new();
        BindingNavigator nav = new BindingNavigator();
        private void DetailedView_Load(object sender, EventArgs e)
        {
            Context.Titles.Load();
            var TLst = Context.Titles.Local.ToBindingList();

            BindingSource bindingSourceTitles = new BindingSource();

            bindingSourceTitles.DataSource = TLst;
            bindingSourceTitles.AddingNew += (sender, e) => e.NewObject = new Title() { TitleId = "", Pubdate = DateTime.Now };

            txtID.DataBindings.Add("Text", bindingSourceTitles, "TitleId");
            txtTitle.DataBindings.Add("Text", bindingSourceTitles, "Title1");
            txtNotes.DataBindings.Add("Text", bindingSourceTitles, "Notes");
            txtType.DataBindings.Add("Text", bindingSourceTitles, "Type");
            txtPrice.DataBindings.Add("text", bindingSourceTitles, "Price", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            txtAdvance.DataBindings.Add("text", bindingSourceTitles, "Advance", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            txtRoyality.DataBindings.Add("text", bindingSourceTitles, "Royalty", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            txtYtd_Sales.DataBindings.Add("text", bindingSourceTitles, "YtdSales", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);

            txtPub_Date.DataBindings.Add("Text", bindingSourceTitles, "Pubdate");
            txtPub_ID.DataBindings.Add("Text", bindingSourceTitles, "PubId");

            nav = new BindingNavigator(bindingSourceTitles);
            this.Controls.Add(nav);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Context.SaveChanges();
        }
    }
}
