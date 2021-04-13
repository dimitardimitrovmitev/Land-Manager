﻿using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class RmsContext : DbContext
    {
        public RmsContext(DbContextOptions options) : base(options) { }
        public RmsContext() { }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Land> Lands { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
    }
}
