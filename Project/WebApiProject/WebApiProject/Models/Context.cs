using Lab1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiProject.DTO;

namespace WebApiProject.Models
{
    public class Context: IdentityDbContext<ApplicationUser>
    {
        public Context() { }
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Job> Job { get; set; }
        public DbSet<Contract> Cotract { get; set; }
        public DbSet<Message> Message { get; set; }

        public DbSet<Payment> Payment { get; set; }
        public DbSet<Proposal> Proposal { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Profile> profile{ get; set; }
        public DbSet<Skills> Skills{ get; set; }
        public DbSet<Languges> Languges{ get; set; }
        public DbSet<Education> educations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Hire> Hire { get; set; }



        //public DbSet<ProfileDTO> profileDTO { get; set; }
        // public DbSet<ProfileDataDTO> ProfileDataDTO { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-C91LV05\SQL19;Initial Catalog=WorkAnyTime;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<skillsprofile>().HasNoKey();
        //}
    }
}
