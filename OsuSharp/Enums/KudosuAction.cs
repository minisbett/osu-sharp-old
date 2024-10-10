using System.ComponentModel;

namespace OsuSharp.Enums;

/// <summary>
/// Represents the type of actions that result in a <see cref="Models.Users.KudosuHistoryEntry"/>.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#kudosuhistory"/><br/>
/// Source: <a href="https://github.com/ppy/osu-web/blob/master/app/Transformers/KudosuHistoryTransformer.php"/>
/// </summary>
public enum KudosuAction
{
  /// <summary>
  /// TODO: what does this mean?
  /// </summary>
  [Description("give")]
  Give,

  /// <summary>
  /// TODO: what does this mean?
  /// </summary>
  [Description("vote.give")]
  VoteGive,

  /// <summary>
  /// TODO: what does this mean?
  /// </summary>
  [Description("reset")]
  Reset,

  /// <summary>
  /// TODO: what does this mean?
  /// </summary>
  [Description("vote.reset")]
  VoteReset,

  /// <summary>
  /// TODO: what does this mean?
  /// </summary>
  [Description("revoke")]
  Revoke,

  /// <summary>
  /// TODO: what does this mean?
  /// </summary>
  [Description("vote.revoke")]
  VoteRevoke
}
