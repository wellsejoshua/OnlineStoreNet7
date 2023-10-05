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
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
