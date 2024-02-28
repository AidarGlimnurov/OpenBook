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
    public class ChapterRepository : BaseRepository<Chapter>, IChapterRepository
    {
        public ChapterRepository(OpenBookContext context) : base(context)
        {
        }

        public async Task Create(Chapter chapter)
        {
            if (chapter.Book == null || chapter.Book.Id == 0)
            {
                chapter.Book = await context.Books.FirstOrDefaultAsync(b => b.Id == chapter.BookId);
            }
            context.Add(chapter);
        }

        public async IAsyncEnumerable<Chapter> GetForBook(int bookId, int start, int? count, bool? isPublic)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            IQueryable<Chapter>? chapters;

            if (isPublic == null)
            {
                chapters = context.Chapters.Include(c => c.Book)
                    .Where(c => c.BookId == bookId).Skip(skip).Take(take);
            }
            else
            {
                chapters = context.Chapters.Include(c => c.Book)
                    .Where(c => c.BookId == bookId && c.IsPublic == isPublic).Skip(skip).Take(take);
            }
            chapters = chapters.OrderBy(c => c.Number);
            foreach (var item in chapters)
            {
                yield return item;
            }
        }

        public async Task Published(int chapterId, bool action)
        {
            var chapter = await context.Chapters.FirstOrDefaultAsync(b => b.Id == chapterId);
            chapter.IsPublic = action;
            context.Update(chapter);
        }

        public async Task Update(Chapter chapter)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == chapter.BookId);
            chapter.Book = book;
            context.Update(chapter);
        }
    }
}
