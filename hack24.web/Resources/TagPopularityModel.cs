using System.Collections.Generic;
using System.Linq;
using hack24.core.Model;

namespace hack24.web.Resources
{
	public sealed class TagPopularityModel
	{
		public IOrderedEnumerable<KeyValuePair<Tag, int>> TagData { get; set; }
	}
}