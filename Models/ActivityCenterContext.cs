using Microsoft.EntityFrameworkCore;
using ActivityCenter.Models;
using System.Linq;
using System;

namespace ActivityCenter.Models
{
    public class ActivityCenterContext : DbContext
    {
        public ActivityCenterContext(DbContextOptions options) : base(options){}
        public DbSet<User> UserList {get; set;}
        public DbSet<DojoEvent> ActivityList {get; set;}
        public DbSet<Participate> Join {get; set;}
    }
}