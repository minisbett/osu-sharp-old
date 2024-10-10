using Newtonsoft.Json;

namespace OsuSharp.Models.Events;

/// <summary>
/// Represents a beatmap associated with an event.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-beatmap"/><br/>
/// Source: <a href=""/>
/// </summary>
public class EventBeatmap
{
  /// <summary>
  /// The title of the beatmap.
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; private set; } = default!;

  /// <summary>
  /// The URL of the beatmap.
  /// </summary>
  [JsonProperty("url")]
  public string Url { get; private set; } = default!;
}
