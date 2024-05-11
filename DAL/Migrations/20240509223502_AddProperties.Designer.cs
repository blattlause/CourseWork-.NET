﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240509223502_AddProperties")]
    partial class AddProperties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Claim");
                });

            modelBuilder.Entity("DAL.Models.Diagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diagnosis");
                });

            modelBuilder.Entity("DAL.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("DAL.Models.MedicineCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdPet")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPet");

                    b.ToTable("MedicineCard");
                });

            modelBuilder.Entity("DAL.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClaim")
                        .HasColumnType("int");

                    b.Property<int>("IdDiagnosis")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicine")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicineCard")
                        .HasColumnType("int");

                    b.Property<int>("IdVet")
                        .HasColumnType("int");

                    b.Property<int>("IdVisit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdClaim");

                    b.HasIndex("IdDiagnosis");

                    b.HasIndex("IdMedicine");

                    b.HasIndex("IdMedicineCard");

                    b.HasIndex("IdVet");

                    b.HasIndex("IdVisit");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("DAL.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("DAL.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<double>("Heigth")
                        .HasColumnType("float");

                    b.Property<int>("IdOwner")
                        .HasColumnType("int");

                    b.Property<int>("IdSpecies")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weigth")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdOwner");

                    b.HasIndex("IdSpecies");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("DAL.Models.Reception", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdOwner")
                        .HasColumnType("int");

                    b.Property<int>("IdVet")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdOwner");

                    b.HasIndex("IdVet");

                    b.ToTable("Reception");
                });

            modelBuilder.Entity("DAL.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("DAL.Models.ServiceVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdService")
                        .HasColumnType("int");

                    b.Property<int>("IdVisit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdService");

                    b.HasIndex("IdVisit");

                    b.ToTable("ServiceVisit");
                });

            modelBuilder.Entity("DAL.Models.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("DAL.Models.Vet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Sallary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Vet");
                });

            modelBuilder.Entity("DAL.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdPet")
                        .HasColumnType("int");

                    b.Property<int>("IdVet")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPet");

                    b.HasIndex("IdVet");

                    b.ToTable("Visit");
                });

            modelBuilder.Entity("DAL.Models.MedicineCard", b =>
                {
                    b.HasOne("DAL.Models.Pet", "Pet")
                        .WithMany("MedicineCards")
                        .HasForeignKey("IdPet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("DAL.Models.Note", b =>
                {
                    b.HasOne("DAL.Models.Claim", "Claim")
                        .WithMany("Notes")
                        .HasForeignKey("IdClaim")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Diagnosis", "Diagnosis")
                        .WithMany("Notes")
                        .HasForeignKey("IdDiagnosis")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Medicine", "Medicine")
                        .WithMany("Notes")
                        .HasForeignKey("IdMedicine")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.MedicineCard", "MedicineCard")
                        .WithMany("Notes")
                        .HasForeignKey("IdMedicineCard")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Vet", "Vet")
                        .WithMany("Notes")
                        .HasForeignKey("IdVet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Visit", "Visit")
                        .WithMany("Notes")
                        .HasForeignKey("IdVisit")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Claim");

                    b.Navigation("Diagnosis");

                    b.Navigation("Medicine");

                    b.Navigation("MedicineCard");

                    b.Navigation("Vet");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("DAL.Models.Pet", b =>
                {
                    b.HasOne("DAL.Models.Owner", "Owner")
                        .WithMany("Pets")
                        .HasForeignKey("IdOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Species", "Species")
                        .WithMany("Pets")
                        .HasForeignKey("IdSpecies")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("DAL.Models.Reception", b =>
                {
                    b.HasOne("DAL.Models.Owner", "Owner")
                        .WithMany("Receptions")
                        .HasForeignKey("IdOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Vet", "Vet")
                        .WithMany("Receptions")
                        .HasForeignKey("IdVet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Vet");
                });

            modelBuilder.Entity("DAL.Models.ServiceVisit", b =>
                {
                    b.HasOne("DAL.Models.Service", "Service")
                        .WithMany("ServiceVisities")
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Visit", "Visit")
                        .WithMany("ServiceVisities")
                        .HasForeignKey("IdVisit")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("DAL.Models.Visit", b =>
                {
                    b.HasOne("DAL.Models.Pet", "Pet")
                        .WithMany("Visities")
                        .HasForeignKey("IdPet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.Vet", "Vet")
                        .WithMany("Visities")
                        .HasForeignKey("IdVet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("Vet");
                });

            modelBuilder.Entity("DAL.Models.Claim", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("DAL.Models.Diagnosis", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("DAL.Models.Medicine", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("DAL.Models.MedicineCard", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("DAL.Models.Owner", b =>
                {
                    b.Navigation("Pets");

                    b.Navigation("Receptions");
                });

            modelBuilder.Entity("DAL.Models.Pet", b =>
                {
                    b.Navigation("MedicineCards");

                    b.Navigation("Visities");
                });

            modelBuilder.Entity("DAL.Models.Service", b =>
                {
                    b.Navigation("ServiceVisities");
                });

            modelBuilder.Entity("DAL.Models.Species", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("DAL.Models.Vet", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("Receptions");

                    b.Navigation("Visities");
                });

            modelBuilder.Entity("DAL.Models.Visit", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("ServiceVisities");
                });
#pragma warning restore 612, 618
        }
    }
}
