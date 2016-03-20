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
		private readonly DiscoveryService discoveryService;

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
				PersonTypes = TagProvider.PersonTypes.OrderBy(x => Guid.NewGuid()),
				Skills = TagProvider.Skills.Union(TagProvider.Locations).OrderBy(x => Guid.NewGuid())
			};

			return this.View(resource);
		}

		[HttpGet]
		public ActionResult test(string id)
		{
			var tagids = id.Split('|').Select(x=>int.Parse(x)).ToArray();
			var profile = this.discoveryService.GetMatches(tagids);


			return this.RedirectToAction("view","profile", new { profile.Id});
		}
	}
}