using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MigrationSamples.Data.EFCore.Entities
{
    /// <summary>
    /// There are no comments for DepartmentConfiguration in the schema.
    /// </summary>
    public partial class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        /// <summary>
        /// There are no comments for Configure(EntityTypeBuilder<Department> builder) method in the schema.
        /// </summary>
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(@"Departments", @"dbo");
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType(@"nvarchar(150)").ValueGeneratedNever().HasMaxLength(150);
            builder.HasKey(@"Id");
            builder.HasMany(x => x.Employees).WithMany(op => op.Departments)
                .UsingEntity<Dictionary<string, object>>(
                    @"EmployeesDepartments",
                    x => x.HasOne<Employee>().WithMany().HasPrincipalKey(@"Id").HasForeignKey(@"EmployeeId"),
                    x => x.HasOne<Department>().WithMany().HasPrincipalKey(@"Id").HasForeignKey(@"Table_2Id")
                )
                .ToTable(@"EmployeesDepartments", @"dbo");

            CustomizeConfiguration(builder);
        }

        #region Partial Methods

        partial void CustomizeConfiguration(EntityTypeBuilder<Department> builder);

        #endregion
    }

}
