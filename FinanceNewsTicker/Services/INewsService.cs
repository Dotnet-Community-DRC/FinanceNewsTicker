using FinanceNewsTicker.Services.Models;

namespace FinanceNewsTicker.Services;

public interface INewsService
{
    FinanceNews GetFinanceNews(int offset);
}

