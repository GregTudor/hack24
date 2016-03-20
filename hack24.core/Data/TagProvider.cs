using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using hack24.core.Model;

namespace hack24.core.Data
{
	public class TagProvider
	{
		public static IEnumerable<Tag> All => Locations.Union(PersonTypes).Union(Skills);

		public static IEnumerable<Tag> Locations = new[]
		{
			new Tag("unitedkingdom", "United Kingdom", 100, "in the"),
			new Tag("unitedstatesofamerica", "USA", 101, "in the"),
			new Tag("australia", "Australia", 102, "in"),
			new Tag("narnia", "Narnia", 103, "in"),
			new Tag("nottingham", "Nottingham", 104, "in"),
			new Tag("newyork", "New York", 105, "in"),
			new Tag("sydney", "Sydney", 106, "in"),
			new Tag("aslandia", "Aslandia", 107, "in")
		};

		public static IEnumerable<Tag> PersonTypes = new[]
		{
			new Tag("softwaregeek", "Software Geek", 1, "a"), //
			new Tag("computerguru", "Computer Guru", 2, "a"),
			new Tag("talentsourcerer", "Talent Sourcerer", 3, "a"),
			new Tag("hrhero", "HR Hero", 4, "an"),
			new Tag("payslippaladin", "Payslip Paladin", 5, "a"),
			new Tag("moneymaker", "Money Maker", 8, "a"),
			new Tag("partnerhunter", "Partner Hunter", 7, "a"),
			new Tag("talentmaster", "Talent Master", 6, "a"), //alien head
			new Tag("numbercruncher", "Number Cruncher", 9, "a"),
			new Tag("warriorofjustice", "Warrior Of Justice", 10, "a"),
			new Tag("crazycreative", "Crazy Creative", 11, "a"),
			new Tag("digitaldynamo", "Digital Dynamo", 12, "a"),
			new Tag("productfanatic", "Product Fanatic", 13, "a"),
			new Tag("emailextrodinaire", "Email Extraordinaire", 14, "a"),
			new Tag("socialgenius", "Social Genius", 15, "a"),
			new Tag("campaignwizard", "Campaign Wizard", 16, "a"),
			new Tag("globalmarketeer", "Global Marketeer", 17, "a")
		};

		public static IEnumerable<Tag> Skills = new[]
		{
			new Tag("problemsolver", "Problem solver", 501, "a"),
			new Tag("listener", "Listener", 502, "a"),
			new Tag("communicator", "Communicator", 503, "a"),
			new Tag("strategist", "Strategist", 504, "a"),
			new Tag("risktaker", "Risk Taker", 505, "a"),
			new Tag("descisionmaker", "Decision Maker", 506, "a"),
			new Tag("collaborator", "Collaborator", 507, "a"),
			new Tag("planner", "Planner", 508, "a"),
			new Tag("organiser", "Organiser", 509, "an"),
			new Tag("planner", "Planner", 510, "a"),
			new Tag("briefmaker", "Brief Maker", 511, "a"),
			new Tag("officesupplier", "Office Supplier", 512, "an"),
			new Tag("creativeproblemsolver", "Creative problem solver",513, "a"),
			new Tag("helper", "Helper", 513, "a"),
			new Tag("inspirer", "Inspirer", 514, "an"),
			new Tag("synergiser", "Synergiser", 515, "a"),
			new Tag("visionary", "Visionary", 516, "a"),
			new Tag("prioritiser", "Prioritiser", 517, "a"),
			new Tag("cheerleader", "Cheerleader", 518, "a"),
			new Tag("customerdelighter", "Customer Delighter", 519, "a"),
			new Tag("realist", "Realist", 520, "a"),
			new Tag("entrepreneural", "Entrepreneural", 521, ""),
			new Tag("futurist", "Futurist", 522, "a"),
			new Tag("technologist", "Technologist", 523, "a"),
			new Tag("technologist", "Technologist", 524, "a"),
			new Tag("explainer", "Explainer", 525, "an"),
			new Tag("teacher", "Teacher", 526, "a")
		};

		public static Tag GetById(string id)
		{
			var intId = Convert.ToInt32(id);
			var tag = All.FirstOrDefault(_ => _.Id == intId);

			return tag ?? new Tag("Oops", "Oops", 1000, "a ");
		}
	}
}