using System.ComponentModel.DataAnnotations;

namespace Loja.ViewModels
{
    public class CategoryCreateViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }

    public class CategoryUpdateViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
