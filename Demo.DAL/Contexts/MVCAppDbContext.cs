﻿using Demo.DAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Contexts
{
    public class MVCAppDbContext : IdentityDbContext<ApplicationUser>
    {

        public MVCAppDbContext(DbContextOptions<MVCAppDbContext> options):base(options) 
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        // =>   optionsBuilder.UseSqlServer("Server=.;Database=MvcAppDb;Trusted_Connection=true");


        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
