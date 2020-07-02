using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BorrowToOwn.Data.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
