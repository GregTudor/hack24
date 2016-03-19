using System;
using System.Linq;
using System.Web.Mvc;
using hack24.core.Data;
using hack24.core.Service;
using hack24.web.Resources;

namespace hack24.web.Controllers
{
	public class DiscoverController : Controller
	{
		private DiscoveryService discoveryService;

		public DiscoverController()
		{
			this.discoveryService = new DiscoveryService();


		}

		// GET: Discover
		[HttpGet]
		public ActionResult Index()
		{
			var resource = new DiscoverIndexResource
			{
				Locations = TagProvider.Locations,
				PersonTypes = TagProvider.PersonTypes.OrderBy(x => Guid.NewGuid()),
				Skills = TagProvider.Skills.OrderBy(x => Guid.NewGuid())
			};

			return this.View(resource);
		}

		[HttpPost]
		public ActionResult Index(DiscoverIndexResource resource)
		{
			var tagids = "";
			this.discoveryService.GetMatches(tagids);

			var id = new Guid();
			return Redirect("/profile/view/"+id);
		}
	}
}