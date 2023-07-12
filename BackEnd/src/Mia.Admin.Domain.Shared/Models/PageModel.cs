using System.Collections.Generic;

namespace Mia.Admin.Models
{
    public class PageModel<T>
    {
        public PageModel(IEnumerable<T> data, int total)
        {
            Data = data;
            Total = total;
        }
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
