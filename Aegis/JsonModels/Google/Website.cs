using Newtonsoft.Json;

namespace Aegis.JsonModels.Google
{
  public class Website
  {
    [JsonProperty("url")]
    public string Url { get; set; }
  }
}
