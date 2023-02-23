global using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Task_2_DetailedView
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
        SqlCommand sqlCmdUpdatePrice;
        SqlCommand sqlCmdUpdateName;
        SqlCommand sqlCmdUpdateSupp;
        SqlCommand sqlCmdUpdateQPerUnit;
        SqlCommand sqlCmdUpdateUnitsInStock;
        SqlCommand sqlCmdUpdateUnitsOnOrder;
        SqlCommand sqlCmdUpdateReorderLevel;
        SqlCommand sqlCmdUpdateDiscontinued;
        SqlCommand sqlCmdUpdateCategoryID;


        private void Form1_Load_1(object sender, EventArgs e)
        {
            SqlCn = new SqlConnection();
            SqlCn.ConnectionString = ConfigurationManager.ConnectionStrings["NorthWindCN"].ConnectionString;

            SqlCmd = new SqlCommand("SelectAllProducts", SqlCn);
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlDA = new SqlDataAdapter(SqlCmd);

            SqlCommandBuilder builder = new SqlCommandBuilder(SqlDA);

            DtPrds = new DataTable();

            SqlDA.Fill(DtPrds);

            #region Update price

            sqlCmdUpdatePrice = new SqlCommand();
            sqlCmdUpdatePrice.CommandText = "Update Products SET UnitPrice=@UnitPrice WHERE (ProductID=@ProductID)";
            sqlCmdUpdatePrice.Connection = SqlCn;

            sqlCmdUpdatePrice.Parameters.Add("@UnitPrice", SqlDbType.Money);
            sqlCmdUpdatePrice.Parameters.Add("@ProductID", SqlDbType.Int);

            #endregion

            #region Update name
            sqlCmdUpdateName = new SqlCommand();
            sqlCmdUpdateName.CommandText = "Update Products SET ProductName=@ProductName WHERE (ProductID=@ProductID)";
            sqlCmdUpdateName.Connection = SqlCn;

            sqlCmdUpdateName.Parameters.Add("@ProductName", SqlDbType.NVarChar);
            sqlCmdUpdateName.Parameters.Add("@ProductID", SqlDbType.Int);
            #endregion

            #region Update  supplier
            sqlCmdUpdateSupp = new SqlCommand();
            sqlCmdUpdateSupp.CommandText = "Update Products SET SupplierID=@SupplierID WHERE (ProductID=@ProductID)";
            sqlCmdUpdateSupp.Connection = SqlCn;

            sqlCmdUpdateSupp.Parameters.Add("@SupplierID", SqlDbType.Int);
            sqlCmdUpdateSupp.Parameters.Add("@ProductID", SqlDbType.Int);
            #endregion

            #region Update Quantity Per Unit
            sqlCmdUpdateQPerUnit = new SqlCommand();
            sqlCmdUpdateQPerUnit.CommandText = "Update Products SET QuantityPerUnit=@QuantityPerUnit WHERE (ProductID=@ProductID)";
            sqlCmdUpdateQPerUnit.Connection = SqlCn;

            sqlCmdUpdateQPerUnit.Parameters.Add("@QuantityPerUnit", SqlDbType.NVarChar);
            sqlCmdUpdateQPerUnit.Parameters.Add("@ProductID", SqlDbType.Int);
            #endregion

            #region Update Units In Stock
            sqlCmdUpdateUnitsInStock = new SqlCommand();
            sqlCmdUpdateUnitsInStock.CommandText = "Update Products SET UnitsInStock=@UnitsInStock WHERE (ProductID=@ProductID)";
            sqlCmdUpdateUnitsInStock.Connection = SqlCn;

            sqlCmdUpdateUnitsInStock.Parameters.Add("@UnitsInStock", SqlDbType.SmallInt);
            sqlCmdUpdateUnitsInStock.Parameters.Add("@ProductID", SqlDbType.Int);
            #endregion

            #region Update UnitsOnOrder
            sqlCmdUpdateUnitsOnOrder = new SqlCommand();
            sqlCmdUpdateUnitsOnOrder.CommandText = "Update Products SET UnitsOnOrder=@UnitsOnOrder WHERE (ProductID=@ProductID)";
            sqlCmdUpdateUnitsOnOrder.Connection = SqlCn;

            sqlCmdUpdateUnitsOnOrder.Parameters.Add("@UnitsOnOrder", SqlDbType.SmallInt);
            sqlCmdUpdateUnitsOnOrder.Parameters.Add("@ProductID", SqlDbType.Int);
            #endregion

            #region Update Reorder level
            sqlCmdUpdateReorderLevel = new SqlCommand();
            sqlCmdUpdateReorderLevel.CommandText = "Update Products SET ReorderLevel=@ReorderLevel WHERE (ProductID=@ProductID)";
            sqlCmdUpdateReorderLevel.Connection = SqlCn;

            sqlCmdUpdateReorderLevel.Parameters.Add("@ReorderLevel", SqlDbType.SmallInt);
            sqlCmdUpdateReorderLevel.Parameters.Add("@ProductID", SqlDbType.Int);
            #endregion

            #region Update Discontinued
            sqlCmdUpdateDiscontinued = new SqlCommand();
            sqlCmdUpdateDiscontinued.CommandText = "Update Products SET Discontinued=@Discontinued WHERE (ProductID=@ProductID)";
            sqlCmdUpdateDiscontinued.Connection = SqlCn;

            sqlCmdUpdateDiscontinued.Parameters.Add("@Discontinued", SqlDbType.Bit);
            sqlCmdUpdateDiscontinued.Parameters.Add("@ProductID", SqlDbType.Int);
            #endregion

            #region Update CategoryID
            sqlCmdUpdateCategoryID = new SqlCommand();
            sqlCmdUpdateCategoryID.CommandText = "Update Products SET CategoryID=@CategoryID WHERE (ProductID=@ProductID)";
            sqlCmdUpdateCategoryID.Connection = SqlCn;

            sqlCmdUpdateCategoryID.Parameters.Add("@CategoryID", SqlDbType.Int);
            sqlCmdUpdateCategoryID.Parameters.Add("@ProductID", SqlDbType.Int);
            #endregion


            //grdPrds.datasource = Dtprds
            BindingSource PrdBindingSource = new BindingSource(DtPrds, "");

            ///Simple Data Binding
            txtPrdID.DataBindings.Add("Text", PrdBindingSource, "ProductID");
            txtPrdName.DataBindings.Add("Text", PrdBindingSource, "ProductName");
            txtUnitPrice.DataBindings.Add("Text", PrdBindingSource, "UnitPrice");
            txtSuppID.DataBindings.Add("Text", PrdBindingSource, "SupplierID");
            txtQPerUnit.DataBindings.Add("Text", PrdBindingSource, "QuantityPerUnit");
            txtUnitsInSock.DataBindings.Add("Text", PrdBindingSource, "UnitsInStock");
            txtUnitsInOrder.DataBindings.Add("Text", PrdBindingSource, "UnitsOnOrder");
            txtReorderLevel.DataBindings.Add("Text", PrdBindingSource, "ReorderLevel");
            txtDiscontinued.DataBindings.Add("Text", PrdBindingSource, "Discontinued");
            txtCategoryID.DataBindings.Add("Text", PrdBindingSource, "CategoryID");


            BindingNavigator bindingNavigator = new BindingNavigator(PrdBindingSource);
            this.Controls.Add(bindingNavigator);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            #region Update price
            if ((decimal.TryParse(txtUnitPrice.Text, out decimal PrdPrice)))
            {
                sqlCmdUpdatePrice.Parameters["@UnitPrice"].Value = PrdPrice;
                sqlCmdUpdatePrice.Parameters["@ProductID"].Value = txtPrdID.Text;

                SqlCn.Open();

                if (sqlCmdUpdatePrice.ExecuteNonQuery() > 0)
                    this.Text = "Done";
                else
                    this.Text = "Error";

                SqlCn.Close();
            }
            #endregion

            #region Update name
            string prdName = txtPrdName.Text;
            sqlCmdUpdateName.Parameters["@ProductName"].Value = prdName;
            sqlCmdUpdateName.Parameters["@ProductID"].Value = txtPrdID.Text;

            SqlCn.Open();

            if (sqlCmdUpdateName.ExecuteNonQuery() > 0)
                this.Text = "Done";
            else
                this.Text = "Error";

            SqlCn.Close();

            #endregion

            #region Update supplier
            if ((int.TryParse(txtSuppID.Text, out int PrdSupp)))
            {
                sqlCmdUpdateSupp.Parameters["@SupplierID"].Value = PrdSupp;
                sqlCmdUpdateSupp.Parameters["@ProductID"].Value = txtPrdID.Text;

                SqlCn.Open();

                if (sqlCmdUpdateSupp.ExecuteNonQuery() > 0)
                    this.Text = "Done";
                else
                    this.Text = "Error";

                SqlCn.Close();
            }
            #endregion

            #region Update Category
            if ((int.TryParse(txtCategoryID.Text, out int PrdCategory)))
            {
                sqlCmdUpdateCategoryID.Parameters["@CategoryID"].Value = PrdCategory;
                sqlCmdUpdateCategoryID.Parameters["@ProductID"].Value = txtPrdID.Text;

                SqlCn.Open();

                if (sqlCmdUpdateCategoryID.ExecuteNonQuery() > 0)
                    this.Text = "Done";
                else
                    this.Text = "Error";

                SqlCn.Close();
            }
            #endregion

            #region Update Quantity Per Unit
            string QPerUnit = txtQPerUnit.Text;
            sqlCmdUpdateQPerUnit.Parameters["@QuantityPerUnit"].Value = QPerUnit;
            sqlCmdUpdateQPerUnit.Parameters["@ProductID"].Value = txtPrdID.Text;

            SqlCn.Open();

            if (sqlCmdUpdateQPerUnit.ExecuteNonQuery() > 0)
                this.Text = "Done";
            else
                this.Text = "Error";

            SqlCn.Close();

            #endregion

            #region Update Units In Stock
            if ((int.TryParse(txtUnitsInSock.Text, out int UnitsInStk)))
            {
                sqlCmdUpdateUnitsInStock.Parameters["@UnitsInStock"].Value = UnitsInStk;
                sqlCmdUpdateUnitsInStock.Parameters["@ProductID"].Value = txtPrdID.Text;

                SqlCn.Open();

                if (sqlCmdUpdateUnitsInStock.ExecuteNonQuery() > 0)
                    this.Text = "Done";
                else
                    this.Text = "Error";

                SqlCn.Close();
            }
            #endregion

            #region Update Units On Order
            if ((int.TryParse(txtUnitsInOrder.Text, out int UnitsOnOrder)))
            {
                sqlCmdUpdateUnitsOnOrder.Parameters["@UnitsOnOrder"].Value = UnitsOnOrder;
                sqlCmdUpdateUnitsOnOrder.Parameters["@ProductID"].Value = txtPrdID.Text;

                SqlCn.Open();

                if (sqlCmdUpdateUnitsOnOrder.ExecuteNonQuery() > 0)
                    this.Text = "Done";
                else
                    this.Text = "Error";

                SqlCn.Close();
            }
            #endregion

            #region Update Reorder level
            if ((int.TryParse(txtReorderLevel.Text, out int ReorderLevel)))
            {
                sqlCmdUpdateReorderLevel.Parameters["@ReorderLevel"].Value = ReorderLevel;
                sqlCmdUpdateReorderLevel.Parameters["@ProductID"].Value = txtPrdID.Text;

                SqlCn.Open();

                if (sqlCmdUpdateReorderLevel.ExecuteNonQuery() > 0)
                    this.Text = "Done";
                else
                    this.Text = "Error";

                SqlCn.Close();
            }
            #endregion

            #region Update Discontinued
            if ((bool.TryParse(txtDiscontinued.Text, out bool Discontinued)))
            {
                sqlCmdUpdateDiscontinued.Parameters["@Discontinued"].Value = Discontinued;
                sqlCmdUpdateDiscontinued.Parameters["@ProductID"].Value = txtPrdID.Text;

                SqlCn.Open();

                if (sqlCmdUpdateDiscontinued.ExecuteNonQuery() > 0)
                    this.Text = "Done";
                else
                    this.Text = "Error";

                SqlCn.Close();
            }
            #endregion
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlDA.Update(DtPrds);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataRow row = DtPrds.NewRow();
            row["ProductName"] = txtPrdName.Text;
            row["SupplierID"] = int.Parse(txtSuppID.Text);
            row["CategoryID"] = int.Parse(txtCategoryID.Text);
            row["UnitsInStock"] = int.Parse(txtUnitsInSock.Text);
            row["UnitsOnOrder"] = int.Parse(txtUnitsInOrder.Text);
            row["ReorderLevel"] = int.Parse(txtReorderLevel.Text);
            row["Discontinued"] = bool.Parse(txtDiscontinued.Text);
            row["QuantityPerUnit"] = txtQPerUnit.Text;
            row["UnitPrice"] = decimal.Parse(txtUnitPrice.Text);
            DtPrds.Rows.Add(row);
            SqlDA.Update(DtPrds);
            
        }
    }
}