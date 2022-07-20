using System.ComponentModel.DataAnnotations;

namespace IDSps1.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public Account()
        {

        }
    }
}
