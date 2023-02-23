using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entity;
using BLL.EntityList;
using DAL;

namespace BLL.EntityManager
{
    public class PublisherManager
    {
        static DBManager manager = new();
        public static PublisherList SelectAllPublishers()
        {
            try
            {
                return DataTableToPublisherList(manager.ExecuteDataTable("SelectPublisherNAME "));
            }
            catch
            {
                return new PublisherList();
            }
        }


        internal static PublisherList DataTableToPublisherList(DataTable dt)
        {
            PublisherList Pub_list = new PublisherList();
            foreach (DataRow dr in dt.Rows)
            {
                Pub_list.Add(DataRowToPublisher(dr));
            }
            return Pub_list;
        }
        internal static Publisher DataRowToPublisher(DataRow row)
        {
            Publisher p = new Publisher();
            try
            {
                p.Pub_id = row["Pub_id"]?.ToString() ?? "NA";
                p.Pub_Name = row["Pub_Name"]?.ToString() ?? "NA";
                p.Country = row["Country"]?.ToString() ?? "NA";
                p.PState = row["State"]?.ToString() ?? "NA";
                p.City = row["city"]?.ToString() ?? "NA";
            }
            catch
            {
            }
            return p;
        }

    }
}
