using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        
        [ForeignKey("Seller")]
        public int? SellerId { get; set; }
        
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
        public virtual Seller Seller { get; set; }


    }
}
