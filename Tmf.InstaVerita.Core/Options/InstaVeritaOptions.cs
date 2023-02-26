namespace Tmf.InstaVerita.Core.Options;

public class InstaVeritaOptions
{
    public const string InstaVerita = "InstaVerita";
    public string ApiTokenType { get; set; } = string.Empty;
    public string ApiTokenKey { get; set; } = string.Empty;
    public string SecretKeyType { get; set; } = string.Empty;
    public string ApiSecretKey { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
