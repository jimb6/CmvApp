using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using CmvApp.Products;

namespace CmvApp.Products
{
    public class ProductsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ProductsDataSeedContributor(IProductRepository productRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _productRepository = productRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _productRepository.InsertAsync(new Product
            (
                id: Guid.Parse("61df9448-10d1-4164-b0cb-9e9e1a0f0324"),
                name: "4b61548",
                description: "57bbcbdf3c374099bcc4b",
                price: 1968859746
            ));

            await _productRepository.InsertAsync(new Product
            (
                id: Guid.Parse("e01811db-c649-47f6-880f-b9db07a2b687"),
                name: "0d3ab1ae12654501",
                description: "36b371630ba04af195a3f9aa4848dc906965c0b1880248b39e1a12d6fcd",
                price: 340036872
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}