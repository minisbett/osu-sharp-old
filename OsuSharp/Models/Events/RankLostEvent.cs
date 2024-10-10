using Newtonsoft.Json;
using OsuSharp.Converters;
using OsuSharp.Enums;

namespace OsuSharp.Models.Events;

/// <summary>
/// Represents an event when a user loses first place to another user.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class RankLostEvent : Event
{
  /// <summary>
  /// The ruleset this event takes place in.
  /// </summary>
  [JsonProperty("mode")]
  public Ruleset Mode { get; private set; } = default!;

  /// <summary>
  /// The beatmap associated with the event.
  /// </summary>
  [JsonProperty("beatmap")]
  public EventBeatmap Beatmap { get; private set; } = default!;

  /// <summary>
  /// The user who lost the rank.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; private set; } = default!;
}
