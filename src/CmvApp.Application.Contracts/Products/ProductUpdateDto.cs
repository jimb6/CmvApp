using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace CmvApp.Products
{
    public class ProductUpdateDto : IHasConcurrencyStamp
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}