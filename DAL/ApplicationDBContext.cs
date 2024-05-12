using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ApplicationDBContext()
        {
           
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
             
        }

        public DbSet<Pet> Pet { get; set; }
        public DbSet<Vet> Vet { get; set; }
        public DbSet<Claim> Claim { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<MedicineCard> MedicineCard { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Reception> Reception { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceVisit> ServiceVisit { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Visit> Visit { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        //Note
        modelBuilder.Entity<Note>()
                .HasOne(n => n.Diagnosis) // Один к одному
                .WithMany(d => d.Notes)   // Один ко многим
                .HasForeignKey(n => n.IdDiagnosis); // Внешний ключ

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Claim) 
                .WithMany(d => d.Notes)   
                .HasForeignKey(n => n.IdClaim); 

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Medicine)
                .WithMany(d => d.Notes)   
                .HasForeignKey(n => n.IdMedicine); 

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Vet) 
                .WithMany(d => d.Notes)
                .HasForeignKey(n => n.IdVet);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.MedicineCard)
                .WithMany(d => d.Notes)
                .HasForeignKey(n => n.IdMedicineCard);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Visit)
                .WithMany(d => d.Notes)
                .HasForeignKey(n => n.IdVisit)
                .OnDelete(DeleteBehavior.Restrict);

            //Pet
            modelBuilder.Entity<Pet>()
                .HasOne(n => n.Owner)
                .WithMany(d => d.Pets)
                .HasForeignKey(n => n.IdOwner);

            modelBuilder.Entity<Pet>()
                .HasOne(n => n.Species)
                .WithMany(d => d.Pets)
                .HasForeignKey(n => n.IdSpecies);

            //Reception
            modelBuilder.Entity<Reception>()
                .HasOne(n => n.Owner)
                .WithMany(d => d.Receptions)
                .HasForeignKey(n => n.IdOwner);

            modelBuilder.Entity<Reception>()
                .HasOne(n => n.Vet)
                .WithMany(d => d.Receptions)
                .HasForeignKey(n => n.IdVet);

            //Visit
            modelBuilder.Entity<Visit>()
                .HasOne(n => n.Vet)
                .WithMany(d => d.Visities)
                .HasForeignKey(n => n.IdVet);

            modelBuilder.Entity<Visit>()
               .HasOne(n => n.Pet)
               .WithMany(d => d.Visities)
               .HasForeignKey(n => n.IdPet);

            //ServiceVisit
            modelBuilder.Entity<ServiceVisit>()
                .HasOne(n => n.Visit)
                .WithMany(d => d.ServiceVisities)
                .HasForeignKey(n => n.IdVisit);

            modelBuilder.Entity<ServiceVisit>()
                .HasOne(n => n.Service)
                .WithMany(d => d.ServiceVisities)
                .HasForeignKey(n => n.IdService);

            //MedicineCard
            modelBuilder.Entity<MedicineCard>()
                .HasOne(n => n.Pet)
                .WithOne(p => p.MedicineCard)
                .HasForeignKey<Pet>(p => p.Id);
        }
    }
}

