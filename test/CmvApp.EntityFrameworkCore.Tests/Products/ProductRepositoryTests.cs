using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using CmvApp.Products;
using CmvApp.EntityFrameworkCore;
using Xunit;

namespace CmvApp.Products
{
    public class ProductRepositoryTests : CmvAppEntityFrameworkCoreTestBase
    {
        private readonly IProductRepository _productRepository;

        public ProductRepositoryTests()
        {
            _productRepository = GetRequiredService<IProductRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _productRepository.GetListAsync(
                    name: "4b61548",
                    description: "57bbcbdf3c374099bcc4b"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("61df9448-10d1-4164-b0cb-9e9e1a0f0324"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _productRepository.GetCountAsync(
                    name: "0d3ab1ae12654501",
                    description: "36b371630ba04af195a3f9aa4848dc906965c0b1880248b39e1a12d6fcd"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}