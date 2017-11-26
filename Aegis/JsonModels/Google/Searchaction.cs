using Newtonsoft.Json;

namespace Aegis.JsonModels.Google
{
  public class Searchaction
  {
    [JsonProperty("target")]
    public string Target { get; set; }

    [JsonProperty("query-input")]
    public string QueryInput { get; set; }
  }
}
