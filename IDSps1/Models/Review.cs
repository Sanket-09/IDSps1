using System.ComponentModel.DataAnnotations;

namespace IDSps1.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Requirements { get; set; }

        public string Link { get; set; }

        public Review()
        {

        }
    }
}
