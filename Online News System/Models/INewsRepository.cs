using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_News_System.Models
{
   public interface INewsRepository
    {
        News AddNews(News news);
        News UpdateNews(News NewsChanges);
        News DeleteNews(int Id);
        News GetNews(int id);
        IEnumerable<News> GetAllNews();
    }
}
