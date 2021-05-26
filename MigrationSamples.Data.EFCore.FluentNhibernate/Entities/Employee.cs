using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationSamples.Data.EFCore.FluentNhibernate.Entities
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime HiredDate { get; set; }
        public virtual double Salary { get; set; }
        public virtual int SickDays { get; set; }
        public virtual IList<Department> Departments { get; set; }

        public Employee()
        {
            Departments = new List<Department>();
        }

        public virtual void AddDepartment(Department department)
        {
            department.Employees.Add(this);
            Departments.Add(department);
        }
    }
}
