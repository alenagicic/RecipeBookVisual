using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using RecipeBookVisual.Context;
using RecipeBookVisual.ModelsProducts;
using RecipeBookVisual.ModelsRecipe;
using RecipeBookVisual.Repository.ProductRepo;
using RecipeBookVisual.ServiceFolder.IngredientService;
using RecipeBookVisual.ServiceFolder.ProductService;
using RecipeBookVisual.ViewsGroceries;
using RecipeBookVisual.ViewsRecipes;
using System.Diagnostics;
using System.Timers;


namespace RecipeBookVisual.ViewModels
{
    public partial class GroceriesViewModel : ObservableObject
    {
        IServiceProvider? _se;

        [ObservableProperty]

        ProductsMain productsMainGroceries = new();

        [ObservableProperty]

        ProductUsage productUsageGroceries = new();

        [ObservableProperty]

        Store storeGroceries = new();

        [ObservableProperty]

        ProductArticleNrPrice productArticleNrPriceGroceries  = new();

        [ObservableProperty]

        ProductInfo productInfoGroceries = new();

        [ObservableProperty]

        public string titleSearch = "";

        public GroceriesViewModel(IServiceProvider serviceProvider) { _se = serviceProvider; }

        public GroceriesViewModel() { }


        [RelayCommand]

        public void ClearFields()
        {
            ProductsMainGroceries = new();
            ProductInfoGroceries = new();
            ProductArticleNrPriceGroceries = new();
            ProductUsageGroceries = new();
            StoreGroceries = new();
        }

        [RelayCommand]
        public void Add()
        {
            if (ProductsMainGroceries.NameOfProduct == "" | ProductsMainGroceries.NameOfProduct == null)
            {
                return;
            }


            Trace.WriteLine(ProductsMainGroceries.NameOfProduct);
            Trace.WriteLine(ProductsMainGroceries.Id);


            var service = _se!.GetService<ProductMainService>();


            var modified = ProductsMainGroceries.NameOfProduct!.ToLower();

            ProductsMainGroceries.NameOfProduct = modified;

            ProductArticleNrPriceGroceries.Stores.Add(StoreGroceries);
            ProductsMainGroceries.ProductArticleNrPrices.Add(ProductArticleNrPriceGroceries);
            ProductsMainGroceries.ProductUsages.Add(ProductUsageGroceries);
            ProductsMainGroceries.ProductInfos.Add(ProductInfoGroceries);


            var mainmodel = _se!.GetService<MainViewModel>();

            var productadded = _se!.GetService<ProductAddedAffirmationView>();

            var error = _se!.GetService<CombinationWarningGroceries>();


            if (service!.AddMainAndAllBelow(ProductsMainGroceries) == true)
            {

                mainmodel!.Window = productadded!;
                ClearFields();


            }
            else
            {

                mainmodel!.Window = error!;

                Trace.WriteLine("viewmodel error!");

            }

        }

        [RelayCommand]
        public void Remove()
        {

            ProductsMainGroceries.NameOfProduct = TitleSearch.ToLower();

            if (ProductsMainGroceries.NameOfProduct == "" | ProductsMainGroceries.NameOfProduct == null)
            {
                return;
            }

            var modified = ProductsMainGroceries.NameOfProduct!.ToLower();

            ProductsMainGroceries.NameOfProduct = modified;


            var mainmodel = _se!.GetService<MainViewModel>();

            var productremoved = _se!.GetService<RemoveProductView>();

            var error = _se!.GetService<CombinationWarningGroceries>();



            var service = _se!.GetService<ProductMainRepo>();

            var result = service!.Remove(x => x.NameOfProduct == ProductsMainGroceries.NameOfProduct);



            if (result == true)
            {
                Trace.WriteLine("Borttagningen gick bra!");
                mainmodel!.Window = productremoved!;
                TitleSearch = "";
            }
            else
            {
                mainmodel!.Window = error!;
                Trace.WriteLine("Viewmodel - borttagning gick ej bra!");
                TitleSearch = "";
            }
        }

        [RelayCommand]
        public void RemoveGrocery()
        {
            var productsearch = _se!.GetService<ProductSearchDeleteView>();

            _se!.GetService<MainViewModel>()!.Window = productsearch!;

        }

