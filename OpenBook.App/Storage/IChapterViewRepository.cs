using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Storage
{
    public interface IChapterViewRepository
    {
        Task AddView(int userId, int chapterId);
        Task<int> GetViewForChapter(int userId, int chapterId);
        Task<int> GetUnicViewForChapter(int userId, int chapterId);
    }
}
