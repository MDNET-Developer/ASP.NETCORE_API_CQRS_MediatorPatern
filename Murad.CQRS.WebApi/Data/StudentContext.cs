using Microsoft.EntityFrameworkCore;

namespace Murad.CQRS.WebApi.Data
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options):base(options)
        {
                    
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[] {
            new(){Id=1,Name="Murad",Surname="Aliyev",age=21},
            new(){Id=2,Name="Osman",Surname="Bashirov",age=21},
            new(){Id=3,Name="Parviz",Surname="Yunisli",age=21},
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
