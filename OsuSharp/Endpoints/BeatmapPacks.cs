using Newtonsoft.Json;
using OsuSharp.Enums;
using OsuSharp.Models.Beatmaps;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#beatmap-packs

  /// <summary>
  /// Returns an asynchronous enumerable for all beatmap packs with the specified type, allowing to lazily
  /// enumerate through all beatmap packs, performing further pagination requests as necessary.<br/>
  /// <br/><br/>
  /// API notes:<br/>
  /// This endpoint does not provide support for targetting a specific page directly per API design.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap-packs"/>
  /// </summary>
  /// <returns>An asynchronous enumerable for lazily enumerating over the beatmap packs.</returns>
  public async IAsyncEnumerable<BeatmapPack> GetBeatmapPacksAsync(BeatmapPackType type = BeatmapPackType.Standard)
  {
    // Always remember the cursor for the next request.
    string? cursor = null;

    // Keep requesting until there are no more pages, and yield return the beatmap packs to asynchronously enumerate over them.
    do
    {
      // Send the request and parse it into a dynamic object to extract the data and cursor.
      dynamic? obj = await GetFromJsonAsync<dynamic>("beatmaps/packs", new Dictionary<string, object?>()
      {
        { "type", type },
        { "cursor_string", cursor }
      });

      // Update the cursor for the next request and yield return the beatmap packs.
      cursor = obj!.cursor_string.Value;
      foreach (BeatmapPack pack in JsonConvert.DeserializeObject<BeatmapPack[]>(obj!.beatmap_packs.ToString(), _jsonSettings))
        yield return pack;
    }
    while (cursor is not null);
  }

  /// <summary>
  /// Gets the beatmap pack with the specified tag. If the beatmap pack was not found, null is returned.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-beatmap-pack"/>
  /// </summary>
  /// <returns>The beatmap pack with the specified tag or null, if the beatmap pack was not found.</returns>
  public async Task<BeatmapPack?> GetBeatmapPackAsync(string tag)
  {
    // Send the request and return the beatmap pack object.
    return await GetFromJsonAsync<BeatmapPack>($"beatmaps/packs/{tag}");
  }
}