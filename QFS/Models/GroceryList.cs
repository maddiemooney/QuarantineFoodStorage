using System;
using System.Collections.Generic;
using System.Text;

namespace QFS.Models
{
    class GroceryList
    {

        public GroceryList()
        {

        }

        List<GroceryItem> groceryItemList { get; set; }
        
        public void CreateAlert(GroceryItem item)
        {
            //push button to get ? push notif
        }

    }
}
