using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsRecipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.Repository.IngredientRepo
{
    internal class PairingsRecipeRepo : MainRepositoryIngredient<PairingsRecipe>
    {
        public PairingsRecipeRepo(IngredientContext ingredientContext) : base(ingredientContext)
        {
        }
    }
}
