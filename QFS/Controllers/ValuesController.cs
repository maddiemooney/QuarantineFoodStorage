using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QFS.Helpers;
using QFS.Models;

namespace QFS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        readonly IWegmansManager wegmansManager;
        readonly IDatabaseManager databaseManager;

        public ValuesController(IWegmansManager wegmansManager, IDatabaseManager databaseManager)
        {
            this.wegmansManager = wegmansManager;
            this.databaseManager = databaseManager;
        }

        // GET api/values
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Content("Beam me up, Scotty.");
        }

        // POST api/values/PostBarcodeGetItem
        [HttpPost]
        [AllowAnonymous]
        [Route("[action]")]
        public ActionResult<IEnumerable<GroceryItem>> PostBarcodeGetItem([FromBody] GroceryItem incompleteItem)
        {
            GroceryItem item = wegmansManager.GetSKUFromBarcode(incompleteItem.barcode);
            return Ok(item);
        }


        // GET api/values/GetAllLocations
        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public ActionResult<IEnumerable<GroceryStorageLocation>> GetAllLocations()
        {
            SqlConnection connection = databaseManager.InitConnection();
            List<GroceryStorageLocation> locations=databaseManager.GetAllLocations(connection);
            return Ok(locations);
        }

        // POST api/values/PostItemToStorage
        [HttpPost]
        [AllowAnonymous]
        [Route("[action]")]
        public ActionResult<IEnumerable<GroceryItem>> PostItemToStorage([FromBody] GroceryItem item)
        {
            SqlConnection connection = databaseManager.InitConnection();
            databaseManager.InsertGroceryItem(connection, item);
            return Ok();
        }




    }
}
