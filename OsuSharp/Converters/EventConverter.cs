using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OsuSharp.Enums;
using OsuSharp.Models.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OsuSharp.Converters;

internal class EventConverter : JsonConverter
{
  public override bool CanWrite => false;

  public override bool CanConvert(Type objectType) => objectType == typeof(Event);

  public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    JObject obj = JObject.Load(reader);

    // Parse the type of event manually and then deserialize the object based on the type.
    return Enum.GetValues<EventType>().FirstOrDefault(x =>
     typeof(EventType).GetField(x.ToString())?.GetCustomAttribute<DescriptionAttribute>()!.Description == obj["type"]!.Value<string>()!) switch
    {
      EventType.Achievement => obj.ToObject<AchievementEvent>(serializer),
      EventType.BeatmapPlaycount => obj.ToObject<BeatmapPlaycountEvent>(serializer),
      EventType.BeatmapsetApprove => obj.ToObject<BeatmapsetApproveEvent>(serializer),
      EventType.BeatmapsetDelete => obj.ToObject<BeatmapsetDeleteEvent>(serializer),
      EventType.BeatmapsetRevive => obj.ToObject<BeatmapsetReviveEvent>(serializer),
      EventType.BeatmapsetUpdate => obj.ToObject<BeatmapsetUpdateEvent>(serializer),
      EventType.BeatmapsetUpload => obj.ToObject<BeatmapsetUploadEvent>(serializer),
      EventType.Rank => obj.ToObject<RankEvent>(serializer),
      EventType.RankLost => obj.ToObject<RankLostEvent>(serializer),
      EventType.UserSupportAgain => obj.ToObject<UserSupportAgainEvent>(serializer),
      EventType.UserSupportFirst => obj.ToObject<UserSupportFirstEvent>(serializer),
      EventType.UserSupportGift => obj.ToObject<UserSupportGiftEvent>(serializer),
      EventType.UsernameChange => obj.ToObject<UsernameChangeEvent>(serializer),
      _ => throw new NotImplementedException($"Event '{obj["type"]!.Value<string>()!}' is not implemented.")
    };
  }

  public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
  {
    throw new NotImplementedException();
  }
}
