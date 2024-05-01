using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UserMessages.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T t);
        void Delete(int id);
        void Update(T t);
        List<T> GetList();
        T GetById(int id);
        List<T> GetByFilter(Expression<Func<T,bool>> filter);
    }
}
