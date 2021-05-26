using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using MigrationSamples.Data.EFCore.Entities;

namespace MigrationSamples.Data.EFCore.Context
{

    public partial class DataContext : DbContext
    {

        public DataContext() :
            base()
        {
            OnCreated();
        }

        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {
            OnCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        public virtual DbSet<ContactInfo> ContactInfos
        {
            get;
            set;
        }

        public virtual DbSet<Department> Departments
        {
            get;
            set;
        }

        public virtual DbSet<Employee> Employees
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<ContactInfo>(new ContactInfoConfiguration());
            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfiguration());
            CustomizeMapping(ref modelBuilder);

            // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            // Please note that mixing configurations in class-per-type and in OnModelCreating is not recommended as it creates
            // hard to read and maintain code. Below code is here just for illustrative purposes

            //this.EmployeeMapping(modelBuilder);
            //this.CustomizeEmployeeMapping(modelBuilder);

            //RelationshipsMapping(modelBuilder);
            //CustomizeMapping(ref modelBuilder);
        }


        //#region Employee Mapping

        //private void EmployeeMapping(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>().ToTable(@"Employees", @"dbo");
        //    modelBuilder.Entity<Employee>().Property(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
        //    modelBuilder.Entity<Employee>().Property(x => x.Name).HasColumnName(@"Name").HasColumnType(@"nvarchar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
        //    modelBuilder.Entity<Employee>().Property(x => x.HiredDate).HasColumnName(@"HiredDate").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
        //    modelBuilder.Entity<Employee>().Property(x => x.Salary).HasColumnName(@"Salary").HasColumnType(@"decimal(18,2)").IsRequired().ValueGeneratedNever().HasPrecision(18, 2);
        //    modelBuilder.Entity<Employee>().Property(x => x.SickDays).HasColumnName(@"SickDays").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
        //    modelBuilder.Entity<Employee>().HasKey(@"Id");
        //}

        //partial void CustomizeEmployeeMapping(ModelBuilder modelBuilder);

        //#endregion

        //private void RelationshipsMapping(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Department>().HasMany(x => x.Employees).WithMany(op => op.Departments)
        //        .UsingEntity<Dictionary<string, object>>(
        //            @"EmployeesDepartments",
        //            x => x.HasOne<Employee>().WithMany().HasPrincipalKey(@"Id").HasForeignKey(@"EmployeeId"),
        //            x => x.HasOne<Department>().WithMany().HasPrincipalKey(@"Id").HasForeignKey(@"Table_2Id")
        //        )
        //        .ToTable(@"EmployeesDepartments", @"dbo");
        //}

        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // End of in-context mapping
        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
        }

        partial void OnCreated();
    }
}
