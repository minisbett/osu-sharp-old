using OsuSharp.Enums;
using OsuSharp.Models.Beatmaps;
using OsuSharp.Models.Events;
using OsuSharp.Models.Scores;
using OsuSharp.Models.Users;
using System.ComponentModel;
using System.Reflection;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#users

  /// <summary>
  /// Returns the kudosu history of the user with the specified ID. If the user was not found, null is returned.
  /// <br/><br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-kudosu"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="limit">Optional. The amount of history entries to return.</param>
  /// <param name="offset">Optional. The offset in the history to return at.</param>
  /// <returns>The kudosu history entries or null, if the user was not found.</returns>
  public async Task<KudosuHistoryEntry[]?> GetKudosuHistoryAsync(int userId, int? limit = null, int? offset = null)
  {
    return (await GetFromJsonAsync<KudosuHistoryEntry[]>($"users/{userId}/kudosu", new Dictionary<string, object?>
    {
      { "limit", limit },
      { "offset", offset }
    }))!;
  }

  /// <summary>
  /// Returns the user's scores with the specified type, optionally excluding Lazer scores or fails, and in the specified ruleset.
  /// If the user was not found, null is returned.
  /// <br/><br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-scores"/>
  /// </summary>
  /// <param name="userId">The user ID.</param>
  /// <param name="type">The type of scores to return.</param>
  /// <param name="legacyOnly">Optional. Bool whether only legacy scores (no lazer) will be returned. Defaults to false.</param>
  /// <param name="includeFails">Optional. Bool whether fails should be included. Defaults to false.</param>
  /// <param name="ruleset">Optional. The ruleset in which the scores are returned. Defaults to the users' preferred ruleset.</param>
  /// <param name="limit">Optional. The amount of results to return.</param>
  /// <param name="offset">Optional. The offset for the scores to return.</param>
  /// <returns>The scores of the specified type or null, if the user was not found.</returns>
  public async Task<Score[]?> GetUserScoresAsync(int userId, UserScoreType type, bool legacyOnly = false, bool includeFails = false,
                                                 Ruleset? ruleset = null, int? limit = null, int? offset = null)
  {
    string typeStr = typeof(UserScoreType).GetField(type.ToString())!.GetCustomAttribute<DescriptionAttribute>()!.Description;
    return await GetFromJsonAsync<Score[]>($"users/{userId}/scores/{typeStr}/", new Dictionary<string, object?>
    {
      { "legacy_only", legacyOnly },
      { "include_fails", includeFails },
      { "mode", ruleset },
      { "limit", limit },
      { "offset", offset }
    });
  }

  /// <summary>
  /// Returns the most played beatmaps of the specified user. If the user was not found, null is returned.
  /// <br/><br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-beatmaps"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="limit">Optional. The amount of beatmaps to limit to.</param>
  /// <param name="offset">Optional. The offset for the beatmaps returned.</param>
  /// <returns>The most played beatmaps of the user or null, if the user was not found.</returns>
  public async Task<BeatmapPlaycount[]?> GetUserMostPlayedAsync(int userId, int? limit = null, int? offset = null)
  {
    string typeStr = typeof(BeatmapType).GetField(nameof(BeatmapType.MostPlayed))!.GetCustomAttribute<DescriptionAttribute>()!.Description;
    return await GetFromJsonAsync<BeatmapPlaycount[]>($"users/{userId}/beatmapsets/{typeStr}", new Dictionary<string, object?>
    {
      { "limit", limit },
      { "offset", offset }
    });
  }

  /// <summary>
  /// Returns all beatmaps of the specified user with the specified type. If the user was not found, null is returned.
  /// <br/><br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-beatmaps"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="limit"> Optional. The amount of beatmaps to limit to.</param>
  /// <param name="offset">Optional. The offset for the beatmaps returned.</param>
  /// <returns>The most played beatmaps of the user or null, if the user was not found.</returns>
  public async Task<BeatmapSetExtended[]?> GetUserBeatmapsAsync(int userId, BeatmapType type, int? limit = null, int? offset = null)
  {
    if (type == BeatmapType.MostPlayed)
      throw new ArgumentException("Please use GetUserMostPlayedAsync(), as the response type differs.", nameof(type));

    string typeStr = typeof(BeatmapType).GetField(type.ToString())!.GetCustomAttribute<DescriptionAttribute>()!.Description;
    return await GetFromJsonAsync<BeatmapSetExtended[]>($"users/{userId}/beatmapsets/{typeStr}", new Dictionary<string, object?>
    {
      { "limit", limit },
      { "offset", offset }
    });
  }

  /// <summary>
  /// Returns the recent events of the specified user. If the user was not found, null is returned.
  /// <br/><br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user-recent-activity"/>
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="limit"> Optional. The amount of events to limit to.</param>
  /// <param name="offset">Optional. The offset for the events returned.</param>
  /// <returns>The recent events of the user or null, if the user was not found.</returns>
  public async Task<Event[]?> GetRecentActivityAsync(int userId, int? limit = null, int? offset = null)
  {
    return await GetFromJsonAsync<Event[]>($"users/{userId}/recent_activity", new Dictionary<string, object?>
    {
      { "limit", limit },
      { "offset", offset }
    });
  }

  /// <summary>
  /// Returns the user with the specified ID, optionally in the specified ruleset.<br/>
  /// If no ruleset is specified, the user is returned in their default ruleset. If the user was not found, null is returned.
  /// <br/><br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user"/>
  /// </summary>
  /// <param name="userId">The user ID.</param>
  /// <param name="ruleset">Optional. The ruleset in which the user is returned.</param>
  /// <returns>The user with the specified ID or null, if the user was not found.</returns>
  public async Task<User?> GetUserAsync(int userId, Ruleset? ruleset = null) => await GetUserInternalAsync(userId.ToString(), ruleset);

  /// <summary>
  /// Returns the user with the specified name, optionally in the specified ruleset.<br/>
  /// If no ruleset is specified, the user is returned in their default ruleset. If the user was not found, null is returned.
  /// <br/><br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user"/>
  /// </summary>
  /// <param name="username">The user name.</param>
  /// <param name="ruleset">Optional. The ruleset in which the user is returned.</param>
  /// <returns>The user with the specified name or null, if the user was not found.</returns>
  public async Task<User?> GetUserAsync(string username, Ruleset? ruleset = null) => await GetUserInternalAsync($"@{username}", ruleset);

  /// <summary>
  /// Returns the user with the specified identifier, optionally in the specified ruleset.<br/>
  /// If no ruleset is specified, the user is returned in their default ruleset. If the user was not found, null is returned.
  /// <br/><br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-user"/>
  /// </summary>
  /// <param name="userIdentifier">The user identifier (ID or '@'-prefixed username).</param>
  /// <param name="ruleset">Optional. The ruleset in which the user is returned.</param>
  /// <returns>The user with the specified identifier or null, if the user was not found.</returns>
  private async Task<User?> GetUserInternalAsync(string userIdentifier, Ruleset? ruleset)
  {
    string rulesetStr = ruleset is null ? "" : typeof(Ruleset).GetField(ruleset.ToString()!)!.GetCustomAttribute<DescriptionAttribute>()!.Description;

    return await GetFromJsonAsync<User>($"users/{userIdentifier}/{rulesetStr}");
  }

  /// <summary>
  /// Returns all users with the specified IDs, optionally including the <c>statistics_rulesets.variants</c> attribute.<br/>
  /// Non-existent user IDs are ignored and not included in the response.
  /// <br/><br/>
  /// API notes:<br/>
  /// Up to 50 users can be requested at once.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-users"/>
  /// </summary>
  /// <param name="ids">The user IDs.</param>
  /// <param name="includeVariantStatistics">Optional. Bool whether the <c>statistics_rulesets.variants</c> attribute is included.</param>
  /// <returns>The users with the specified IDs.</returns>
  public async Task<User[]> GetUsersAsync(int[] ids, bool includeVariantStatistics = false)
  {
    if (ids.Length > 50)
      throw new ArgumentOutOfRangeException(nameof(ids), "The API only supporst 50 users to be requested at once.");

    // Build the query parameters with an entry for each specified id. TODO: Actually add statistics_rulesets to the model
    Dictionary<string, object?> parameters = new() { { "include_variant_statistics", includeVariantStatistics } };
    foreach (int id in ids)
      parameters.Add($"ids[]", id);

    return (await GetFromJsonAsync<User[]>($"users", parameters, x => x["users"]))!;
  }
}
