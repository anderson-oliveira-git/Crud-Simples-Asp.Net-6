using System.Text.Json.Serialization;

namespace WebApiBase.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DepartamentoEnum
{
    RH,
    Financeiro,
    Compras,
    Atendimento,
    Zeladoria
}
