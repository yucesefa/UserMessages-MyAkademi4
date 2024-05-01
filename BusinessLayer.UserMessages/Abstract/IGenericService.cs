using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.UserMessages.Abstract
{
    public interface IGenericService <T>
    {
        void TInsert(T t);
        void TUptade(T t);
        void TDelete(int id);

        List<T> TGetListAll();
        T TGetById(int id);
    }
}
