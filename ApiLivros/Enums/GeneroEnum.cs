using System.Text.Json.Serialization;

namespace ApiLivros.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GeneroEnum
    {
        Fantasia,
        Romance,
        Terror,
        Drama,
        Suspense
    }
}
