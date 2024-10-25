using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost,1442;initial Catalog=MultiShopCommentDb;User Id=sa;Password=123456aA*");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
