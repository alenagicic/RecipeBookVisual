using RecipeBookVisual.ModelsProducts;
using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.ServiceFolder.ProductService
{
    internal class ProductInfoService
    {
        ProductInfoRepo? _info;

        public ProductInfoService(ProductInfoRepo? info)
        {
            _info = info;
        }



        public bool AddInfo(string info)
        {
            ProductInfo main = new ProductInfo()
            {
                 ProductDescription = info,
            };

            var result = _info!.Add(main);

            return result;
        }

        public bool RemoveInfo(string info)
        {
            var result = _info!.Remove(x => x.ProductDescription == info);

            return result;
        }

        public bool UpdateInfo(ProductInfo info)
        {
            var some = _info!.Update(x => x.ProductDescription == info.ProductDescription, info);

            return some;
        }

        public ProductInfo ReadInfo(string info)
        {
            var result = _info!.Read(x => x.ProductDescription == info);

            return result!;

        }

        public IEnumerable<ProductInfo> ReadAllInfo()
        {
            var result = _info!.ReadAll();

            return result!;
        }


    }
}
