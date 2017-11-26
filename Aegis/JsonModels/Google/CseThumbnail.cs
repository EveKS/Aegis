using Newtonsoft.Json;

namespace Aegis.JsonModels.Google
{
  public class CseThumbnail
  {
    [JsonProperty("width")]
    public string Width { get; set; }

    [JsonProperty("height")]
    public string Height { get; set; }

    [JsonProperty("src")]
    public string Src { get; set; }
  }
}
