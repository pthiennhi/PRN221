using BussinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoriesRepository: ICategoriesRepository
    {
        public List<Category> GetCategories() => new CategoriesDAO() .getCategories ();
    }
}
