using Newtonsoft.Json;

namespace FinanceNewsTicker.Services.Models
{

    public class FinanceNews
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("data")]
        public List<NewsArticle> News { get; set; }
    }
}
