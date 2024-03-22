using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FAPWeb_Se1705.Models
{
    public partial class FAPPRJContext : DbContext
    {
        public FAPPRJContext()
        {
        }

        public FAPPRJContext(DbContextOptions<FAPPRJContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Instructor> Instructors { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-MN7VKOQ5;database=FAPPRJ;uid=sa;pwd=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseCode)
                    .HasName("PK_Course_1");

                entity.ToTable("Course");

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("course_code")
                    .IsFixedLength();

                entity.Property(e => e.CourseName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("course_name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.GroupName);

                entity.ToTable("Group");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("groupName")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasKey(e => e.InstructorCode);

                entity.ToTable("Instructor");

                entity.Property(e => e.InstructorCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("instructorCode")
                    .IsFixedLength();

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("role_name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.RoomName);

                entity.ToTable("Room");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("roomName")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("course_code")
                    .IsFixedLength();

                entity.Property(e => e.GroupName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("groupName")
                    .IsFixedLength();

                entity.Property(e => e.InstructorCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("instructorCode")
                    .IsFixedLength();

                entity.Property(e => e.RoomName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("roomName")
                    .IsFixedLength();

                entity.Property(e => e.TimeSlot)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("timeSlot")
                    .IsFixedLength();

                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.CourseCode)
                    .HasConstraintName("FK_Session_Course1");

                entity.HasOne(d => d.GroupNameNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.GroupName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Group");

                entity.HasOne(d => d.InstructorCodeNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.InstructorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Instructor");

                entity.HasOne(d => d.RoomNameNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.RoomName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Room");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
