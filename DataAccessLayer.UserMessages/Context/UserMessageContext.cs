using EntityLayer.UserMessages.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UserMessages.Context
{
    public class UserMessageContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=YUCESAFA\\SQLEXPRESS;initial catalog=DbUserMessage;integrated security=true;");
        }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<Draft> Drafts { get; set; }
    }
}
