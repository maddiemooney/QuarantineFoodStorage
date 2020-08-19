using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.PowerShell;

namespace QFS.Models
{
    public class GroceryItem
    {

        public GroceryItem(){}

        public string barcode { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public DateTime dateadded { get; set; }
        public int quarantinelength { get; set; }
        public int alertexists { get; set; }
        public int locationid { get; set; }


        //bool isAvailable?
        //bool needMore?

        public override string ToString()
        {
            return "barcode: " + this.barcode + "\nsku: " + this.sku + "\nname: " + this.name;
        }
    }
}
