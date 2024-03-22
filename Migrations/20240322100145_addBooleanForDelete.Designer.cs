﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using first_mvc_pattern_c_.Data;

#nullable disable

namespace first_mvc_pattern_c_.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240322100145_addBooleanForDelete")]
    partial class addBooleanForDelete
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("first_mvc_pattern_c_.Models.Cinema", b =>
                {
                    b.Property<int>("CinemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CinemaId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CinemaId");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("first_mvc_pattern_c_.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("FilmId"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<string>("FilmName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("FilmId");

                    b.HasIndex("CinemaId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("first_mvc_pattern_c_.Models.Film", b =>
                {
                    b.HasOne("first_mvc_pattern_c_.Models.Cinema", "Cinema")
                        .WithMany("Films")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("first_mvc_pattern_c_.Models.Cinema", b =>
                {
                    b.Navigation("Films");
                });
#pragma warning restore 612, 618
        }
    }
}
