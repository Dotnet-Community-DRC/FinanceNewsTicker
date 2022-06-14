using FinanceNewsTicker.Services.Models;
using Newtonsoft.Json;

namespace FinanceNewsTicker.Services
{
    public interface INewsService
    {
        FinanceNews GetFinanceNews(int offset);
    }

    public class NewsService : INewsService
    {
        private readonly IConfiguration _configuration;
        public NewsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public FinanceNews GetFinanceNews(int offset)
        {
            string apikey = _configuration.GetValue<string>("API_KEY");
            string baseUrl = _configuration.GetValue<string>("API_URL");

            string parameters = string.Format("?apikey={0}&offset={1}&date={2}&sort={3}", apikey, offset, "today", "desc");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                
                HttpResponseMessage response = client.GetAsync(parameters).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<FinanceNews>(result);
                }
                else
                {
                    return new FinanceNews
                    {
                        News = new List<NewsArticle>(),
                        Pagination = new Pagination()
                    };
                }
            }

        }
    }
}
