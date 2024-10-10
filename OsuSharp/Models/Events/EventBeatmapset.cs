using Newtonsoft.Json;

namespace OsuSharp.Models.Events;

/// <summary>
/// Represents a beatmapset associated with an event.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-beatmapset"/><br/>
/// Source: <a href=""/>
/// </summary>
public class EventBeatmapset
{
  /// <summary>
  /// The title of the beatmapset.
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; private set; } = default!;

  /// <summary>
  /// The URL of the beatmapset.
  /// </summary>
  [JsonProperty("url")]
  public string Url { get; private set; } = default!;
}
