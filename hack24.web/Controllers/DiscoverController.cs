using System;
using System.Linq;
using System.Web.Mvc;
using hack24.core.Data;
using hack24.web.Resources;

namespace hack24.web.Controllers
{
	public class DiscoverController : Controller
	{
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

	}
}