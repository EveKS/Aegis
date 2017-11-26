using Newtonsoft.Json;

namespace Aegis.JsonModels.Google
{
  public class Person
  {
    [JsonProperty("url")]
    public string Url { get; set; }
  }
}
