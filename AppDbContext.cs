using MauiApp2;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace MauiApp2 
{
    public class AppDbContext : DbContext
    {
        public DbSet<Shift> Shifts { get; set; }
    }
}

