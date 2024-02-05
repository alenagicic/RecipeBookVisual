using Microsoft.EntityFrameworkCore;
using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsRecipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.Repository.IngredientRepo
{
    public class MainRecipeRepo : MainRepositoryIngredient<MainRecipe>
    {

        private readonly IngredientContext? _context;
        public MainRecipeRepo(IngredientContext ingredientContext) : base(ingredientContext)
        {
            _context = ingredientContext;
        }

        public override MainRecipe Read(Expression<Func<MainRecipe, bool>> expression)
        {

            MainRecipe mainRecipe = new();

            var list = _context!.MainRecipes
                .Include(x => x.FunFactRecipes)
                .Include(x => x.AlternativeIngredients)
                .Include(x => x.PairingsRecipes)
                .Include(x => x.RecipeStories)
                .Where(expression).ToList();

            foreach(var item in list)
            {
                mainRecipe = item;
            }

            return mainRecipe;
        }

        public override bool Remove(Expression<Func<MainRecipe, bool>> expression)
        {
            var list = _context!.MainRecipes
                .Include(x => x.AlternativeIngredients)
                .Include(x => x.FunFactRecipes)
                .Include(x => x.PairingsRecipes)
                .Include(x => x.RecipeStories)
                .Where(expression).ToList();

            try
            {
             
                foreach(var data in list)
                {
                    foreach(var item in data.AlternativeIngredients)
                    {
                        _context.AlternativeIngredients.Remove(item);
                    }
                    foreach(var item in data.FunFactRecipes)
                    {
                        _context.FunFactRecipes.Remove(item);
                    }
                    foreach(var item in data.PairingsRecipes)
                    {
                        _context.PairingsRecipes.Remove(item);
                    }
                    foreach(var item in data.RecipeStories)
                    {
                        _context.RecipeStories.Remove(item);
                    }

                    _context.SaveChanges();

                    _context.MainRecipes.Remove(data);

                    _context.SaveChanges();
                }

                return true;

            }
            catch
            {
                return false;
            }





        }
    }
}
