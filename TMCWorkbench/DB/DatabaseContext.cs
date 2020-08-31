using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Text;

namespace TMCWorkbench.DB
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DatabaseContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Composer> Composers { get; set; }
        public DbSet<Scenegroup> Scenegroups { get; set; }
        public DbSet<C_Scenegroup_Composer> C_Scenegroup_Composers { get; set; }
        public DbSet<Tracker> Trackers { get; set; }

        //"server=localhost;database=dbtryout;user=root;password=;
        public DatabaseContext() : base()
        {

        }

        // Constructor to use on a DbConnection that is already opened
        public DatabaseContext(DbConnection existingConnection, bool contextOwnsConnection)  : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Set Unique keys
            modelBuilder.Entity<Style>().HasIndex(x => x.Style_id).IsUnique();
            modelBuilder.Entity<Style>()
                .HasMany(x => x.ParentStyleChildren)
                .WithRequired(x => x.ParentStyle);

            modelBuilder.Entity<Style>()
                .HasMany(x => x.ParentAltStyleChildren)
                .WithRequired(x => x.ParentAltStyle);


            //modelBuilder.Entity<Style>().HasOptional(x => x.ParentStyle).WithMany().HasForeignKey(x => x.Style_id);

            modelBuilder.Entity<Composer>().HasIndex(x => x.Composer_id).IsUnique();
            modelBuilder.Entity<Scenegroup>().HasIndex(x => x.Scenegroup_id).IsUnique();
            modelBuilder.Entity<C_Scenegroup_Composer>().HasIndex(x => x.Scenegroup_composer_id).IsUnique();
            modelBuilder.Entity<Tracker>().HasIndex(x => x.Tracker_id).IsUnique();

            //Set default values
            //modelBuilder.Entity<Track>().Property(x => x.Date_created).HasDefaultValue(DateTime.Now);
            //modelBuilder.Entity<Track>().Property(x => x.Date_modified).HasDefaultValue(DateTime.Now);
        }
    }
}
