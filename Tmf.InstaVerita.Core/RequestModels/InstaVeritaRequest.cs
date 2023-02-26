using System.Text.Json.Serialization;

namespace Tmf.InstaVerita.Core.RequestModels;

public class InstaVeritaRequest
{
    [JsonPropertyName("rc_number")]
    public string RcNumber { get; set; } = string.Empty;
}
