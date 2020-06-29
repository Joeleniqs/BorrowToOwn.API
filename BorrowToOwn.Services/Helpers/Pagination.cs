using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BorrowToOwn.Services.Helpers
{
    public class Pagination
    {
        const int maxPageSize = 20;
        public int CategoryId{ get; set; }
        public int SubCategoryId { get; set; }
        public string SearchQuery { get; set; }
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }

}
