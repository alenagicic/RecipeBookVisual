using RecipeBookVisual.ModelsProducts;
using RecipeBookVisual.Repository.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.ServiceFolder.ProductService
{
    public class ProductMainService
    {

        ProductMainRepo? _main;

        public ProductMainService(ProductMainRepo? main)
        {
            _main = main;
        }


        public bool AddProductMain(string name, int price)
        {
            ProductsMain main = new ProductsMain()
            {
                 NameOfProduct = name,
                 Price = price
            };

            var result = _main!.Add(main);

            return result;
        }

        public bool AddMainAndAllBelow(ProductsMain main) 
        {
            var result = _main!.Add(main);
            return result;
        }

        public bool RemoveProductMain(string main)
        {
            var result = _main!.Remove(x => x.NameOfProduct == main);

            return result;
        }

        public bool UpdateProductMain(ProductsMain main)
        {
            var some = _main!.Update(x => x.NameOfProduct == main.NameOfProduct, main);

            return some;
        }

        public ProductsMain ReadProductMain(string main)
        {
            var result = _main!.Read(x => x.NameOfProduct == main);

            return result!;

        }

        public IEnumerable<ProductsMain> ReadAllProductMain()
        {
            var result = _main!.ReadAll();

            return result!;
        }

    }
}
