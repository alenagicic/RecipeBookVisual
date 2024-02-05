using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository.IngredientRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.ServiceFolder.IngredientService
{
    internal class AlternativeIngredientService
    {

        AlternativeIngredientRepo? _alt;

        public AlternativeIngredientService(AlternativeIngredientRepo alt) { _alt = alt; }



        public bool AddAltRecipe(string title, string ingredient, string description, string cookingtime)
        {
            AlternativeIngredient main = new AlternativeIngredient()
            {
                Title = title,
                Ingredients = ingredient,
                Description = description,
                CookingTime = cookingtime
            };

            var result = _alt!.Add(main);

            return result;
        }

        public bool RemoveAltRecipe(string title)
        {
            var result = _alt!.Remove(x => x.Title == title);

            return result;
        }

        public bool UpdateAltRecipe(AlternativeIngredient alt)
        {
            var some = _alt!.Update(x => x.Title == alt.Title, alt);

            return some;
        }

        public AlternativeIngredient ReadAltRecipe(string title)
        {
            var result = _alt!.Read(x => x.Title == title);

            return result;

        }

        public IEnumerable<AlternativeIngredient> ReadAllAlts()
        {
            var result = _alt!.ReadAll();

            return result;
        }





    }
}
