using System;
using System.Collections.Generic;
using System.Text;

namespace QFS.Models
{
    class StorageLocation
    {

        public StorageLocation()
        {

        }


        List<GroceryItem> foodItems { get; set; }
        string name { get; set; }
        List<GroceryItem> cleanFood { get; set; }

    }
}
