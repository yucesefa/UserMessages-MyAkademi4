using DataAccessLayer.UserMessages.Abstract;
using DataAccessLayer.UserMessages.Repository;
using EntityLayer.UserMessages.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UserMessages.Entity_Framework
{
    public class EfUserMessageDal : GenericRepository<UserMessage> , IUserMessageDal
    {
    }
}
