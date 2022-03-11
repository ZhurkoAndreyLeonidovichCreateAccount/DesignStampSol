using DataLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<AllForce> AllForces { get; set; }
        public DbSet<DifferHole> DifferHoles { get; set; }
        public DbSet<Matrix> Matrices { get; set; }
        public DbSet<Holder> Holders { get; set; }
        public DbSet<BottomPlate> BottomPlates { get; set; }
        public DbSet<TopPlate> TopPlates { get; set; }
        public DbSet<PunchMatrix> PunchMatrices { get; set; }
        public DbSet<Puller> Pullers { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Bushing> Bushings { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<Spring> Springs { get; set; }
        public DbSet<Punch> Punches { get; set; }
        public DbSet<EnlargedPunch> EnlargedPunches { get; set; }
        public DbSet<PunchesID> PunchesID { get; set; }
        public DbSet<EnlargedPunchesID> EnlargedPunchesID { get; set; }
        public DbSet<PunchesID> punchesID { get; set; }
        public DbSet<Press> Pressess { get; set; }

        public DbSet<Stamp> Stamps { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


       
    }
}
