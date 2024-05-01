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
    public class UserMessageManager : IUserMessageService
    {
        IUserMessageDal _userMessageDal;

        public UserMessageManager(IUserMessageDal userMessageDal)
        {
            _userMessageDal = userMessageDal;
        }

        public List<UserMessage> GetListDeleteMessage()
        {
            return _userMessageDal.GetByFilter(x => x.Status == false);
        }

        public List<UserMessage> GetListReceiverMessage(string p)
        {
            return _userMessageDal.GetByFilter(x => x.ReceiverMail ==p  && x.Status == true && x.IsDraft == false);
        }

        public List<UserMessage> GetListSenderMessage(string p)
        {
            return _userMessageDal.GetByFilter(x => x.SenderMail == p && x.Status == true && x.IsDraft == false);
        }

        public void TDelete(int id)
        {
            _userMessageDal.Delete(id);
        }

        public UserMessage TGetById(int id)
        {
            return _userMessageDal.GetById(id);
        }

        public List<UserMessage> TGetListAll()
        {
            return _userMessageDal.GetList();
        }

        public void TInsert(UserMessage t)
        {
            _userMessageDal.Insert(t);
        }

        public void TUptade(UserMessage t)
        {
            _userMessageDal.Update(t);
        }
    }
}
