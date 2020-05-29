using System;
namespace BorrowToOwn.Data.Models
{
    public class Card
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public int  CVV { get; set; }
        public long Number { get; set; }
        public int Pin { get; set; }
        public User User { get; set; }
    }
}
