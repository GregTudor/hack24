using System.Collections.Generic;
using hack24.core.Model;

namespace hack24.web.Resources
{
	public sealed class DiscoverIndexResource
	{
		public IEnumerable<Tag> Locations { get; set; }
		public IEnumerable<Tag> PersonTypes { get; set; }
		public IEnumerable<Tag> Skills { get; set; }
	}
}