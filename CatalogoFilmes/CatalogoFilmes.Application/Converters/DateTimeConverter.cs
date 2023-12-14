using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Globalization;
using System.Reflection.PortableExecutable;

namespace CatalogoFilmes.Application.Converters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dataNormal = reader.GetString();

            return DateTime.ParseExact(dataNormal,"dd-MM-yyyy",CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("dd/MM/yyyy"));
        }
    }
}
