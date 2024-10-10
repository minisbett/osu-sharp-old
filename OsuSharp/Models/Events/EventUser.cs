using Newtonsoft.Json;

namespace OsuSharp.Models.Events;

/// <summary>
/// Represents a user associated with an event.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-user"/><br/>
/// Source: <a href=""/>
/// </summary>
public class EventUser
{
  /// <summary>
  /// The username of the user.
  /// </summary>
  [JsonProperty("username")]
  public string Username { get; private set; } = default!;

  /// <summary>
  /// The URL of the user's profile.
  /// </summary>
  [JsonProperty("url")]
  public string Url { get; private set; } = default!;

  /// <summary>
  /// The previous username of the user. This will be null if the related event is not a username change event.
  /// </summary>
  [JsonProperty("previousUsername")]
  public string? PreviousUsername { get; private set; }
}
