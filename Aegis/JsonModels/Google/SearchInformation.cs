using Newtonsoft.Json;

namespace Aegis.JsonModels.Google
{
  public class SearchInformation
  {
    [JsonProperty("searchTime")]
    public double SearchTime { get; set; }

    [JsonProperty("formattedSearchTime")]
    public string FormattedSearchTime { get; set; }

    [JsonProperty("totalResults")]
    public string TotalResults { get; set; }

    [JsonProperty("formattedTotalResults")]
    public string FormattedTotalResults { get; set; }
  }
}
