using RecipeBookVisual.ModelsProducts;
using RecipeBookVisual.Repository.ProductRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.ServiceFolder.ProductService
{
    internal class StoreService
    {
        StoreRepo? _store;
        public StoreService(StoreRepo storeRepo) { _store = storeRepo; }



        public bool AddProductStore(string store)
        {
            Store main = new Store()
            {
                 FindInStoreName = store
            };

            var result = _store!.Add(main);

            return result;
        }

        public bool RemoveProductStore(string store)
        {
            var result = _store!.Remove(x => x.FindInStoreName == store);

            return result;
        }

        public bool UpdateProductStore(Store store)
        {
            var some = _store!.Update(x => x.FindInStoreName == store.FindInStoreName, store);

            return some;
        }

        public Store ReadProductStore(string store)
        {
            var result = _store!.Read(x => x.FindInStoreName == store);

            return result!;
        }

        public IEnumerable<Store> ReadAllProductStore()
        {
            var result = _store!.ReadAll();

            return result!;
        }
    }
}
