using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository.IngredientRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.ServiceFolder.IngredientService
{
    internal class PairingsRecipeService
    {

        PairingsRecipeRepo? _pair;

        public PairingsRecipeService(PairingsRecipeRepo? pairing) { pairing = _pair; }


        public bool AddPairing(string drink, string dessert, string movie)
        {
            PairingsRecipe main = new PairingsRecipe()
            {
                SuggestDrinks = drink,
                SuggestDesserts = dessert,
                SuggestMovie = movie
            };

            var result = _pair!.Add(main);

            return result;
        }

        public bool RemovePairing(string drink)
        {
            var result = _pair!.Remove(x => x.SuggestDrinks == drink);

            return result;
        }

        public bool UpdatePairing(PairingsRecipe pair)
        {
            var some = _pair!.Update(x => x.SuggestDrinks == pair.SuggestDrinks, pair);

            return some;
        }

        public PairingsRecipe ReadPairing(string pair)
        {
            var result = _pair!.Read(x => x.SuggestDrinks == pair);

            return result;

        }

        public IEnumerable<PairingsRecipe> ReadAllMains()
        {
            var result = _pair!.ReadAll();

            return result;
        }




    }
}
