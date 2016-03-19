using System.Collections.Generic;
using hack24.core.Model;

namespace hack24.core.Data
{
	public class TagProvider
	{
		public static IEnumerable<Tag> Locations = new[]
		{
			new Tag("unitedkingdom", "United Kingdom", 100),
			new Tag("unitedstatesofamerica", "United States of America", 101),
			new Tag("austrailia", "Austrailia", 102),
			new Tag("narnia", "Narnia", 103),
			new Tag("nottingham", "Nottingham", 104),
			new Tag("newyork", "New York", 105),
			new Tag("sydney", "Sydney", 106),
			new Tag("alandia", "Aslandia", 107)
		};

		public static IEnumerable<Tag> PersonTypes = new[]
		{
			new Tag("softwaregeek", "Software Geek", 1), //
			new Tag("computerguru", "Computer Guru", 2),
			new Tag("talentsourcerer", "Talent Sourcerer", 3),
			new Tag("hrhero", "HR Hero", 4),
			new Tag("payslippaladin", "Payslip Paladin", 5),
			new Tag("moneymaker", "Money Maker", 8),
			new Tag("partnerhunter", "Partner Hunter", 7),
			new Tag("talentmaster", "Talent Master", 6), //alien head
			new Tag("numbercruncher", "Number Cruncher", 9),
			new Tag("warriorofjustice", "Warrior Of Justice", 10),
			new Tag("crazycreative", "Crazy Creative", 11),
			new Tag("digitaldynamo", "Digital Dynamo", 12),
			new Tag("productfanatic", "Product Fanatic", 13),
			new Tag("emailextrodinaire", "Email Extrodinaire", 14),
			new Tag("socialgenius", "Social Genius", 15),
			new Tag("campaignwizard", "Campaign Wizard", 16),
			new Tag("globalmarketeer", "Global Marketeer", 17)
		};

		public static IEnumerable<Tag> Skills = new[]
		{
			new Tag("problemsolver", "Problem solver", 501),
			new Tag("listener", "Problem solver", 502),
			new Tag("communicator", "Communicator", 503),
			new Tag("strategist", "Strategist", 504),
			new Tag("risktaker", "Risk taker", 505),
			new Tag("descisionmaker", "Decision maker", 506),
			new Tag("collaborator", "Collaborator", 507),
			new Tag("planner", "Planner", 508),
			new Tag("organiser", "Organiser", 509),
			new Tag("planner", "Planner", 510),
			new Tag("briefmaker", "Brief maker", 511),
			new Tag("officesuplier", "officesupplier", 512),
			new Tag("creativeproblemsolver", "Creative problem solver", 513),
			new Tag("helper", "Helper", 513),
			new Tag("inspirer", "Inspirer", 514),
			new Tag("synergiser", "Synergiser", 515),
			new Tag("visionary", "Visionary", 516),
			new Tag("prioritiser", "Prioritiser", 517),
			new Tag("cheerleader", "Cheerleader", 518),
			new Tag("customerdelighter", "Customer Delighter", 519),
			new Tag("realist", "Realist", 520),
			new Tag("entrepreneural", "Entrepreneural", 521),
			new Tag("futurist", "Futurist", 522),
			new Tag("technologist", "Technologist", 523),
			new Tag("technologist", "Technologist", 524),
			new Tag("explainer", "Explainer", 525),
			new Tag("teacher", "Teacher", 526)
		};
	}
}.