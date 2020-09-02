//Models define which fields are available in the data

using System.ComponentModel.DataAnnotations;

namespace Commander.Models
//Shortcut => type prop and hit tab for quickly snippets for public properties
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}