using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using hack24.core.Service;
using hack24.web.Resources;

namespace hack24.web.Controllers
{
    public class VisualiseController : Controller
    {
	    private DiscoveryService discoveryService;

	    public VisualiseController()
	    {
			this.discoveryService = new DiscoveryService();

		}

		// GET: Visualise
		public ActionResult Index()
		{
			var tags = this.discoveryService.TagUsage();
			var resource = new TagPopularityModel
			{
				TagData = tags
			};
            return View(resource);
        }

		[HttpGet]
	    public ActionResult GetTagJson()
	    {
			var tags = this.discoveryService.TagUsage();
			var jsonResult = Json (new { Data = tags.Select(x => new { text = x.Key.DisplayName, weight = x.Value }) } );
			jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

			return jsonResult;
	    }
    }
}