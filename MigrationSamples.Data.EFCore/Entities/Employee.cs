using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace MigrationSamples.Data.EFCore.Entities
{
    public partial class Employee {

        public Employee()
        {
            this.Departments = new List<Department>();
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime HiredDate { get; set; }

        public virtual decimal Salary { get; set; }

        public virtual int SickDays { get; set; }

        public virtual IList<Department> Departments { get; set; }
    }

}
