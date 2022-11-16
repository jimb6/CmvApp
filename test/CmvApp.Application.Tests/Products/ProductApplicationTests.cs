using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace CmvApp.Products
{
    public class ProductsAppServiceTests : CmvAppApplicationTestBase
    {
        private readonly IProductsAppService _productsAppService;
        private readonly IRepository<Product, Guid> _productRepository;

        public ProductsAppServiceTests()
        {
            _productsAppService = GetRequiredService<IProductsAppService>();
            _productRepository = GetRequiredService<IRepository<Product, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _productsAppService.GetListAsync(new GetProductsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("61df9448-10d1-4164-b0cb-9e9e1a0f0324")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("e01811db-c649-47f6-880f-b9db07a2b687")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _productsAppService.GetAsync(Guid.Parse("61df9448-10d1-4164-b0cb-9e9e1a0f0324"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("61df9448-10d1-4164-b0cb-9e9e1a0f0324"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ProductCreateDto
            {
                Name = "52c0c69be03140388467dd11cbb1c320ee272bdd36924787b468333bdd197966",
                Description = "9b61ec1b8cf547d8a5fa338a37b5cc259fe42744df9c4f2ebbe112c06914f9107956af1b78a947",
                Price = 28432203
            };

            // Act
            var serviceResult = await _productsAppService.CreateAsync(input);

            // Assert
            var result = await _productRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("52c0c69be03140388467dd11cbb1c320ee272bdd36924787b468333bdd197966");
            result.Description.ShouldBe("9b61ec1b8cf547d8a5fa338a37b5cc259fe42744df9c4f2ebbe112c06914f9107956af1b78a947");
            result.Price.ShouldBe(28432203);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ProductUpdateDto()
            {
                Name = "c890fe3329b14b1a97288321c527a7cf3a890918ac944432b36046",
                Description = "2da6d3501753458d9da65baf59f034205979c46db5",
                Price = 558973454
            };

            // Act
            var serviceResult = await _productsAppService.UpdateAsync(Guid.Parse("61df9448-10d1-4164-b0cb-9e9e1a0f0324"), input);

            // Assert
            var result = await _productRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("c890fe3329b14b1a97288321c527a7cf3a890918ac944432b36046");
            result.Description.ShouldBe("2da6d3501753458d9da65baf59f034205979c46db5");
            result.Price.ShouldBe(558973454);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _productsAppService.DeleteAsync(Guid.Parse("61df9448-10d1-4164-b0cb-9e9e1a0f0324"));

            // Assert
            var result = await _productRepository.FindAsync(c => c.Id == Guid.Parse("61df9448-10d1-4164-b0cb-9e9e1a0f0324"));

            result.ShouldBeNull();
        }
    }
}