using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.Repository.ProductRepo
{
    internal class ProductArtNrPriceRepo : MainRepositoryProduct<ProductArticleNrPrice>
    {
        public ProductArtNrPriceRepo(ProductContext? productContext) : base(productContext)
        {
        }



        
    }
}
