using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string Color { get; set; } = null!;
        public int Stock { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }       
        public virtual Category Category { get; set; }
        public virtual Seller Seller { get; set; }

    }
}
