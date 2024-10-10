using Newtonsoft.Json;

namespace OsuSharp.Models.Events;

/// <summary>
/// Represents an event when a user changes their username.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public class UsernameChangeEvent : Event
{
  /// <summary>
  /// The user who changed their username.
  /// </summary>
  [JsonProperty("user")]
  public EventUser User { get; private set; } = default!;
}
