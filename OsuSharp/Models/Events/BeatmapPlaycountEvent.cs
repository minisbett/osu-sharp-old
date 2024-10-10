using Newtonsoft.Json;

namespace OsuSharp.Models.Events;

/// <summary>
/// Represents an event when a beatmap has been played a certain number of times.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class BeatmapPlaycountEvent : Event
{
  /// <summary>
  /// The beatmap associated with the event.
  /// </summary>
  [JsonProperty("beatmap")]
  public EventBeatmap Beatmap { get; private set; } = default!;

  /// <summary>
  /// The count of times the beatmap has been played.
  /// </summary>
  [JsonProperty("count")]
  public int Count { get; private set; }
}
