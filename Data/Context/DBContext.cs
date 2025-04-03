

using Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

      
        #region User

        
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> userDetails { get; set; }
       



        #endregion

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDeleted);
              
            
     

            base.OnModelCreating(modelBuilder);
        }
     

    }

   
}
