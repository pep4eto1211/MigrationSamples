using FluentNHibernate.Mapping;
using MigrationSamples.Data.EFCore.FluentNhibernate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationSamples.Data.EFCore.FluentNhibernate.Mappings
{
    public class DepartmentMap : ClassMap<Department>
    {
        public DepartmentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
            Table("Departments");
            Cache.ReadWrite();
            HasManyToMany(x => x.Employees)
                .Cascade.All()
                .Inverse()
                .Table("EmployeesDepartments");
        }
    }
}
