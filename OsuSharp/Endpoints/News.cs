using Newtonsoft.Json;
using OsuSharp.Models.News;

namespace OsuSharp;

public partial class OsuApiClient
{
  // API docs: https://osu.ppy.sh/docs/index.html#news

  /// <summary>
  /// Returns an asynchronous enumerable for all news posts, allowing to lazily enumerate through all news posts,
  /// performing further pagination requests as necessary.<br/>
  /// <br/><br/>
  /// API notes:<br/>
  /// This endpoint does not provide support for targetting a specific page directly per API design.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-news"/>
  /// </summary>
  /// <returns>An asynchronous enumerable for lazily enumerating over the news posts.</returns>
  public async IAsyncEnumerable<NewsPost> GetNewsPostsAsync()
  {
    // Always remember the cursor for the next request.
    string? cursor = null;

    // Keep requesting until there are no more pages, and yield return the news posts to asynchronously enumerate over them.
    do
    {
      // Send the request and parse it into a dynamic object to extract the data and cursor.
      dynamic? obj = await GetFromJsonAsync<dynamic>("news", new Dictionary<string, object?>()
      {
        { "cursor_string", cursor }
      });

      // Update the cursor for the next request and yield return the news posts.
      cursor = obj!.cursor_string.Value;
      foreach(NewsPost post in JsonConvert.DeserializeObject<NewsPost[]>(obj!.news_posts.ToString(), _jsonSettings))
        yield return post;
    }
    while (cursor is not null);
  }

  /// <summary>
  /// Gets the news post with the specified slug. If the news post was not found, null is returned.<br/>
  /// The slug is a unique identifier for the news post, which is a part of the URL of the news post. (eg. <c>2021-04-27-results-a-labour-of-love</c>)<br/>
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-news-post"/>
  /// </summary>
  /// <returns>The news post with the specified slug or null, if the news post was not found.</returns>
  public async Task<NewsPost?> GetNewsPostAsync(string slug)
  {
    // Send the request and return the news post object.
    return await GetFromJsonAsync<NewsPost>($"news/{slug}");
  }

  /// <summary>
  /// Gets the news post with the specified ID. If the news post was not found, null is returned.<br/>
  /// <br/><br/>
  /// API notes:<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-news-post"/>
  /// </summary>
  /// <returns>The news post with the specified ID or null, if the news post was not found.</returns>
  public async Task<NewsPost?> GetNewsPostAsync(int id) => await GetNewsPostAsync($"{id}");
}
