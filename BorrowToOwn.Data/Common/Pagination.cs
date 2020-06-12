using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BorrowToOwn.Data.Common
{
    public class Pagination
    {
        [Required]
        public int From { get; set; }
        [Required]
        public int  To { get; set; }


        internal async Task<bool> IsValid(Pagination pagination) {
            if (From > To)  return  await Task.Run(() => { return false; });
            else if (To - From > 50) return await Task.Run(() => { return false; });
            return await Task.Run(() => { return true; });
        }
    }

}
