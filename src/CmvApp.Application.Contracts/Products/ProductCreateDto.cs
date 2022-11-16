using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CmvApp.Products
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}