using System;
using CmvApp.Shared;
using Volo.Abp.AutoMapper;
using CmvApp.Products;
using AutoMapper;

namespace CmvApp;

public class CmvAppApplicationAutoMapperProfile : Profile
{
    public CmvAppApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Product, ProductDto>();
        CreateMap<Product, ProductExcelDto>();
    }
}