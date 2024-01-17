using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Shared.OutputData
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        //	for frontView
        public string? ErrorMessage { get; set; } = string.Empty;

        //	for backView
        public string? ErrorInfo { get; set; } = string.Empty;
        // for additional information
        public string? Info { get; set; } = string.Empty;
    }

    public class Response<T> : Response
    {
        public T? Value { get; set; }
    }
}
