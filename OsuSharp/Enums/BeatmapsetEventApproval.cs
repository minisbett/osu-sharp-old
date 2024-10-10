using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// Represents the approval state of a <see cref="Models.Events.BeatmapsetApproveEvent"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#event-type"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/resources/js/interfaces/event-json.ts"/>
/// </summary>
public enum BeatmapsetEventApproval
{
  /// <summary>
  /// The beatmapset was ranked.
  /// </summary>
  [Description("ranked")]
  Ranked,

  /// <summary>
  /// The beatmapset was approved.
  /// </summary>
  [Description("approved")]
  Approved,

  /// <summary>
  /// The beatmapset was qualified.
  /// </summary>
  [Description("qualified")]
  Qualified,

  /// <summary>
  /// The beatmapset was loved.
  /// </summary>
  [Description("loved")]
  Loved
}
