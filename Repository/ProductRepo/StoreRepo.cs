using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.Repository.ProductRepo
{
    internal class StoreRepo : MainRepositoryProduct<Store>
    {
        public StoreRepo(ProductContext? productContext) : base(productContext)
        {
        }
    }
}
