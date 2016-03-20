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
    }
}