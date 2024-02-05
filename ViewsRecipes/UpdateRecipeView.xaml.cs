using RecipeBookVisual.ViewModels;
using RecipeBookVisual.ViewsRecipes;

using System.Windows.Controls;


namespace RecipeBookVisual.ViewsRecipes
{
    /// <summary>
    /// Interaction logic for UpdateRecipeView.xaml
    /// </summary>
    public partial class UpdateRecipeView : UserControl
    {
        public UpdateRecipeView(RecipeViewModel recipeViewModel)
        {
            InitializeComponent();
            DataContext = recipeViewModel;
        }
    }
}
