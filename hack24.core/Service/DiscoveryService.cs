using System.Collections.Generic;
using System.Linq;
using hack24.core.Data;
using hack24.core.Model;

namespace hack24.core.Service
{
	public class DiscoveryService
	{
		public IEnumerable<ProfileModel> GetMatches(int[] tagids)
		{
			var dict = new Dictionary<ProfileModel, int>();
			using (var session = MartenStuff.Store.LightweightSession())
			{
				var profiles = session.Query<ProfileModel>().ToArray();

				foreach (var profileModel in profiles)
				{
					var ids = profileModel.Tags.Select(x => x.Id).ToArray();

					var matchCount = ids.Intersect(tagids).Count();

					dict.Add(profileModel, matchCount);
				}

				var t = dict.OrderByDescending(x => x.Value);

				return t.Take(4).Select(x => x.Key);
			}
		}

		public IOrderedEnumerable<KeyValuePair<Tag, int>> TagUsage()
		{
			var list = new List<Tag>();

			using (var session = MartenStuff.Store.LightweightSession())
			{
				var profiles = session.Query<ProfileModel>().ToArray();

				foreach (var profileModel in profiles)
					list.InsertRange(0, profileModel.Tags);

				var d = list.GroupBy(x => x.Id).ToDictionary(x => list.First(y => y.Id == x.Key), x => x.Count());


				return d.OrderByDescending(x=>x.Value);
			}
		}
	}
}