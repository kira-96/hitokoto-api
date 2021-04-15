using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hitokoto
{
    public class UnixDateTimeConverter : JsonConverter<DateTime>
    {
        internal static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(DateTime) || typeToConvert == typeof(DateTime?);
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            long seconds;

            if (reader.TokenType == JsonTokenType.Number)
            {
                seconds = reader.GetInt64();
            }
            else if (reader.TokenType == JsonTokenType.String)
            {
                if (!long.TryParse(reader.GetString(), out seconds))
                {
                    throw new JsonException($"Cannot convert invalid value to {typeToConvert}.");
                }
            }
            else
            {
                throw new JsonException($"Unexpected token parsing date. Expected Integer or String, got {reader.TokenType}.");
            }

            if (seconds >= 0)
            {
                return UnixEpoch.AddSeconds(seconds);
            }
            else
            {
                throw new JsonException($"Cannot convert value that is before Unix epoch of 00:00:00 UTC on 1 January 1970 to {typeToConvert}.");
            }
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            long seconds = (long)(value.ToUniversalTime() - UnixEpoch).TotalSeconds;

            if (seconds < 0)
            {
                throw new JsonException($"Cannot convert date value that is before Unix epoch of 00:00:00 UTC on 1 January 1970.");
            }

            writer.WriteNumberValue(seconds);
        }
    }
}
