using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Enums;

/// <summary>
/// An enum containing the types of ranking on the ranking endpoint.
/// <br/><br/>
/// API docs: <a href="https://osu.ppy.sh/docs/index.html#rankingtype"/><br/>
/// Source: <a hef="https://github.com/ppy/osu-web/blob/master/app/Http/Controllers/RankingController.php"/>
/// </summary>
public enum RankingType
{
  /// <summary>
  /// The charts ranking.
  /// </summary>
  [Description("charts")]
  Charts,

  /// <summary>
  /// The country ranking.
  /// </summary>
  [Description("country")]
  Country,

  /// <summary>
  /// The performance (PP) ranking.
  /// </summary>
  [Description("performance")]
  Performance,

  /// <summary>
  /// The score ranking.
  /// </summary>
  [Description("score")]
  Score
}