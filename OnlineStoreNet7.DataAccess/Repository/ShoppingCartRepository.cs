using OnlineStoreFrontNet7.DataAccess.Data;
using OnlineStoreFrontNet7.Models;
using OnlineStoreNet7.DataAccess.Repository.IRepository;
using OnlineStoreNet7.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreNet7.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext _context;

        public ShoppingCartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(ShoppingCart obj) 
        {
            _context.ShoppingCarts.Update(obj);
        }
    }
}
