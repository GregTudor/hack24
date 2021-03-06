﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using hack24.core.Data;
using hack24.core.Model;
using hack24.core.Service;
using hack24.web.Resources;

namespace hack24.web.Controllers
{
	public class ProfileController : Controller
	{
		private readonly DiscoveryService discoveryService;

		public ProfileController()
		{
			this.discoveryService = new DiscoveryService();
		}

		// GET: Profile
		public ActionResult Index()
		{
			return this.View();
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

				return this.View(new ProfileResource
				{
					Primary = profile
				});
			}
		}
		public ActionResult Me()
		{

			using (var session = MartenStuff.Store.LightweightSession())
			{
				var profile = session.Query<ProfileModel>().Single(x => x.Id == new Guid("018b2e28-a971-428d-9b1f-f7d07f716a03"));
				var holidayApprover = session.Query<ProfileModel>().Single(x => x.Id == new Guid("23af654b-768b-44da-af04-1fbe8c66a1a5"));
				var lineManager = session.Query<ProfileModel>().Single(x => x.Id == new Guid("452b677a-fc9e-4331-85ec-c014a11472e7"));
				var payManger = session.Query<ProfileModel>().Single(x => x.Id == new Guid("76802d04-04ed-4961-ae3e-71570e88cc85"));
				if (profile == null)
				{
					return new HttpNotFoundResult();
				}

				return this.View(new ProfileResource
				{
					Primary = profile,
					HolidayApprover = holidayApprover,
					LineManager = lineManager,
					PayManager = payManger
				});
			}
		}

		[HttpPost]
		public ActionResult Suggested(string id)
		{
			var tagids = id.Split('|').Select(x => int.Parse(x)).ToArray();
			var profiles = this.discoveryService.GetMatches(tagids);

			return this.View("View", new ProfileResource
			{
				Primary = profiles.ElementAt(0),
				Alternatives = profiles.Skip(1)
			});
		}

		public ActionResult ByTag(string name)
		{
			using (var session = MartenStuff.Store.LightweightSession())
			{
				var profiles = session.Query<ProfileModel>().Where(x => x.Tags.Any(y=>y.Name== name)).ToArray();
				

				return this.View(new ProfileListResource
				{
					Tag = name,
					Profiles = profiles
				});
			}
		}

		public ActionResult Fist()
		{
			using (var sr = new StreamReader(System.IO.File.OpenRead(@"C:\git\hack24\DBBackups\data.csv")))
			using (var session = MartenStuff.Store.LightweightSession())
			{
				var profiles = new List<ProfileModel>();
				while (!sr.EndOfStream)
				{
					var line = sr.ReadLine();
					var split = line.Split(',');

					var profile = new ProfileModel
					{
						Id = Guid.NewGuid(),
						Bio =
							"Emmental airedale queso. Cheese on toast smelly cheese st. agur blue cheese cauliflower cheese stinking bishop blue castello pepper jack bavarian bergkase.",
						FirstName = split[0].Split(' ')[0],
						LastName = split[0].Split(' ')[1],
						JobTitle = split[3],
						Tags = split[2].Split('|').Select(TagProvider.GetById).ToArray(),
						//ProfileImage = "Default.png",
						Department = split[1]
					};

					session.Store(profile);
				}


				session.SaveChanges();
			}

			var json = this.Json(new { success = true });
			json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
			return json;
		}
	}
}