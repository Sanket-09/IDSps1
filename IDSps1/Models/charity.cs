using System.ComponentModel.DataAnnotations;

namespace IDSps1.Models
{
    public class Charity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NGO { get; set; }

        public string Requirements { get; set; }

        public Charity()
        {
            
        }
    }
}
