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
        public DbSet<LabCourseProject.Models.City> City { get; set; }
        public DbSet<LabCourseProject.Models.AccommodationType> AccommodationType { get; set; }
        public DbSet<LabCourseProject.Models.AccommodationFacility> AccomodationFacility { get; set; }
    }
}
