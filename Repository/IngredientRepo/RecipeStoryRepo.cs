using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsRecipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.Repository.IngredientRepo
{
    internal class RecipeStoryRepo : MainRepositoryIngredient<RecipeStory>
    {
        public RecipeStoryRepo(IngredientContext ingredientContext) : base(ingredientContext)
        {
        }
    }
}
