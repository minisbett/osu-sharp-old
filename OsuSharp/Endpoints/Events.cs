using Newtonsoft.Json;
using OsuSharp.Enums;
using OsuSharp.Models.Events;

namespace OsuSharp;

public partial class OsuApiClient
{
  /// <summary>
  /// Returns an asynchronous enumerable for all events across osu! in the last 30 days, optionally with the specified sorting,
  /// allowing to lazily enumerate through all beatmap packs, performing further pagination requests as necessary.<br/>
  /// <br/><br/>
  /// API docs:<br/>
  /// This endpoint does not provide support for targetting a specific page directly per API design.<br/>
  /// <a href="https://osu.ppy.sh/docs/index.html#get-events"/>
  /// </summary>
  /// <param name="sort">The sorting for the events. Default to newest first.</param>
  /// <returns>An asynchronous enumerable for lazily enumerating over the events.</returns>
  public async IAsyncEnumerable<Event> GetEventsAsync(PostSort sort = PostSort.IDDescending)
  {
    // Always remember the cursor for the next request.
    string? cursor = null;

    // Keep requesting until there are no more pages, and yield return the events to asynchronously enumerate over them.
    do
    {
      // Send the request and parse it into a dynamic object to extract the data and cursor.
      dynamic? obj = await GetFromJsonAsync<dynamic>("events", new Dictionary<string, object?>() 
      {
        { "sort", sort },
        { "cursor_string", cursor }
      });

      // Update the cursor for the next request and yield return the events.
      cursor = obj!.cursor_string.Value;
      foreach (Event @event in JsonConvert.DeserializeObject<Event[]>(obj!.events.ToString(), _jsonSettings))
        yield return @event;
    }
    while (cursor is not null);
  }
}
