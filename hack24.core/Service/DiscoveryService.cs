using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using hack24.core.Data;
using hack24.core.Model;

namespace hack24.core.Service
{
	public class DiscoveryService
	{
		public DiscoveryService()
		{
			
		}

		public IEnumerable<ProfileModel> GetMatches(int[] tagids)
		{
			var dict = new Dictionary< ProfileModel, int>();
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

				return t.Take(4).Select(x=>x.Key);



			}
		}
	}
}
