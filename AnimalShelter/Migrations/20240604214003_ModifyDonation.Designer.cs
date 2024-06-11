﻿// <auto-generated />
using System;
using AnimalShelter.Controllers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimalShelter.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240604214003_ModifyDonation")]
    partial class ModifyDonation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AnimalShelterWPF.Models.Adoption", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("integer")
                        .HasColumnName("id_user");

                    b.Property<TimeOnly>("DateAdoption")
                        .HasColumnType("time without time zone")
                        .HasColumnName("date_adoption");

                    b.Property<int>("IdAdoption")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_adoption");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdAdoption"));

                    b.Property<int>("PetId")
                        .HasColumnType("integer")
                        .HasColumnName("pet_id");

                    b.HasKey("IdUser")
                        .HasName("adoption_pkey");

                    b.HasIndex("PetId");

                    b.ToTable("adoption", (string)null);
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Appointment", b =>
                {
                    b.Property<int>("IdAppoitment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_appoitment");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdAppoitment"));

                    b.Property<string>("Date")
                        .HasColumnType("text")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("IdPet")
                        .HasColumnType("integer")
                        .HasColumnName("id_pet");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<string>("Time")
                        .HasColumnType("text");

                    b.Property<string>("Veterinary")
                        .HasColumnType("character varying")
                        .HasColumnName("veterinary");

                    b.HasKey("IdAppoitment")
                        .HasName("appointment_pkey");

                    b.HasIndex("IdPet");

                    b.ToTable("appointment", (string)null);
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Donation", b =>
                {
                    b.Property<int>("IdDonation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_donation");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdDonation"));

                    b.Property<string>("DateDonation")
                        .HasColumnType("text")
                        .HasColumnName("date_donation");

                    b.Property<string>("Donor")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("donor");

                    b.Property<int>("IdShelter")
                        .HasColumnType("integer")
                        .HasColumnName("id_shelter");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("money")
                        .HasColumnName("quantity");

                    b.Property<string>("TypeDonation")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("type_donation");

                    b.HasKey("IdDonation")
                        .HasName("donation_pkey");

                    b.HasIndex("IdShelter");

                    b.ToTable("donation", (string)null);
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Item", b =>
                {
                    b.Property<int>("IdItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_item");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdItem"));

                    b.Property<string>("AnimalType")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("animal_type");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("IdShelter")
                        .HasColumnType("integer")
                        .HasColumnName("id_shelter");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<float?>("Price")
                        .HasColumnType("real");

                    b.Property<char?>("Status")
                        .HasColumnType("char")
                        .HasColumnName("status");

                    b.Property<int?>("Stock")
                        .HasColumnType("integer")
                        .HasColumnName("stock");

                    b.Property<string>("TypeItem")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("type_item");

                    b.Property<string>("imgItem")
                        .HasColumnType("text");

                    b.HasKey("IdItem")
                        .HasName("items_pkey");

                    b.HasIndex("IdShelter");

                    b.ToTable("items", (string)null);
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Permission", b =>
                {
                    b.Property<int>("IdPermission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_permission");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdPermission"));

                    b.Property<int?>("IdRol")
                        .HasColumnType("integer")
                        .HasColumnName("id_rol");

                    b.Property<int?>("IdUser")
                        .HasColumnType("integer")
                        .HasColumnName("id_user");

                    b.HasKey("IdPermission")
                        .HasName("permissions_pkey");

                    b.HasIndex("IdRol");

                    b.HasIndex("IdUser");

                    b.ToTable("permissions", (string)null);
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Pet", b =>
                {
                    b.Property<int>("IdPet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_pet");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdPet"));

                    b.Property<string>("Age")
                        .HasColumnType("text")
                        .HasColumnName("age");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<string>("DateEntry")
                        .HasColumnType("text")
                        .HasColumnName("date_entry");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<char?>("Esterilization")
                        .HasColumnType("character(1)");

                    b.Property<char?>("Genre")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("genre");

                    b.Property<string>("Hair")
                        .HasColumnType("text");

                    b.Property<int?>("IdShelter")
                        .HasColumnType("integer")
                        .HasColumnName("id_shelter");

                    b.Property<string>("ImgItem")
                        .HasColumnType("text");

                    b.Property<string>("MedicalHistory")
                        .HasColumnType("text")
                        .HasColumnName("medical_history");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<string>("NumChip")
                        .HasColumnType("text");

                    b.Property<string>("Race")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("race");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.Property<string>("Species")
                        .HasColumnType("text");

                    b.Property<char?>("Status")
                        .HasColumnType("char")
                        .HasColumnName("status");

                    b.HasKey("IdPet")
                        .HasName("pet_pkey");

                    b.HasIndex("IdShelter");

                    b.ToTable("pet", (string)null);
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_rol");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<char>("Type")
                        .HasColumnType("char")
                        .HasColumnName("type");

                    b.HasKey("IdRol")
                        .HasName("rol_pkey");

                    b.ToTable("rol", (string)null);
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Shelter", b =>
                {
                    b.Property<int>("IdShelter")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_shelter");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdShelter"));

                    b.Property<string>("Cif")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("cif");

                    b.Property<string>("Direccion")
                        .HasColumnType("text")
                        .HasColumnName("direccion");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.HasKey("IdShelter")
                        .HasName("Shelter_pkey");

                    b.ToTable("Shelter", (string)null);
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_user");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdUser"));

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("dni");

                    b.Property<int>("IdCataloge")
                        .HasColumnType("integer")
                        .HasColumnName("id_cataloge");

                    b.Property<int>("IdShelter")
                        .HasColumnType("integer")
                        .HasColumnName("id_shelter");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("password");

                    b.Property<string>("Telephone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("telephone");

                    b.Property<string>("Username")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("username");

                    b.HasKey("IdUser")
                        .HasName("users_pkey");

                    b.HasIndex("IdCataloge");

                    b.HasIndex("IdShelter");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.UserCataloge", b =>
                {
                    b.Property<int>("IdCataloge")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_cataloge");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdCataloge"));

                    b.Property<string>("Description")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<char>("Type")
                        .HasColumnType("char")
                        .HasColumnName("type");

                    b.HasKey("IdCataloge")
                        .HasName("user_cataloge_pkey");

                    b.ToTable("user_cataloge", (string)null);
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Adoption", b =>
                {
                    b.HasOne("AnimalShelterWPF.Models.User", "IdUserNavigation")
                        .WithOne("Adoption")
                        .HasForeignKey("AnimalShelterWPF.Models.Adoption", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("adoption_id_user_fkey");

                    b.HasOne("AnimalShelterWPF.Models.Pet", "Pet")
                        .WithMany("Adoptions")
                        .HasForeignKey("PetId")
                        .IsRequired()
                        .HasConstraintName("pet_id");

                    b.Navigation("IdUserNavigation");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Appointment", b =>
                {
                    b.HasOne("AnimalShelterWPF.Models.Pet", "IdPetNavigation")
                        .WithMany("Appointments")
                        .HasForeignKey("IdPet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("appointment_id_pet_fkey");

                    b.Navigation("IdPetNavigation");
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Donation", b =>
                {
                    b.HasOne("AnimalShelterWPF.Models.Shelter", "IdShelterNavigation")
                        .WithMany("Donations")
                        .HasForeignKey("IdShelter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("donation_id_shelter_fkey");

                    b.Navigation("IdShelterNavigation");
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Item", b =>
                {
                    b.HasOne("AnimalShelterWPF.Models.Shelter", "IdShelterNavigation")
                        .WithMany("Items")
                        .HasForeignKey("IdShelter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("items_id_shelter_fkey");

                    b.Navigation("IdShelterNavigation");
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Permission", b =>
                {
                    b.HasOne("AnimalShelterWPF.Models.Rol", "IdRolNavigation")
                        .WithMany("Permissions")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("permissions_id_rol_fkey");

                    b.HasOne("AnimalShelterWPF.Models.User", "IdUserNavigation")
                        .WithMany("Permissions")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("permissions_id_user_fkey");

                    b.Navigation("IdRolNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Pet", b =>
                {
                    b.HasOne("AnimalShelterWPF.Models.Shelter", "IdShelterNavigation")
                        .WithMany("Pets")
                        .HasForeignKey("IdShelter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("pet_id_shelter_fkey");

                    b.Navigation("IdShelterNavigation");
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.User", b =>
                {
                    b.HasOne("AnimalShelterWPF.Models.UserCataloge", "IdCatalogeNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdCataloge")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("id_cataloge");

                    b.HasOne("AnimalShelterWPF.Models.Shelter", "IdShelterNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdShelter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("users_id_shelter_fkey");

                    b.Navigation("IdCatalogeNavigation");

                    b.Navigation("IdShelterNavigation");
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Pet", b =>
                {
                    b.Navigation("Adoptions");

                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Rol", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.Shelter", b =>
                {
                    b.Navigation("Donations");

                    b.Navigation("Items");

                    b.Navigation("Pets");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.User", b =>
                {
                    b.Navigation("Adoption");

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("AnimalShelterWPF.Models.UserCataloge", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
