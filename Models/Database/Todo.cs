using System.ComponentModel.DataAnnotations;

namespace MAUIExampleAPI.Models.Database
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string TodoName { get; set; }
    }
}
