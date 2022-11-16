using CmvApp.Web.Pages.Products;
using Volo.Abp.AutoMapper;
using CmvApp.Products;
using AutoMapper;

namespace CmvApp.Web;

public class CmvAppWebAutoMapperProfile : Profile
{
    public CmvAppWebAutoMapperProfile()
    {
        //Define your object mappings here, for the Web project

        CreateMap<ProductDto, ProductUpdateViewModel>();
        CreateMap<ProductUpdateViewModel, ProductUpdateDto>();
        CreateMap<ProductCreateViewModel, ProductCreateDto>();
    }
}