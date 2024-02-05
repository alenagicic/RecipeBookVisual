using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository.IngredientRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.ServiceFolder.IngredientService
{
    public class MainRecipeService
    {
        MainRecipeRepo? MainRecipeRepo;

        public MainRecipeService(MainRecipeRepo? mainRecipeRepo)
        {
            MainRecipeRepo = mainRecipeRepo;
        }
        
        public bool AddMainRecipe(MainRecipe mainRecipe)
        {
            var result = MainRecipeRepo!.Add(mainRecipe);

            return result;
        } 

        public bool RemoveMainRecipe(string title) 
        {
            var result = MainRecipeRepo!.Remove(x => x.TitleRecipe == title);

            return result;
        }

        public bool UpdateMainRecipe(MainRecipe mainRecipe) 
        {
            var some = MainRecipeRepo!.Update(x => x.TitleRecipe == mainRecipe.TitleRecipe, mainRecipe);

            return some;
        }

        public MainRecipe ReadMainRecipe(string title) 
        {
            var result = MainRecipeRepo!.Read(x => x.TitleRecipe == title);

            return result;
        }

        public IEnumerable<MainRecipe> ReadAllMains()
        {
            var result = MainRecipeRepo!.ReadAll();

            return result;
        }






    }
}
