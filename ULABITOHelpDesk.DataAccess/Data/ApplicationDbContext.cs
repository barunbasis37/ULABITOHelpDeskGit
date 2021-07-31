using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ULABITOHelpDesk.Models;

namespace ULABITOHelpDesk.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProgramData> Programs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<IssueSubtype> IssueSubtypes { get; set; }
        public DbSet<IssueInitiate> IssueInitiates { get; set; }

    }
}
