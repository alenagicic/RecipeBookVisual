using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using RecipeBookVisual.ModelsProducts;
using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.ServiceForCombine;
using RecipeBookVisual.ViewsCombine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Xps.Packaging;

namespace RecipeBookVisual.ViewModels
{
    public partial class ViewModelCombine : ObservableObject
    {
        IServiceProvider? _se;

        [ObservableProperty]

        public string titlesearch = null!;

        [ObservableProperty]

        public MainRecipe mainRecipe = null!;

        [ObservableProperty]

        public ProductsMain productsMain = null!;

        [ObservableProperty]

        public ObservableCollection<ProductsMain>? finishedlistofproducts = new();


        public ViewModelCombine(IServiceProvider? se)
        {
            _se = se;
        }

        public ViewModelCombine() { }


        [RelayCommand]

        public void SearchAndDisplay()
        {


            if (Titlesearch == "" | Titlesearch == null)
            {
                return;
            }


            _se!.GetService<MainViewModel>()!.Window = _se!.GetService<CombinationViewData>()!;

            var service = _se!.GetService<ServiceForCombineClass>();

            service!.GetAllData();
            service.OrganizeIntoSubstrings();
            service.ConvertALLIntoProductMains();

            service.TitleSearch = Titlesearch!;

            service.GetRecipe();

            var list = service.recipes;

            foreach (var item in list)
            {
                MainRecipe = item;
            }

            var products = service.GetIngredients();

            foreach (var item in products)
            {
                if (!Finishedlistofproducts!.Contains(item))
                {
                    Finishedlistofproducts!.Add(item);
                }
            }

            Titlesearch = "";

            Trace.WriteLine(Finishedlistofproducts!.Count);

        }

    }
}
