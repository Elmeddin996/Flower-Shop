using System.ComponentModel.DataAnnotations;

namespace Flowers.UI.Models
{
    public class CategoryCreateRequest
    {
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
