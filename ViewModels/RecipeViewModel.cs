using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository.IngredientRepo;
using RecipeBookVisual.ServiceFolder.IngredientService;
using RecipeBookVisual.ViewsRecipes;
using System.Diagnostics;

namespace RecipeBookVisual.ViewModels
{
    public partial class RecipeViewModel : ObservableObject
    {
        public IServiceProvider? _se;

        // NEDAN ÄR PROPERY FÖR ADDRECIPE

        [ObservableProperty]

        public AlternativeIngredient? alternativeIngredient = new();

        [ObservableProperty]

        public FunFactRecipe? funFactRecipe = new();

        [ObservableProperty]

        public MainRecipe? mainRecipe = new();

        [ObservableProperty]

        public PairingsRecipe? pairingsRecipe = new();

        [ObservableProperty]

        public RecipeStory? recipeStory = new();

      


        // NEDAN ÄR PROPERTY FÖR UPDATERECIPE

        [ObservableProperty]

        public AlternativeIngredient? alternativeIngredientupdate = new();

        [ObservableProperty]

        public FunFactRecipe? funFactRecipeupdate = new();

        [ObservableProperty]

        public MainRecipe? mainRecipeupdate = new();

        [ObservableProperty]

        public PairingsRecipe? pairingsRecipeupdate = new();

        [ObservableProperty]

        public RecipeStory? recipeStoryupdate = new();

        // NEDAN ÄR PROPERTY FÖR GETRECIPE

        [ObservableProperty]

        public AlternativeIngredient? alternativeIngredientGet = new();

        [ObservableProperty]

        public FunFactRecipe? funFactRecipeGet = new();

        [ObservableProperty]

        public MainRecipe? mainRecipeGet = new();

        [ObservableProperty]

        public PairingsRecipe? pairingsRecipeGet = new();

        [ObservableProperty]

        public RecipeStory? recipeStoryGet = new();
        
        public RecipeViewModel(IServiceProvider serviceProvider) { _se = serviceProvider; }

        public RecipeViewModel() { }

        [RelayCommand]

        public void AddRecipe()
        {
            var service = _se!.GetService<MainRecipeService>();

            var view = _se!.GetService<CombinationWarning>();
            var viewmodel = _se!.GetService<MainViewModel>();

            if (MainRecipe!.TitleRecipe == null | MainRecipe.TitleRecipe == "")
            {
                return;
            }


            var manipulatedstringone = MainRecipe.TitleRecipe!.ToLower();

            MainRecipe.TitleRecipe = manipulatedstringone;

            var resultofsearch = service!.ReadMainRecipe(MainRecipe.TitleRecipe);

            if (resultofsearch.TitleRecipe == MainRecipe.TitleRecipe)
            {
                viewmodel!.Window = view!;
                Trace.WriteLine("Receptet finns redan!");
                return;
            }

            if (MainRecipe.Ingredient != null)
            {
                var manipulatedstring = MainRecipe.Ingredient!.ToLower();

                MainRecipe.Ingredient = manipulatedstring.Replace(" ", ",").Replace(", ", ",");
            }


            MainRecipe.AlternativeIngredients.Add(AlternativeIngredient!);
            MainRecipe.FunFactRecipes.Add(FunFactRecipe!);
            MainRecipe.RecipeStories.Add(RecipeStory!);
            MainRecipe.PairingsRecipes.Add(PairingsRecipe!);

            var result = service.AddMainRecipe(MainRecipe);

            if (result == true)
            {

                var main = _se!.GetService<MainViewModel>();

                main!.Window = _se!.GetService<RecipeUpdated>()!;

                MainRecipe = new();
                AlternativeIngredient = new();
                FunFactRecipe = new();
                RecipeStory = new();
                PairingsRecipe = new();


            }
            else
            {
                Trace.WriteLine("Något gick snett!");
            }

        }

        [RelayCommand]

        public void RemoveRecipe()
        {

            // Remove recipe with title!

            var service = _se!.GetService<MainRecipeRepo>();

            if (MainRecipe!.TitleRecipe == null || MainRecipe.TitleRecipe == "")
            {
                return;
            }

            var modifiedstring = MainRecipe!.TitleRecipe!.ToLower();

            var result = service!.Remove(x => x.TitleRecipe == modifiedstring);

            if (result == true)
            {
                var mainviewmodel = _se!.GetService<MainViewModel>();

                mainviewmodel!.Window = _se!.GetService<RemoveRecipeView>()!;

            }
            else
            {
                var mainviewmodel = _se!.GetService<MainViewModel>();

                mainviewmodel!.Window = _se!.GetService<UserDoesNotExistView>()!;
                Trace.WriteLine("Fick tillbaks en false från service, Viewmodel!");

            }


        }

