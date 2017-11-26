using Newtonsoft.Json;

namespace Aegis.JsonModels.Google
{
  public class Musicrecording
  {
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("duration")]
    public string Duration { get; set; }
  }
}
