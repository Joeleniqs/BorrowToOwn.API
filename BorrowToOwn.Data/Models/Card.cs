using System;
using System.ComponentModel.DataAnnotations;

namespace BorrowToOwn.Data.Models
{
    public class Card
    {
        public long Id { get; set; }

        [MaxLength(40)]
        public string AppUserId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [Range(100,999,ErrorMessage ="Invalid CVV number")]
        public int  CVV { get; set; }

        [MaxLength(20,ErrorMessage ="Card Number cannot be greater than 20")]
        public string Number { get; set; }

        [MaxLength(4, ErrorMessage = "Card Number cannot be greater than 4")]
        [MinLength(4, ErrorMessage = "Card Number cannot be less than 4")]
        public string Pin { get; set; }

        public AppUser AppUser { get; set; }
    }
}
