using System.Text.Json.Serialization;

namespace WebApiBase.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TurnoEnum
{
    Manha,
    Tarde,
    Noite
}
