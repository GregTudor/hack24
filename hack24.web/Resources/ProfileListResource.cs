using System.Linq;
using hack24.core.Model;

namespace hack24.web.Resources
{
	public class ProfileListResource
	{
		public ProfileModel[] Profiles { get; set; }
		public string Tag { get; set; }
	}
}