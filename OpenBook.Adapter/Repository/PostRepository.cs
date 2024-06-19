using Microsoft.EntityFrameworkCore;
using OpenBook.App.Storage;
using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Adapter.Repository
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(OpenBookContext context) : base(context)
        {
        }

        public async Task AddView(int userId, int chapterId)
        {
            // Загружаем view из базы данных
            var view = await context.Posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(v =>
                    v.User.Id == userId && v.Content.Contains(chapterId.ToString() + "|")
                );

            // Если view не найден
            if (view == null)
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (user == null)
                {
                    throw new InvalidOperationException("User not found");
                }

                Post post = new()
                {
                    User = user,
                    Content = chapterId.ToString() + "|1"
                };

                context.Add(post);
            }
            else
            {
                // Извлекаем текущий count
                var parts = view.Content.Split('|');
                var currentChapterId = Convert.ToInt32(parts[0]);
                var currentCount = Convert.ToInt32(parts[1]);

                if (currentChapterId == chapterId)
                {
                    currentCount++;
                    view.Content = currentChapterId + "|" + currentCount;
                    context.Update(view);
                }
            }

            await context.SaveChangesAsync();
        }

        public async Task Create(Post post)
        {
            if (post.User == null || post.User.Id == 0)
            {
                post.User = await context.Users.FirstOrDefaultAsync(u => u.Id == post.UserId);
            }
            context.Add(post);
        }

        public async IAsyncEnumerable<Post> GetAll(int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var cycles = context.Posts.Skip(skip).Take(take);

            foreach (var item in cycles)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<Post> GetForUser(int userId, int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var posts = context.Posts.Include(p => p.User)
                .Where(p => p.UserId == userId).Skip(skip).Take(take);

            foreach (var item in posts)
            {
                yield return item;
            }
        }

        public async Task<int> GetUnicViewForChapter(int chapterId)
        {
            // Загружаем данные из базы данных
            var views = await context.Posts
                .Include(p => p.User)
                .ToListAsync();

            // Выполняем фильтрацию на стороне клиента
            var uniqueViews = views
                .Where(v =>
                {
                    var delimiterIndex = v.Content.IndexOf('|');
                    if (delimiterIndex == -1) return false;
                    var currentChapterId = Convert.ToInt32(v.Content.Substring(0, delimiterIndex));
                    return currentChapterId == chapterId;
                });

            return uniqueViews.Count();
        }

        public async Task<int> GetViewForChapter(int chapterId)
        {
            // Загружаем данные из базы данных
            var views = await context.Posts
                .Include(p => p.User)
                .ToListAsync();

            // Выполняем фильтрацию и подсчет на стороне клиента
            var count = views
                .Where(v =>
                {
                    var delimiterIndex = v.Content.IndexOf('|');
                    if (delimiterIndex == -1) return false;
                    var currentChapterId = Convert.ToInt32(v.Content.Substring(0, delimiterIndex));
                    return currentChapterId == chapterId;
                })
                .Sum(v =>
                {
                    var countIndex = v.Content.IndexOf('|') + 1;
                    return Convert.ToInt32(v.Content.Substring(countIndex));
                });

            return count;
        }
    }
}
