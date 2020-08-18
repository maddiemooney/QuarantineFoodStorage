using System.Collections.Generic;
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

        public ValuesController(IWegmansManager wegmansManager)
        {
            this.wegmansManager = wegmansManager;
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




    }
}
