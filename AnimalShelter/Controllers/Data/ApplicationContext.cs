using AnimalShelterWPF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers.Data
{
    public partial class ApplicationContext : DbContext
    {
        public DbSet<Adoption> Adoptions { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Donation> Donations { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Rol> Rols { get; set; }

        public DbSet<Shelter> Shelters { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserCataloge> UserCataloges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("ShelterDB"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adoption>(entity =>
            {
                entity.HasKey(e => e.IdUser).HasName("adoption_pkey");

                entity.ToTable("adoption");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user");
                entity.Property(e => e.DateAdoption).HasColumnName("date_adoption");
                entity.Property(e => e.IdAdoption)
                    .ValueGeneratedOnAdd()
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id_adoption");
                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.HasOne(d => d.IdUserNavigation).WithOne(p => p.Adoption)
                    .HasForeignKey<Adoption>(d => d.IdUser)
                    .HasConstraintName("adoption_id_user_fkey");

                entity.HasOne(d => d.Pet).WithMany(p => p.Adoptions)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pet_id");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.IdAppoitment).HasName("appointment_pkey");

                entity.ToTable("appointment");

                entity.Property(e => e.IdAppoitment)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id_appoitment");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.IdPet).HasColumnName("id_pet");
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");
                entity.Property(e => e.Veterinary)
                    .HasColumnType("character varying")
                    .HasColumnName("veterinary");

                entity.HasOne(d => d.IdPetNavigation).WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdPet)
                    .HasConstraintName("appointment_id_pet_fkey");
            });

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.HasKey(e => e.IdDonation).HasName("donation_pkey");

                entity.ToTable("donation");

                entity.Property(e => e.IdDonation)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id_donation");
                entity.Property(e => e.DateDonation).HasColumnName("date_donation");
                entity.Property(e => e.Donor)
                    .HasMaxLength(20)
                    .HasColumnName("donor");
                entity.Property(e => e.IdShelter).HasColumnName("id_shelter");
                entity.Property(e => e.Quantity)
                    .HasColumnType("money")
                    .HasColumnName("quantity");
                entity.Property(e => e.TypeDonation)
                    .HasMaxLength(20)
                    .HasColumnName("type_donation");

                entity.HasOne(d => d.IdShelterNavigation).WithMany(p => p.Donations)
                    .HasForeignKey(d => d.IdShelter)
                    .HasConstraintName("donation_id_shelter_fkey");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.IdItem).HasName("items_pkey");

                entity.ToTable("items");

                entity.Property(e => e.IdItem)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id_item");
                entity.Property(e => e.AnimalType)
                    .HasMaxLength(20)
                    .HasColumnName("animal_type");
                entity.Property(e => e.IdShelter).HasColumnName("id_shelter");
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");
                entity.Property(e => e.Status)
                    .HasColumnType("char")
                    .HasColumnName("status");
                entity.Property(e => e.Stock).HasColumnName("stock");
                entity.Property(e => e.TypeItem)
                    .HasMaxLength(20)
                    .HasColumnName("type_item");

                entity.HasOne(d => d.IdShelterNavigation).WithMany(p => p.Items)
                    .HasForeignKey(d => d.IdShelter)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("items_id_shelter_fkey");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.IdPermission).HasName("permissions_pkey");

                entity.ToTable("permissions");

                entity.Property(e => e.IdPermission)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id_permission");
                entity.Property(e => e.IdRol).HasColumnName("id_rol");
                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("permissions_id_rol_fkey");

                entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("permissions_id_user_fkey");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.IdPet).HasName("pet_pkey");

                entity.ToTable("pet");

                entity.Property(e => e.IdPet)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id_pet");
                entity.Property(e => e.Age).HasColumnName("age");
                entity.Property(e => e.DateEntry).HasColumnName("date_entry");
                entity.Property(e => e.Genre)
                    .HasMaxLength(1)
                    .HasColumnName("genre");
                entity.Property(e => e.IdShelter).HasColumnName("id_shelter");
                entity.Property(e => e.MedicalHistory).HasColumnName("medical_history");
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");
                entity.Property(e => e.Race)
                    .HasMaxLength(20)
                    .HasColumnName("race");
                entity.Property(e => e.Status)
                    .HasColumnType("char")
                    .HasColumnName("status");

                entity.HasOne(d => d.IdShelterNavigation).WithMany(p => p.Pets)
                    .HasForeignKey(d => d.IdShelter)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pet_id_shelter_fkey");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol).HasName("rol_pkey");

                entity.ToTable("rol");

                entity.Property(e => e.IdRol)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id_rol");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");
                entity.Property(e => e.Type)
                    .HasColumnType("char")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Shelter>(entity =>
            {
                entity.HasKey(e => e.IdShelter).HasName("Shelter_pkey");

                entity.ToTable("Shelter");

                entity.Property(e => e.IdShelter)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id_shelter");
                entity.Property(e => e.Cif)
                    .HasMaxLength(11)
                    .HasColumnName("cif");
                entity.Property(e => e.Direccion).HasColumnName("direccion");
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser).HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.IdUser)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id_user");
                entity.Property(e => e.Dni)
                    .HasMaxLength(11)
                    .HasColumnName("dni");
                entity.Property(e => e.IdCataloge).HasColumnName("id_cataloge");
                entity.Property(e => e.IdShelter).HasColumnName("id_shelter");
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");
                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");
                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .HasColumnName("telephone");
                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdCatalogeNavigation).WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdCataloge)
                    .HasConstraintName("id_cataloge");

                entity.HasOne(d => d.IdShelterNavigation).WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdShelter)
                    .HasConstraintName("users_id_shelter_fkey");
            });

            modelBuilder.Entity<UserCataloge>(entity =>
            {
                entity.HasKey(e => e.IdCataloge).HasName("user_cataloge_pkey");

                entity.ToTable("user_cataloge");

                entity.Property(e => e.IdCataloge)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id_cataloge");
                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .HasColumnName("description");
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");
                entity.Property(e => e.Type)
                    .HasColumnType("char")
                    .HasColumnName("type");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);   
    }
}
