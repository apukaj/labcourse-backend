using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabCourseProject.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LabCourseProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your own configuration here
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties().Where(p => p.IsPrimaryKey()))
                {
                    property.ValueGenerated = ValueGenerated.OnAdd;
                }
            }
        }
        public DbSet<LabCourseProject.Models.Menu> Menu { get; set; }
        public DbSet<LabCourseProject.Models.City> City { get; set; }
        public DbSet<LabCourseProject.Models.AccommodationType> AccommodationType { get; set; }
        public DbSet<LabCourseProject.Models.AccommodationFacility> AccommodationFacility { get; set; }
        public DbSet<LabCourseProject.Models.Accommodation> Accommodation { get; set; }
        public DbSet<LabCourseProject.Models.RestaurantType> RestaurantType { get; set; }
        public DbSet<LabCourseProject.Models.Room> Room { get; set; }
        public DbSet<LabCourseProject.Models.VendetTuristike> VendetTuristike { get; set; }
        public DbSet<LabCourseProject.Models.Cave> Cave { get; set; }
        public DbSet<LabCourseProject.Models.Park> Park { get; set; }
        public DbSet<LabCourseProject.Models.Monument> Monument { get; set; }
        public DbSet<LabCourseProject.Models.Restaurant> Restaurant { get; set; }
        public DbSet<LabCourseProject.Models.BusinessType> BusinessType { get; set; }
        public DbSet<LabCourseProject.Models.Shopping> Shopping { get; set; }
        public DbSet<LabCourseProject.Models.ShoppingFacility> ShoppingFacility { get; set; }
        public DbSet<LabCourseProject.Models.Promotion> Promotion { get; set; }
        public DbSet<LabCourseProject.Models.AccommodationReservation> AccommodationReservation { get; set; }
        public DbSet<LabCourseProject.Models.RestaurantReservation> RestaurantReservation { get; set; }
        public DbSet<LabCourseProject.Models.Image> Image { get; set; }
        
    }
}
