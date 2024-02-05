using Microsoft.EntityFrameworkCore;
using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsProducts;
using RecipeBookVisual.ModelsRecipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.Repository.ProductRepo
{
    public class ProductMainRepo : MainRepositoryProduct<ProductsMain>
    {

        private readonly ProductContext? _context;

        public ProductMainRepo(ProductContext productContext) : base(productContext)
        {
            _context = productContext;
        }

        public override ProductsMain Read(Expression<Func<ProductsMain, bool>> expression)
        {
            ProductsMain productsMain = new();


            var list = _context!.ProductsMains
                .Include(x => x.ProductInfos)
                .Include(x => x.ProductArticleNrPrices)
                .ThenInclude(x => x.Stores)
                .Include(x => x.ProductUsages)
                .Where(expression).ToList();


            foreach(var item in list)
            {
                productsMain = item;
            }

            return productsMain;
        }

        public override bool Remove(Expression<Func<ProductsMain, bool>> expression)
        {
            var list = _context!.ProductsMains
                .Include(x => x.ProductInfos)
                .Include(x => x.ProductArticleNrPrices)
                .ThenInclude(x => x.Stores)
                .Include(x => x.ProductUsages)
                .Where(expression).ToList();

            try
            {     
                foreach(var item in list)
                {
                    // Bekymmret är att den försöker ta bort allt utan cascadeDelete


                    foreach(var data in item.ProductArticleNrPrices)
                    {
                        foreach(var items in data.Stores)
                        {
                            _context.Stores.Remove(items);
                        }

                        _context.ProductArticleNrPrices.Remove(data);
                    }
                    foreach(var data in item.ProductUsages)
                    {
                        _context.ProductUsages.Remove(data);
                    }
                    foreach(var data in item.ProductInfos)
                    {
                        _context.ProductInfos.Remove(data);
                    }

                    _context.SaveChanges();

                    _context.ProductsMains.Remove(item);
                    _context.SaveChanges();
                }


                 return true;

            }catch
            {
                return false;
            }


        }


       



    }
}
