using OsuSharp.Enums;
using OsuSharp.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp;

public partial class OsuApiClient
{
  /// <summary>
  /// Returns the users on the specified page of the kudosu ranking, sorted by kudosu.
  /// <br/><br/>
  /// API notes:<br/>
  /// Includes <see cref="User.Kudosu"/>.<br/>
  /// One page equals to 50 entries.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-kudosu-ranking"/>
  /// </summary>
  /// <param name="page">Optional. The page.</param>
  /// <returns>The users on the specified page of the kudosu ranking.</returns>
  public async Task<User[]?> GetKudosuRankingAsync(int? page = null)
  {
    return await GetFromJsonAsync<User[]>($"rankings/kudosu", new Dictionary<string, object?>()
    {
      { "page", page }
    }, x => x["ranking"]);
  }

  /// <summary>
  /// Returns the user ranking by performance (PP) or score, optionally filtered by country.
  /// </summary>
  /// <param name="page">Optional. The page.</param>
  /// <param name="type">The type of ranking. Defaults to <see cref="RankingType.Performance"/> ranking.</param>
  /// <param name="ruleset">The ruleset for the ranking. Defaults to osu!standard.</param>
  /// <param name="country">Optional. The targetted country. Only available for <see cref="RankingType.Performance"/>.</param>
  /// <param name="spotlight">Optional. The ID for the spotlight, latest by default. Only available for <see cref="RankingType.Charts"/>.</param>
  /// <param name="variant">Optional. The ruleset variant. Only available for <see cref="Ruleset.Mania"/> (<c>4k</c> or <c>7k</c>) with <see cref="RankingType.Performance"/>.</param>
  /// <returns>The user statistics of the requested ranking.</returns>
  public async Task<UserStatistics[]?> GetPlayerRankingAsync(int? page = null, RankingType type = RankingType.Performance, Ruleset ruleset = Ruleset.Osu,
                                                            string? country = null, string? spotlight = null, string? variant = null)
  {
    return await GetFromJsonAsync<UserStatistics[]>($"rankings/{ruleset}/{type}".ToLower(), new Dictionary<string, object?>()
    {
      { "country", country },
      { "spotlight", spotlight },
      { "variant", variant },
      { "cursor[page]", page }
    }, x => x["ranking"]);
  }
}