        [RelayCommand]

        public void UpdateRecipe()
        {
            var MainWindow = _se!.GetService<MainViewModel>();

            var service = _se!.GetService<MainRecipeRepo>();

            var UpdateFields = _se!.GetService<UpdateRecipeUserControl>()!;

            if (MainRecipeupdate!.TitleRecipe == null | MainRecipeupdate.TitleRecipe == "")
            {
                return;
            }

            var modifiedstring = MainRecipeupdate.TitleRecipe!.ToLower();

            var result = service!.Read(x => x.TitleRecipe == modifiedstring);





            if (result.TitleRecipe == modifiedstring)
            {
                MainRecipeupdate = result;

                foreach(var item in result.PairingsRecipes)
                {
                    PairingsRecipeupdate = item;
                }
                foreach(var item in result.FunFactRecipes)
                {
                    FunFactRecipeupdate = item;
                }
                foreach(var item in result.RecipeStories)
                {
                    RecipeStoryupdate = item;
                }
                foreach(var item in result.AlternativeIngredients)
                {
                    AlternativeIngredientupdate = item;
                }


                MainWindow!.Window = UpdateFields;



            }
            else
            {
                var userDoesNotExist = _se!.GetService<UserDoesNotExistView>();

                MainWindow!.Window = userDoesNotExist!;
                Trace.WriteLine("Viewmodelreturnerarfalse");

            }


        }

        [RelayCommand]
        public void UpdateRecipeFields()
        {
            if (MainRecipeupdate!.Ingredient != null | MainRecipeupdate!.Ingredient != "")
            {
                var manipulatedstring = MainRecipeupdate!.Ingredient!.ToLower();

                MainRecipeupdate.Ingredient = manipulatedstring.Replace(" ", ",").Replace(".", ",");
            }

            MainRecipeupdate!.TitleRecipe!.ToLower();

            var mainservice = _se!.GetService<MainRecipeService>();

            MainRecipeupdate.AlternativeIngredients.Add(AlternativeIngredientupdate!);
            MainRecipeupdate.FunFactRecipes.Add(FunFactRecipeupdate!);
            MainRecipeupdate.RecipeStories.Add(RecipeStoryupdate!);
            MainRecipeupdate.PairingsRecipes.Add(PairingsRecipeupdate!);


            var result = mainservice!.UpdateMainRecipe(MainRecipeupdate);

            if (result == true)
            {

                var mainviewmodel = _se!.GetService<MainViewModel>();
                var Recipeupdatedview = _se!.GetService<RecipeUpdated>();

                mainviewmodel!.Window = Recipeupdatedview!;



            }
            else
            {
                Trace.WriteLine("Något gick snett vid uppdatering, viewmodel!");
            }







        }

        [RelayCommand]

        public void GetRecipe()
        {
            

            var service = _se!.GetRequiredService<MainRecipeRepo>();

            var mainview = _se!.GetService<MainViewModel>();

            var userfields = _se!.GetRequiredService<GetRecipeUserControll>();

            if (MainRecipeGet!.TitleRecipe == "" | MainRecipeGet.TitleRecipe == null)
            {
                return;
            }

            var modifiedstring = MainRecipeGet!.TitleRecipe!.ToLower();

            MainRecipeGet.TitleRecipe = modifiedstring;



            var result = service.Read(x => x.TitleRecipe == modifiedstring);



            if (result.TitleRecipe == modifiedstring)
            {

                MainRecipeGet = result;

                foreach(var item in result.PairingsRecipes)
                {
                    PairingsRecipeGet = item;
                }
                foreach(var item in result.FunFactRecipes)
                {
                    FunFactRecipeGet = item;
                }
                foreach(var item in result.RecipeStories)
                {
                    RecipeStoryGet = item;
                }
                foreach(var item in result.AlternativeIngredients)
                {
                    AlternativeIngredientGet = item;
                }

                

                mainview!.Window = userfields;

            }
            else
            {
                var otherview = _se!.GetService<UserDoesNotExistView>();
                mainview!.Window = otherview!;


            }


        }



    }
}
