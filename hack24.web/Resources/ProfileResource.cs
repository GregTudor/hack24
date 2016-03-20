using System;
using System.Collections.Generic;
using hack24.core.Model;

namespace hack24.web.Resources
{
	public class ProfileResource
	{ 
		public ProfileModel Primary { get; set; }
		public IEnumerable<ProfileModel> Alternatives { get; set; }
		public ProfileModel HolidayApprover { get; set; }
		public ProfileModel LineManager { get; set; }
		public ProfileModel PayManager { get; set; }

		public ProfileResource()
		{
			this.Alternatives = new ProfileModel[0];
		}
	}
}