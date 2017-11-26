using Newtonsoft.Json;

namespace Aegis.JsonModels.Google
{
  public class Imageobject
  {
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("width")]
    public string Width { get; set; }

    [JsonProperty("height")]
    public string Height { get; set; }
  }
}
