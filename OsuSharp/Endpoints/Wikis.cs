using OsuSharp.Models.Wikis;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#wiki

  /// <summary>
  /// Returns the wikipage at the specified path in the specified locale.
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-wiki-page"/>
  /// </summary>
  /// <param name="locale">The BCP 47 language tag of the wiki page.</param>
  /// <param name="path">The path of the wiki page.</param>
  /// <returns>The wiki page or null, if the wiki page was not found.</returns>
  public async Task<WikiPage?> GetWikiPageAsync(string locale, string path)
  {
    return await GetFromJsonAsync<WikiPage>($"wiki/{locale}/{path}");
  }
}
