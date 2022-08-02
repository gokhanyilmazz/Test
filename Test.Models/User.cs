using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }
        public string FullName { get; set; } = null!;
        [Required(ErrorMessage = "Kullanıcı adı veya şifre yanlış.")]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "Kullanıcı adı veya şifre yanlış.")]
        public string PassWord { get; set; } = null!;
        public string Address { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public bool? IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual UserType UserType { get; set; } = null!;       
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
