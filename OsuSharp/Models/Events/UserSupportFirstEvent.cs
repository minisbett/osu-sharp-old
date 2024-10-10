using Newtonsoft.Json;

namespace OsuSharp.Models.Events;

/// <summary>
/// Represents an event when a user becomes a supporter for the first time.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class UserSupportFirstEvent : Event
{
  /// <summary>
  /// The user who supported osu! for the first time.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; private set; } = default!;
}
