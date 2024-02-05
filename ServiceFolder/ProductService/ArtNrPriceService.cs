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
    internal class ArtNrPriceService
    {
        ProductArtNrPriceRepo? _pro;
        public ArtNrPriceService(ProductArtNrPriceRepo pro) { _pro = pro; }


        public bool AddArtNr(string art)
        {
            ProductArticleNrPrice main = new ProductArticleNrPrice()
            {
                 ProductArticleNumber = art,
            };

            var result = _pro!.Add(main);

            return result;
        }

        public bool RemoveArtNr(string art)
        {
            var result = _pro!.Remove(x => x.ProductArticleNumber == art);

            return result;
        }

        public bool UpdateArtNr(ProductArticleNrPrice article)
        {
            var some = _pro!.Update(x => x.Price == article.Price, article);

            return some;
        }

        public ProductArticleNrPrice ReadArtNr(string art)
        {
            var result = _pro!.Read(x => x.ProductArticleNumber == art);

            return result;

        }

        public IEnumerable<ProductArticleNrPrice> ReadAllArtNr()
        {
            var result = _pro!.ReadAll();

            return result;
        }

    }
}
