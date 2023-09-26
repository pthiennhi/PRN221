using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoriesDAO
    {
        public List<Category> getCategories()
        {
            var context = new MyStoreContext();

            var categories = context.Categories.ToList();

            return categories;
        }
    }
}
