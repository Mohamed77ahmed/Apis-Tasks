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
        void IDataSeeding.DataSeed()
        {
            try
            {

                if (_storeDb.Database.GetPendingMigrations().Any())
                {
                    _storeDb.Database.Migrate();
                }

                if (!_storeDb.productBrands.Any())
                {
                    var productBrandData = File.ReadAllText(@"..\InfraStructure\\PersistenceLayer\\Data\\DataSeed\\brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandData);
                    if (brands.Any() && brands is not null)
                    {

                        _storeDb.productBrands.AddRange(brands);
                    }
                }

                if (!_storeDb.productTypes.Any())
                {
                    var productTypeData = File.ReadAllText(@"..\InfraStructure\\PersistenceLayer\\Data\\DataSeed\\types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);
                    if (types.Any() && types is not null)
                    {

                        _storeDb.productTypes.AddRange(types);
                    }
                }


                if (!_storeDb.products.Any())
                {
                    var productsData = File.ReadAllText(@"..\InfraStructure\\PersistenceLayer\\Data\\DataSeed\\products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    if (products.Any() && products is not null)
                    {

                        _storeDb.products.AddRange(products);
                    }
                }

                _storeDb.SaveChanges();
            }
            catch (Exception)
            {

              //ToDo
            }
        }
    }
}
