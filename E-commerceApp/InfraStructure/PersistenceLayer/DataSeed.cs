using DomainLayer.Contracts;
using DomainLayer.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PersistenceLayer
{
    public class DataSeed(StoreDbContext _storeDb): IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            try
            {

                if ((await _storeDb.Database.GetPendingMigrationsAsync()).Any())
                {
                   await _storeDb.Database.MigrateAsync();
                }

                if (!_storeDb.productBrands.Any())
                {
                    var productBrandData = File.OpenRead(@"..\InfraStructure\\PersistenceLayer\\Data\\DataSeed\\brands.json");

                    var brands =await JsonSerializer.DeserializeAsync<List<ProductBrand>>(productBrandData);
                    if (brands is not null && brands.Any())
                    {

                        await _storeDb.productBrands.AddRangeAsync(brands);
                    }
                }

                if (!_storeDb.productTypes.Any())
                {
                    var productTypeData = File.OpenRead(@"..\InfraStructure\\PersistenceLayer\\Data\\DataSeed\\types.json");

                    var types = await JsonSerializer.DeserializeAsync<List<ProductType>>(productTypeData);
                    if ( types is not null&& types.Any() )
                    {

                       await _storeDb.productTypes.AddRangeAsync(types);
                    }
                }


                if (!_storeDb.products.Any())
                {
                    var productsData = File.OpenRead(@"..\InfraStructure\\PersistenceLayer\\Data\\DataSeed\\products.json");

                    var products =await JsonSerializer.DeserializeAsync<List<Product>>(productsData);
                    if ( products is not null&& products.Any() )
                    {

                        _storeDb.products.AddRange(products);
                    }
                }

                await _storeDb.SaveChangesAsync();
            }
            catch (Exception)
            {

              //ToDo
            }
        }
    }
}
