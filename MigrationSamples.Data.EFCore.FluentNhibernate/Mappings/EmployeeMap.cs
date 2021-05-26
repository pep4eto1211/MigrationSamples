using FluentNHibernate.Mapping;
using MigrationSamples.Data.EFCore.FluentNhibernate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationSamples.Data.EFCore.FluentNhibernate.Mappings
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.HiredDate);
            Map(x => x.Salary);
            Map(x => x.SickDays);
            Table("Employees");
            HasManyToMany(x => x.Departments)
                .Cascade.All()
                .Table("EmployeesDepartments");
        }
    }
}
