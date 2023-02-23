using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;

namespace DAL
{
    public class DBManager
    {
        SqlConnection SqlCN;
        SqlCommand SqlCmd;
        SqlDataAdapter SqlDA;
        DataTable Dt;

        public DBManager()
        {
            try
            {
                SqlCN = new SqlConnection(ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString);
                SqlCmd = new SqlCommand();
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Connection = SqlCN;
                SqlDA = new(SqlCmd);
                Dt = new();
            }
            catch { }

        }

        public int ExecuteNonQuery(string SPName)
        {
            try
            {
                SqlCmd.Parameters.Clear();

                SqlCmd.CommandText = SPName;

                if (SqlCN.State == ConnectionState.Closed)
                    SqlCN.Open();

                return SqlCmd.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }

            finally { SqlCN.Close(); }
        }


        public int ExecuteNonQuery(string SPName, Dictionary<String, object> ParmLst)
        {
            try
            {
                SqlCmd.Parameters.Clear();

                foreach (var item in ParmLst)
                    SqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                SqlCmd.CommandText = SPName;

                if (SqlCN.State == ConnectionState.Closed)
                    SqlCN.Open();

                return SqlCmd.ExecuteNonQuery();

            }
            catch
            {
                return -1;
            }
            finally
            {
                SqlCN.Close();
            }
        }


        public object ExecuteScalar(string SPName)
        {
            try
            {
                SqlCmd.Parameters.Clear();

                SqlCmd.CommandText = SPName;

                if (SqlCN.State == ConnectionState.Closed)
                    SqlCN.Open();

                return SqlCmd.ExecuteScalar();

            }
            catch
            {
                return new();
            }
            finally { SqlCN.Close(); }
        }

        public object ExecuteScalar(string SPName, Dictionary<String, object> ParmLst)
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteDataTable(string SPName)
        {
            try
            {
                Dt.Clear();
                SqlCmd.Parameters.Clear();
                SqlCmd.CommandText = SPName;

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(SqlDA);


                SqlDA.Fill(Dt);
                return Dt;

            }
            catch 
            {
                return new();
            }

        }

        public DataTable ExecuteDataTable(string SPName, Dictionary<String, object> ParmLst)
            => throw new NotImplementedException();


    }
}