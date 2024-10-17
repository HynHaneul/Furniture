using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Furniture.Models.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Furniture.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("WoodenFurniture") { }
        public DbSet<Category> categories { get; set; }
        public DbSet<Advertisement> advertisements { get; set; }
        public DbSet<Post>posts { get; set; }   
        public DbSet <News> news { get; set; }
        public DbSet<System_Setting> system_Settings { get; set; }
        public DbSet <C_Product> products { get; set; }
        public DbSet<Product_Category>  productCategories { get; set; }
        public DbSet <Contact> contacts { get; set; }
        public DbSet<C_Order> orders { get; set; }
        public DbSet<Order_Details> orderDetails { get; set; }
        public DbSet <Subscribe> subscribes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}