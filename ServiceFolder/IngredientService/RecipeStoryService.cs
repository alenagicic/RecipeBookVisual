using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository.IngredientRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.ServiceFolder.IngredientService
{
    internal class RecipeStoryService
    {
        RecipeStoryRepo? _rep;
        public RecipeStoryService(RecipeStoryRepo? rep) { rep = _rep; }



        public bool AddStory(string story)
        {
            RecipeStory main = new RecipeStory()
            {
                Stories = story
            };

            var result = _rep!.Add(main);

            return result;
        }

        public bool RemoveStory(string story)
        {
            var result = _rep!.Remove(x => x.Stories == story);

            return result;
        }

        public bool UpdateStory(RecipeStory story)
        {
            var some = _rep!.Update(x => x.Stories == story.Stories, story);

            return some;
        }

        public RecipeStory ReadStory(string story)
        {
            var result = _rep!.Read(x => x.Stories == story);

            return result;

        }

        public IEnumerable<RecipeStory> ReadAllStory()
        {
            var result = _rep!.ReadAll();

            return result;
        }



    }
}
