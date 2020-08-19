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

        // GET api/values/GetSKU
        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public ActionResult<IEnumerable<string>> GetSKU()
        {
            GroceryItem item = wegmansManager.GetSKUFromBarcode("3700076213");
            return Ok(item.ToString());

            //change to post?
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
            return Ok();
        }


    }
}
