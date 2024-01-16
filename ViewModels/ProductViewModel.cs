using System.ComponentModel.DataAnnotations;

namespace Loja.ViewModels
{
    public class ProductCreateViewModel
    {   
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Value { get; set; }
        public string Image { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }

    public class ProductUpdateViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Value { get; set; }
        [Required]
        public string Image { get; set; } = string.Empty;
        [Required]
        public int CategoryId { get; set; }
    }
}
