using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_1.Models
{
    public class MinPrice: ValidationAttribute
    {
        int value;
        public MinPrice(int value)
        {
            this.value = value;
        }
        public override bool IsValid(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            else
            {
                if (obj is decimal) 
                { 
                    decimal SuppliedzValue  =(decimal)obj;
                    if(SuppliedzValue > value) 
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessage = "Price must be larger than +" + value;
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}