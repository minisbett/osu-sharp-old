using Newtonsoft.Json;
using OsuSharp.Enums;

namespace OsuSharp.Models.Events;

/// <summary>
/// Represents the base class for any event (user events, beatmap events, ...).
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event"/><br/>
/// Source: <a href=""/>
/// </summary>
public class Event
{
  /// <summary>
  /// The datetime at which this event happened.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTime CreatedAt { get; private set; }

  /// <summary>
  /// The ID of this event.
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The type of this event.
  /// </summary>
  [JsonProperty("type")]
  public EventType Type { get; private set; }
}
