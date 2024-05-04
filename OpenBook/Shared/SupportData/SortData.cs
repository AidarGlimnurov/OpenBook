using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Shared.SupportData
{
    public class SortData
    {
        public int[]? GenreIds{ get; set; }
        public int Action { get; set; } = 0;
        public int? Start { get; set; }
        public int? Count { get; set; }
    }
}
