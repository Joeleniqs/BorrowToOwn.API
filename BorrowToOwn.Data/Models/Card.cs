using System;
namespace BorrowToOwn.Data.Models
{
    public class Card
    {
        public long Id { get; set; }
        public string AppUserId { get; set; }

        public string Name { get; set; }
        public int  CVV { get; set; }
        public long Number { get; set; }
        public int Pin { get; set; }

        public AppUser AppUser { get; set; }
    }
}
