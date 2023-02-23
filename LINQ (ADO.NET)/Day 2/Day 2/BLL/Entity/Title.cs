using BLL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Title:EntityBase
    {
        string title_id;
        public string Title_Id
        {
            get => title_id;
            set
            {
                if (value != title_id)
                {
                    title_id = value;
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                }
            }
        }
        string title;
        public string TitleName
        {
            get => title;
            set
            {
                if (value != title)
                {
                    title = value;
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                }
            }
        }
        string type;
        public string Type
        {
            get => type;
            set
            {
                if (value != type)
                {
                    type = value;
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                }
            }
        }
        string pub_id;
        public string Pub_id
        {
            get => pub_id;
            set
            {
                if (value != pub_id)
                {
                    pub_id = value;
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                }
            }
        }
        decimal price;
        public decimal Price
        {
            get => price;
            set
            {
                if (value != price)
                {
                    price = value;
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                }
            }
        }
        Nullable<decimal> advance;
        public Nullable<decimal> Advance
        {
            get => advance;
            set
            {
                if (value != advance)
                {
                    advance = value;
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                }
            }
        }
        Nullable<int> royalty;
        public Nullable<int> Royalty
        {
            get => royalty;
            set
            {
                if (value != royalty)
                {
                    royalty = value;
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                }
            }
        }
        Nullable<int> ytd_sales;
        public Nullable<int> Ytd_sales
        {
            get => ytd_sales;
            set
            {
                if (value != ytd_sales)
                {
                    ytd_sales = value;
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                }
            }
        }
        string notes;
        public string Notes
        {
            get => notes;
            set
            {
                if (value != notes)
                {
                    notes = value;
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                }
            }
        }
        DateTime pubdate;
        public DateTime Pubdate
        {
            get => pubdate;
            set
            {
                if (value != pubdate)
                {
                    pubdate = value;
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                }
            }
        }
    }
}



