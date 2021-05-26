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
    /// There are no comments for EmployeeConfiguration in the schema.
    /// </summary>
    public partial class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        /// <summary>
        /// There are no comments for Configure(EntityTypeBuilder<Employee> builder) method in the schema.
        /// </summary>
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(@"Employees", @"dbo");
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType(@"nvarchar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
            builder.Property(x => x.HiredDate).HasColumnName(@"HiredDate").HasColumnType(@"datetime").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Salary).HasColumnName(@"Salary").HasColumnType(@"decimal(18,2)").IsRequired().ValueGeneratedNever().HasPrecision(18, 2);
            builder.Property(x => x.SickDays).HasColumnName(@"SickDays").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            builder.HasKey(@"Id");
            builder.HasMany(x => x.Departments).WithMany(op => op.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    @"EmployeesDepartments",
                    x => x.HasOne<Department>().WithMany().HasPrincipalKey(@"Id").HasForeignKey(@"Table_2Id"),
                    x => x.HasOne<Employee>().WithMany().HasPrincipalKey(@"Id").HasForeignKey(@"EmployeeId")
                )
                .ToTable(@"EmployeesDepartments", @"dbo");

            CustomizeConfiguration(builder);
        }

        #region Partial Methods

        partial void CustomizeConfiguration(EntityTypeBuilder<Employee> builder);

        #endregion
    }

}
