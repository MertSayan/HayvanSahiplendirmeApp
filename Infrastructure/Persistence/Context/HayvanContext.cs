using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class HayvanContext:DbContext
    {
        public HayvanContext(DbContextOptions<HayvanContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<PetComment> PetComments { get; set; }
        public DbSet<PetLike> PetLikes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequests { get; set; }
        public DbSet<AdoptionTracking> AdoptionTrackings { get; set; }
        public DbSet<PetImage> PetImages { get; set; }
        public DbSet<PetFavorite> PetFavorites { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // (1) Primary Key’ler – EF Core konvansiyonla da yakalar, ama açıklık açısından ekleyebiliriz
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Role>().HasKey(r => r.RoleId);
            modelBuilder.Entity<Pet>().HasKey(p => p.PetId);
            modelBuilder.Entity<PetType>().HasKey(pt => pt.PetTypeId);
            modelBuilder.Entity<PetComment>().HasKey(pc => pc.PetCommentId);
            modelBuilder.Entity<PetLike>()
                .HasKey(pl => new { pl.PetId, pl.UserId });
            modelBuilder.Entity<Message>().HasKey(m => m.MessageId);
            modelBuilder.Entity<AdoptionRequest>().HasKey(ar => ar.AdoptionRequestId);
            modelBuilder.Entity<AdoptionTracking>().HasKey(at => at.AdoptionTrackingId);
            modelBuilder.Entity<PetFavorite>()
                .HasKey(pf => new { pf.PetId, pf.UserId });

            // (2) User ↔ Role (1-N)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()                   // Role içinde User listesi yoksa boş bırak, varsa .WithMany(r=>r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // (3) User ↔ Pet (1-N)
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.User)
                .WithMany(u => u.Pets)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // (4) Pet ↔ PetType (1-N)
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.PetType)
                .WithMany(pt => pt.Pets)
                .HasForeignKey(p => p.PetTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // (5) Pet ↔ PetComment (1-N)
            modelBuilder.Entity<PetComment>()
                .HasOne(pc => pc.Pet)
                .WithMany(p => p.PetComments)
                .HasForeignKey(pc => pc.PetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PetComment>()
                .HasOne(pc => pc.User)
                .WithMany(u => u.PetComments)
                .HasForeignKey(pc => pc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // (6) Pet ↔ PetLike (1-N)

            


            modelBuilder.Entity<PetLike>()
                .HasOne(pl => pl.Pet)
                .WithMany(p => p.PetLikes)
                .HasForeignKey(pl => pl.PetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PetLike>()
                .HasOne(pl => pl.User)
                .WithMany(u => u.PetLikes)
                .HasForeignKey(pl => pl.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // (7) Message ↔ User (Gönderen / Alıcı)
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            // (8) AdoptionRequest ↔ Pet, Sender, Owner
            modelBuilder.Entity<AdoptionRequest>()
                .HasOne(ar => ar.Pet)
                .WithMany(p => p.AdoptionRequests)
                .HasForeignKey(ar => ar.PetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AdoptionRequest>()
                .HasOne(ar => ar.Sender)
                .WithMany(u => u.SentRequests)
                .HasForeignKey(ar => ar.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AdoptionRequest>()
                .HasOne(ar => ar.Owner)
                .WithMany(u => u.ReceivedRequests)
                .HasForeignKey(ar => ar.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // (9) AdoptionTracking ↔ AdoptionRequest (1-N)
            modelBuilder.Entity<AdoptionTracking>()
                .HasOne(at => at.AdoptionRequest)
                .WithMany(ar => ar.Trackings)
                .HasForeignKey(at => at.AdoptionRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            // (10) Pet ↔ PetImage (1-N)
            modelBuilder.Entity<PetImage>()
                .HasOne(pi => pi.Pet)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.PetId)
                .OnDelete(DeleteBehavior.Cascade);

           
            // (11) pet-petfavoritte ( 1- N )
            modelBuilder.Entity<PetFavorite>()
                .HasOne(f => f.Pet)
                .WithMany(p => p.PetFavorites)
                .HasForeignKey(f => f.PetId)
                .OnDelete(DeleteBehavior.Cascade);
            // (12) user-petfavoritte (1-N)
            modelBuilder.Entity<PetFavorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.PetFavorites)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
