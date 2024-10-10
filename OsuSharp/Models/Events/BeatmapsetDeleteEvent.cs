using Newtonsoft.Json;

namespace OsuSharp.Models.Events;

/// <summary>
/// Represents an event when a beatmapset is deleted.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class BeatmapsetDeleteEvent : Event
{
  /// <summary>
  /// The beatmapset that was deleted.
  /// </summary>
  [JsonProperty("beatmapset")]
  public EventBeatmapset Beatmapset { get; private set; } = default!;
}
