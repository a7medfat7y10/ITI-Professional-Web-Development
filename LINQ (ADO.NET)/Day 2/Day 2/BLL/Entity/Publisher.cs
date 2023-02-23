using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Publisher : EntityBase
    {
        string pub_id;
        string pub_Name;
        string city;
        string state;
        string country;

        public string Pub_id
        {
            get => pub_id;
            set
            {
                if (value != pub_id)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;

                    this.pub_id = value;
                }
            }
        }
        public string Pub_Name
        {
            get => pub_Name;
            set
            {
                if (value != pub_Name)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;

                    this.pub_Name = value;
                }

            }
        }
        public string City
        {
            get => city;

            set
            {
                if (value != city)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    this.city = value;
                }
            }
        }
        public string PState
        {
            get => state;
            set
            {
                if (value != state)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    state = value;
                }
            }
        }
        public string Country
        {
            get => country;
            set
            {
                if (value != country)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    this.country = value;


                }
            }
        }
    }
}
