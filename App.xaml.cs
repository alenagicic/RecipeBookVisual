using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.ModelsProducts;
using RecipeBookVisual.ViewModels;
using RecipeBookVisual.ViewsGroceries;
using RecipeBookVisual.ViewsRecipes;
using System.Windows;
using RecipeBookVisual.ViewsCombine;
using RecipeBookVisual.Repository.IngredientRepo;
using RecipeBookVisual.Repository.ProductRepo;
using RecipeBookVisual.Repository;
using RecipeBookVisual.ServiceFolder.IngredientService;
using RecipeBookVisual.ServiceFolder.ProductService;
using RecipeBookVisual.ServiceForCombine;

namespace RecipeBookVisual
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static IHost? builder;

        public App()
        {
            builder = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {

                    services.AddSingleton<MainWindow>();


                    // Nedan har vi DbContext
                    services.AddDbContext<IngredientContext>();
                    services.AddDbContext<ProductContext>();

                    // Nedan har vi produkttabellerna
                    services.AddTransient<ProductArticleNrPrice>();
                    services.AddTransient<ProductInfo>();
                    services.AddTransient<ProductsMain>();
                    services.AddTransient<ProductUsage>();
                    services.AddTransient<Store>();

                    services.AddTransient<AlternativeIngredient>();
                    services.AddTransient<FunFactRecipe>();
                    services.AddTransient<MainRecipe>();
                    services.AddTransient<PairingsRecipe>();
                    services.AddTransient<RecipeStory>();


                    // Nedan har vi Repositories

                    services.AddScoped<AlternativeIngredientRepo>();
                    services.AddScoped<FunFactRepo>();
                    services.AddScoped<MainRecipeRepo>();
                    services.AddScoped<PairingsRecipeRepo>();
                    services.AddScoped<RecipeStoryRepo>();
                    services.AddScoped<ProductArtNrPriceRepo>();
                    services.AddScoped<ProductInfoRepo>();
                    services.AddScoped<ProductMainRepo>();
                    services.AddScoped<ProductUsageRepo>();
                    services.AddScoped<StoreRepo>();



                    //Nedan har vi services

                    services.AddTransient<AlternativeIngredientService>();
                    services.AddTransient<FunFactService>();
                    services.AddTransient<MainRecipeService>();
                    services.AddTransient<PairingsRecipeService>();
                    services.AddTransient<RecipeStoryService>();
                    services.AddTransient<ArtNrPriceService>();
                    services.AddTransient<ProductInfoService>();
                    services.AddTransient<ProductMainService>();
                    services.AddTransient<ProductUsageService>();
                    services.AddTransient<StoreService>();


                    // Något eget

                    services.AddTransient<ServiceForCombineClass>();

                    // Nedan har vi ViewModels

                    services.AddSingleton<GroceriesViewModel>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<RecipeViewModel>();
                    services.AddScoped<ViewModelCombine>();

                    // Nedan har vi VIEWS

                    services.AddSingleton<AddGroceriesView>();
                    services.AddTransient<ProductAddedAffirmationView>();
                    services.AddTransient<ProductSearchView>();
                    services.AddTransient<CombinationWarningGroceries>();
                    services.AddTransient<RemoveProductView>();
                    services.AddTransient<GetGroceriesView>();
                    services.AddTransient<UpdateProductViewFields>();
                    services.AddTransient<ProductSearchUpdateView>();
                    services.AddTransient<ProductSearchDeleteView>();
                    services.AddTransient<AddRecipeUserControl>();
                    services.AddTransient<CombinationWarning>();
                    services.AddTransient<GetRecipeView>();
                    services.AddScoped<GetRecipeUserControll>();
                    services.AddTransient<RemoveRecipeView>();
                    services.AddTransient<RemoveUserTitleView>();
                    services.AddTransient<UpdateRecipeView>();
                    services.AddTransient<UpdateRecipeUserControl>();
                    services.AddTransient<UserDoesNotExistView>();
                    services.AddTransient<RecipeUpdated>();
                    services.AddTransient<CombinationView>();
                    services.AddTransient<CombinationViewData>();






       
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            builder!.Start();

            var MainWindow = builder!.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

        }
    }

}
