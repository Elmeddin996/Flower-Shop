using System.ComponentModel.DataAnnotations;

namespace Flowers.UI.Models
{
    public class CategoryUpdateRequest
    {
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
