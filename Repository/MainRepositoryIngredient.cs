using RecipeBookVisual.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookVisual.Repository
{
    public class MainRepositoryIngredient<Tentity> where Tentity : class
    {

        IngredientContext? _context;

        public MainRepositoryIngredient(IngredientContext ingredientContext) { _context = ingredientContext; }


        public virtual bool Add(Tentity tentity) 
        {
            var add = _context!.Set<Tentity>().Add(tentity);
            var result = _context.SaveChanges();

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
            var result = _context!.Set<Tentity>().FirstOrDefault(expression);
            _context.Remove(result!);
            var results = _context.SaveChanges();

            if (results != 0)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public virtual bool Update(Expression<Func<Tentity, bool>> expression, Tentity tentity) 
        {
            var result = _context!.Set<Tentity>().FirstOrDefault(expression);

            if (result != null) 
            {
                _context.Entry(result!).CurrentValues.SetValues(tentity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public virtual Tentity Read(Expression<Func<Tentity, bool>> expression) 
        {
            var result = _context!.Set<Tentity>().FirstOrDefault(expression);
            return result!;
        }

        public virtual IEnumerable<Tentity> ReadAll()
        {
            var result = _context!.Set<Tentity>().ToList();
            return result;
        }




    }
}
