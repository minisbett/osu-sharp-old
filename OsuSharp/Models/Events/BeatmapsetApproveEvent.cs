using Newtonsoft.Json;
using OsuSharp.Converters;
using OsuSharp.Enums;

namespace OsuSharp.Models.Events;

/// <summary>
/// Represents an event when a beatmapset changes state (ranked, approved, qualified, loved).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class BeatmapsetApproveEvent : Event
{
  /// <summary>
  /// The approval state of the beatmapset.
  /// </summary>
  [JsonProperty("approval")]
  public BeatmapsetEventApproval Approval { get; private set; } = default!;

  /// <summary>
  /// The beatmapset associated with this event.
  /// </summary>
  [JsonProperty("beatmapset")]
  public EventBeatmapset Beatmapset { get; private set; } = default!;

  /// <summary>
  /// The user who is the owner of this beatmapset.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; private set; } = default!;
}
