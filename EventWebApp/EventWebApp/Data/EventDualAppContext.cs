using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EventWebApp.Data
{
    public class EventDualAppContext : DbContext
    {

        public EventDualAppContext(DbContextOptions<EventDualAppContext> options) : base(options)
        {
        }

        public virtual DbSet<Event> Events
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().ToTable("Event");

        }
    }


}
