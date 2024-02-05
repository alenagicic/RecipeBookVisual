using RecipeBookVisual.ViewModels;

using System.Windows.Controls;


namespace RecipeBookVisual.ViewsGroceries
{
    /// <summary>
    /// Interaction logic for AddGroceriesView.xaml
    /// </summary>
    public partial class AddGroceriesView : UserControl
    {
        public AddGroceriesView(GroceriesViewModel groceriesViewModel)
        {
            InitializeComponent();
            DataContext = groceriesViewModel;
        }

    }
}
