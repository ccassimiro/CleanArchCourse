using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Price is required")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Stock is required")]
        [Range(1, 9999)]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get; set; }

        [DisplayName("Categories")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
