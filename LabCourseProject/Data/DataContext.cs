using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabCourseProject.Models;

namespace LabCourseProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<LabCourseProject.Models.Menu> Menu { get; set; }
        public DbSet<LabCourseProject.Models.City> City { get; set; }
        public DbSet<LabCourseProject.Models.AccommodationType> AccommodationType { get; set; }
        public DbSet<LabCourseProject.Models.AccommodationFacility> AccomodationFacility { get; set; }
        public DbSet<LabCourseProject.Models.Accommodation> Accomodation { get; set; }
        public DbSet<LabCourseProject.Models.RestaurantType> RestaurantType { get; set; }
        public DbSet<LabCourseProject.Models.Room> Room { get; set; }
        public DbSet<LabCourseProject.Models.VendetTuristike> VendetTuristike { get; set; }
        public DbSet<LabCourseProject.Models.Cave> Cave { get; set; }
        public DbSet<LabCourseProject.Models.Park> Park { get; set; }
        public DbSet<LabCourseProject.Models.Monument> Monument { get; set; }
        
    }
}
