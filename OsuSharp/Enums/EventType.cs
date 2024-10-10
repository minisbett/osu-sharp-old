using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// Represents the type of an event. This can be related to recent user activity, general osu! events, beatmap set related events, etc.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// <br/><br/>
/// </summary>
public enum EventType
{
  /// <summary>
  /// Represents an event when a user obtained an achievement.
  /// </summary>
  [Description("achievement")]
  Achievement,

  /// <summary>
  /// Represents an event when a beatmap has been played a certain number of times.
  /// </summary>
  [Description("beatmapPlaycount")]
  BeatmapPlaycount,

  /// <summary>
  /// Represents an event when a beatmap changes state (ranked, approved, qualified, loved).
  /// </summary>
  [Description("beatmapsetApprove")]
  BeatmapsetApprove,

  /// <summary>
  /// Represents an event when a beatmapset is deleted.
  /// </summary>
  [Description("beatmapsetDelete")]
  BeatmapsetDelete,

  /// <summary>
  /// Represents an event when a beatmapset in graveyard state is updated.
  /// </summary>
  [Description("beatmapsetRevive")]
  BeatmapsetRevive,

  /// <summary>
  /// Represents an event when a beatmapset is updated.
  /// </summary>
  [Description("beatmapsetUpdate")]
  BeatmapsetUpdate,

  /// <summary>
  /// Represents an event when a new beatmapset is uploaded.
  /// </summary>
  [Description("beatmapsetUpload")]
  BeatmapsetUpload,

  /// <summary>
  /// Represents an event when a user achieves a certain rank on a beatmap.
  /// </summary>
  [Description("rank")]
  Rank,

  /// <summary>
  /// Represents an event when a user loses first place to another user.
  /// </summary>
  [Description("rankLost")]
  RankLost,

  /// <summary>
  /// Represents an event when a user supports osu! for the second time and onwards.
  /// </summary>
  [Description("userSupportAgain")]
  UserSupportAgain,

  /// <summary>
  /// Represents an event when a user supports osu! for the first time.
  /// </summary>
  [Description("userSupportFirst")]
  UserSupportFirst,

  /// <summary>
  /// Represents an event when a user is gifted a supporter tag by another user.
  /// </summary>
  [Description("userSupportGift")]
  UserSupportGift,

  /// <summary>
  /// Represents an event when a user changes their username.
  /// </summary>
  [Description("usernameChange")]
  UsernameChange
}
