using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace CmvApp.Products
{
    public class ProductManager : DomainService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // public async Task<Product> CreateAsync(
        // string name, string description, decimal price)
        // {
        //     var product = new Product(
        //      GuidGenerator.Create(),
        //      name, description, price
        //      );
        //
        //     return await _productRepository.InsertAsync(product);
        // }
        //
        // public async Task<Product> UpdateAsync(
        //     Guid id,
        //     string name, string description, decimal price, [CanBeNull] string concurrencyStamp = null
        // )
        // {
        //     var queryable = await _productRepository.GetQueryableAsync();
        //     var query = queryable.Where(x => x.Id == id);
        //
        //     var product = await AsyncExecuter.FirstOrDefaultAsync(query);
        //
        //     product.Name = name;
        //     product.Description = description;
        //     product.Price = price;
        //
        //     product.SetConcurrencyStampIfNotNull(concurrencyStamp);
        //     return await _productRepository.UpdateAsync(product);
        // }

    }
}