        [RelayCommand]
        public void UpdateRead()
        {

            ProductsMainGroceries.NameOfProduct = TitleSearch;

            if (ProductsMainGroceries.NameOfProduct == "" | ProductsMainGroceries.NameOfProduct == null)
            {
                return;
            }

            _se!.GetService<MainViewModel>()!.Window
                = _se!.GetService<UpdateProductViewFields>()!;


            var modified = ProductsMainGroceries.NameOfProduct!.ToLower();

            ProductsMainGroceries.NameOfProduct = modified;


            var service = _se!.GetService<ProductMainRepo>();
            var result = service!.Read(x => x.NameOfProduct == ProductsMainGroceries.NameOfProduct);



            if (result.NameOfProduct != null)
            {
                ProductsMainGroceries = result;

                    foreach (var items in result.ProductUsages)
                    {
                        ProductUsageGroceries = items;
                    }
                    foreach (var items in result.ProductArticleNrPrices)
                    {
                        ProductArticleNrPriceGroceries = items;

                        foreach (var itemss in items.Stores)
                        {
                            StoreGroceries = itemss;
                        }
                    }
                    foreach (var items in result.ProductInfos)
                    {
                        ProductInfoGroceries = items;
                    }

                

                Trace.WriteLine("Produkten hämtades!");
                TitleSearch = "";


            }
            else
            {
                Trace.WriteLine("Produkt finns ej!");
                TitleSearch = "";


            }

        }

        [RelayCommand]
        public void UpdateGrocery()
        {
            _se!.GetService<MainViewModel>()!.Window
                = _se!.GetService<ProductSearchUpdateView>()!;

        }

        [RelayCommand]
        public void UpdateGroceryOfficially()
        {

            if (ProductsMainGroceries.NameOfProduct == "" | ProductsMainGroceries.NameOfProduct == null)
            {
                return;
            }

            var services = _se!.GetService<ProductMainService>();

            var modified = ProductsMainGroceries.NameOfProduct!.ToLower();

            ProductsMainGroceries.NameOfProduct = modified;


            ProductArticleNrPriceGroceries.Stores.Add(StoreGroceries);
            ProductsMainGroceries.ProductArticleNrPrices.Add(ProductArticleNrPriceGroceries);
            ProductsMainGroceries.ProductUsages.Add(ProductUsageGroceries);
            ProductsMainGroceries.ProductInfos.Add(ProductInfoGroceries);

            var result = services!.UpdateProductMain(ProductsMainGroceries);


            if (result == true)
            {
                _se!.GetService<MainViewModel>()!.Window = _se!.GetService<ProductAddedAffirmationView>()!;
                Trace.WriteLine("Produkten uppdaterades!");
                ClearFields();

            }
            else
            {
                _se!.GetService<MainViewModel>()!.Window = _se!.GetService<CombinationWarningGroceries>()!;
                Trace.WriteLine("Något gick fel, produkt ej uppdaterad!");
                ClearFields();

            }

        }

        [RelayCommand]
        public void GetRead()
        {

            ProductsMainGroceries.NameOfProduct = TitleSearch;

            if (ProductsMainGroceries.NameOfProduct == "" | ProductsMainGroceries.NameOfProduct == null)
            {
                return;
            }

            var service = _se!.GetService<ProductMainRepo>();

            ProductsMainGroceries.NameOfProduct!.ToLower();

            var result = service!.Read(x => x.NameOfProduct == ProductsMainGroceries.NameOfProduct);
      

            if (result.NameOfProduct == ProductsMainGroceries.NameOfProduct)
            {
                var mainviewmodel = _se!.GetService<MainViewModel>();
                var addgroceriesview = _se!.GetService<GetGroceriesView>();

                mainviewmodel!.Window = addgroceriesview!;


                ProductsMainGroceries = result;

                  

                    foreach (var items in result.ProductUsages)
                    {
                        ProductUsageGroceries = items;
                    }
                    foreach (var items in result.ProductArticleNrPrices)
                    {
                        ProductArticleNrPriceGroceries = items;
                        foreach (var itemss in items.Stores)
                        {
                            StoreGroceries = itemss;
                        }
                    }
                    foreach (var items in result.ProductInfos)
                    {
                        ProductInfoGroceries = items;
                    }

                

                TitleSearch = "";

            }
            else
            {
                var mainviewmodel = _se!.GetService<MainViewModel>();
                mainviewmodel!.Window = _se!.GetService<CombinationWarningGroceries>()!;
                Trace.WriteLine("Fel i viewmodellen");

                TitleSearch = "";


            }


        }

        [RelayCommand]
        public void SearchGrocery()
        {
            var setsearch = _se!.GetService<ProductSearchView>();

            _se!.GetService<MainViewModel>()!.Window = setsearch!;

        }

        [RelayCommand]
        public void ReturnToMain()
        {
            _se!.GetService<MainViewModel>()!.Window = _se!.GetService<AddGroceriesView>()!;
            ClearFields();
        }


    }
}
