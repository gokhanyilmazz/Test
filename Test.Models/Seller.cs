using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Product> Products { get; set; }
        public virtual User User { get; set; }

    }
}
