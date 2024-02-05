using Microsoft.EntityFrameworkCore;
using RecipeBookVisual.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.Repository
{
    public class MainRepositoryProduct<Tentity> where Tentity : class
    {
        ProductContext? _productContext;

        public MainRepositoryProduct(ProductContext? productContext)
        {
            _productContext = productContext;
        }




        public virtual bool Add(Tentity tentity)
        {
            var add = _productContext!.Set<Tentity>().Add(tentity);
            var result = _productContext.SaveChanges();

            if (result != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool Remove(Expression<Func<Tentity, bool>> expression)
        {
            var result = _productContext!.Set<Tentity>().FirstOrDefault(expression);
            _productContext.Remove(result!);
            var results = _productContext.SaveChanges();

            if (results != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool Update(Expression<Func<Tentity, bool>> expression, Tentity tentity)
        {
            var result = _productContext!.Set<Tentity>().FirstOrDefault(expression);

            if (result != null)
            {
                _productContext.Entry(result!).CurrentValues.SetValues(tentity);
                _productContext.SaveChanges();
                return true;
            }

            return false;
        }

        public virtual Tentity Read(Expression<Func<Tentity, bool>> expression)
        {
            var result = _productContext!.Set<Tentity>().FirstOrDefault(expression);
            return result!;
        }

        public virtual IEnumerable<Tentity> ReadAll()
        {
            var result = _productContext!.Set<Tentity>().ToList();
            return result;
        }


    }
}
