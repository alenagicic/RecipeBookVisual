using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using RecipeBookVisual.ViewsRecipes;
using RecipeBookVisual.ViewsGroceries;
using RecipeBookVisual.ViewsCombine;


namespace RecipeBookVisual.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        IServiceProvider? _se;

        [ObservableProperty]
        object window = null!;

        public MainViewModel(IServiceProvider serviceProvider) { _se = serviceProvider; }

        public MainViewModel() { }


        [RelayCommand]
        public void RecipeAdd() 
        {

            var something = _se!.GetService<AddRecipeUserControl>()!;


            Window = something;


        }
        [RelayCommand]
        public void RecipeRemove() { Window = _se!.GetService<RemoveUserTitleView>()!; }
        [RelayCommand]
        public void RecipeUpdate() { Window = _se!.GetService<UpdateRecipeView>()!; }
        [RelayCommand]
        public void RecipeGet() { Window = _se!.GetService<GetRecipeView>()!; }
        [RelayCommand]
        public void GroceriesAdd() { Window = _se!.GetService<AddGroceriesView>()!; }

        [RelayCommand]
        public void Combine() { Window = _se!.GetService<CombinationView>()!; }

    }
}
