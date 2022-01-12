using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Response<T>
    {
        public T Data { get; set; }
        public List<T> DataList { get; set; } = null;
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
    }
}
