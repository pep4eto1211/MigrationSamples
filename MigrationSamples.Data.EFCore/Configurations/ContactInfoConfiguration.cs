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
    /// There are no comments for ContactInfoConfiguration in the schema.
    /// </summary>
    public partial class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        /// <summary>
        /// There are no comments for Configure(EntityTypeBuilder<ContactInfo> builder) method in the schema.
        /// </summary>
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.ToTable(@"ContactInfos", @"dbo");
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            builder.Property(x => x.Email).HasColumnName(@"Email").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            builder.Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType(@"nvarchar(50)").ValueGeneratedNever().HasMaxLength(50);
            builder.HasKey(@"Id");

            CustomizeConfiguration(builder);
        }

        #region Partial Methods

        partial void CustomizeConfiguration(EntityTypeBuilder<ContactInfo> builder);

        #endregion
    }

}
