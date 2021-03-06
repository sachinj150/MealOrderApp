﻿// <auto-generated />
using MealOrderApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MealOrderApp.Migrations
{
    [DbContext(typeof(MealsDbContext))]
    [Migration("20190325061346_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MealOrderApp.Models.Meal", b =>
                {
                    b.Property<int>("MealId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfMeals");

                    b.HasKey("MealId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("MealOrderApp.Models.OrderedMealType", b =>
                {
                    b.Property<int>("OrderedMealTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MealId");

                    b.Property<string>("MealType");

                    b.Property<int>("NumberOfMeals");

                    b.HasKey("OrderedMealTypeId");

                    b.HasIndex("MealId");

                    b.ToTable("OrderedMealTypes");
                });

            modelBuilder.Entity("MealOrderApp.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity");

                    b.Property<decimal>("Rating");

                    b.Property<string>("RestaurantName");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("MealOrderApp.Models.RestaurantMealType", b =>
                {
                    b.Property<int>("RestaurantMealTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity");

                    b.Property<string>("MealType");

                    b.Property<int>("RestaurantId");

                    b.HasKey("RestaurantMealTypeId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantMealTypes");
                });

            modelBuilder.Entity("MealOrderApp.Models.OrderedMealType", b =>
                {
                    b.HasOne("MealOrderApp.Models.Meal", "Meal")
                        .WithMany("OrderedMealTypes")
                        .HasForeignKey("MealId")
                        .HasConstraintName("ForeignKey_OrderedMealType_Meal")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MealOrderApp.Models.RestaurantMealType", b =>
                {
                    b.HasOne("MealOrderApp.Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantMealTypes")
                        .HasForeignKey("RestaurantId")
                        .HasConstraintName("ForeignKey_RestaurantMealType_Restaurant")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
