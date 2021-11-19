using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_News_System.Models
{
    public class SQLNewsRepository : INewsRepository
    {
        private readonly AppDbContext context;
        public  SQLNewsRepository(AppDbContext context)
        {
            this.context = context;
        }
        News INewsRepository.AddNews(News news)
        {
            context.News.Add(news);
            context.SaveChanges();
            return news;
        }

        News INewsRepository.UpdateNews(News NewsChanges)
        {
            var news = context.News.Attach(NewsChanges);
            news.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return NewsChanges;
        }

        News INewsRepository.DeleteNews(int Id)
        {
            News news = context.News.Find(Id);
            if (news != null)
            {
                context.News.Remove(news);
                context.SaveChanges();
            }
            return news;
        }

        News INewsRepository.GetNews(int id)
        {
            return context.News.Find(id);
        }
        public IEnumerable<News> GetAllNews()
        {
            return context.News;
        }
    }
}
