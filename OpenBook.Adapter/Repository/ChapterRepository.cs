﻿using Microsoft.EntityFrameworkCore;
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

        public async IAsyncEnumerable<Chapter> GetForBook(int bookId, int start, int? count, bool? isPublic)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var chapters = context.Chapters.Include(c => c.Book)
                .Where(c => c.BookId == bookId && isPublic == isPublic).Skip(skip).Take(take);

            foreach (var item in chapters)
            {
                yield return item;
            }
        }

        public async Task Published(int chapterId, bool action)
        {
            var chapter = await context.Chapters.FirstOrDefaultAsync(b => b.Id == chapterId);
            chapter.IsPublic = action;
        }
    }
}