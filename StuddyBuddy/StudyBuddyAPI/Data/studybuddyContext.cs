using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudyBuddyAPI.Models;

#nullable disable

namespace StudyBuddyAPI.Data
{
    public partial class studybuddyContext : DbContext
    {
        public studybuddyContext()
        {
        }

        public studybuddyContext(DbContextOptions<studybuddyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UsersModule> UsersModules { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Password=studdybuddy@123;Persist Security Info=True;User ID=studdybuddyadmin;Initial Catalog=studybuddy;Data Source=tcp:studybuddysql.database.windows.net,1433");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK__Modules__A2A2A54A69DA518D");

                entity.Property(e => e.Completed)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK__Roles__A2A2A54AD958C705");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(user_name())");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK__Tasks__A2A2A54AEF8F7FFA");

                entity.Property(e => e.Completed)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tasks_Modules");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK__Users__3214EC0777CF8A5F");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK__UserRole__A2A2A54AB059F448");

                entity.ToTable("UserRole");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Users");
            });

            modelBuilder.Entity<UsersModule>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("PK__UsersMod__A2A2A54ADF7AC836");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.UsersModules)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersModules_Modules");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersModules)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersModules_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
