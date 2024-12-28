using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSystem.Application.DTOs
{
    public class PagedResponse<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }
        public List<T> Data { get; set; } = new List<T>();
    }
}
