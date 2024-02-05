using RecipeBookVisual.ModelsProducts;
using RecipeBookVisual.Repository.ProductRepo;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.ServiceFolder.ProductService
{
    internal class ProductUsageService
    {
        ProductUsageRepo? _use;

        public ProductUsageService(ProductUsageRepo? use)
        {
            _use = use;
        }


        public bool AddProductUsage(string use)
        {
            ProductUsage main = new ProductUsage()
            {
                 ProductUsage1 = use
            };

            var result = _use!.Add(main);

            return result;
        }

        public bool RemoveProductUsage(string use)
        {
            var result = _use!.Remove(x => x.ProductUsage1 == use);

            return result;
        }

        public bool UpdateProductUsage(ProductUsage use)
        {
            var some = _use!.Update(x => x.ProductUsage1 == use.ProductUsage1, use);

            return some;
        }

        public ProductUsage ReadProductUsage(string use)
        {
            var result = _use!.Read(x => x.ProductUsage1 == use);

            return result!;
        }

        public IEnumerable<ProductUsage> ReadAllProductUsage()
        {
            var result = _use!.ReadAll();

            return result!;
        }
    }
}
