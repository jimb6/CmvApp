using Volo.Abp.Application.Dtos;
using System;

namespace CmvApp.Products
{
    public class ProductExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string FilterText { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }

        public ProductExcelDownloadDto()
        {

        }
    }
}