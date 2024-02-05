using RecipeBookVisual.ViewModels;
using System.Windows.Controls;
using RecipeBookVisual.ViewsRecipes;


namespace RecipeBookVisual.ViewsRecipes
{
    /// <summary>
    /// Interaction logic for RemoveRecipeView.xaml
    /// </summary>
    public partial class RemoveRecipeView : UserControl
    {
        public RemoveRecipeView(RecipeViewModel recipeViewModel)
        {
            InitializeComponent();
            DataContext = recipeViewModel;
        }
    }
}
