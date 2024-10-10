using Newtonsoft.Json;

namespace OsuSharp.Models.Users;

/// <summary>
/// Represents the origin of a <see cref="KudosuHistoryEntry"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#kudosuhistory"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/KudosuHistoryTransformer.php"/>
/// </summary>
public class KudosuPost
{
  /// <summary>
  /// The URL of the object that originated the kudosu history entry. This will be null if the beatmap got deleted.
  /// </summary>
  [JsonProperty("url")]
  public string? Url { get; private set; }

  /// <summary>
  /// The title of the object that originated the kudosu history entry. This will be <c>[deleted beatmap]</c> if the beatmap got deleted.
  /// </summary>
  [JsonProperty("title")]
  public string Title { get; private set; } = default!;
}
