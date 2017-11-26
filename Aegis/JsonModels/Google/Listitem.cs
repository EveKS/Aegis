using Newtonsoft.Json;

namespace Aegis.JsonModels.Google
{
  public class Listitem
  {
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("position")]
    public string Position { get; set; }
  }
}
