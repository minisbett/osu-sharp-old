using Newtonsoft.Json;
using OsuSharp.Converters;
using OsuSharp.Enums;

namespace OsuSharp.Models.Users;

/// <summary>
/// Represents the kudosu history of a user.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#kudosuhistory"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/KudosuHistoryTransformer.php"/>
/// </summary>
public class KudosuHistoryEntry
{
  /// <summary>
  /// TODO: what is this? The entries have ids?
  /// </summary>
  [JsonProperty("id")]
  public int Id { get; private set; }

  /// <summary>
  /// The action that resulted in this kudosu entry.
  /// </summary>
  [JsonProperty("action")]
  public KudosuAction Action { get; private set; }

  /// <summary>
  /// The amount of kudosu involved in this entry.
  /// </summary>
  [JsonProperty("amount")]
  public int Amount { get; private set; }

  /// <summary>
  /// The type of object that this kudosu entry origins from.
  /// </summary>
  [JsonProperty("model")]
  public KudosuModel Model { get; private set; }

  /// <summary>
  /// The datetime at which this entry was created.
  /// </summary>
  [JsonProperty("created_at")]
  public DateTimeOffset CreatedAt { get; private set; }

  /// <summary>
  /// The user that caused this kudosu entry. This may be null. (TODO: why? maybe when revoking etc sure but its null when giving?)
  /// </summary>
  [JsonProperty("giver")]
  public KudosuGiver? Giver { get; private set; }

  /// <summary>
  /// The object that this kudosu entry origins from.
  /// </summary>
  [JsonProperty("post")]
  public KudosuPost Post { get; private set; } = default!;
}
