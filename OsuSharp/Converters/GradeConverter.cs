using Newtonsoft.Json;
using OsuSharp.Enums;

namespace OsuSharp.Converters;

/// <summary>
/// A <see cref="JsonConverter"/> to convert strings to a <see cref="Grade"/> and vice versa.
/// </summary>
internal class GradeConverter : JsonConverter
{
  public override bool CanWrite => false;

  public override bool CanConvert(Type objectType) => objectType == typeof(Grade);

  public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    // If the value is a string and not null, parse it as a grade and return it.
    if (reader.TokenType == JsonToken.String && reader.Value is not null)
      return reader.Value.ToString() switch
      {
        "XH" or "SSH" => Grade.XH,
        "SH" => Grade.SH,
        "X" or "SS" => Grade.X,
        "S" => Grade.S,
        "A" => Grade.A,
        "B" => Grade.B,
        "C" => Grade.C,
        "D" => Grade.D,
        _ => throw new JsonSerializationException($"Unable to convert '{reader.Value}' into a grade."),
      };

    // If the value is not valid, throw an exception.
    throw new JsonSerializationException($"Unable to convert '{reader.Value}' ({reader.TokenType}) into a grade.");
  }

  public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
  {
    throw new NotImplementedException();
  }
}