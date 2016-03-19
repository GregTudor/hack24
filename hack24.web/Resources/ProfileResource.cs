using System;
using System.Collections.Generic;
using hack24.core.Model;

namespace hack24.web.Resources
{
	public class ProfileResource
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string ProfileImage { get; set; }
		public string JobTitle { get; set; }
		public string Bio { get; set; }

		public IEnumerable<Tag> Tags { get; set; }
		public IEnumerable<Tag> LocationTags { get; set; }
	}
}