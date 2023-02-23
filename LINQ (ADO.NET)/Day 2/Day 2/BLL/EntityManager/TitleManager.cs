using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entity;
using BLL.EntityList;
using DAL;
using static Azure.Core.HttpHeader;

namespace BLL.EntityManager
{
    public class TitleManager
    {
        static DBManager manager = new();
        public static TitleList SelectAllTitles()
        {
            try
            {
                return DataTableToTitleList(manager.ExecuteDataTable("SelectAllTitles"));
            }
            catch
            {
                return new TitleList();
            }
        }

        public static int UpdateTitle(string title_id, string title, string type, string pub_id, decimal price, decimal? advance, int? royalty, int? ytd_sales, string notes, DateTime pubdate)
        {
            try
            {
                Dictionary<string, object> dic = new()
                {
                    ["@TitleID"] = title_id,
                    ["@TitleName"] = title,
                    ["@Type"] = type,
                    ["@PubID"] = pub_id,
                    ["@Price"] = price,
                    ["@Advance"] = advance ?? 0,
                    ["@Royalty"] = royalty ?? 0,
                    ["ytd_sales"] = ytd_sales ?? 0,
                    ["@notes"] = notes,
                    ["@pubdate"] = pubdate

                };
                return manager.ExecuteNonQuery("UpdateTitleById", dic);
            }
            catch
            {
                return -1;
            }
        }
        public static int DeleteTitle(string title_id)
        {
            try
            {
                Dictionary<string, object> dic = new()
                {
                    ["@TitleID"] = title_id,
                };
                return manager.ExecuteNonQuery("DeleteTitle", dic);
            }
            catch { return -1; }
        }
        public static int InsertTitle(string title_id, string title, string type, string pub_id, decimal price, decimal? advance, int? royalty, int? ytd_sales, string notes, DateTime pubdate)
        {
            try
            {
                Dictionary<string, object> dic = new()
                {
                    ["@TitleID"] = title_id,
                    ["@TitleName"] = title,
                    ["@Type"] = type,
                    ["@PubID"] = pub_id,
                    ["@Price"] = price,
                    ["@Advance"] = advance??0,
                    ["@Royalty"] = royalty ??0,
                    ["ytd_sales"] = ytd_sales ?? 0,
                    ["@notes"] = notes,
                    ["@pubdate"] = pubdate
                };
                return manager.ExecuteNonQuery("InsertTitle", dic);
            }
            catch { return -1; }
        }


        #region Mapping
        public static TitleList DataTableToTitleList(DataTable Dt)
        {
            TitleList TLst = new();
            try
            {
                foreach (DataRow Dr in Dt.Rows)
                    TLst.Add(DataRowToTitle(Dr));
            }
            catch
            {
                return new();
            }
            return TLst;
        }

        public static Title DataRowToTitle(DataRow Dr)
        {
            Title T = new();

            try 
            {
                T.Title_Id = Dr["title_id"]?.ToString() ?? "NA";
                T.TitleName = Dr["title"]?.ToString() ?? "NA";
                T.Type = Dr["type"]?.ToString() ?? "NA";
                T.Pub_id = Dr["pub_id"]?.ToString() ?? "NA";

                if (decimal.TryParse(Dr["price"]?.ToString() ?? "-1", out decimal TempDecimal))
                    T.Price = TempDecimal;

                if (decimal.TryParse(Dr["advance"]?.ToString() ?? "-1", out TempDecimal))
                    T.Advance = TempDecimal;

                if (int.TryParse(Dr["royalty"]?.ToString() ?? "-1", out int TempInt))
                    T.Royalty = TempInt;

                if (int.TryParse(Dr["ytd_sales"]?.ToString() ?? "-1", out TempInt))
                    T.Ytd_sales = TempInt;

                if (DateTime.TryParse(Dr["pubdate"]?.ToString() ?? "1-1-2022", out DateTime TempDateTime))
                    T.Pubdate = TempDateTime;

                T.Notes = Dr["notes"]?.ToString() ?? "NA";

                //reseting state after mapping object
                T.State = EntityState.Unchanged;

            }

            catch
            {
                return new ();
            }

            return T;
        }
        
        #endregion
    }
}
