using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.Repository.ProductRepo
{
    internal class ProductUsageRepo : MainRepositoryProduct<ProductUsage>
    {
        public ProductUsageRepo(ProductContext? productContext) : base(productContext)
        {
        }
    }
}
