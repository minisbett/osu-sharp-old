using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// Represents the beatmap type of beatmaps listed on a user's profile.</br>
/// This includes ranked, pending, guest difficulties, etc., as well as favourited and most played beatmaps.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#get-user-beatmaps"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/UsersController.php"/>
/// </summary>
public enum BeatmapType
{
  /// <summary>
  /// The beatmap is in the favourited beatmaps section of the user.
  /// </summary>
  [Description("favourite")]
  Favourite,

  /// <summary>
  /// The beatmap is in the graveyarded section of the user.
  /// </summary>
  [Description("graveyard")]
  Graveyard,

  /// <summary>
  /// The beatmap is in the guest difficulty section of the user.
  /// </summary>
  [Description("guest")]
  Guest,

  /// <summary>
  /// The beatmap is in the loved beatmaps section of the user.
  /// </summary>
  [Description("loved")]
  Loved,

  /// <summary>
  /// The beatmap is in the most played beatmaps section of the user.
  /// </summary>
  [Description("most_played")]
  MostPlayed,

  /// <summary>
  /// The beatmap is in the nominated beatmap section of the user.
  /// </summary>
  [Description("nominated")]
  Nominated,

  /// <summary>
  /// The beatmap is in the pending beatmaps section of the user.
  /// </summary>
  [Description("pending")]
  Pending,

  /// <summary>
  /// The beatmap is in the ranked beatmaps section of the user.
  /// </summary>
  [Description("ranked")]
  Ranked
}
