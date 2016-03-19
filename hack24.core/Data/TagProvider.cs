using System.Collections.Generic;
using hack24.core.Model;

namespace hack24.core.Data
{
	public class TagProvider
	{
		public IEnumerable<Tag> Locations = new[]
		{
			new Tag("unitedkingdom", "United Kingdom"),
			new Tag("austrailia", "Austrailia"),
			new Tag("unitedstatesofamerica", "United States of America"),
			new Tag("nottingham", "Nottingham"),
			new Tag("newyork", "New York"),
			new Tag("sydney", "Sydney")
		};

		public IEnumerable<Tag> PersonTypes = new[]
		{
			new Tag("softwaregeek", "Software Geek"),
			new Tag("computerguru", "Computer Guru"),
			new Tag("talentsourcerer", "Talent Sourcerer"),
			new Tag("numbercruncher", "Number Cruncher"),
			new Tag("productfanatic", "Product Fanatic"),
			new Tag("crazycreative", "Crazy Creative"),
			new Tag("warriorofjustice", "Warrior Of Justice")
		};

		public IEnumerable<Tag> Skills = new[]
		{
			new Tag("problemsolver", "Problem solver"),
			new Tag("listener", "Problem solver"),
			new Tag("communicator", "Problem solver"),
			new Tag("strategist", "Strategist"),
			new Tag("risktaker", "Risk taker"),
			new Tag("descisionmaker", "Decision maker"),
			new Tag("collaborator", "Collaborator"),
			new Tag("planner", "Planner"),
			new Tag("organiser", "Organiser"),
			new Tag("planner", "Planner"),
			new Tag("briefmaker", "Brief maker"),
			new Tag("officesuplier", "officesupplier"),
			new Tag("creativeproblemsolver", "Creative problem solver")
		};
	}
}

/*
Problem solver
Listener 
Communicator
Strategist
Risk taker
Decision maker
Collaborator
Planner
Organiser
Office supplier
Creative problem solver
Brief maker

Anybody

Talent maker
Wage guru
Team guru


Partner connector
Money maker
Number cruncher
Justice advisor


Crazy creative
Digital dooer
Product fanatic
	*/