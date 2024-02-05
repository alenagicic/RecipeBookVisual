using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository.IngredientRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.ServiceFolder.IngredientService
{
    internal class FunFactService
    {

        FunFactRepo? _fun;

        public FunFactService(FunFactRepo? fun)
        {
            _fun = fun;
        }




        public bool AddFunfact(string funfact)
        {
            FunFactRecipe main = new FunFactRecipe()
            {
                FoodForTought = funfact
            };

            var result = _fun!.Add(main);

            return result;
        }

        public bool RemoveFunfact(string funfact)
        {
            var result = _fun!.Remove(x => x.FoodForTought == funfact);

            return result;
        }

        public bool UpdateFunFact(FunFactRecipe funfact)
        {
            var some = _fun!.Update(x => x.FoodForTought == funfact.FoodForTought, funfact);

            return some;
        }

        public FunFactRecipe ReadFunFact(string funfact)
        {
            var result = _fun!.Read(x => x.FoodForTought == funfact);

            return result;

        }

        public IEnumerable<FunFactRecipe> ReadAllFunFact()
        {
            var result = _fun!.ReadAll();

            return result;
        }

    }
}
