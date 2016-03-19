using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hack24.core.Data;
using hack24.core.Model;
using hack24.web.Resources;

namespace hack24.web.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

	    public ActionResult View(Guid id)
	    {
		    using (var session = MartenStuff.Store.LightweightSession())
		    {
			    var profile = session.Query<ProfileModel>().Single(x => x.Id == id);
			    if (profile == null)
			    {
				    return new HttpNotFoundResult();
			    }

			    return View(new ProfileResource
			    {
					Id = profile.Id,
					Bio = profile.Bio,
					FirstName = profile.FirstName,
					JobTitle = profile.JobTitle,
					LastName = profile.LastName,
					LocationTags = profile.LocationTags,
					Tags = profile.Tags
				});
		    }
	    }

	    public ActionResult Fist()
	    {
		    var profile = new ProfileModel
		    {
			    FirstName = "Stevie",
				Bio = "Collector of bins extraordinaire.",
				JobTitle = "Bin Master",
				LastName = "Tubins",
				//LocationTags = new[] { new Tag {DisplayName = "Nottingham", Name = "nottm" } },
				//Tags = new[] { new Tag { DisplayName = "Bin Hoarder", Name = "binhoarder" } }
			};
		    using (var session = MartenStuff.Store.LightweightSession())
		    {
			    session.Store(profile);

				session.SaveChanges();
		    }

			var json = Json(new { success = true });
		    json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			return json;
	    }
    }
}