using Microsoft.Extensions.DependencyInjection;
using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsProducts;
using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository.IngredientRepo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.ServiceForCombine
{
    public class ServiceForCombineClass
    {
        IServiceProvider? _se;

        public string stringofIngredients = null!;

        public List<ProductsMain> ingredients = new();

        public List<MainRecipe> recipes = new();

        public List<string> UNALTEREDListOfIngredients = new();

        public List<string> ALTEREDlistofingredient = new();

        public List<string> FinalBeforeSendIngredients = new();
        public string TitleSearch { get; set; } = "";


        public ServiceForCombineClass(IServiceProvider? se)
        {
            _se = se;
        }
        public ServiceForCombineClass() { }


        public void GetAllData()
        {

            var context = _se!.GetService<IngredientContext>();

            var listofingredients = context!.MainRecipes.Select(x => x.Ingredient);


            foreach (var ingredient in listofingredients)
            {
                if (!UNALTEREDListOfIngredients.Contains(ingredient!))
                {
                    UNALTEREDListOfIngredients.Add(ingredient!);
                }
            }

        }

        public void OrganizeIntoSubstrings()
        {



            foreach (var ingredients in UNALTEREDListOfIngredients)
            {
                if (ingredients != null)
                {
                    foreach (var ingredient in ingredients!.Split(","))
                    {
                        if (!ALTEREDlistofingredient.Contains(ingredient))
                        {
                            ingredient.TrimStart();
                            ALTEREDlistofingredient.Add(ingredient);
                        }

                    }
                }

            }

        }

        public void ConvertALLIntoProductMains()
        {
            var context = _se!.GetService<ProductContext>();

            if (ALTEREDlistofingredient.Count == 0) { Trace.WriteLine("Finns inga produkter att konvertera?"); }



            foreach (var ingredient in ALTEREDlistofingredient)
            {
                var some = context!.ProductsMains
                    .Where(x => x.NameOfProduct == ingredient.TrimStart());



                foreach (var item in some)
                {
                    if (!ingredients.Contains(item))
                    {
                        ingredients.Add(item);
                    }
                }

            }


        }

        public void GetRecipe()
        {

            var repository = _se!.GetService<MainRecipeRepo>();

            var result = repository!.Read(x => x.TitleRecipe == TitleSearch);

            recipes.Add(result);

        }

        public List<ProductsMain> GetIngredients()
        {
            foreach (var ingredientstring in recipes)
            {
                foreach (var ingredientsplit in ingredientstring.Ingredient!.Split(","))
                {
                    FinalBeforeSendIngredients.Add(ingredientsplit.TrimStart());
                }

            }

            // Två listor ska jämföras!

            List<ProductsMain> list = new();

            foreach (var item in FinalBeforeSendIngredients)
            {
                foreach (var items in ingredients)
                {
                    if (items.NameOfProduct == item)
                    {
                        list.Add(items);

                    }
                }
            }


            return list;


        }

    }
}
