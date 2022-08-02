using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<User> Users {get; set;}
    }
}
