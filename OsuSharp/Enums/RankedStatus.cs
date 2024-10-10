using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the rank statuses a beatmap can have.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#beatmapset-rank-status"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/beatmapset-json.ts"/>
/// </summary>
public enum RankedStatus
{
  /// <summary>
  /// The beatmap is in the graveyard.
  /// </summary>
  [Description("graveyard")]
  Graveyard = -2,

  /// <summary>
  /// The beatmap is a work in progress.
  /// </summary>
  [Description("wip")]
  WIP = -1,

  /// <summary>
  /// The beatmap is pending a rank status evaluation.
  /// </summary>
  [Description("pending")]
  Pending = 0,

  /// <summary>
  /// The beatmap is ranked.
  /// </summary>
  [Description("ranked")]
  Ranked = 1,

  /// <summary>
  /// The beatmap is approved.
  /// </summary>
  [Description("approved")]
  Approved = 2,

  /// <summary>
  /// The beatmap is qualified.
  /// </summary>
  [Description("qualified")]
  Qualified = 3,

  /// <summary>
  /// The beatmap is loved.
  /// </summary>
  [Description("loved")]
  Loved = 4
}
