using OnlineStoreFrontNet7.DataAccess.Data;
using OnlineStoreFrontNet7.Models;
using OnlineStoreNet7.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreNet7.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category obj) 
        {
            _context.Categories.Update(obj);
        }
    }
}
