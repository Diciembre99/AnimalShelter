using System;
using System.Collections.Generic;
using AnimalShelterWPF.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Controllers.Data;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adoption> Adoptions { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Shelter> Shelters { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCataloge> UserCataloges { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)        => optionsBuilder.UseNpgsql("Host=localhost;Database=ShelterDB;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adoption>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("adoption_pkey");

            entity.ToTable("adoption");

            entity.HasIndex(e => e.PetId, "IX_adoption_pet_id");

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

            entity.HasIndex(e => e.IdPet, "IX_appointment_id_pet");

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

            entity.HasIndex(e => e.IdShelter, "IX_donation_id_shelter");

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

            entity.HasIndex(e => e.IdShelter, "IX_items_id_shelter");

            entity.Property(e => e.IdItem)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_item");
            entity.Property(e => e.AnimalType)
                .HasMaxLength(20)
                .HasColumnName("animal_type");
            entity.Property(e => e.IdShelter).HasColumnName("id_shelter");
            entity.Property(e => e.ImgItem).HasColumnName("imgItem");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
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

            entity.HasIndex(e => e.IdRol, "IX_permissions_id_rol");

            entity.HasIndex(e => e.IdUser, "IX_permissions_id_user");

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

            entity.HasIndex(e => e.IdShelter, "IX_pet_id_shelter");

            entity.Property(e => e.IdPet)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_pet");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.DateEntry).HasColumnName("date_entry");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Esterilization)
                .HasMaxLength(1)
                .HasColumnName("esterilization");
            entity.Property(e => e.Genre)
                .HasMaxLength(1)
                .HasColumnName("genre");
            entity.Property(e => e.Hair).HasColumnName("hair");
            entity.Property(e => e.IdShelter).HasColumnName("id_shelter");
            entity.Property(e => e.MedicalHistory).HasColumnName("medical_history");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Numchip).HasColumnName("numchip");
            entity.Property(e => e.Race)
                .HasMaxLength(20)
                .HasColumnName("race");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Species).HasColumnName("species");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
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
                .HasMaxLength(1)
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

            entity.HasIndex(e => e.IdCataloge, "IX_users_id_cataloge");

            entity.HasIndex(e => e.IdShelter, "IX_users_id_shelter");

            entity.Property(e => e.IdUser)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_user");
            entity.Property(e => e.Dni)
                .HasMaxLength(11)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("dni");
            entity.Property(e => e.IdCataloge)
                .HasDefaultValue(0)
                .HasColumnName("id_cataloge");
            entity.Property(e => e.IdShelter)
                .HasDefaultValue(0)
                .HasColumnName("id_shelter");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasDefaultValueSql("''::character varying")
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
                .HasMaxLength(1)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
