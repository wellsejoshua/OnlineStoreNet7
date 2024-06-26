﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreNet7.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T - Category or any other generic model on which we want to perform curd opperations or interact with database
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, string? includeProperties = null);
        //general syntax for first or dafault with linq
        //ITEMS FROM GET ARE NOT TRACKED TO AVOID SHOPPING CART UPDATE PROBLEMS!!!
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);

    }
}
