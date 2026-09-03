using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KdtSdk.Utils
{
    /// <summary>
    /// Supports APIs that may return either a single object or an array for the same field.
    /// </summary>
    public class SingleOrArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<T>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            JToken token = JToken.Load(reader);

            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<List<T>>(serializer);
            }

            T instance = token.ToObject<T>(serializer);
            return new List<T> { instance };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}

