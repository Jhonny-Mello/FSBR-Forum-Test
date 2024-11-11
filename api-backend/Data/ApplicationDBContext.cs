using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Post>(x => x.HasKey(p => new { p.AppUserId, p.Id }));
            builder.Entity<Post>()
                    .Property(f => f.Id)
                    .ValueGeneratedOnAdd(); ;

            builder.Entity<Post>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<Post>()
                .HasMany(u => u.Comentarios)
                .WithOne(u => u.Post)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Post>()
                .HasMany(u => u.Avaliacoes)
                .WithOne(x => x.Post)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.Entity<Comentario>()
                .HasMany(u => u.Avaliacoes)
                .WithOne(x => x.Comentario)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(p => p.CommentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            //builder.Entity<Avaliacao>()
            //.HasOne(u => u.AppUser)
            //.WithMany(x => x.Avaliacao)
            //.HasPrincipalKey(x => x.Id)
            //.HasForeignKey(p => p.AppUserId)
            //.OnDelete(DeleteBehavior.NoAction);

            string adminroleid = "2c5e174e-3b0e-446f-86af-483d56fd7210";
            string adminuserid = "8e445865-a24d-4543-a6c6-9443d048cdb9";

            var userroleid = Guid.NewGuid();
            var useruserid = Guid.NewGuid();

            //eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Impob25ueW1lbGxvNTA1QGdtYWlsLmNvbSIsImdpdmVuX25hbWUiOiJqaG9ubnkiLCJuYmYiOjE3MzEyNzczNzMsImV4cCI6MTczMTg4MjE3MywiaWF0IjoxNzMxMjc3MzczLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUyNDYiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUyNDYifQ.JLx35O0skRu2snKfle_E6tmqXLCKS2e6NiwQ-AL-Vm7GqWnrSyoq0PC2WfuGa-z4S51xTBcsa7NheoYqE9SgLw

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Id = adminroleid
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = userroleid.ToString()
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);


            var hasher = new PasswordHasher<AppUser>();

            List<AppUser> users = new List<AppUser>
           {
               new AppUser
                {
                    Id = adminuserid,
                    UserName = "Jhonny",
                    NormalizedUserName = "Jhonny Mello",
                    PasswordHash = hasher.HashPassword(null, "Apenas_umt4st4de$senh4")
                },
                new AppUser
                {
                    Id = useruserid.ToString(),
                    UserName = "Heloyza",
                    NormalizedUserName = "Heloyza Morais",
                    PasswordHash = hasher.HashPassword(null, "Jesuse10-90w74hj")
                }
           };
            builder.Entity<AppUser>().HasData(users);


            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminroleid,
                    UserId = adminuserid
                }
            );


            var newpost = Guid.NewGuid();

            List<Post> posts = new List<Post>
            {
                new Post
                {
                    Id = newpost,
                    AppUserId = adminuserid,
                    Tema = "Apenas um novo tema inserido diretamente do migration pelo meu usuário ADM",
                    PostContent = "Esta publicação foi adicionada diretamente pelo migration do entity framework",
                    CreatedOn = DateTime.Now
                }
            };

            List<Comentario> comentarios = new List<Comentario>
            {
                new Comentario
                {
                    Id = Guid.NewGuid(),
                    AppUserId = useruserid.ToString(),
                    PostId = newpost,
                    Content = "Apenas um comentário inserido diramente do migration",
                    CreatedOn = DateTime.Now
                },
                new Comentario
                {
                    Id = Guid.NewGuid(),
                    AppUserId = useruserid.ToString(),
                    PostId = newpost,
                    Content = "Apenas outro comentário inserido diramente do migration",
                    CreatedOn = DateTime.Now
                }
            };

            List<Avaliacao> avaliacaos = [];

            var rnd = new Random();
            for (int i = 0; i < 30; i++)
            {
                var avl = new Avaliacao
                {
                    Id = Guid.NewGuid(),
                    AppUserId = adminuserid,
                    PostId = newpost,
                    Value = rnd.Next(1, 5),
                    CreatedOn = DateTime.Now
                };

                avaliacaos.Add(avl);
            }

            builder.Entity<Post>().HasData(posts);
            builder.Entity<Comentario>().HasData(comentarios);
            builder.Entity<Avaliacao>().HasData(avaliacaos);
        }
    }
}