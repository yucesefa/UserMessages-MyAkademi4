using BusinessLayer.UserMessages.Abstract;
using DataAccessLayer.UserMessages.Abstract;
using EntityLayer.UserMessages.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.UserMessages.Concrete
{
    public class DraftManager : IDraftService
    {
        IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }

        public Draft TGetById(int id)
        {
            return _draftDal.GetById(id);
        }

        public List<Draft> TGetListAll()
        {
            return _draftDal.GetList();
        }

        public void TDelete(int id)
        {
            _draftDal.Delete(id);
        }

        public void TInsert(Draft t)
        {
            _draftDal.Insert(t);
        }

        public void TUptade(Draft t)
        {
            _draftDal.Update(t);
        }
    }
}
