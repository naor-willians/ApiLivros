using System.Text.Json.Serialization;

namespace ApiLivros.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AvaliacaoEnum
    {
        Excelente,
        Bom,
        Ruim
    }
}
