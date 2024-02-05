using RecipeBookVisual.ViewModels;
using System.Windows.Controls;



namespace RecipeBookVisual.ViewsRecipes
{
    /// <summary>
    /// Interaction logic for GetRecipeView.xaml
    /// </summary>
    public partial class GetRecipeView : UserControl
    {
   

        public GetRecipeView(RecipeViewModel recipeViewModel)
        {
            InitializeComponent();

            DataContext = recipeViewModel;
           
        }
    }
}
