global using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection SqlCn;
        SqlCommand SqlCmd;
        SqlDataAdapter SqlDA;
        DataTable DtPrds;

        //Supplier Id to Supplier Name 
        SqlCommand sqlCmdSupp;
        SqlDataAdapter SuppDA;
        DataTable DTSupp;

        //Category Id to Supplier Name 
        SqlCommand sqlCmdCategory;
        SqlDataAdapter CategoryDA;
        DataTable DTCategory;


        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCn= new SqlConnection();
            SqlCn.ConnectionString = ConfigurationManager.ConnectionStrings["NorthWindCN"].ConnectionString;

            SqlCmd = new SqlCommand("Select * from Products", SqlCn);
            SqlDA = new SqlDataAdapter(SqlCmd);

            DtPrds = new DataTable();

            SqlCommandBuilder commandBuilder= new SqlCommandBuilder(SqlDA);
            SqlDA.InsertCommand = commandBuilder.GetInsertCommand();
            SqlDA.UpdateCommand = commandBuilder.GetUpdateCommand();
            SqlDA.DeleteCommand = commandBuilder.GetDeleteCommand();


            //Suplier Id to name combo box
            sqlCmdSupp = new SqlCommand("Select * from Suppliers", SqlCn);
            SuppDA = new SqlDataAdapter(sqlCmdSupp);
            DTSupp = new DataTable();

            //Category Id to name combo box
            sqlCmdCategory = new SqlCommand("Select * from Categories", SqlCn);
            CategoryDA = new SqlDataAdapter(sqlCmdCategory);
            DTCategory = new DataTable();


        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlDA.Fill(DtPrds);
            grdPrds.DataSource = DtPrds;

            //Suplier Id to name
            SuppDA.Fill(DTSupp);
            DataGridViewComboBoxColumn combo1 = new DataGridViewComboBoxColumn();
            combo1.HeaderText = "Supplier Name";
            combo1.DataSource = DTSupp;
            combo1.DisplayMember = "CompanyName";
            combo1.ValueMember = "SupplierID";
            combo1.DataPropertyName = "SupplierID";
            grdPrds.Columns.Add(combo1);

            //Category Id to name
            CategoryDA.Fill(DTCategory);
            DataGridViewComboBoxColumn combo2 = new DataGridViewComboBoxColumn();
            combo2.HeaderText = "Category";
            combo2.DataSource = DTCategory;
            combo2.DisplayMember = "CategoryName";
            combo2.ValueMember = "CategoryID";
            combo2.DataPropertyName = "CategoryID";
            grdPrds.Columns.Add(combo2);

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grdPrds.EndEdit();
            SqlDA.Update(DtPrds);
        }
    }
}


