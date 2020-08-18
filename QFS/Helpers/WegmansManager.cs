using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QFS.Models;

namespace QFS.Helpers
{

    public interface IWegmansManager
    {
        GroceryItem GetSKUFromBarcode(string barcode);
        WebResponse GetProductFromSKU(string sku);
    }

    class WegmansManager : IWegmansManager
    {

        private readonly IConfiguration config;

        public WegmansManager(IConfiguration config)
        {
            this.config = config;
        }

        //get the sku from barcode
        //get the name from sku
        //

        public GroceryItem GetSKUFromBarcode(string barcode)
        {

            string url = config["Wegmans:Webhook"] + "/products/barcodes/" + barcode + config["Wegmans:SubscriptionKey"];

            WebRequest webRequest = WebRequest.Create(url);

            webRequest.ContentType = "application/json";
            webRequest.PreAuthenticate = true;
            webRequest.Method = "GET";
            WebResponse webResponse = webRequest.GetResponse();
            using (StreamReader stream = new StreamReader(webResponse.GetResponseStream()))
            {
                GroceryItem item = JsonConvert.DeserializeObject<GroceryItem>(stream.ReadToEnd());
                return item;
            }
        }

        public WebResponse GetProductFromSKU(string sku)
        {
            WebRequest webRequest = WebRequest.Create("test");

            webRequest.ContentType = "application/json";
            webRequest.PreAuthenticate = true;
            webRequest.Method = "GET";
            
            WebResponse webResponse = webRequest.GetResponse();
            return webResponse;
        }


    }
}
